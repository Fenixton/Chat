using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace ChatLibrary
{
    [DataContract, Serializable]
    public class Message
    {
        [DataMember]
        public User Author { get; set; }
        [DataMember]
        public string Text { get; set; }
        [DataMember]
        public User Destination { get; set; }
        [DataMember]
        public string Time { get; set; }

        public override string ToString()
        {
            if (this.Destination == null)
                return string.Format("({0}) {1}: {2}", Time, Author.Login, Text);
            else
                return string.Format("({0}) {1} - {2}: {3}", Time, Author.Login, Destination.Login, Text);
        }

        public Message() { }

        public Message(User usr, string text, User destinationUser = null)
        {
            Author = usr;
            Text = text;
            Destination = destinationUser;
            Time = DateTime.Now.ToShortTimeString();
        }
    }

    [DataContract, Serializable]
    public class User
    {
        [DataMember]
        public string Login { get; set; }
        [DataMember]
        public bool UserRespond { get; set; }
        [DataMember]
        public bool IsOnline = true;
        private string _password;
        public User() { }
        public User(string name, string password)
        {
            Login = name;
            _password = password;
            UserRespond = true;
            IsOnline = true;
        }
        public override string ToString()
        {
            if (IsOnline == true)
                return string.Format("{0} (Online)", Login);
            else
                return string.Format("{0}", Login);
        }
        public bool Equals(User user)
        {
            return this.Login.Equals(user.Login);
        }
        public bool CheckPassword(string pass)
        {
            if (pass == _password)
                return true;
            else
                return false;
        }
        
    }
}
