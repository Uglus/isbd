namespace ClassLibrary
{
    using System;
    using System.Collections.Generic;

    [Serializable]
    public partial class Achievement
    {
        public Achievement()
        {
            this.UserToAchievement = new HashSet<UserToAchievement>();
        }
    
        public int Id { get; set; }
        public string Title { get; set; }
        public string Decription { get; set; }
        public string Icon { get; set; }
    
        public virtual ICollection<UserToAchievement> UserToAchievement { get; set; }
    }
}
