using System.Management.Automation;
using Google.OpenLocationCode;

namespace PSOpenLocationCode
{
    [Cmdlet(VerbsData.ConvertTo, "OLC")]
    [OutputType(typeof(string))]
    public class ConverToOLC : Cmdlet
    {
        [ValidateNotNullOrEmpty] [Parameter(Position = 0, Mandatory = true, HelpMessage = "Latitude to convert.")]
        public double Latitude;

        [Parameter(Position = 1, Mandatory = true, HelpMessage = "Longitude to convert.")]
        public double Longitude;

        protected override void ProcessRecord()
        {
            var code = new OpenLocationCode(Latitude, Longitude, 10);
            WriteObject(code.ToString());
        }
    }

    [Cmdlet(VerbsData.ConvertFrom, "OLC")]
    [OutputType(typeof(CodeArea))]
    public class ConverFromOLC : Cmdlet
    {
        [ValidateNotNullOrEmpty] [Parameter(Position = 0, Mandatory = true, HelpMessage = "OLC code to convert from.")]
        public string Code;

        protected override void ProcessRecord()
        {
            var code = new OpenLocationCode(Code);
            WriteObject(code.Decode());
        }
    }
}