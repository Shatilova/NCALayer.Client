using System;

namespace NCALayer.Client.CommonUtils
{
    [Flags]
    public enum CreateCMSSignatureFromBase64Option
    {
        None = 0,

        /// <summary>
        /// Content is base64 encoded
        /// </summary>
        IsBase64Encoded = 1,

        /// <summary>
        /// Content should be attached to CMS
        /// </summary>
        AttachContent = 2
    }

    [Flags]
    public enum CreateCAdESFromBase64Option
    {
        None = 0,

        /// <summary>
        /// Content is base64 encoded
        /// </summary>
        IsBase64Encoded = 1,

        /// <summary>
        /// Content should be attached to CMS
        /// </summary>
        AttachContent = 2
    }

    [Flags]
    public enum CreateCAdESFromBase64HashOption
    {
        None = 0,

        /// <summary>
        /// Content is base64 encoded
        /// </summary>
        IsBase64Encoded = 1
    }
}
