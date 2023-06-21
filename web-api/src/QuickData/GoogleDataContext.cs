using BogdaroneApp.Domain.DataAccess;

namespace BogdaroneApp.QuickData;

internal class GoogleDataContext : IDbContext
{
    private readonly GoogleDataConnection _connection;
    private readonly IServiceProvider _serviceProvider;

    public GoogleDataContext(
        GoogleDataConnection connection,
        IServiceProvider serviceProvider
    ) {
        _connection = connection;
        _serviceProvider = serviceProvider;
    }

    public DriveDataReader GetDriveReader()
    {
        return _connection.DriveReader;
    }

    public SpreadsheetDataReader GetSpreadsheetReader()
    {
        return _connection.SpreadsheetReader;
    }

    public IRepository<T>? GetRepository<T>() where T : class
    {
        return _serviceProvider.GetService<IRepository<T>>();
    }
}
