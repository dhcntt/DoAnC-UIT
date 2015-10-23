using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enum
{
<<<<<<< HEAD

    //Các kiểu tin nhắn sẽ nhận và gởi để server hoặc client có thể nhận biết
    public enum CommandType_
    {
        Message,//kiểu tin nhắn 
        ClientList,//list danh sách bạn
        NameExists,//đã kết nối
        Login,//kiểu đăng nhập
        LoginSuccess,//đăng nhập thành công
        Logout,//đăng xuất
        Failure,//đăng nhập thất bại
        Register,//đăng kí
        RegisterFailure,//đăng kí thất bại
        RegisterSuccess,//đang kí thành công
=======
    public enum CommandType_
    {
        Message,
        ClientList,
        NameExists,
        Login,
        LoginSuccess,
        Logout,
        Failure,
        Register,
        RegisterFailure,
        RegisterSuccess,
>>>>>>> f9323e39cdf9d6f6df6f0bd551b0690ce32f9358
    }
}
