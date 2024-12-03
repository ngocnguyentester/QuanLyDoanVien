using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; //thư viện sử dụng SQL
using QuanLiNhanSu.DUNGCHUNG;
using System.Runtime.CompilerServices;
using QuanLiNhanSu.DAO;

namespace QuanLiNhanSu
{
    public partial class Trang_chu : Form
    {
        public Trang_chu()
        {
            InitializeComponent();
        }


        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            Doan_Vien NV = new Doan_Vien();
            NV.ShowDialog();
        }

        private void btnChucVu_Click(object sender, EventArgs e)
        {
            Chuc_Vu CVu = new Chuc_Vu();
            CVu.ShowDialog();
        }

        private void btnPhongBan_Click(object sender, EventArgs e)
        {
            Chi_Doan PBan = new Chi_Doan();
            PBan.ShowDialog();
        }

        private void btnLuong_Click(object sender, EventArgs e)
        {
            Xep_Loai Lng = new Xep_Loai();
            Lng.ShowDialog();
        }

        private void btnDanToc_Click(object sender, EventArgs e)
        {
            Dan_Toc DToc = new Dan_Toc();
            DToc.ShowDialog();
        }

        private void btnChuyenMon_Click(object sender, EventArgs e)
        {
            Khoa CMon = new Khoa();
            CMon.ShowDialog();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Bạn có muốn đóng chương trình không?", "Thông báo",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK)
                Application.Exit();
        }

