using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiNhanSu.DUNGCHUNG
{
    internal class HeThong
    {
        public static int ID = 0;
        public static string TenDangNhap = "";
        public static string MatKhau = "";
        public static string QuyenHan = "";

        public static string MD5(string s)
        {
            var provider = System.Security.Cryptography.MD5.Create();
            StringBuilder builder = new StringBuilder();

            foreach (byte b in provider.ComputeHash(Encoding.UTF8.GetBytes(s)))
                builder.Append(b.ToString("x2").ToLower());

            return builder.ToString();
        }
    }
}

