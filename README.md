# Hello World Assessment

This solution has two projects: **HelloWorld** and **HelloWorldTests**.  The main api simply writes some given text to a specified writer via an http POST request.

## Call the API from a client
Since it's an http request, any client that supports http requests can call the api.  Here are some examples from different clients.

### cURL
    curl --location --request POST 'https://localhost:5001/hello' \
    --header 'Content-Type: application/json' \    
    --data-raw '{
    "textd": "Hello World","writeTo": "console"
    }'

### C#

    var client = new RestClient("https://localhost:5001/hello");
    client.Timeout = -1;
    var request = new RestRequest(Method.POST);
    request.AddHeader("Content-Type", "application/json");
    request.AddParameter("application/json", "{\n \"text\": \"Hello World\",\"writeTo\": \"console\"\n}", ParameterType.RequestBody);
    IRestResponse response = client.Execute(request);
    Console.WriteLine(response.Content);

### Powershell

    $headers = New-Object "System.Collections.Generic.Dictionary[[String],[String]]"
    $headers.Add("Content-Type", "application/json")
    $body = "{`n `"textd`": `"Hello World`",`"writeTo`": `"console`"`n}"
    $response = Invoke-RestMethod 'https://localhost:5001/hello' -Method 'POST' -Headers $headers -Body $body
    $response | ConvertTo-Json
