using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Enum;
using System.Drawing;
using System.Data;
namespace _Command
{
    //đây là 1 toàn bộ nội dung của 1 tin nhắn được gửi đi hoặc nhận lại  giữa client -server
    public class Command
    {
        private CommandType_ _cmdType;//loại Command được gửi
        public CommandType_ CommandType
        {
            get { return _cmdType; }
            set { _cmdType = value; }
        }
        private string _commandBody;//nội dung cần gửi
        public string commandBody
        {
            get { return _commandBody; }
            set { _commandBody = value; }
        }
        private Font fontsyle;

        public Font Fontsyle
        {
            get { return fontsyle; }
            set { fontsyle = value; }
        }
        private string _username;

        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }
        private string _account;

        public string Account
        {
            get { return _account; }
            set { _account = value; }
        }
        private string _password;

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        private string _email;

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        private byte[] _image;

        public byte[] Image_
        {
            get { return _image; }
            set { _image = value; }
        }
        private string _status;

        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }




        private string _userPrimary;

        public string UserPrimary
        {
            get { return _userPrimary; }
            set { _userPrimary = value; }
        }
        private string _userReference;

        public string UserReference
        {
            get { return _userReference; }
            set { _userReference = value; }
        }
        private string _type;

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }
        private string _content;

        public string Content
        {
            get { return _content; }
            set { _content = value; }
        }
        private string _time;

        public string Time
        {
            get { return _time; }
            set { _time = value; }
        }
        private DataTable _dt;

        public DataTable Dt
        {
            get { return _dt; }
            set { _dt = value; }
        }
        //contructor
        public int count;
        public Command(CommandType_ type)
        {
            _cmdType = type;
        }
        public Command(CommandType_ type, string metaData,int a=0)
        {
            this._cmdType = type;
            this._commandBody = metaData;
            count = a;
            fontsyle = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular);
        }
        public Command(CommandType_ type, string metaData, Font fonttemp)
        {
            this._cmdType = type;
            this._commandBody = metaData;
            this.fontsyle = fonttemp;
        }
        public Command(CommandType_ type, string _UserPrimary, string _UserReference, string _Type="", string _Content=" ", string _Time=" ")
        {
            this._cmdType = type;
            _userPrimary = _UserPrimary;
            _userReference = _UserReference;
            _type = _Type;
            _content = _Content;
            _time = _Time;
        }
        public Command(CommandType_ type, string username)
        {
            _cmdType = type;
            _username = username;
        }
        public Command(CommandType_ type, string username, string metaData, Font fonttemp)
        {
            _cmdType = type;
            _username = username;
            _commandBody = metaData;
            fontsyle = fonttemp;
        }
        public Command(CommandType_ type, string username, string email, byte[] image, string status="")
        {
            _cmdType = type;
            _username = username;
            _email = email;
            _image = image;
            _status = status;
        }
         public Command(CommandType_ type, DataTable dt)
         {
             _cmdType = type;
             _dt = dt;
         }
        public Command(CommandType_ type, string username, byte[] image, DataTable dt)
        {
            _cmdType = type;
            _username = username;
            _image = image;
            _dt = dt;
        }
    }
}
