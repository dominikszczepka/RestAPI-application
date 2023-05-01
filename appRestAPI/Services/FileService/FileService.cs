using appRestAPI.Contracts.Dtos;
using appRestAPI.Contracts.Orders;
using appRestAPI.Models;
using AutoMapper;
using CsvHelper;
using Microsoft.Extensions.Options;
using System.Globalization;

namespace appRestAPI.Services.FileService
{
    public class FileService : IFileService
    {
        private readonly FileServiceConfig _config;
        private readonly IMapper _mapper;

        public FileService(IOptions<FileServiceConfig> options, IMapper mapper)
        {
            _config = options?.Value ?? throw new ArgumentNullException(nameof(options));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public Task<IEnumerable<Order>> GetOrdersAsync(GetOrdersQuery query)
        {
            using (var reader = new StreamReader(_config.FileLocation))
            {
                using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
                var records = csv.GetRecords<OrderDto>();
                var orders = _mapper.Map<IEnumerable<Order>>(records);

                if (query.OrderDate != null)
                    orders = FilterByDate(orders, query.OrderDate);
                if (query.ClientNumbers != null)
                    orders = FilterByClientNumber(orders, query.ClientNumbers);
                if (query.OrderNumber != null)
                    orders = FilterByNumber(orders, query.OrderNumber);

                return Task.FromResult(orders);
            }
        }

        private static IEnumerable<Order> FilterByClientNumber(IEnumerable<Order> orders, IEnumerable<string> clientNumbers)
        {
            return orders.Where(o => clientNumbers.Contains(o.ClientCode));
        }
        private static IEnumerable<Order> FilterByNumber(IEnumerable<Order> orders, string number)
        {
            return orders.Where(o => o.Number == number);
        }
        private static IEnumerable<Order> FilterByDate(IEnumerable<Order> orders, OrderDateDto date)
        {
            var startingDate = DateOnly.Parse(date.StartingDate);
            var endDate = DateOnly.Parse(date.EndDate);

            return orders.Where(o =>
                o.OrderDate.CompareTo(startingDate) >= 0 &&
                o.OrderDate.CompareTo(endDate) <= 0);
        }
    }
}
