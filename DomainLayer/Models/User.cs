using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DomainLayer.Models
{
    public class User
    {
        [Key]
        public string UserAddress { get; set; }
        public string GeneratedName { get; set; }
        public IList<Bet> OwnedBets { get; set; }
    }
}
