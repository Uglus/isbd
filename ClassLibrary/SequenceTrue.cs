namespace ClassLibrary
{
    using System;
    using System.Collections.Generic;

    [Serializable]
    public partial class SequenceTrue
    {
        public SequenceTrue()
        {
            this.UserAnswerSequence = new HashSet<UserAnswerSequence>();
        }
    
        public int Id { get; set; }
        public string Answer1 { get; set; }
        public string Answer2 { get; set; }
        public string Answer3 { get; set; }
        public string Answer4 { get; set; }
        public int QuestionId { get; set; }
    
        public virtual Question Question { get; set; }
        public virtual ICollection<UserAnswerSequence> UserAnswerSequence { get; set; }
    }
}
