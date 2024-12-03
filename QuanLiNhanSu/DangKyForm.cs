using QuanLiNhanSu.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiNhanSu
{
    public partial class DangKyForm : Form
    {
        public DangKyForm()
        {
            InitializeComponent();
        }
     
        private void btnThem_Click(object sender, EventArgs e)
        {
            string tendn = txbTenDangNhap.Text;
            string matkhau = txbMatKhau.Text;
            string quyen = cmbLoaiTK.SelectedItem.ToString();

            if (tendn.Length > 0 && matkhau.Length > 0)
            {
                try
                {
                    TaiKhoanDAO.Them(tendn, matkhau, quyen);
                    //btnTaiLai.PerformClick();
                }
                catch
                {
                    MessageBox.Show("Tên đăng nhập đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
           int id = (int)numID.Value;
            string tendn = txbTenDangNhap.Text;
            string matkhau = txbMatKhau.Text;
            string quyen = cmbLoaiTK.SelectedItem.ToString();
          
            if (id > 0 && tendn.Length > 0 && matkhau.Length > 0)
            {
                try
                {
                    TaiKhoanDAO.Sua(tendn, matkhau, quyen, id);
                   // btnTaiLai.PerformClick();
                }
                catch
                {
                    MessageBox.Show("Tên đăng nhập đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int id = (int)numID.Value;

          if (MessageBox.Show("Bạn có muốn xóa dòng có id = " + id + "?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
          {
               TaiKhoanDAO.Xoa(id);
                // btnTaiLai.PerformClick();
           }
        }
        private void dgvDuLieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           numID.Value = int.Parse(dgvAccount.CurrentRow.Cells[0].Value.ToString());
            txbTenDangNhap.Text = dgvAccount.CurrentRow.Cells[1].Value.ToString().Trim();
            txbMatKhau.Text = dgvAccount.CurrentRow.Cells[2].Value.ToString().Trim();
            cmbLoaiTK.SelectedItem = dgvAccount.CurrentRow.Cells[3].Value.ToString();
        }

        
    }

      

     
    }


        //private void btnThem_Click(object sender, EventArgs e)
      //  {
            /*if (string.IsNullOrEmpty(txtTaiKhoan.Text))
            {
                ChucNang.ShowWarningDialog("Tài khoản không được phép để trống.");
                return;
            }
            if (string.IsNullOrEmpty(txtMatKhau.Text))
            {
                ChucNang.ShowWarningDialog("Mật khẩu không được phép để trống.");
                return;
            }
            if (string.IsNullOrEmpty(cbQuyen.Text))
            {
                ChucNang.ShowWarningDialog("Quyền hạn không được phép để trống.");
                return;
            }
            foreach (DataGridViewRow row1 in dgvAccount.Rows)
            {
                DataGridViewCell cell = row1.Cells[0];
                if (cell.Value != null && cell.Value.ToString() == txtTaiKhoan.Text)
                {
                    ChucNang.ShowWarningDialog("Tài khoản đã tồn tại.");
                    return;
                }
            }
            DataRow row = SqlManager.dataSet.Tables["tblTaiKhoan"].NewRow();
            row["Account"] = txtTaiKhoan.Text;
            row["Pass"] = txtMatKhau.Text;
            row["Permission"] = cbQuyen.Text;
            SqlManager.dataSet.Tables["tblTaiKhoan"].Rows.Add(row);
        }*/
    
    

