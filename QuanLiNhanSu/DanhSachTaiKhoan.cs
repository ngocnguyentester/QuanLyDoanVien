using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiNhanSu
{
    class DanhSachTaiKhoan
    {
        private List<TaiKhoan> list_account;

        public DanhSachTaiKhoan()
        {
            List<DanhSachTaiKhoan> list = new List<DanhSachTaiKhoan>();
           /* list.Add(new TaiKhoan("admin", "admin", true));
            list.Add(new TaiKhoan("user", "user", false));*/
            // Khởi tạo danh sách tài khoản trong constructor
            // Thêm các tài khoản vào danh sách
        }


    }
}
