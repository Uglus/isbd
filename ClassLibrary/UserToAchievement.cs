namespace ClassLibrary
{
    using System;
    using System.Collections.Generic;

    [Serializable]
    public partial class UserToAchievement
    {
        public int Id { get; set; }
        public int AchievementId { get; set; }
        public int UserId { get; set; }
    
        public virtual Achievement Achievement { get; set; }
        public virtual User User { get; set; }
    }
}
