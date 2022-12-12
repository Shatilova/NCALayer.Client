using Newtonsoft.Json;
using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Websocket.Client;
using Websocket.Client.Logging;

namespace NCALayer.Client
{
    public delegate Task NCACallback<T>(T response);

    public abstract class NCALayerClientBase
    {   
        public void Ping(
            NCACallback<NCAPingResponse> callback)
        {
            SpawnWebSocket(callback).Send("--heartbeat--");
        }

        public void RawRequest(
            string module,
            string method,
            object args,
            NCACallback<NCARawResponse> callback)
        {
            SpawnWebSocket(callback).Send(JsonConvert.SerializeObject(new
            {
                module,
                method,
                args
            }));
        }

        protected WebsocketClient SpawnWebSocket<T>(NCACallback<T> callback) where T : class
        {
            var ws = new WebsocketClient(new Uri("wss://127.0.0.1:13579"));
            ws.ReconnectTimeout = null;
            ws.MessageReceived.Subscribe(msg =>
            {
                if (!IsReliableResponse(msg.Text))
                    return;
                
                callback((T)Activator.CreateInstance(typeof(T), msg.Text));
                ws.Stop(System.Net.WebSockets.WebSocketCloseStatus.NormalClosure, string.Empty);
                ws.Dispose();
            });

            ws.DisconnectionHappened.Subscribe(msg =>
            {
                if (msg.Type == DisconnectionType.Exit || msg.Type == DisconnectionType.ByUser)
                    return;

                callback((T)Activator.CreateInstance(typeof(T), "{\"code\": 500, \"message\": \"unable.to.connect\"}"));
                ws.Dispose();
            });
            ws.Start();

            return ws;
        }

        static readonly Regex UnreliableResponseRegex = new Regex(@"{""result"":{""version"":""[0-9.]*""}}", RegexOptions.Compiled);
        bool IsReliableResponse(string response)
        {
            return !string.IsNullOrWhiteSpace(response) &&
                !UnreliableResponseRegex.IsMatch(response);
        }
    }
}
