﻿using System;
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
        public static void Change_information(string username, string email, byte[] image, byte[] status)
        {
            Khachang_DAO.Change_information(username, email, image, status);
        }
        public static DataTable Loadds_FRIEND(string _userNameTemp)
        {
            return FRIEND.Loadds(_userNameTemp);
        }
        public static DataTable FindFriend(string _userNameTemp)
        {
            return FRIEND.FindFriend(_userNameTemp);
        }
        public static void Add_Friend(string userPrimary,string userReference)
        {
            FRIEND.Add_Friend(userPrimary, userReference);
        }
        public static DataTable LoadNotice(string _userNameTemp)
        {
            return NOTICE.Load_notice(_userNameTemp);
        }
        public static DataTable AddNotice(NOTICE_DTO notice)
        {
            return NOTICE.Add_notice(notice);
        }
        public static void DeleteNotice(string _userPrimary,string _userReference)
        {
            NOTICE.Delete_notice(_userPrimary, _userReference);
        }
        public static void Save_message(string _userPrimaryTemp, string _userReference, byte[] _content, byte[] _font, string _time)
        {
            MESSAGETEXT.Save_message(_userPrimaryTemp, _userReference, _content, _font, _time);
        }
        public static DataTable Load_message(int count, string userPrimary,string userReferences)
        {
            return MESSAGETEXT.Load_message(count,userPrimary,userReferences);
        }
    }
}
