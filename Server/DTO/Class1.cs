using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DTO
{
    public class KhachHang_DTO
    {
        private int _stt;

        public int Stt
        {
            get { return _stt; }
            set { _stt = value; }
        }
        private string _account;

        public string Account
        {
            get { return _account; }
            set { _account = value; }
        }
        private string _username;

        public string Username
        {
            get { return _username; }
            set { _username = value; }
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

        public byte[] Image
        {
            get { return _image; }
            set { _image = value; }
        }
        public KhachHang_DTO(string account,string password,string username,byte[] image=null,string email="")
        {
            _account = account;
            _password = password;
            _username = username;
            _email = email;
            _image = image;
        }
    }
<<<<<<< HEAD
    public class FRIEND_DTO
    {
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
        public FRIEND_DTO(string _UserPrimary,string _UserReference)
        {
            _userPrimary = _UserPrimary;
            _userReference = _UserReference;
        }
    }
    public class NOTICE_DTO
    {
        private int _stt;

        public int Stt
        {
            get { return _stt; }
            set { _stt = value; }
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
        public NOTICE_DTO(string _UserPrimary,string _UserReference,string _Type,string _Content,string _Time)
        {
            _userPrimary = _UserPrimary;
            _userReference = _UserReference;
            _type = _Type;
            _content = _Content;
            _time = _Time;
        }
    }
=======
>>>>>>> 254841375a781fe47587c9cc588e7372e753005e
}
