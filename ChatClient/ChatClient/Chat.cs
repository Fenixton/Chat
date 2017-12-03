using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ChatClient.ChatServer;
using ChatLibrary;

namespace ChatClient
{
    public partial class Chat : Form
    {
        ChatServerClient client = new ChatServerClient();
        User me = new User(null, null);
        bool _isLoggedIn = false;
        List<ChatLibrary.Message> chatHistory = new List<ChatLibrary.Message>();
        HashSet<User> allUsers = new HashSet<User>();
        HashSet<String> _ignoredUsers = new HashSet<String>();
        string _nameUserPrivateDialog = string.Empty;
        
        public Chat()
        {
            InitializeComponent();
            messageHistory.Items.Add("Добро пожаловать в чат!");
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            ChatLibrary.Message msg = new ChatLibrary.Message(me, textMessage.Text);

            if (_nameUserPrivateDialog != string.Empty)
            {
                string textWithoutDestination = textMessage.Text.Substring(_nameUserPrivateDialog.Length + 1);
                msg = new ChatLibrary.Message(me, textWithoutDestination, new User(_nameUserPrivateDialog, null));
                client.GetMessage(msg);
                //chatHistory.Add((ChatLibrary.Message) msg);  // Ликвидация задержки для собственного сообщения
                //messageHistory.Items.Add(msg);
                UpdateChat();
                textMessage.Text = string.Format("/{0} ", _nameUserPrivateDialog);
                textMessage.SelectionStart = _nameUserPrivateDialog.Length + 2;
            }
            else
            {
                client.GetMessage(msg);
                //chatHistory.Add((ChatLibrary.Message) msg);  // Ликвидация задержки для собственного сообщения
                //messageHistory.Items.Add(msg);
                UpdateChat();
                textMessage.Clear();
            }
        }       

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            client.LogOut(me);
            me = new User(null, null);
            _isLoggedIn = false;
            _ignoredUsers = new HashSet<string>();
            _nameUserPrivateDialog = string.Empty;
            passwordField.Text = string.Empty;
            textMessage.Text = String.Empty;
            _nameUserPrivateDialog = string.Empty;
            labelRegister.Visible = true;
            loginField.Visible = true;
            btnRegister.Visible = true;
            labelPassword.Visible = true;
            passwordField.Visible = true;
            btnExit.Visible = true;
            textMessage.Visible = false;
            buttonSend.Visible = false;
            btnLogOut.Visible = false;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            User newUser = new User(loginField.Text, passwordField.Text);
            bool registrationIsSuccessful = client.RegisterUser(newUser.Login, passwordField.Text);
            if (registrationIsSuccessful)
            {
                me = new User(loginField.Text, passwordField.Text);
                _isLoggedIn = true;
                allUsers.Add(me);
                userList.Items.Add(me);
                labelRegister.Visible = false;
                loginField.Visible = false;
                btnRegister.Visible = false;
                labelPassword.Visible = false;
                passwordField.Visible = false;
                btnExit.Visible = false;
                textMessage.Visible = true;
                buttonSend.Visible = true;
                btnLogOut.Visible = true;
            }
            else
            {
                _isLoggedIn = false;
                MessageBox.Show("Ошибка авторизации!");
            }
        }
        private void userUpdateTimer_Tick(object sender, EventArgs e)
        {
            UpdateUserList();
        }
        private void chatUpdateTimer_Tick(object sender, EventArgs e)
        {
            UpdateChat();
        }
        private void UpdateChat()
        {
            List<ChatLibrary.Message>updatedList = client.GetUpdate(chatHistory.Count, me.Login).ToList();
            foreach (var msg in updatedList)
            {
                chatHistory.Add((ChatLibrary.Message) msg);
                if (!_ignoredUsers.Contains(msg.Author.Login))
                {
                    messageHistory.Items.Add(msg);
                }
            }
            if (updatedList.Count != 0)  // Прокрутка вниз
            {
                messageHistory.SelectedIndex = messageHistory.Items.Count - 1;
                messageHistory.SelectedIndex = -1;
            }
           
        }
        private void UpdateUserList()
        {
            List<User> newUserList = client.UpdateUsers().ToList();
            newUserList = (from User user in newUserList orderby user.IsOnline select user).Reverse().ToList();
            if (newUserList.Count != allUsers.Count)
            {
                
                userList.Items.Clear();
                allUsers.Clear();
                foreach (User user in newUserList)
                {
                    allUsers.Add(user);
                    userList.Items.Add(user);
                }
            }
            else
            {
                foreach (User user1 in newUserList)
                {
                    bool contains = false;
                    foreach (User user2 in allUsers)
                    {
                        if ((user1.Login == user2.Login) && (user1.IsOnline == user2.IsOnline))
                        {
                            contains = true;
                            break;
                        }
                    }
                    if (!contains)
                    {
                        userList.Items.Clear();
                        allUsers.Clear();
                        foreach (User user in newUserList)
                        {
                            allUsers.Add(user);
                            userList.Items.Add(user);
                        }
                        break;
                    }
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void loginField_TextChanged(object sender, EventArgs e)
        {
            LogPassCheckFields();
        }

        private void passwordField_TextChanged(object sender, EventArgs e)
        {
            LogPassCheckFields();
        }

        private void LogPassCheckFields()
        {
            if (loginField.Text == String.Empty || passwordField.Text == String.Empty)
                btnRegister.Enabled = false;
            else
                btnRegister.Enabled = true;
        }

        private void textMessage_TextChanged(object sender, EventArgs e)
        {
            MessageCheckField();
        }

        private void MessageCheckField()
        {
            if (_nameUserPrivateDialog == string.Empty)
            {
                if (textMessage.Text == string.Empty)
                    buttonSend.Enabled = false;
                else
                    buttonSend.Enabled = true;
            }
            else
            {
                string destination = string.Format("/{0} ", _nameUserPrivateDialog);
                if (textMessage.Text.Length <= destination.Length)
                    buttonSend.Enabled = false;
                else
                    buttonSend.Enabled = true;
                if (textMessage.Text.Length < destination.Length || textMessage.Text.Substring(0, destination.Length) != string.Format("/{0} ", _nameUserPrivateDialog))
                { 
                    _nameUserPrivateDialog = string.Empty;
                    buttonSend.Enabled = false;
                }
            }
        }

        

        private void textMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && buttonSend.Enabled)
                buttonSend_Click(textMessage, new EventArgs());
        }

        private void loginField_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && btnRegister.Enabled)
                btnRegister_Click(textMessage, new EventArgs());
        }

        private void passwordField_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && btnRegister.Enabled)
                btnRegister_Click(textMessage, new EventArgs());            
        }

        private void userList_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int y = e.Y / userList.ItemHeight;

                if (y < userList.Items.Count)
                    userList.SelectedIndex = userList.TopIndex + y;                

                if (_isLoggedIn && userList.SelectedIndex != -1 && ((User) userList.Items[userList.SelectedIndex]).Login != me.Login)
                {
                    if (_ignoredUsers.Contains(((User) userList.Items[userList.SelectedIndex]).Login))
                    {
                        добавитьВИгнорToolStripMenuItem1.Text = "Убрать из игнора";
                    }
                    else
                    {
                        добавитьВИгнорToolStripMenuItem1.Text = "Добавить в игнор";
                    }
                    приватToolStripMenuItem1.Enabled = true;
                    добавитьВИгнорToolStripMenuItem1.Enabled = true;

                }
                else
                {
                    приватToolStripMenuItem1.Enabled = false;
                    добавитьВИгнорToolStripMenuItem1.Enabled = false;
                }
            }
        }

        
        private void IgnoreUser(User user)
        {
            _ignoredUsers.Add(user.Login);
        }

        private void ForgiveUser(User user)
        {
            _ignoredUsers.Remove(user.Login);
        }

        private void приватToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (userList.Items[userList.SelectedIndex] is User)
                Private((userList.Items[userList.SelectedIndex] as User).Login);
        }

        private void Private(string login)
        {
            _nameUserPrivateDialog = login;
            textMessage.Text = string.Format("/{0} ", _nameUserPrivateDialog);
            textMessage.SelectionStart = _nameUserPrivateDialog.Length + 2;
        }

        private void добавитьВИгнорToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (userList.Items[userList.SelectedIndex] is User)
            {
                if (добавитьВИгнорToolStripMenuItem1.Text == "Добавить в игнор")
                    IgnoreUser(userList.Items[userList.SelectedIndex] as User);
                else
                    ForgiveUser(userList.Items[userList.SelectedIndex] as User);                
            }
        }

        
    }
}