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
        Message,//kiểu tin nhắn  cho Server
        MessageFriend,//gởi tin nhắn từ client đến client
=======


    //Các kiểu tin nhắn sẽ nhận và gởi để server hoặc client có thể nhận biết
    public enum CommandType_
    {
        Message,//kiểu tin nhắn 
>>>>>>> 254841375a781fe47587c9cc588e7372e753005e
        ClientList,//list danh sách bạn
        NameExists,//đã kết nối
        Login,//kiểu đăng nhập
        LoginSuccess,//đăng nhập thành công
        Logout,//đăng xuất
        Failure,//đăng nhập thất bại
        Register,//đăng kí
        RegisterFailure,//đăng kí thất bại
        RegisterSuccess,//đang kí thành công
<<<<<<< HEAD
        Status,//thong điệp trạng thái
        Online,//trạng thái online
        Offline,//trạng thái offline
        ListFriend,//Thong điệp danh sách bạn
        FindFriend,//Thông điệp tìm bạn
        AddFriend,
        AddFriendFailure,
        Found,//tìm thấy bạn cần tìm
        NotFound,//không tìm thấy bạn tìm để thêm bạn
        AddNotice,
        AddNoticeFailure,
        AddNoticeSuccess,
        LoadNotice,
        DeleteNotice,
        DeleteNoticeSuccess,
=======
>>>>>>> 254841375a781fe47587c9cc588e7372e753005e
    }
}
