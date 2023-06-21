using BogdaroneApp.Domain.Models;

namespace BogdaroneApp.QuickData.Repositories;

internal class ImageRepository : Repository<Image>
{
    /// <inheritdoc />
    public ImageRepository() { }

    public ImageRepository(IDbContext dbContext): base(dbContext) { }


    public override void Add(Image entity)
    {
        throw new NotImplementedException();
    }

    public override void Delete(Image entity)
    {
        throw new NotImplementedException();
    }

    public override IEnumerable<Image> GetAll()
    {
        throw new NotImplementedException();
    }

    public override Image GetById(string id)
    {
        DriveDataReader reader = base.DbContext.GetDriveReader();
        Google.Apis.Drive.v3.Data.File file = reader.GetFile(id);
        byte[] imageData = reader.FetchDataById(id);
        Image image = new()
        {
            Id = file.Id,
            Bytes = imageData
        };
        return image;
    }

    public override void Update(Image entity)
    {
        throw new NotImplementedException();
    }
}
