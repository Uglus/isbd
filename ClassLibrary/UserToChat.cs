namespace ClassLibrary
{
    using System;
    using System.Collections.Generic;

    [Serializable]
    public partial class UserToChat
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ChatId { get; set; }
    
        public virtual User User { get; set; }
        public virtual Chat Chat { get; set; }
    }
}
