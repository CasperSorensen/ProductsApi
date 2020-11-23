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
        public int ProductId { get; set; }
        public string Content { get; set; }
        public int Price { get; set; }

    }

}