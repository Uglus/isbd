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
    
    public partial class UserFriends
    {
        public int Id { get; set; }
        public bool Activated { get; set; }
        public System.DateTime Date { get; set; }
        public int UserIdFrom { get; set; }
        public int UserIdTo { get; set; }
    
        public virtual User UserFrom { get; set; }
        public virtual User UserTo { get; set; }
    }
}
