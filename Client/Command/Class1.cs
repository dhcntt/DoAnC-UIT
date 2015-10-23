using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Enum;
using System.Drawing;
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
        // 2 contructor
        public Command(CommandType_ type, string metaData)
        {
            this._cmdType = type;
            this._commandBody = metaData;
            fontsyle = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular);
        }
        public Command(CommandType_ type, string metaData, Font fonttemp)
        {
            this._cmdType = type;
            this._commandBody = metaData;
            this.fontsyle = fonttemp;
        }
    }
}
