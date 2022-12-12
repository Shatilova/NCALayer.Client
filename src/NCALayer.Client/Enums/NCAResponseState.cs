namespace NCALayer.Client
{
    public enum NCAResponseState
    {
        Success,

        /// <summary>
        /// Action cancelled by user
        /// </summary>
        Canceled,

        /// <summary>
        /// Invalid arguments were passed<br/><br/>
        /// More details can be found in <b>ErrorMessage</b> property of response
        /// </summary>
        BadRequest,

        /// <summary>
        /// Unexpected result
        /// </summary>
        Undefined,

        /// <summary>
        /// NCALayer not launched
        /// </summary>
        UnableToConnect,

        /// <summary>
        /// Requested method not found
        /// </summary>
        NotFound
    }
}
