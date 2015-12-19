using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enum
{
    //Các kiểu tin nhắn sẽ nhận và gởi để server hoặc client có thể nhận biết
    public enum CommandType_
    {
        SaveMessage,
        LoadMessage,
        Message,//kiểu tin nhắn  cho Server
        MessageFriend,//gởi tin nhắn từ client đến client
        ClientList,//list danh sách bạn
        NameExists,//đã kết nối
        Login,//kiểu đăng nhập
        LoginSuccess,//đăng nhập thành công
        Logout,//đăng xuất
        Failure,//đăng nhập thất bại
        Register,//đăng kí
        RegisterFailure,//đăng kí thất bại
        RegisterSuccess,//đang kí thành công
        ChangeInformation,//thay đổi thông tin cá nhân
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
    }
}
