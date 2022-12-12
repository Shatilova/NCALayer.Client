using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NCALayer.Client.CommonUtils
{
    public class KeyIssuer
    {
        public string CommonName { get; set; }
        public string CountryCode { get; set; }
        public string DN { get; set; }
    }

    public class KeySubject
    {
        public string CommonName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public string IIN { get; set; }
        public string DN { get; set; }
        public string CountryCode { get; set; }
        public string BIN { get; set; }
    }

    public class KeyInfo
    {
        public DateTime NotBefore { get; set; }
        public DateTime NotAfter { get; set; }
        public string AuthorityKeyIdentifier { get; set; }
        public string SerialNumber { get; set; }
        public string KeyId { get; set; }
        public string Alias { get; set; }
        public string PEM { get; set; }
        public string Algorithm { get; set; }
        public KeyIssuer Issuer { get; set; }
        public KeySubject Subject { get; set; }
    }

    public class KeyInfoDto
    {
        public long CertNotBefore { get; set; }
        public string IssuerCn { get; set; }
        public string AuthorityKeyIdentifier { get; set; }
        public string SerialNumber { get; set; }
        public long CertNotAfter { get; set; }
        public string IssuerDn { get; set; }
        public string KeyId { get; set; }
        public string Alias { get; set; }
        public string PEM { get; set; }
        public string SubjectCn { get; set; }
        public string Algorithm { get; set; }
        public string SubjectDn { get; set; }
    }

    public class GetKeyInfoResponse : NCABaseResponse
    {
        public KeyInfo KeyInfo { get; }
        public GetKeyInfoResponse(string response) : base(response)
        {
            JObject j = JObject.Parse(response);
            if (!j.TryGetValue("responseObject", out var respObj))
                return;

            var dto = JsonConvert.DeserializeObject<KeyInfoDto>(respObj.ToString());
            KeyInfo = new KeyInfo()
            {
                Algorithm = dto.Algorithm,
                Alias = dto.Alias,
                AuthorityKeyIdentifier = dto.AuthorityKeyIdentifier,
                KeyId = dto.KeyId,
                PEM = dto.PEM,
                SerialNumber = dto.SerialNumber,
                NotAfter = DateTimeOffset.FromUnixTimeMilliseconds(dto.CertNotAfter).DateTime,
                NotBefore = DateTimeOffset.FromUnixTimeMilliseconds(dto.CertNotBefore).DateTime,
                Issuer = BuildIssuer(dto.IssuerDn),
                Subject = BuildSubject(dto.SubjectDn)
            };
        }

        KeyIssuer BuildIssuer(string issuerDn)
        {
            var parsedDn = ParseDN(issuerDn);
            return new KeyIssuer()
            {
                DN = issuerDn,
                CommonName = parsedDn.FirstOrDefault(e => e.Key == "CN").Value,
                CountryCode = parsedDn.FirstOrDefault(e => e.Key == "C").Value
            };
        }

        KeySubject BuildSubject(string subjectDn)
        {
            var parsedDn = ParseDN(subjectDn);

            string iin = parsedDn.FirstOrDefault(e => e.Key == "SERIALNUMBER").Value;
            string bin = parsedDn.FirstOrDefault(e => e.Key == "OU").Value;
            return new KeySubject()
            {
                DN = subjectDn,
                Email = parsedDn.FirstOrDefault(e => e.Key == "E").Value,
                IIN = iin == null ? null : iin.StartsWith("IIN") ? iin.Substring(3) : null,
                LastName = parsedDn.FirstOrDefault(e => e.Key == "SURNAME").Value,
                MiddleName = parsedDn.FirstOrDefault(e => e.Key == "G").Value,
                CommonName = parsedDn.FirstOrDefault(e => e.Key == "CN").Value,
                CountryCode = parsedDn.FirstOrDefault(e => e.Key == "C").Value,
                BIN = bin == null ? null : bin.StartsWith("BIN") ? bin.Substring(3) : null,
            };
        }

        public Dictionary<string, string> ParseDN(string dn) =>
            dn.Split(',').ToDictionary(k => k.Substring(0, k.IndexOf('=')), v => v.Substring(v.IndexOf('=') + 1));
    }
}
