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
    
    public partial class BoolTrue
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BoolTrue()
        {
            this.UserAnswerBool = new HashSet<UserAnswerBool>();
        }
    
        public int Id { get; set; }
        public bool Answer { get; set; }
        public int QuestionId { get; set; }
    
        public virtual Question Question { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserAnswerBool> UserAnswerBool { get; set; }
    }
}