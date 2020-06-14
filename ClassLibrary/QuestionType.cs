namespace ClassLibrary
{
    using System;
    using System.Collections.Generic;

    [Serializable]
    public partial class QuestionType
    {
        public QuestionType()
        {
            this.Question = new HashSet<Question>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<Question> Question { get; set; }
    }
}
