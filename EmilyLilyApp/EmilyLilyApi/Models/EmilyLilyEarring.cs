using Azure;
using Azure.Data.Tables;
using System.Text.Json.Serialization;

namespace EmilyLilyApi.Models
{
    public class EmilyLilyEarring : ITableEntity
    {
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string Colour { get; set; }
        public string ImageUrl { get; set; }
        public int QuantityPairs { get; set; }
        public string Name { get; set; }
        public string Materials { get; set; }
        public string Size { get; set; }

        [JsonIgnore]
        public ETag ETag { get; set; }
    }
}
