using appRestAPI.Contracts.Orders;
using appRestAPI.Models;

namespace appRestAPI.Services.FileService
{
    public interface IFileService
    {
        public Task<IEnumerable<Order>> GetOrdersAsync(GetOrdersQuery query);
    }
}
