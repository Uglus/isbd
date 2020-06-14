namespace ClassLibrary
{
    using System;
    using System.Collections.Generic;

    [Serializable]
    public partial class BoolTrue
    {
        public BoolTrue()
        {
            this.UserAnswerBool = new HashSet<UserAnswerBool>();
        }
    
        public int Id { get; set; }
        public bool Answer { get; set; }
        public int QuestionId { get; set; }
    
        public virtual Question Question { get; set; }
        public virtual ICollection<UserAnswerBool> UserAnswerBool { get; set; }
    }
}
