using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DomainLayer.Models
{
    public class Bet
    {
        [Key]
        public string BetAddress { get; set; }
        public string OwnerAddress { get; set; }
        public virtual User Owner { get; set; }
    }
}
