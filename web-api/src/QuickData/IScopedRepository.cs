namespace BogdaroneApp.QuickData;

internal interface IScopedRepository
{
    IDbContext DbContext { get; set; }
}
