using System;
using System.Threading.Tasks;
using Xunit;
using ProductsApi.Data;
using ProductsApi.Contexts;
using ProductsApi.Configs;

namespace ProductsApi.Unittests
{
  public class ProductsRepositoryTests
  {

    private IProductsContext _context { get; set; }

    public ProductsRepositoryTests()
    {
      var config = new ServerConfig();

      config.MongoDb.Database = "products_Db";
      config.MongoDb.Host = "localhost";
      config.MongoDb.Port = 27018;
      config.MongoDb.User = "root";
      config.MongoDb.Password = "example";
      this._context = new ProductsContext(config.MongoDb);
    }

    // [Fact, Trait("Priority", "1"), Trait("Category", "IntegrationTests")]
    // public async Task GetAllProductsTest_NotNullOrEmptyList()
    // {
    //   ProductsRepository pr = new ProductsRepository(this._context);
    //   var result = await pr.GetAllProducts();
    //   foreach (var item in result)
    //   {
    //     System.Console.WriteLine(item.product_name);
    //   }
    //   System.Console.WriteLine();
    //   Assert.NotEmpty(result);
    //   Assert.NotNull(result);
    // }
  }
}
