using QuanLiNhanSu.DUNGCHUNG;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiNhanSu.DAO
{
    public class TaiKhoanDAO
    {

        public static bool DangNhap(string tendangnhap, string matkhau)
        {
            string s = "SELECT id FROM dbo.TaiKhoan WHERE TenDN = @TenDN AND MatKhau = @MatKhau";
            return CSDL.LayDanhSach(s, new object[] { tendangnhap, HeThong.MD5(matkhau) }).Rows.Count > 0;
        }
        public static void DangXuat()
        {
            HeThong.ID = -1;
            HeThong.TenDangNhap = "";
            HeThong.MatKhau = "";
            HeThong.QuyenHan = "";
        }
        public static void LayChiTietTaiKhoan(string tendangnhap)
        {
            DataTable data = CSDL.LayDanhSach("SELECT * FROM dbo.TaiKhoan WHERE TenDN = @TenDN", new object[] { tendangnhap });
            HeThong.ID = int.Parse(data.Rows[0]["id"].ToString());
            HeThong.TenDangNhap = data.Rows[0]["TenDN"].ToString().Trim();
            HeThong.MatKhau = data.Rows[0]["MatKhau"].ToString().Trim();
            HeThong.QuyenHan = data.Rows[0]["Loai"].ToString().Trim();
        }

        public static DataTable DanhSach()
        {
            return CSDL.LayDanhSach("SELECT * FROM dbo.TaiKhoan");
        }

        public static bool Them(string tendangnhap, string matkhau, string loai)
        {
            string s = "INSERT INTO TaiKhoan(TenDN,MatKhau,Loai) VALUES( @TenDN , @MatKhau , @Loai )";
            return CSDL.ThemSuaXoa(s, new object[] { tendangnhap, HeThong.MD5(matkhau), loai }) > 0;
        }

        public static bool Sua(string tendangnhap, string matkhau, string loai, int id)
        {
            string s = "UPDATE dbo.TaiKhoan SET TenDN = @TenDN , MatKhau = @MatKhau , Loai = @Loai WHERE id = @id";
            return CSDL.ThemSuaXoa(s, new object[] { tendangnhap, HeThong.MD5(matkhau), loai, id }) > 0;
        }

        public static bool Xoa(int id)
        {
            string s = "DELETE FROM dbo.TaiKhoan WHERE id = @id";
            return CSDL.ThemSuaXoa(s, new object[] { id }) > 0;
        }

        public static bool DoiTenDangNhap(string tendangnhap)
        {
            string s = "UPDATE dbo.TaiKhoan SET TenDN = @TenDN WHERE id = @id";
            return CSDL.ThemSuaXoa(s, new object[] { tendangnhap, HeThong.ID }) > 0;
        }

        public static bool DoiMatKhau(string matkhau)
        {
            string s = "UPDATE dbo.TaiKhoan SET MatKhau = @MatKhau WHERE id = @id";
            return CSDL.ThemSuaXoa(s, new object[] { HeThong.MD5(matkhau), HeThong.ID }) > 0;
        }

        public static bool DoiMatKhau_TenDangNhap(string matkhau, string tendangnhap)
        {
            string s = "UPDATE dbo.TaiKhoan SET MatKhau = @MatKhau , TenDN = @TenDN WHERE id = @id";
            return CSDL.ThemSuaXoa(s, new object[] { HeThong.MD5(matkhau), tendangnhap, HeThong.ID }) > 0;
        }
    }

}


