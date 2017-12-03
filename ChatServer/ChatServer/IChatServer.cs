using System.Collections.Generic;
using System.ServiceModel;
using ChatLibrary;

namespace ChatServer
{
    [ServiceContract]
    public interface IChatServer
    {

        [OperationContract]
        void GetMessage(Message message);
        [OperationContract]
        bool RegisterUser(string login, string password);
        [OperationContract]
        List<Message> GetUpdate(int userHistoryLength, string userLogin);
        [OperationContract]
        HashSet<User> UpdateUsers();
        [OperationContract]
        void LogOut(User usr);
    }
    

    

}
