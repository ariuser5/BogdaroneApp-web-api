using BogdaroneApp.Domain.DataAccess;

namespace BogdaroneApp.QuickData;

internal interface IDbContext
{
    SpreadsheetDataReader GetSpreadsheetReader();
    DriveDataReader GetDriveReader();
    IRepository<T>? GetRepository<T>() where T : class;
}
