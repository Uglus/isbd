//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Server.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserAnswerSequence
    {
        public int Id { get; set; }
        public string Answer1 { get; set; }
        public string Answer2 { get; set; }
        public string Answer3 { get; set; }
        public string Answer4 { get; set; }
        public int SequenceId { get; set; }
        public int UserSessionId { get; set; }
    
        public virtual SequenceTrue SequenceTrue { get; set; }
        public virtual UserToSession UserToSession { get; set; }
    }
}