using Newtonsoft.Json.Linq;

namespace NCALayer.Client.CommonUtils
{
    public class CreateCAdESFromBase64HashResponse : NCABaseResponse
    {
        public string SignedCms { get; set; }

        public CreateCAdESFromBase64HashResponse(string response) : base(response)
        {
            JObject j = JObject.Parse(response);

            if (j.TryGetValue("responseObject", out var signedCms))
            {
                SignedCms = signedCms.ToString();
            }
        }
    }
}
