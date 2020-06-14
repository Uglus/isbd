namespace ClassLibrary
{
    using System;
    using System.Collections.Generic;

    [Serializable]
    public partial class UserQuizResp
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int QuizId { get; set; }
        public string Rate { get; set; }
        public bool Favourite { get; set; }
    
        public virtual Quiz Quiz { get; set; }
        public virtual User User { get; set; }
    }
}
