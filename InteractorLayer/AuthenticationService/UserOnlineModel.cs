using System;
using System.Collections.Generic;
using System.Text;

namespace InteractorLayer.AuthenticationService
{
    public class UserOnlineModel
    {
        public string Address { get; set; }
        public string Name { get; set; }
        public UserStatus UserStatus { get; set; }
        public IList<string> Friends { get; set; }
    }
}
