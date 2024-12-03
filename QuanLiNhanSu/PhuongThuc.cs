using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiNhanSu
{
    public class PhuongThuc
    {
        public SqlConnection KetNoi()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=LAPTOP-4M6GTD3M;Initial Catalog=QL_NhanSu;Integrated Security=True";
            return conn;
        }
        public static SqlConnection MoKetNoi()
        {
            string s = @"Data Source=LAPTOP-4M6GTD3M;Initial Catalog=QL_NhanSu;Integrated Security=True";
            SqlConnection KetNoi = new SqlConnection(s);
            KetNoi.Open();
            return KetNoi;
        }

        public static void DongKetNoi(SqlConnection KetNoi)
        {
            KetNoi.Close();
        }


        // Thực hiện truy vấn trả về bảng dữ liệu
        public static DataTable TruyVanLayDuLieu(string sTruyVan, SqlConnection KetNoi)
        {
            SqlDataAdapter da = new SqlDataAdapter(sTruyVan, KetNoi);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        // Thực hiện truy vấn không trả về dữ liệu
        public static bool TruyVanKhongLayDuLieu(string sTruyVan, SqlConnection KetNoi)
        {
            try
            {
                SqlCommand cm = new SqlCommand(sTruyVan, KetNoi);
                cm.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        internal class CSDL_BUS
        {
         
            static SqlConnection con;
            public static bool SaoLuu(string sDuongDan)
            {

                string sTen = string.Format(@"\\QL_NhanSu(" + DateTime.Now.Day.ToString() + "_" +
                            DateTime.Now.Month.ToString() + "_" +
                            DateTime.Now.Year.ToString() + "_" +
                            DateTime.Now.Hour.ToString() + "_" +
                            DateTime.Now.Minute.ToString() + ").bak");
                string sql = "BACKUP DATABASE QL_NhanSu TO DISK = N'" + sDuongDan + sTen + "'";
          //  con = DataProvider.MoKetNoi();

                bool kq = DataProvider.TruyVanKhongLayDuLieu(sql, con);
                return kq;
            }
            public static bool PhucHoi(string sDuongDan)
            {

                string sql = string.Format(@"USE Master alter database QL_NhanSu set offline with 
rollback immediate RESTORE DATABASE QL_NhanSu FROM DISK = N'{0}' alter database QL_NhanSu set online", sDuongDan);

               // con = DataProvider.MoKetNoi();
                bool kq = DataProvider.TruyVanKhongLayDuLieu(sql, con);
                return kq;
            }
        }


    }
}
