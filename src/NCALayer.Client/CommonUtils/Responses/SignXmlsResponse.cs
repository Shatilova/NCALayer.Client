using Newtonsoft.Json.Linq;
using System.Linq;

namespace NCALayer.Client.CommonUtils
{
    public class SignXmlsResponse : NCABaseResponse
    {
        public string[] SignedXmls { get; }
        public SignXmlsResponse(string response) : base(response)
        {
            JObject j = JObject.Parse(response);
            if (j.TryGetValue("responseObject", out var signedXml))
            {
                SignedXmls = signedXml.Values<string>().ToArray();
            }
        }
    }
}
