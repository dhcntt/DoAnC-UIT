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
        private DataTable _dt;

        public DataTable Dt
        {
            get { return _dt; }
            set { _dt = value; }
        } 
        //contructor
        public Command(CommandType_ type)
        {
            _cmdType = type;
        }
        public Command(CommandType_ type, string metaData)
        {
            this._cmdType = type;
             this._commandBody = metaData;
             fontsyle = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular);
        }
        public Command(CommandType_ type, string metaData,Font fonttemp)
        {
            this._cmdType = type;
            this._commandBody = metaData;
            this.fontsyle = fonttemp;
        }
        public Command(CommandType_ type,string username,int temp)
        {
            _cmdType = type;
            _username = username;
        }
        public Command(CommandType_ type,string username,string metaData,Font fonttemp)
        {
            _cmdType = type;
            _username = username;
            _commandBody = metaData;
            fontsyle = fonttemp;
        }
        public Command(CommandType_ type,string username,byte[] image,DataTable dt)
        {
            _cmdType = type;
            _username = username;
            _image = image;
            _dt = dt;
        }
    }
}
