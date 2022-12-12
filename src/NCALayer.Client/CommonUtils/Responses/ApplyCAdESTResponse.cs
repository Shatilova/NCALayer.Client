using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace NCALayer.Client.CommonUtils
{
    public class ApplyCAdESTResponse : NCABaseResponse
    {
        public string SignedCms { get; }
        public ApplyCAdESTResponse(string response) : base(response)
        {
            JObject j = JObject.Parse(response);

            if (j.TryGetValue("responseObject", out var signedCms))
            {
                SignedCms = signedCms.ToString();
            }
        }
    }
}
