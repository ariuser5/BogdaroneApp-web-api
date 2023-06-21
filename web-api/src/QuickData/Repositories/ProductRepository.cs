using BogdaroneApp.Domain.DataAccess;
using BogdaroneApp.Domain.Models;

namespace BogdaroneApp.QuickData.Repositories;

internal class ProductRepository : Repository<Product>
{
    /// <inheritdoc />
    public ProductRepository() { }

    public ProductRepository(IDbContext dbContext) : base(dbContext) { }


    public override void Add(Product entity)
    {
        throw new NotImplementedException();
    }

    public override void Delete(Product entity)
    {
        throw new NotImplementedException();
    }

    public override IEnumerable<Product> GetAll()
    {
        IEnumerable<IList<object>> values = DbContext.GetSpreadsheetReader().Read("Products!A1:D10");
        List<Product> products = new();

        foreach (var row in values)
        {
            var newProduct = new Product()
            {
                Id = row[0].ToString(),
                Name = row[1].ToString(),
                ImageId = row[2].ToString(),
                Description = row[3].ToString()
            };

            products.Add(newProduct);
        }

        return products;
    }

    public override Product GetById(string id)
    {
        throw new NotImplementedException();
    }

    public override void Update(Product entity)
    {
        throw new NotImplementedException();
    }
}