using System;
using System.Threading.Tasks;
using Xunit;
using ProductsApi.Data;
using ProductsApi.Contexts;
using ProductsApi.Configs;
using ProductsApi.Models;

namespace ProductsApi.Unittests
{
  public class ProductsTests
  {

    private Product _testProduct { get; set; }

    public ProductsTests()
    {
      this._testProduct = new Product();
    }

    [Fact, Trait("Priority", "1"), Trait("Category", "UnitTests")]
    public void CreateDummyProduct_NotNull()
    {
      var testproduct = this._testProduct.CreateDummyProduct();
      Assert.NotNull(testproduct);
    }

    [Fact, Trait("Priority", "1"), Trait("Category", "UnitTests")]
    public void CreateDummyOrder_ProductPriceZero()
    {
      var testproduct = this._testProduct.CreateDummyProduct();
      Assert.Equal(0, testproduct.product_price);
    }
  }
}
