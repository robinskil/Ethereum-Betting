using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DomainLayer.Models
{
    public sealed class Bet
    {
        [Key]
        public string BetAddress { get; set; }
        public string UserAddress { get; set; }
        public User Owner { get; set; }
    }
}
