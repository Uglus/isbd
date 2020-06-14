namespace ClassLibrary
{
    using System;
    using System.Collections.Generic;

    [Serializable]
    public partial class UserRole
    {
        public UserRole()
        {
            this.User = new HashSet<User>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<User> User { get; set; }
    }
}
