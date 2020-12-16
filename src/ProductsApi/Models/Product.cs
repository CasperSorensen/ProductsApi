using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProductsApi.Models
{
  public class Product
  {

    [BsonId]
    public ObjectId InternalId { get; set; }
    public long Id { get; set; }
    public int product_id { get; set; }
    public string product_name { get; set; }
    public string product_description { get; set; }
    public int product_price { get; set; }
  }
}