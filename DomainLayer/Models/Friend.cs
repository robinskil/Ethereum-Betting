using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer.Models
{
    public class Friend
    {
        public string UserIdAddress { get; set; }
        public string UserFriendAddress { get; set; }
        public User User { get; set; }
        public User UserFriend { get; set; }
    }
}
