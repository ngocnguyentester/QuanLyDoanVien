using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiNhanSu
{
    internal class SqlManager
    {
        public static SqlConnection conn;
        public static DataSet dataSet = new DataSet("QL_NhanSu");
        /*public static SqlDataAdapter daHocSinh;
        public static SqlDataAdapter daLopHoc;
        public static SqlDataAdapter daMonHoc;
        public static SqlDataAdapter daBangDiem;*/
        public static SqlDataAdapter daTaiKhoan;

        public static void LoadConnection()
        {
            conn = new SqlConnection
            {
                ConnectionString = @"Data Source=LAPTOP-4M6GTD3M;Initial Catalog=QL_NhanSu;Integrated Security=True"
            };
            conn.Open();

           
        }

     /*   public static void ExecuteCommand(string cmd)
        {
            SqlCommand sqlcmd = new(cmd)
            {
                CommandType = CommandType.Text,
                Connection = conn
            };
            sqlcmd.ExecuteNonQuery();
        }*/
/*
       public static SqlDataReader ReadCommand(string cmd)
        {
            SqlCommand sqlcmd = new(cmd)
            {
                CommandType = CommandType.Text,
                Connection = conn
            };
            return sqlcmd.ExecuteReader();
        }*/
    }
}
