using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductsApi.Models;
using ProductsApi.Data;
using Newtonsoft.Json;

namespace ProductsApi.Controllers
{
  [Controller]
  [Route("[controller]")]
  public class ProductsController : Controller
  {
    private readonly IProductsRepository _productsrepo;

    public ProductsController(IProductsRepository repo)
    {
      this._productsrepo = repo;    
    }

    // GET /Product
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> Get()
    {
      return new ObjectResult(await this._productsrepo.GetAllProducts());
    }

    // GET /Product/1
    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> Get(long id)
    {
      var Product = await this._productsrepo.GetProduct(id);
      if (Product == null)
        return new NotFoundResult();

      return new ObjectResult(Product);
    }

    // POST /Product
    [HttpPost]
    public async Task<ActionResult<Product>> Post([FromBody] Product Product)
    {
      Product.Id = await this._productsrepo.GetNextId();

      string jsondata = JsonConvert.SerializeObject(Product);
      await _productsrepo.Create(Product);
      return new OkObjectResult(Product);
    }

    // PUT /Product/1
    [HttpPut("{id}")]
    public async Task<ActionResult<Product>> Put(long id, [FromBody] Product Product)
    {
      var ProductFromDb = await _productsrepo.GetProduct(id);

      if (ProductFromDb == null)
        return new NotFoundResult();

      Product.Id = ProductFromDb.Id;
      Product.InternalId = ProductFromDb.InternalId;

      await _productsrepo.Update(Product);

      return new OkObjectResult(Product);
    }

    // DELETE /Products/1
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
      var post = await _productsrepo.GetProduct(id);

      if (post == null)
        return new NotFoundResult();

      await _productsrepo.Delete(id);

      return new OkResult();
    }

  }
}
