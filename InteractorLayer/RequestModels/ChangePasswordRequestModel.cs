using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InteractorLayer.RequestModels
{
    public class ChangePasswordRequestModel
    {
        [Required]
        public string Address { get; set; }
        [Required]
        public string OldPassword { get; set; }
        [Required]
        public string NewPassword { get; set; }
    }
}
