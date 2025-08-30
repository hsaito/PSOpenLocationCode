using System;
using System.Diagnostics.CodeAnalysis;
using System.Management.Automation;
using System.Runtime.Serialization;
using Google.OpenLocationCode;
// ReSharper disable UnusedMember.Global

namespace PSOpenLocationCode
{
    [Cmdlet(VerbsData.ConvertTo, "OLC")]
    [OutputType(typeof(string))]
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
    public class ConvertToOLC : Cmdlet
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
                var shortenedCode = code.Shorten(ReferenceLatitude, ReferenceLongitude);
                WriteObject(shortenedCode.Code);
                return;
            }
            
            WriteObject(code.Code);
        }
    }

    [Cmdlet(VerbsData.ConvertFrom, "OLC")]
    [OutputType(typeof(CodeArea))]
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
    public class ConvertFromOLC : Cmdlet
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
            
            
            if (Short)
            {
                var code = new OpenLocationCode.ShortCode(Code);
                var result = code.RecoverNearest(ReferenceLatitude, ReferenceLongitude);
                WriteVerbose($"Full code: {code.Code}");
                WriteObject(result.Decode());
                
            }
            else
            {
                var code = new OpenLocationCode(Code);
                WriteObject(code.Decode());
            }
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

    public class TestReference
    {
        public static string Hello => "Hello from main project";
    }
}