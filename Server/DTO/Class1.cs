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
}
