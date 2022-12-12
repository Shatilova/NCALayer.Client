using Newtonsoft.Json.Linq;

namespace NCALayer.Client.CommonUtils
{
    public class SignXmlResponse : NCABaseResponse
    {
        public string SignedXml { get; }
        public SignXmlResponse(string response) : base(response)
        {
            JObject j = JObject.Parse(response);
            if (j.TryGetValue("responseObject", out var signedXml))
            {
                SignedXml = signedXml.Value<string>();
            }
        }
    }
}
