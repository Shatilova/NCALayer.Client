using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace NCALayer.Client.CommonUtils
{
    public class GetActiveTokensResponse : NCABaseResponse
    {
        public NCAStorage[] Storages { get; }

        public GetActiveTokensResponse(string response) : base(response)
        {
            JObject j = JObject.Parse(response);
            if (j.TryGetValue("responseObject", out var storages))
            {
                var storagesCatalog = EnumDescriptions.NCAStorages.ToDictionary(k => k.Value, v => v.Key);
                var storagesList = new List<NCAStorage>();

                foreach (var storage in storages.Values<string>())
                {
                    if (storagesCatalog.TryGetValue(storage, out var storageAlias))
                        storagesList.Add(storageAlias);
                }

                if (!storagesList.Contains(NCAStorage.PKCS12))
                    storagesList.Add(NCAStorage.PKCS12);

                Storages = storagesList.ToArray();
            }
        }
    }
}
