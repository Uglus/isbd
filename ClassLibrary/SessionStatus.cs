namespace ClassLibrary
{
    using System;
    using System.Collections.Generic;

    [Serializable]
    public partial class SessionStatus
    {
        public SessionStatus()
        {
            this.Session = new HashSet<Session>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<Session> Session { get; set; }
    }
}
