using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer.Models
{
    public sealed class UserAchievement
    {
        public Guid UserId { get; set; }
        public Guid AchievementId { get; set; }
        public User User { get; set; }
        public Achievement Achievement { get; set; }
    }
}
