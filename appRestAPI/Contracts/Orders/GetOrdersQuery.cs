using appRestAPI.Contracts.Dtos;
using MediatR;

namespace appRestAPI.Contracts.Orders
{
    public class GetOrdersQuery : IRequest<GetOrdersResult>
    {
        public string? OrderNumber { get; set; } = null!;

        public OrderDateDto? OrderDate { get; set; } = null!;

        public IEnumerable<string>? ClientNumbers { get; set; } = null!;
    }
}
