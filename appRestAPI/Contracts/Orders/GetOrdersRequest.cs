using appRestAPI.Models;

namespace appRestAPI.Contracts.Orders
{
    public record GetOrdersResult
    {
        public bool IsQueryValid { get; set; }

        public string InvalidityReason { get; set; } = null!;

        public IEnumerable<OrderResult> Orders { get; set; } = Enumerable.Empty<OrderResult>();
    }
}
