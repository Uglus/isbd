namespace ClassLibrary
{
    using System;
    using System.Collections.Generic;

    [Serializable]
    public partial class Chat
    {
        public Chat()
        {
            this.UserToChat = new HashSet<UserToChat>();
            this.ChatMessage = new HashSet<ChatMessage>();
        }
    
        public int Id { get; set; }
        public string Title { get; set; }
    
        public virtual ICollection<UserToChat> UserToChat { get; set; }
        public virtual ICollection<ChatMessage> ChatMessage { get; set; }
    }
}
