namespace ClassLibrary
{
    using System;
    using System.Collections.Generic;

    [Serializable]
    public partial class QuizCaetgory
    {
        public QuizCaetgory()
        {
            this.QuizToCategory = new HashSet<QuizToCategory>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    
        public virtual ICollection<QuizToCategory> QuizToCategory { get; set; }
    }
}
