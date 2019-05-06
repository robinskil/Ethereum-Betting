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
        public string Password { get; set; }
        public string GeneratedName { get; set; }
        public IList<UserAchievement> Achievements { get; set; }
        public IList<Bet> OwnedBets { get; set; }
        public IList<Friend> Friends { get; set; }
        public IList<FriendRequest> FriendRequests { get; set; }
    }
}
