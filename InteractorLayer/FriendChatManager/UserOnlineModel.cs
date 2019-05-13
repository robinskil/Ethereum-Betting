using System;
using System.Collections.Generic;
using System.Text;

namespace InteractorLayer.FriendChatManager
{
    public class UserOnlineModel
    {
        public string Address { get; set; }
        public string Name { get; set; }
        public UserStatus UserStatus { get; set; }
        public HashSet<string> Friends { get; set; }
    }
}
