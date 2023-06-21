using Azure.Data.Tables;
using EmilyLilyApi.Models;

namespace EmilyLilyApi.Services
{
    public class TableServices
    {
        private readonly TableClient _tableClient;

        public TableServices(TableClient tableClient)
        {
            _tableClient = tableClient;
        }

        public async Task<IEnumerable<EmilyLilyEarring>> GetItems()
        {
            var list = _tableClient.Query<EmilyLilyEarring>().ToList();

            return list;
        }

        public async Task<EmilyLilyEarring> GetItemId(string id)
        {
            var item = _tableClient.Query<EmilyLilyEarring>()
                .FirstOrDefault(i => i.RowKey == id);

            return item;
        }

        public async Task AddItemAsync(EmilyLilyEarring item)
        {
            var newItem = _tableClient.Query<EmilyLilyEarring>()
                .FirstOrDefault(i => i.RowKey == item.RowKey);

            if (newItem is null)
            {
                await _tableClient.AddEntityAsync(item);
            }
        }

        public async Task UpdateItemAsync(EmilyLilyEarring item)
        {
            await _tableClient.UpsertEntityAsync(item, TableUpdateMode.Replace);
        }

        public async Task DeleteItemAsync(string itemId)
        {
            var item = _tableClient.Query<EmilyLilyEarring>()
                .FirstOrDefault(i => i.RowKey == itemId);

            await _tableClient.DeleteEntityAsync(item.PartitionKey, item.RowKey);
        }
    }
}
