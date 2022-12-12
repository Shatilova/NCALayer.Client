using Newtonsoft.Json.Linq;

namespace NCALayer.Client.CommonUtils
{
    public class CreateCMSSignatureFromBase64Response : NCABaseResponse
    {
        public string SignedCms { get; set; }

        public CreateCMSSignatureFromBase64Response(string response) : base(response)
        {
            JObject j = JObject.Parse(response);

            if (j.TryGetValue("responseObject", out var signedCms))
            {
                SignedCms = signedCms.ToString();
            }
        }
    }
}
