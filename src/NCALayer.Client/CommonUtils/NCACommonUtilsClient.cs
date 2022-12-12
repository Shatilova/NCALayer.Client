using Newtonsoft.Json;
using System;
using System.Linq;
using System.Text;

namespace NCALayer.Client.CommonUtils
{
    /// <summary>
    /// Client for <i><b>kz.gov.pki.knca.commonUtils</b></i> module
    /// </summary>
    public class NCACommonUtilsClient : NCALayerClientBase
    {
        public void CreateCMSSignatureFromBase64(
            NCAStorage storage,
            NCAKey key,
            string content,
            NCACallback<CreateCMSSignatureFromBase64Response> callback,
            CreateCMSSignatureFromBase64Option options = CreateCMSSignatureFromBase64Option.None)
        {
            SpawnWebSocket(callback).Send(JsonConvert.SerializeObject(new
            {
                module = EnumDescriptions.NCAModules[NCAModule.CommonUtils],
                method = EnumDescriptions.NCAMethods[NCAMethod.CreateCMSSignatureFromBase64],
                args = new object[] {
                    EnumDescriptions.NCAStorages[storage],
                    EnumDescriptions.NCAKeys[key],
                    options.HasFlag(CreateCMSSignatureFromBase64Option.IsBase64Encoded) ? content : Convert.ToBase64String(Encoding.UTF8.GetBytes(content)),
                    options.HasFlag(CreateCMSSignatureFromBase64Option.AttachContent)
                }
            }));
        }

        public void CreateCAdESFromBase64(
            NCAStorage storage,
            NCAKey key,
            string content,
            NCACallback<CreateCAdESFromBase64Response> callback,
            CreateCAdESFromBase64Option options = CreateCAdESFromBase64Option.None)
        {
            SpawnWebSocket(callback).Send(JsonConvert.SerializeObject(new
            {
                module = EnumDescriptions.NCAModules[NCAModule.CommonUtils],
                method = EnumDescriptions.NCAMethods[NCAMethod.CreateCAdESFromBase64],
                args = new object[] {
                    EnumDescriptions.NCAStorages[storage],
                    EnumDescriptions.NCAKeys[key],
                    options.HasFlag(CreateCAdESFromBase64Option.IsBase64Encoded) ? content : Convert.ToBase64String(Encoding.UTF8.GetBytes(content)),
                    options.HasFlag(CreateCAdESFromBase64Option.AttachContent)
                }
            }));
        }

        public void ApplyCAdEST(
            NCAStorage storage,
            NCAKey key,
            string cms,
            NCACallback<ApplyCAdESTResponse> callback)
        {
            SpawnWebSocket(callback).Send(JsonConvert.SerializeObject(new
            {
                module = EnumDescriptions.NCAModules[NCAModule.CommonUtils],
                method = EnumDescriptions.NCAMethods[NCAMethod.ApplyCAdEST],
                args = new object[]
                {
                    EnumDescriptions.NCAStorages[storage],
                    EnumDescriptions.NCAKeys[key],
                    cms
                }
            }));
        }

        public void CreateCAdESFromBase64Hash(
            NCAStorage storage,
            NCAKey key,
            string content,
            NCACallback<CreateCAdESFromBase64HashResponse> callback,
            CreateCAdESFromBase64HashOption options = CreateCAdESFromBase64HashOption.None)
        {
            SpawnWebSocket(callback).Send(JsonConvert.SerializeObject(new
            {
                module = EnumDescriptions.NCAModules[NCAModule.CommonUtils],
                method = EnumDescriptions.NCAMethods[NCAMethod.CreateCAdESFromBase64Hash],
                args = new object[] {
                    EnumDescriptions.NCAStorages[storage],
                    EnumDescriptions.NCAKeys[key],
                    options.HasFlag(CreateCAdESFromBase64HashOption.IsBase64Encoded) ? content : Convert.ToBase64String(Encoding.UTF8.GetBytes(content))
                }
            }));
        }

        public void SignXml(
            NCAStorage storage,
            NCAKey key,
            string xml,
            NCACallback<SignXmlResponse> callback,
            string tbsElementXPath = "",
            string sigParentElementXPath = "")
        {
            SpawnWebSocket(callback).Send(JsonConvert.SerializeObject(new
            {
                module = EnumDescriptions.NCAModules[NCAModule.CommonUtils],
                method = EnumDescriptions.NCAMethods[NCAMethod.SignXml],
                args = new object[]
                {
                    EnumDescriptions.NCAStorages[storage],
                    EnumDescriptions.NCAKeys[key],
                    xml,
                    tbsElementXPath,
                    sigParentElementXPath
                }
            }));
        }

        public void SignXmls(
            NCAStorage storage,
            NCAKey key,
            string[] xmls,
            NCACallback<SignXmlsResponse> callback,
            string tbsElementXPath = "",
            string sigParentElementXPath = "")
        {
            SpawnWebSocket(callback).Send(JsonConvert.SerializeObject(new
            {
                module = EnumDescriptions.NCAModules[NCAModule.CommonUtils],
                method = EnumDescriptions.NCAMethods[NCAMethod.SignXmls],
                args = new object[]
                {
                    EnumDescriptions.NCAStorages[storage],
                    EnumDescriptions.NCAKeys[key],
                    xmls.Select(e => e),
                    tbsElementXPath,
                    sigParentElementXPath
                }
            }));
        }

        public void GetActiveTokens(
            NCACallback<GetActiveTokensResponse> callback)
        {
            SpawnWebSocket(callback).Send(JsonConvert.SerializeObject(new
            {
                module = EnumDescriptions.NCAModules[NCAModule.CommonUtils],
                method = EnumDescriptions.NCAMethods[NCAMethod.GetActiveTokens]
            }));
        }

        public void GetKeyInfo(
            NCAStorage storageType,
            NCACallback<GetKeyInfoResponse> callback)
        {
            SpawnWebSocket(callback).Send(JsonConvert.SerializeObject(new
            {
                module = EnumDescriptions.NCAModules[NCAModule.CommonUtils],
                method = EnumDescriptions.NCAMethods[NCAMethod.GetKeyInfo],
                args = new object[]
                {
                    EnumDescriptions.NCAStorages[storageType]
                }
            }));
        }

        public void ChangeLocale(
            NCALocale locale,
            NCACallback<ChangeLocaleResponse> callback)
        {
            SpawnWebSocket(callback).Send(JsonConvert.SerializeObject(new
            {
                module = EnumDescriptions.NCAModules[NCAModule.CommonUtils],
                method = EnumDescriptions.NCAMethods[NCAMethod.ChangeLocale],
                args = new object[]
                {
                    EnumDescriptions.NCALocales[locale]
                }
            }));
        }
    }
}
