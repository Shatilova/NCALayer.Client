using NCALayer.Client;
using NCALayer.Client.CommonUtils;

var client = new NCACommonUtilsClient();

var exitEvent = new ManualResetEvent(false);
client.Ping(PingCallback);
exitEvent.WaitOne();

exitEvent = new ManualResetEvent(false);
client.RawRequest("kz.gov.pki.knca.commonUtils", "getActiveTokens", null, GetActiveTokensCallback);
exitEvent.WaitOne();

Console.WriteLine("Press any key to terminate the program");
Console.ReadKey();

Task PingCallback(NCAPingResponse response)
{
    Console.WriteLine($"NCA Layer {(response.Success ? string.Empty : "not")} launched");
    exitEvent.Set();
    return Task.CompletedTask;
}

Task GetActiveTokensCallback(NCARawResponse response)
{
    if (response.Success)
        Console.WriteLine($"Raw response: {response.RawResponse}");
    else
        Console.WriteLine($"GetActiveTokensCallback error: {response.ResponseState}");

    exitEvent.Set();
    return Task.CompletedTask;
}