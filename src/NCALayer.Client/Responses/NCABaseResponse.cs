using Newtonsoft.Json.Linq;

namespace NCALayer.Client
{
    public abstract class NCABaseResponse
    {
        public NCAResponseState ResponseState { get; }
        public bool Success { get { return ResponseState == NCAResponseState.Success; } }
        public string ErrorMessage { get; }
        public string RawResponse { get; }

        public NCABaseResponse(string response)
        {
            RawResponse = response;

            JObject j = JObject.Parse(response);

            if (!j.TryGetValue("code", out var code))
            {
                ResponseState = NCAResponseState.Undefined;
                return;
            }

            if (j.TryGetValue("message", out var message))
            {
                if (message.Value<string>() == "action.canceled")
                    ResponseState = NCAResponseState.Canceled;
                else if (message.Value<string>() == "unable.to.connect")
                    ResponseState = NCAResponseState.UnableToConnect;
                else if (message.Value<string>().StartsWith("NoSuchMethodException"))
                    ResponseState = NCAResponseState.NotFound;
                else
                {
                    ResponseState = NCAResponseState.BadRequest;
                    ErrorMessage = message.Value<string>();
                }
            }
            else if (code.Value<string>() == "200")
                ResponseState = NCAResponseState.Success;
            else
                ResponseState = NCAResponseState.Undefined;
        }
    }
}
