namespace NCALayer.Client
{
    public class NCAPingResponse
    {
        public bool Success { get; }

        public NCAPingResponse(string response)
        {
            Success = response == "--heartbeat--";
        }
    }
}
