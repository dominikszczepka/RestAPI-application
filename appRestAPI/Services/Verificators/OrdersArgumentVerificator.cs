using appRestAPI.Contracts.Orders;
using System.Reflection;
using System.Text;

namespace appRestAPI.Services.Verificators
{
    public class OrdersArgumentVerificator : IArgumentVerificator<GetOrdersQuery>
    {
        private readonly StringBuilder reasonStringBuilder = new();
        private int fieldCounter = 0;

        public string? Verify(GetOrdersQuery query)
        {
            var type = typeof(GetOrdersQuery);
            var properties = type.GetProperties();
            foreach (var property in properties)
            {
                if (property.GetValue(query) == null)
                    reasonStringBuilder.Append($"Missing Field Value {property.Name}");
                else fieldCounter++;
            }

            if (fieldCounter == 1 || fieldCounter == 3)
                return null;

            return reasonStringBuilder.ToString();
        }
    }
}
