namespace ClassLibrary
{
    using System;
    using System.Collections.Generic;

    [Serializable]
    public partial class QuizToCategory
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int QuizId { get; set; }
    
        public virtual QuizCaetgory QuizCaetgory { get; set; }
        public virtual Quiz Quiz { get; set; }
    }
}
