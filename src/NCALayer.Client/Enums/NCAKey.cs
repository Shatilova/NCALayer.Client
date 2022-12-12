namespace NCALayer.Client
{
    public enum NCAKey
    {
        /// <summary>
        /// Requires AUTH key
        /// </summary>
        Authentication,

        /// <summary>
        /// Requires RSA/GOST key
        /// </summary>
        Signature,

        /// <summary>
        /// Allows use any key
        /// </summary>
        Any
    }
}
