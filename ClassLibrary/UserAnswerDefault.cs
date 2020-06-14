
namespace ClassLibrary
{
    using System;
    using System.Collections.Generic;

    [Serializable]
    public partial class UserAnswerDefault
    {
        public int Id { get; set; }
        public string Answer { get; set; }
        public int DefaultId { get; set; }
        public int UserSessionId { get; set; }
    
        public virtual DefaultTrue DefaultTrue { get; set; }
        public virtual UserToSession UserToSession { get; set; }
    }
}
