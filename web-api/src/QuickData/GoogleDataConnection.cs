namespace BogdaroneApp.QuickData;

internal class GoogleDataConnection
{
    public GoogleDataConnection(DriveDataReader driveReader, SpreadsheetDataReader spreadsheetReader)
    {
        DriveReader = driveReader;
        SpreadsheetReader = spreadsheetReader;
    }

    public DriveDataReader DriveReader { get; }
    public SpreadsheetDataReader SpreadsheetReader { get; }
}
