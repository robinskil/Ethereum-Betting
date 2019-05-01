using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer.Models
{
    public sealed class Achievement
    {
        public Guid AchievementId { get; set; }
        public string AchievementTitle { get; set; }
        public string AchievementDescription { get; set; }
        public int Points { get; set; }
    }
}
