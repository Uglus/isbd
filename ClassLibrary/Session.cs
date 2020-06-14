namespace ClassLibrary
{
    using System;
    using System.Collections.Generic;

    [Serializable]
    public partial class Session
    {
        public Session()
        {
            this.UserToSession = new HashSet<UserToSession>();
        }
    
        public int Id { get; set; }
        public string AccessCode { get; set; }
        public System.DateTime Date { get; set; }
        public int StatusId { get; set; }
        public int QuizId { get; set; }
    
        public virtual SessionStatus SessionStatus { get; set; }
        public virtual Quiz Quiz { get; set; }
        public virtual ICollection<UserToSession> UserToSession { get; set; }
    }
}
