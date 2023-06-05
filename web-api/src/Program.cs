using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Services;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

const string credentialFilePath = "quick-data-credentials.json";
const string spreadsheetId = "10qDdoWPP1QgYjzRsVgTn93E7_K4k-Q31lOq0HMq1xI8";

SheetsService service = GetSheetsService("BogdaroneApp-web-api");
string range = "Sheet1!A1:C10"; // Specify the range you want to read from

try {
    
SpreadsheetsResource.ValuesResource.GetRequest request 
    = service.Spreadsheets.Values.Get(spreadsheetId, range);

ValueRange response = request.Execute();
IList<IList<object>> values = response.Values;

if (values != null && values.Count > 0)
{
    foreach (var row in values)
    {
        foreach (var cell in row)
        {
            Console.WriteLine(cell);
        }
    }
}
} catch (Exception e) {
    Console.WriteLine(e.Message);
}


//**************************
// Helpers
//**************************

static SheetsService GetSheetsService(string applicationName)
{
    GoogleCredential credential;
    using (var stream = new FileStream(credentialFilePath, FileMode.Open, FileAccess.Read))
    {
        credential = GoogleCredential.FromStream(stream)
            .CreateScoped(SheetsService.Scope.Spreadsheets);
    }

    var service = new SheetsService(new BaseClientService.Initializer()
    {
        HttpClientInitializer = credential,
        ApplicationName = applicationName,
    });

    return service;
}