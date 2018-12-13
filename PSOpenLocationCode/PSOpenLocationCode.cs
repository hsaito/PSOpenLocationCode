using System;
using System.Management.Automation;
using System.Runtime.Serialization;
using Google.OpenLocationCode;
using JetBrains.Annotations;

namespace PSOpenLocationCode
{
    [PublicAPI]
    [Cmdlet(VerbsData.ConvertTo, "OLC")]
    [OutputType(typeof(string))]
    public class ConverToOLC : Cmdlet
    {
        [ValidateNotNullOrEmpty] [Parameter(Position = 0, Mandatory = true, HelpMessage = "Latitude to convert.", ParameterSetName = "LongCode")]
        [Parameter(Position = 0, Mandatory = true, HelpMessage = "Latitude to convert.", ParameterSetName = "ShortCode")]
        public double Latitude { get; set; }

        [Parameter(Position = 1, Mandatory = true, HelpMessage = "Longitude to convert.", ParameterSetName = "LongCode")]
        [Parameter(Position = 1, Mandatory = true, HelpMessage = "Longitude to convert.", ParameterSetName = "ShortCode")]
        public double Longitude { get; set; }

        [Parameter(Position = 2, Mandatory = false, HelpMessage = "Length of the code.", ParameterSetName = "LongCode")]
        public int? Length { get; set; }
        
        [Parameter(Mandatory = true, HelpMessage = "Reference latitude for shorter code.", ParameterSetName = "ShortCode")]
        public double ReferenceLatitude { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Reference longitude for shorter code.", ParameterSetName = "ShortCode")]
        public double ReferenceLongitude { get; set; }
        
        [Parameter(Mandatory = false, HelpMessage = "Generate short code. (Requires reference latitude and longitude", ParameterSetName = "ShortCode")]
        public SwitchParameter Short { get; set; }
        

        protected override void ProcessRecord()
        {
            if (Length == null)
            {
                Length = 10;
            }

            if (!Short && Length < 10)
            {
                throw new PSOpenLocationCodeException("Code cannot be shorter than 10.");
            }
            
            var code = new OpenLocationCode(Latitude, Longitude, (int)Length);
            
            if (Short)
            {
                code = code.Shorten(ReferenceLatitude, ReferenceLongitude);
            }
            
            WriteObject(code.Code);
        }
    }

    [PublicAPI]
    [Cmdlet(VerbsData.ConvertFrom, "OLC")]
    [OutputType(typeof(CodeArea))]
    public class ConverFromOLC : Cmdlet
    {
        [ValidateNotNullOrEmpty] [Parameter(Position = 0, Mandatory = true, HelpMessage = "OLC code to convert from.", ParameterSetName = "LongCode")]
        [Parameter(Position = 0, Mandatory = true, HelpMessage = "OLC code to convert from.", ParameterSetName ="ShortCode")]
        public string Code { get; set; }
        
        [Parameter(Mandatory = true, HelpMessage = "Reference latitude for shorter code.", ParameterSetName = "ShortCode")]
        public double ReferenceLatitude { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Reference longitude for shorter code.", ParameterSetName = "ShortCode")]
        public double ReferenceLongitude { get; set; }
        
        [Parameter(Mandatory = false, HelpMessage = "Generate short code. (Requires reference latitude and longitude", ParameterSetName = "ShortCode")]
        public SwitchParameter Short { get; set; }
        
        protected override void ProcessRecord()
        {
            var code = new OpenLocationCode(Code);
            
            if (Short)
            {
                code = code.Recover(ReferenceLatitude, ReferenceLongitude);
                WriteVerbose($"Full code: {code.Code}");
            }
            WriteObject(code.Decode());
        }
    }
    
    public class PSOpenLocationCodeException : Exception
    {
        public PSOpenLocationCodeException()
        {
        }

        protected PSOpenLocationCodeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public PSOpenLocationCodeException(string message) : base(message)
        {
        }

        public PSOpenLocationCodeException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}