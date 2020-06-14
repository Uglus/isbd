namespace ClassLibrary
{
    using System;
    using System.Collections.Generic;

    [Serializable]
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
