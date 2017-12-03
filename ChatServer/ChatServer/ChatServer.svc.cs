using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using ChatLibrary;
using System.Timers;


namespace ChatServer
{
    [ServiceBehavior(IncludeExceptionDetailInFaults=true)]
    public class ChatServer : IChatServer
    {
        public static List<Message> History = new List<Message>();
        public static HashSet<User> UserList = new HashSet<User>();
        public static Timer Timer = new Timer(){Enabled = true, Interval = 5000};
        
        public ChatServer()
        {
            Timer.Elapsed += TimerTick;
        }
        public void GetMessage(Message message)
        {
            Message newmsg = new Message(message.Author, message.Text, message.Destination);
            History.Add(newmsg);
        }
        public bool RegisterUser(string login, string password)
        {
            bool correct = false;
            bool noSuchUserAtAll = true;
            foreach (User user in UserList)
            {
                if (user.Login == login)
                {
                    noSuchUserAtAll = false;
                    if (user.IsOnline == false)
                    {
                        if (user.CheckPassword(password))
                        {
                            correct = true;
                            user.IsOnline = true;
                            break;
                        }
                    }
                }
            }
            if (correct)
            {
                return true;
            }
            if (noSuchUserAtAll)
            {
                UserList.Add(new User(login, password));
                return true;
            }
            return false;
        }
        public List<Message> GetUpdate(int userHistoryLenght, string userLogin)
        { 
            List<Message> newMessages = new List<Message>();
            List<Message> newHistory = (from m in History where (m.Destination == null || m.Author.Login == userLogin || m.Destination.Login == userLogin) select m).ToList();
            if (newHistory.Count > userHistoryLenght)
            {
                for (int i = userHistoryLenght; i < newHistory.Count; i++)
                {
                    newMessages.Add(newHistory[i]);
                }
            }
            foreach (User user in UserList)
                if (user.Login == userLogin)
                {
                    user.UserRespond = true;
                    user.IsOnline = true;
                    break;
                }
            return newMessages;
        }
        public HashSet<User> UpdateUsers()
        {
            return UserList;
        }
        public void LogOut(User usr)
        {
            foreach (User user in UserList)
            {
                if (user.Login == usr.Login)
                {
                    user.IsOnline = false;
                    break;
                }
            }
        }

        private void TimerTick(object sender, ElapsedEventArgs e)
        {
            CheckOnlineUsers();
        }
        private void CheckOnlineUsers()
        {
            foreach (User user in UserList)
            {
                if (user.UserRespond == false)
                {
                    user.IsOnline = false;
                }
                user.UserRespond = false;
            }
        }
    }
}
