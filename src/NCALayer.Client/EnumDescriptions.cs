using System.Collections.Generic;

namespace NCALayer.Client
{
    internal static class EnumDescriptions
    {
        public static Dictionary<NCAMethod, string> NCAMethods = new Dictionary<NCAMethod, string>()
        {
            [NCAMethod.CreateCMSSignatureFromBase64] = "createCMSSignatureFromBase64",
            [NCAMethod.CreateCAdESFromBase64] = "createCAdESFromBase64",
            [NCAMethod.CreateCAdESFromBase64Hash] = "createCAdESFromBase64Hash",
            [NCAMethod.ApplyCAdEST] = "applyCAdEST",
            [NCAMethod.GetActiveTokens] = "getActiveTokens",
            [NCAMethod.GetKeyInfo] = "getKeyInfo",
            [NCAMethod.ChangeLocale] = "changeLocale",
            [NCAMethod.SignXml] = "signXml",
            [NCAMethod.SignXmls] = "signXmls"
        };

        public static Dictionary<NCAModule, string> NCAModules = new Dictionary<NCAModule, string>()
        {
            [NCAModule.CommonUtils] = "kz.gov.pki.knca.commonUtils"
        };

        public static Dictionary<NCAStorage, string> NCAStorages = new Dictionary<NCAStorage, string>()
        {
            [NCAStorage.PKCS12] = "PKCS12",
            [NCAStorage.KAZTOKEN] = "AKKaztokenStore",
            [NCAStorage.IDCard] = "AKKZIDCardStore",
            [NCAStorage.EToken72k] = "AKEToken72KStore",
            [NCAStorage.EToken5110] = "AKEToken5110Store",
            [NCAStorage.JaCarta] = "AKJaCartaStore",
            [NCAStorage.AKey] = "AKAKEYStore",
            [NCAStorage.JKS] = "JKS"
        };

        public static Dictionary<NCAKey, string> NCAKeys = new Dictionary<NCAKey, string>()
        {
            [NCAKey.Authentication] = "AUTHENTICATION",
            [NCAKey.Signature] = "SIGNATURE",
            [NCAKey.Any] = "ANY"
        };

        public static Dictionary<NCALocale, string> NCALocales = new Dictionary<NCALocale, string>()
        {
            [NCALocale.Ru] = "ru",
            [NCALocale.Kz] = "kk"
        };
    }
}
