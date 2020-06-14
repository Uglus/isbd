namespace ClassLibrary
{
    using System;
    using System.Collections.Generic;

    [Serializable]
    public partial class UserToSession
    {
        public UserToSession()
        {
            this.UserAnswerSequence = new HashSet<UserAnswerSequence>();
            this.UserAnswerBool = new HashSet<UserAnswerBool>();
            this.UserAnswerDefault = new HashSet<UserAnswerDefault>();
        }
    
        public int Id { get; set; }
        public int SessionId { get; set; }
        public int UserId { get; set; }
    
        public virtual Session Session { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<UserAnswerSequence> UserAnswerSequence { get; set; }
        public virtual ICollection<UserAnswerBool> UserAnswerBool { get; set; }
        public virtual ICollection<UserAnswerDefault> UserAnswerDefault { get; set; }
    }
}
