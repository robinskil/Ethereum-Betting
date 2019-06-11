using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InteractorLayer.RequestModels
{
    public class CreateUserRequestModel
    {
        [Required]
        public string Address { get; set; }
        [Required]
        public string Password { get; set; }
        public string Username { get; set; }
    }
}
