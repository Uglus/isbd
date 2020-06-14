namespace ClassLibrary
{
    using System;
    using System.Collections.Generic;

    [Serializable]
    public partial class ChatMessage
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public System.DateTime Date { get; set; }
        public int ChatId { get; set; }
        public int UserId { get; set; }
    
        public virtual Chat Chat { get; set; }
        public virtual User User { get; set; }
    }
}
