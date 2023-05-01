using System.ComponentModel.DataAnnotations;

namespace appRestAPI.Contracts.Orders
{
    public class OrderResult
    {
        [Required]
        public string Number { get; set; } = null!;

        [Required]
        public string ClientCode { get; set; } = null!;

        [Required]
        public string ClientName { get; set; } = null!;

        [Required]
        public string OrderDate { get; set; } = null!;

        public string? ShipmentDate { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public bool Confirmed { get; set; }

        [Required]
        public float Value { get; set; }
    }
}
