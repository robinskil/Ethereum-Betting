using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer.Models
{
    public class FriendRequest
    {
        public Guid UserCallerId { get; set; }
        public Guid UserReceiverId { get; set; }
        public User UserCaller { get; set; }
        public User UserReceiver { get; set; }
    }
}
