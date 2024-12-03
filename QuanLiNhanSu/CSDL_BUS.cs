using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiNhanSu
{
    internal class CSDL_BUS
    {
        static SqlConnection con;
        public static bool SaoLuu(string sDuongDan)
        {
            string sTen = string.Format(@"QL_NhanSu(" + DateTime.Now.Day.ToString() + "_" +
                        DateTime.Now.Month.ToString() + "_" +
                        DateTime.Now.Year.ToString() + "_" +
                        DateTime.Now.Hour.ToString() + "_" +
                        DateTime.Now.Minute.ToString() + ").bak");
            string sql = "BACKUP DATABASE QL_NhanSu TO DISK = N'" + sDuongDan + sTen + "'";
            con = DataProvider.MoKetNoi();

            bool kq = DataProvider.TruyVanKhongLayDuLieu(sql, con);
            return kq;
        }
        public static bool PhucHoi(string sDuongDan)
        {

            string sql = string.Format(@"USE Master alter database QL_NhanSu set offline with 
rollback immediate RESTORE DATABASE QL_NhanSu FROM DISK = N'{0}' alter database QuanLyDoanVien set online", sDuongDan);

            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sql, con);
            return kq;
        }

    }
}
