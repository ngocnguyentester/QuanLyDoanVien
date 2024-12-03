//using LoginAndPermissionApp;
using QuanLiNhanSu.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLiNhanSu.DUNGCHUNG;
using QuanLiNhanSu;


namespace QuanLiNhanSu
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();

            //SqlManager.LoadConnection();

        }
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txbTenDangNhap.ResetText();
            txbMatKhau.ResetText();
        }

        private void btnDangNhap_Click_1(object sender, EventArgs e)
        {
            string tendangnhap = txbTenDangNhap.Text;
            string matkhau = txbMatKhau.Text;

            if (TaiKhoanDAO.DangNhap(tendangnhap, matkhau) == true)
            {
                //lấy thông tin chi tiết của tài khoản
                TaiKhoanDAO.LayChiTietTaiKhoan(tendangnhap);
                //khởi tạo form Quản lý
                this.Close();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keydata)
        {
            if (keydata == Keys.Enter)
            {
                btnDangNhap.PerformClick();

                return true;
            }
            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Bạn có muốn đóng chương trình không?", "Thông báo",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK)
                Application.Exit();
        }
    }
}
    

