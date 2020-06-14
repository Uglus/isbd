namespace ClassLibrary
{
    using System;
    using System.Collections.Generic;

    [Serializable]
    public partial class QuizStatus
    {
        public QuizStatus()
        {
            this.Quiz = new HashSet<Quiz>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<Quiz> Quiz { get; set; }
    }
}
