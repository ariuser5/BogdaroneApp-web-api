using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;

namespace BogdaroneApp.QuickData;

internal static class GoogleData
{
    const string CredentialFileName = "quick-data-credentials";
    const string SpreadsheetId = "10qDdoWPP1QgYjzRsVgTn93E7_K4k-Q31lOq0HMq1xI8";

    public const string SchemaSheetName = "Schemas";

    public static string[] SchemaSheetColumnHeaderCaptions => new string[]
    {
        "TableName",
        "Schema(JSON)",
    };


    public static GoogleDataConnection Connect(string requesterAppName) {
        SheetsService sheetsService = GetSheetsService(requesterAppName);
        DriveService driveService = GetDriveService(requesterAppName);
        var spreadsheetReader = new SpreadsheetDataReader(sheetsService, SpreadsheetId);
        var driveReader = new DriveDataReader(driveService);
        return new GoogleDataConnection(driveReader, spreadsheetReader);
    }

    static SheetsService GetSheetsService(string applicationName)
    {
        string CredentialFilePath = Path.Combine(Directory.GetCurrentDirectory(), CredentialFileName);
        GoogleCredential credential;
        using (var stream = new FileStream(CredentialFilePath, FileMode.Open, FileAccess.Read))
        {
            credential = GoogleCredential.FromStream(stream).CreateScoped(SheetsService.Scope.Spreadsheets);
        }

        var service = new SheetsService(new BaseClientService.Initializer()
        {
            HttpClientInitializer = credential,
            ApplicationName = applicationName,
        });

        return service;
    }

    static DriveService GetDriveService(string applicationName)
    {
        string CredentialFilePath = Path.Combine(Directory.GetCurrentDirectory(), CredentialFileName);
        GoogleCredential credential;
        using (var stream = new FileStream(CredentialFilePath, FileMode.Open, FileAccess.Read))
        {
            credential = GoogleCredential.FromStream(stream).CreateScoped(DriveService.Scope.DriveReadonly);
        }

        var service = new DriveService(new BaseClientService.Initializer()
        {
            HttpClientInitializer = credential,
            ApplicationName = applicationName,
        });

        return service;
    }
}
