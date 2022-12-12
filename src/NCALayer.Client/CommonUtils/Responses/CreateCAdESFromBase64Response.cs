using Newtonsoft.Json.Linq;

namespace NCALayer.Client.CommonUtils
{
    public class CreateCAdESFromBase64Response : NCABaseResponse
    {
        public string SignedCms { get; set; }

        public CreateCAdESFromBase64Response(string response) : base(response)
        {
            JObject j = JObject.Parse(response);

            if (j.TryGetValue("responseObject", out var signedCms))
            {
                SignedCms = signedCms.ToString();
            }
        }
    }
}
