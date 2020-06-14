namespace ClassLibrary
{
    using System;
    using System.Collections.Generic;

    [Serializable]
    public partial class DefaultTrue
    {
        public DefaultTrue()
        {
            this.UserAnswerDefault = new HashSet<UserAnswerDefault>();
        }
    
        public int Id { get; set; }
        public string Answer { get; set; }
        public string Variant1 { get; set; }
        public string Variant2 { get; set; }
        public string Variant3 { get; set; }
        public string Variant4 { get; set; }
        public int QuestionId { get; set; }
    
        public virtual Question Question { get; set; }
        public virtual ICollection<UserAnswerDefault> UserAnswerDefault { get; set; }
    }
}
