using System;

namespace ProductsApi.Configs
{
  public class ServerConfig
  {
    public MongoDbConfig MongoDb { get; set; } = new MongoDbConfig();
  }
}