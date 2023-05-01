using appRestAPI.Contracts.Orders;

namespace appRestAPI.Services.Verificators
{
    public interface IArgumentVerificator<TQuery>
    {
        public string? Verify(TQuery query);
    }
}
