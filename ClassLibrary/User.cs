using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    [Serializable]
    public partial class User
    {
        public User()
        {
            this.UserFriendsFrom = new HashSet<UserFriends>();
            this.UserFriendsTo = new HashSet<UserFriends>();
            this.UserToChat = new HashSet<UserToChat>();
            this.ChatMessage = new HashSet<ChatMessage>();
            this.QuizApproved = new HashSet<QuizApproved>();
            this.UserQuizResp = new HashSet<UserQuizResp>();
            this.Quiz = new HashSet<Quiz>();
            this.UserToAchievement = new HashSet<UserToAchievement>();
            this.UserToSession = new HashSet<UserToSession>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public System.DateTime RegistrationDate { get; set; }
        public string ActivateLink { get; set; }
        public int RoleId { get; set; }
        public int StatusId { get; set; }

        public string FuncName { get; set; }//Для визначення сервером, яку функцію юзати

        public virtual UserRole Role { get; set; }
        public virtual UserStatus UserStatus { get; set; }
        public virtual ICollection<UserFriends> UserFriendsFrom { get; set; }
        public virtual ICollection<UserFriends> UserFriendsTo { get; set; }
        public virtual ICollection<UserToChat> UserToChat { get; set; }
        public virtual ICollection<ChatMessage> ChatMessage { get; set; }
        public virtual ICollection<QuizApproved> QuizApproved { get; set; }
        public virtual ICollection<UserQuizResp> UserQuizResp { get; set; }
        public virtual ICollection<Quiz> Quiz { get; set; }
        public virtual ICollection<UserToAchievement> UserToAchievement { get; set; }
        public virtual ICollection<UserToSession> UserToSession { get; set; }
    }
}
