namespace ClassLibrary
{
    using System;
    using System.Collections.Generic;

    [Serializable]
    public partial class UserAnswerBool
    {
        public int Id { get; set; }
        public bool Answer { get; set; }
        public int BoolId { get; set; }
        public int UserSessionId { get; set; }
    
        public virtual BoolTrue BoolTrue { get; set; }
        public virtual UserToSession UserToSession { get; set; }
    }
}
