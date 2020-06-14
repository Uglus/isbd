namespace ClassLibrary
{
    using System;
    using System.Collections.Generic;

    [Serializable]
    public partial class Quiz
    {
        public Quiz()
        {
            this.QuizApproved = new HashSet<QuizApproved>();
            this.UserQuizResp = new HashSet<UserQuizResp>();
            this.QuizToCategory = new HashSet<QuizToCategory>();
            this.Question = new HashSet<Question>();
            this.Session = new HashSet<Session>();
        }
    
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public System.DateTime Date { get; set; }
        public int StatusId { get; set; }
        public int UserId { get; set; }
    
        public virtual ICollection<QuizApproved> QuizApproved { get; set; }
        public virtual ICollection<UserQuizResp> UserQuizResp { get; set; }
        public virtual User User { get; set; }
        public virtual QuizStatus QuizStatus { get; set; }
        public virtual ICollection<QuizToCategory> QuizToCategory { get; set; }
        public virtual ICollection<Question> Question { get; set; }
        public virtual ICollection<Session> Session { get; set; }
    }
}
