using System.ComponentModel.DataAnnotations;

namespace appRestAPI.Models
{
    public class Order
    {
        [Required]
        public string Number { get; set; } = null!;

        [Required]
        public string ClientCode { get; set; } = null!;

        [Required]
        public string ClientName { get; set; } = null!;

        [Required]
        public DateOnly OrderDate { get; set; }

        public DateOnly? ShipmentDate { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public bool Confirmed { get; set; }

        [Required]
        public float Value { get; set; }
    }
}
