using Google.Apis.Http;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;

namespace BogdaroneApp.QuickData;

public class SpreadsheetDataReader : IDisposable
{
    private readonly SheetsService _sheetsService;

    public SpreadsheetDataReader(SheetsService sheetsService, string spreadsheetId)
    {
        _sheetsService = sheetsService;
        SpreadsheetId = spreadsheetId;
    }

    public string SpreadsheetId { get; }

    public IList<IList<object>> Read(string range)
    {
        SpreadsheetsResource.ValuesResource.GetRequest request 
            = _sheetsService.Spreadsheets.Values.Get(this.SpreadsheetId, range);
        
        request.AddExceptionHandler(new MyHttpExceptionHandler());
        
        ValueRange response = request.Execute();
        IList<IList<object>> values = response.Values.ToArray();

        return values;
    }

    public IAsyncEnumerable<object> ReadAsync(string range, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    private SortedSet<KeyValuePair<string, string>> ReadSchema(string name)
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        _sheetsService.Dispose();
    }


    public class MyHttpExceptionHandler : IHttpExceptionHandler
    {
        public Task<bool> HandleExceptionAsync(HandleExceptionArgs args)
        {
            throw args.Exception;
        }
    }
}