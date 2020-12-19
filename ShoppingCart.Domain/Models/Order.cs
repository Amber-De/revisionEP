using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShoppingCart.Domain.Models
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Email { get; set; }
        public DateTime DatePlace { get; set; }

    }
}