        private void menu_Thoat_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Bạn có muốn đóng chương trình không?", "Thông báo",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK)
                Application.Exit();
        }

        private void thêmMớiĐoànViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Doan_Vien NV = new Doan_Vien();
            NV.ShowDialog();
        }

        private void chứcDanhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Chuc_Vu CVu = new Chuc_Vu();
            CVu.ShowDialog();
        }

        private void lớpHọcChiĐoànToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Chi_Doan PBan = new Chi_Doan();
            PBan.ShowDialog();
        }

        private void xếpLoạiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Xep_Loai Lng = new Xep_Loai();
            Lng.ShowDialog();
        }

        private void dânTộcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dan_Toc DToc = new Dan_Toc();
            DToc.ShowDialog();
        }

        private void khoaHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Khoa CMon = new Khoa();
            CMon.ShowDialog();
        }

        private void thoátChươngTrìnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Bạn có muốn đóng chương trình không?", "Thông báo",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK)
                Application.Exit();
        }

        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginForm NV = new LoginForm();
            NV.ShowDialog();
            ShowHideMenu(true);
        }

        private void saoLưuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog saoluuFolder = new FolderBrowserDialog();
            saoluuFolder.Description = "Chọn thư mục lưu trữ";
            if (saoluuFolder.ShowDialog() == DialogResult.OK)
            {
                string sDuongDan = saoluuFolder.SelectedPath;

                if (CSDL_BUS.SaoLuu(sDuongDan) == true)
                    MessageBox.Show("Đã sao lưu dữ liệu vào " + sDuongDan);
                else
                    MessageBox.Show("Dữ liệu đã được sao lưu!");
            }
        }

        private void phụcHồiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog phuchoiFile = new OpenFileDialog();
            phuchoiFile.Filter = "*.bak|*.bak"; phuchoiFile.Title = "Chọn tập tin phục hồi (.bak)";
            if (phuchoiFile.ShowDialog() == DialogResult.OK &&
                    phuchoiFile.CheckFileExists == true)
            {

                string sDuongDan = phuchoiFile.FileName;
                if (CSDL_BUS.PhucHoi(sDuongDan) == true)
                    MessageBox.Show("Thành công");
                else
                    MessageBox.Show("Dữ liệu đã được phục hồi");

            }
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Bạn có muốn đăng xuất và quay về FORM ĐĂNG NHẬP??", "Thông báo",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            // Đăng xuất và thiết lập lại menu
            TaiKhoanDAO.DangXuat();
            ShowHideMenu(false);
        }

        private void ngườiDùngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DangKyForm NV = new DangKyForm();
            NV.ShowDialog();
        }
        private void Trang_chu_Load(object sender, EventArgs e)
        {
            //Khởi động form thì lấy thông tin
            //thiết lập quyền mới sử dụng được chức năng
            ShowHideMenu(false);
            //tự động nhấn vào nút Thông Tin
            // btnThongTin.PerformClick();
        }

        void ShowHideMenu(bool isLogin)
        {
            đăngXuấtToolStripMenuItem.Visible = isLogin;
            đăngNhậpToolStripMenuItem.Visible = !isLogin;
            if (HeThong.QuyenHan == "admin")
            {
                cấuHìnhToolStripMenuItem.Visible = true;
                đoànViênToolStripMenuItem.Visible = true;
                vănBảnToolStripMenuItem.Visible = true;
                hoạtĐộngToolStripMenuItem.Visible = true;
                saoLưuToolStripMenuItem.Visible = true;
            }
            else if (HeThong.QuyenHan == "user")
            {
                đoànViênToolStripMenuItem.Visible = true;
                saoLưuToolStripMenuItem.Visible = true;
                cấuHìnhToolStripMenuItem.Visible = false;
                vănBảnToolStripMenuItem.Visible = false;
                hoạtĐộngToolStripMenuItem.Visible = false;
            }else
            {
                đoànViênToolStripMenuItem.Visible = false;
                saoLưuToolStripMenuItem.Visible = false;
                cấuHìnhToolStripMenuItem.Visible = false;
                vănBảnToolStripMenuItem.Visible = false;
                hoạtĐộngToolStripMenuItem.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog saoluuFolder = new FolderBrowserDialog();
            saoluuFolder.Description = "Chọn thư mục lưu trữ";
            if (saoluuFolder.ShowDialog() == DialogResult.OK)
            {
                string sDuongDan = saoluuFolder.SelectedPath;

                if (CSDL_BUS.SaoLuu(sDuongDan) == true)
                    MessageBox.Show("Đã sao lưu dữ liệu vào " + sDuongDan);
                else
                    MessageBox.Show("Dữ liệu đã được sao lưu!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog phuchoiFile = new OpenFileDialog();
            phuchoiFile.Filter = "*.bak|*.bak"; phuchoiFile.Title = "Chọn tập tin phục hồi (.bak)";
            if (phuchoiFile.ShowDialog() == DialogResult.OK &&
                    phuchoiFile.CheckFileExists == true)
            {

                string sDuongDan = phuchoiFile.FileName;
                if (CSDL_BUS.PhucHoi(sDuongDan) == true)
                    MessageBox.Show("Thành công");
                else
                    MessageBox.Show("Dữ liệu đã được phục hồi");

            }
        }

        /*private void Trang_chu_Load(object sender, EventArgs e)
        {
            if (ChucNang.accountUsing.Permission == "Admin")
            {
                đăngXuấtToolStripMenuItem.Enabled = true;
                đăngNhậpToolStripMenuItem.Enabled = true;
                cấuHìnhToolStripMenuItem.Enabled = true;
                đoànViênToolStripMenuItem.Enabled = true;
                vănBảnToolStripMenuItem.Enabled=true;
                hoạtĐộngToolStripMenuItem.Enabled=true;
                saoLưuToolStripMenuItem.Enabled=true;
                thoátChươngTrìnhToolStripMenuItem.Enabled= true;
            }
            else
            {
              đăngXuấtToolStripMenuItem.Enabled = true;
               đăngNhậpToolStripMenuItem.Enabled = true;
                cấuHìnhToolStripMenuItem.Enabled = false;
                đoànViênToolStripMenuItem.Enabled = true;
                vănBảnToolStripMenuItem.Enabled = false;
                hoạtĐộngToolStripMenuItem.Enabled = false;
                saoLưuToolStripMenuItem.Enabled = true;
                thoátChươngTrìnhToolStripMenuItem.Enabled = true;
            }
        }*/
        /*void PhanQuyen()
        {
            if (Const.LoaiTaiKhoan == false)
            {
                đăngXuấtToolStripMenuItem.Enabled = false;
            }
        }*/
    }
    } 



    

