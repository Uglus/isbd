namespace ClassLibrary
{
    using System;
    using System.Collections.Generic;

    [Serializable]
    public partial class UserAnswerSequence
    {
        public int Id { get; set; }
        public string Answer1 { get; set; }
        public string Answer2 { get; set; }
        public string Answer3 { get; set; }
        public string Answer4 { get; set; }
        public int SequenceId { get; set; }
        public int UserSessionId { get; set; }
    
        public virtual SequenceTrue SequenceTrue { get; set; }
        public virtual UserToSession UserToSession { get; set; }
    }
}
