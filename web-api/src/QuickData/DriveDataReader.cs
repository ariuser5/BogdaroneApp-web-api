using Google.Apis.Drive.v3;

namespace BogdaroneApp.QuickData;

internal class DriveDataReader
{
    private readonly DriveService _driveService;

    public DriveDataReader(DriveService driveService)
    {
        _driveService = driveService;
    }

    public Google.Apis.Drive.v3.Data.File GetFile(string fileId)
    {
        try {
            FilesResource.GetRequest request = _driveService.Files.Get(fileId);
            Google.Apis.Drive.v3.Data.File fileData = request.Execute();
            return fileData;
        } catch (Exception e) {
            Console.WriteLine(e);
            throw;
        }
    }

    public byte[] FetchDataById(string fileId)
    {
        FilesResource.GetRequest request = _driveService.Files.Get(fileId);
        using MemoryStream stream = new();
        request.Download(stream);
        return stream.ToArray();
    }
}
