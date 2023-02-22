using Newtonsoft.Json;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal struct ConfigJSON {

  [JsonProperty("token")]
  public string Token { get; private set; }

  [JsonProperty("prefix")]
  public string Prefix { get; private set; }

  [JsonProperty("mongo")]
  public string Mongo { get; private set; }

}