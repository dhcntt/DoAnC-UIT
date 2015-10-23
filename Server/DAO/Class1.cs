using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DTO;

namespace DAO
{
    public class SQLConnectionData
    {
        public static SqlConnection KetnoiCSDL()
        {
            SqlConnection con = new SqlConnection("Data Source=WINDOW;Initial Catalog=Server;Integrated Security=True");
            return con;
        }
    }
    public class Khachang_DAO
    {
        public static DataTable Loadds()
        {
            SqlConnection con = SQLConnectionData.KetnoiCSDL();
            SqlCommand cmd = new SqlCommand("Loadds", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtb = new DataTable();
            da.Fill(dtb);
            return dtb;
        }
        public static DataTable Dangnhap(string account,string password)
        {
            SqlConnection con = SQLConnectionData.KetnoiCSDL();
            SqlCommand cmd = new SqlCommand("dangnhap", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@account", SqlDbType.NChar, 30);
            cmd.Parameters.Add("@password", SqlDbType.NChar, 30);
            cmd.Parameters["@account"].Value = account;
            cmd.Parameters["@password"].Value = password;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtb = new DataTable();
            da.Fill(dtb);
            return dtb;
        }
        public static DataTable Kiemtra_dangki(string account,string username)
        {
            SqlConnection con = SQLConnectionData.KetnoiCSDL();
            SqlCommand cmd = new SqlCommand("kiemtra_dangki", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@account", SqlDbType.NChar, 30);
            cmd.Parameters.Add("@username", SqlDbType.NChar, 30);
            cmd.Parameters["@account"].Value = account;
            cmd.Parameters["@username"].Value = username;
            SqlDataAdapter ds = new SqlDataAdapter(cmd);
            DataTable dtb = new DataTable();
            ds.Fill(dtb);
            return dtb;
        }
        public static void Add_kh(KhachHang_DTO user)
        {
            SqlConnection con = SQLConnectionData.KetnoiCSDL();
            SqlCommand cmd = new SqlCommand("add_kh", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@account", SqlDbType.NChar, 30);
            cmd.Parameters.Add("@email", SqlDbType.NChar, 30);
            cmd.Parameters.Add("@password", SqlDbType.NChar, 30);
            cmd.Parameters.Add("@username", SqlDbType.NChar, 30);
            cmd.Parameters.Add("@image", SqlDbType.Image);
            cmd.Parameters["@account"].Value = user.Account;
            cmd.Parameters["@username"].Value = user.Username;
            cmd.Parameters["@password"].Value = user.Password;
            cmd.Parameters["@email"].Value = user.Email;
            cmd.Parameters["@image"].Value = user.Image;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
    public class FRIEND
    {
        public static DataTable Loadds(string _userPrimaryTemp)
        {
            SqlConnection con = SQLConnectionData.KetnoiCSDL();
            SqlCommand cmd = new SqlCommand("Loadds_friend", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@UserPrimary", SqlDbType.NChar, 30);
            cmd.Parameters["@UserPrimary"].Value = _userPrimaryTemp;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
