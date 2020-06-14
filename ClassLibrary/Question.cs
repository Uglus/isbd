namespace ClassLibrary
{
    using System;
    using System.Collections.Generic;

    [Serializable]
    public partial class Question
    {
        public Question()
        {
            this.SequenceTrue = new HashSet<SequenceTrue>();
            this.BoolTrue = new HashSet<BoolTrue>();
            this.DefaultTrue = new HashSet<DefaultTrue>();
        }
    
        public int Id { get; set; }
        public string Text { get; set; }
        public string Points { get; set; }
        public string Image { get; set; }
        public int TypeId { get; set; }
        public int QuizId { get; set; }
    
        public virtual QuestionType QuestionType { get; set; }
        public virtual Quiz Quiz { get; set; }
        public virtual ICollection<SequenceTrue> SequenceTrue { get; set; }
        public virtual ICollection<BoolTrue> BoolTrue { get; set; }
        public virtual ICollection<DefaultTrue> DefaultTrue { get; set; }
    }
}
