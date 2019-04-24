using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InteractorLayer.RequestModels
{
    public class DeleteUserRequestModel
    {
        [Required]
        public string Address { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
