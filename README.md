# NCALayer.Client

___
### Remarks of 2024
#### It’s better to use [NCANode](https://github.com/malikzh/NCANode) for digital signatures instead of NCALayer and this package

*The remainder of this document is left as is.*
___

Client for working with [NCALayer](https://pki.gov.kz/ncalayer/) via websockets

## Features
- installation via NuGet ([NCALayer.Client](https://www.nuget.org/packages/NCALayer.Client))
- targeting .NET Standard 2.0 and any newer specification

## Usage example
``` csharp
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
```
More examples can be found in *samples/* folder

## TODO
- improve Distinguished Names parsing in **getKeyInfo**
- implement **createCAdESFromFile**, **showFileChooser**, **createCMSSignatureFromFile** from *kz.gov.pki.knca.commonUtils*
- implement out-of-box *kz.gov.pki.knca.basics* module support (NCALayer.Client.NCABasicsClient in future)
