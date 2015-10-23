using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DAO;
using DTO;

namespace BUS
{
    public class Khachhang_BUS
    {
        public static DataTable Loadds()
        {
            return Khachang_DAO.Loadds();
        }
        public static DataTable Dangnhap(string account, string password)
        {
            return Khachang_DAO.Dangnhap(account, password);
        }
        public static DataTable Kiemtra_Dangki(string account, string username)
        {
            return Khachang_DAO.Kiemtra_dangki(account, username);
        }
        public static void Add_kh(KhachHang_DTO user)
        {
            Khachang_DAO.Add_kh(user);
        }
        public static DataTable Loadds_FRIEND(string _userNameTemp)
        {
            return FRIEND.Loadds(_userNameTemp);
        }
    }
}
