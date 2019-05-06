using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer.Models
{
    public class Friend
    {
        public Guid UserId { get; set; }
        public Guid UserFriendId { get; set; }
        public User User { get; set; }
        public User UserFriend { get; set; }
    }
}
