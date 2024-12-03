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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLiNhanSu
{
    public partial class Xep_Loai : Form
    {
        public Xep_Loai()
        {
            InitializeComponent();
        }

        PhuongThuc pt = new PhuongThuc();

        DataSet ds = new DataSet("QLLuong");
        SqlDataAdapter daLuong;
        SqlDataAdapter daNhanVien;
        private void HienThiDatagrid()
        {
            string sQueryLuong = @"Select l.*, n.TenNV from Luong l, NhanVien n where n.MaNV=l.MaNV";
            daLuong = new SqlDataAdapter(sQueryLuong, pt.KetNoi());

            daLuong.Fill(ds, "tblLuong");
            dgLuong.DataSource = ds.Tables["tblLuong"];
            //Ngày bắt đầu
          /*  dgLuong.Columns["NgayBD"].HeaderText = "Ngày bắt đầu nhận lương";
            dgLuong.Columns["NgayBD"].Width = 100;*/
            //Mã nhân viên
            dgLuong.Columns["MaNV"].HeaderText = "Mã đoàn viên";
            dgLuong.Columns["MaNV"].Width = 100;
            //Tên nhân viên
            dgLuong.Columns["TenNV"].HeaderText = "Tên đoàn viên";
            dgLuong.Columns["TenNV"].Width = 100;
            dgLuong.Columns["TenNV"].DisplayIndex = 2;
            //Lương căn bản
            dgLuong.Columns["LuongCB"].HeaderText = "Điểm đánh giá đoàn viên";
            dgLuong.Columns["LuongCB"].Width = 150;
            //Hệ số lương
            dgLuong.Columns["HeSoLuong"].HeaderText = "Xếp loại";
            dgLuong.Columns["HeSoLuong"].Width = 100;
            //Tổng lương
         /* dgLuong.Columns["TongLuong"].HeaderText = "Tổng lương";
            dgLuong.Columns["TongLuong"].Width = 150;*/

        }

        private void Luong_Load(object sender, EventArgs e)
        {
            string sQueryLuong = @"select * from Luong";
            daLuong = new SqlDataAdapter(sQueryLuong, pt.KetNoi());
            
            //----------- Dữ liệu datagrid Danh sách
            string sQueryNhanVien = @"select * from NhanVien";
            daNhanVien = new SqlDataAdapter(sQueryNhanVien, pt.KetNoi());
            daNhanVien.Fill(ds, "tblNhanVien");
            cmbTenNV.DataSource = ds.Tables["tblNhanVien"];
            cmbTenNV.DisplayMember = "TenNV";
            cmbTenNV.ValueMember = "TenNV";

            cmbMaNV.DataSource = ds.Tables["tblNhanVien"];
            cmbMaNV.DisplayMember = "MaNV";
            cmbMaNV.ValueMember = "MaNV";

            HienThiDatagrid();
            //Parameters: truyền tham số
            //Command thêm lương
            string sThemL = @"insert into Luong values(@NgayBD,@MaNV,@LuongCB,@HeSoLuong,@TongLuong)";
            SqlCommand cmThemL = new SqlCommand(sThemL, pt.KetNoi());
            cmThemL.Parameters.Add("@NgayBD", SqlDbType.Date, 10, "NgayBD");
            cmThemL.Parameters.Add("@MaNV", SqlDbType.Char, 6, "MaNV");
            cmThemL.Parameters.Add("@LuongCB", SqlDbType.VarChar, int.MaxValue, "LuongCB");
            cmThemL.Parameters.Add("@HeSoLuong", SqlDbType.VarChar, int.MaxValue, "HeSoLuong");
            cmThemL.Parameters.Add("@TongLuong", SqlDbType.VarChar, int.MaxValue, "TongLuong");
            daLuong.InsertCommand = cmThemL;

            //Command sửa lương
            string sSuaL = @"update Luong set NgayBD=@NgayBD,LuongCB=@LuongCB,HeSoLuong=@HeSoLuong,TongLuong=@TongLuong where MaNV=@MaNV";
            SqlCommand cmSuaL = new SqlCommand(sSuaL, pt.KetNoi());
            cmSuaL.Parameters.Add("@NgayBD", SqlDbType.Date, 10, "NgayBD");
            cmSuaL.Parameters.Add("@MaNV", SqlDbType.Char, 6, "MaNV");
            cmSuaL.Parameters.Add("@LuongCB", SqlDbType.VarChar, int.MaxValue, "LuongCB");
            cmSuaL.Parameters.Add("@HeSoLuong", SqlDbType.VarChar, int.MaxValue, "HeSoLuong");
            cmSuaL.Parameters.Add("@TongLuong", SqlDbType.VarChar, int.MaxValue, "TongLuong");
            daLuong.UpdateCommand = cmSuaL;

            //Command xóa lương
            string sXoaL = @"delete from Luong where MaNV=@MaNV";
            SqlCommand cmXoaL = new SqlCommand(sXoaL, pt.KetNoi());
            cmXoaL.Parameters.Add("@MaNV", SqlDbType.Char, 6, "MaNV");
            daLuong.DeleteCommand = cmXoaL;


            txtTongLuong.ReadOnly = true;

            if (dgLuong == null)
            {
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                btnThem.Enabled = false;
                btnHuy.Enabled = false;
            }
            else
            {
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnThem.Enabled = true;
                btnHuy.Enabled = true;
            }

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            /*//Kiểm tra ràng buộc
            if (txtLuongCB.Text == "" || txtHeSoLuong.Text == "")
            {
                MessageBox.Show("Dữ liệu vừa nhập chưa hợp lệ!", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            else
            {
                DataRow row = ds.Tables["tblLuong"].NewRow();
                row["NgayBD"] = dtpNgayBD.Text;
                row["MaNV"] = cmbMaNV.SelectedValue;
                row["TenNV"] = cmbTenNV.SelectedValue;
                row["LuongCB"] = txtLuongCB.Text;
                row["HeSoLuong"] = txtHeSoLuong.Text;
                row["TongLuong"] = txtTongLuong.Text;
                
                ds.Tables["tblLuong"].Rows.Add(row);

                cmbMaNV.ResetText();
                cmbTenNV.ResetText();
                txtHeSoLuong.ResetText();
                txtLuongCB.ResetText();
                txtTongLuong.ResetText();
                dtpNgayBD.Refresh();
            }
        }

        private void dgLuong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dr = dgLuong.SelectedRows[0];
            dtpNgayBD.Text = dr.Cells["NgayBD"].Value.ToString();
            cmbMaNV.SelectedValue = dr.Cells["MaNV"].Value.ToString();
            txtLuongCB.Text = dr.Cells["LuongCB"].Value.ToString();
            txtHeSoLuong.Text = dr.Cells["HeSoLuong"].Value.ToString();
            txtTongLuong.Text = dr.Cells["TongLuong"].Value.ToString();

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            txtTongLuong.Enabled = false;
            //Kiểm tra ràng buộc
            if (txtHeSoLuong.Text == "" || txtLuongCB.Text == "")
            {
                MessageBox.Show("Dữ liệu vừa nhập chưa hợp lệ!", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            else
            {
                try 
                {
                    DataGridViewRow dr = dgLuong.SelectedRows[0];
                    dgLuong.BeginEdit(true);

                    dr.Cells["NgayBD"].Value = dtpNgayBD.Text;
                    dr.Cells["MaNV"].Value = cmbMaNV.SelectedValue;
                    dr.Cells["LuongCB"].Value = txtLuongCB.Text;
                    dr.Cells["HeSoLuong"].Value = txtHeSoLuong.Text;
                    dr.Cells["TongLuong"].Value = txtTongLuong.Text;

                    dgLuong.EndEdit();
                    MessageBox.Show("Đã cập nhật!", "Thông báo");
                }
                catch { }
            }*/
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dialog = new DialogResult();
            dialog = MessageBox.Show("Bạn có chắc chắn muốn xóa dòng này?", "Thông báo",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialog == DialogResult.OK)
            {
                DataGridViewRow dr = dgLuong.SelectedRows[0];
                dgLuong.Rows.Remove(dr);

            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                daLuong.Update(ds, "tblLuong");
                MessageBox.Show("Đã lưu!", "Thông báo");
                dgLuong.Refresh();
                //HienThiDatagrid();
            }
            catch
            {
                return;
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult dialog = new DialogResult();
            dialog = MessageBox.Show("Bạn có chắc chắn muốn hủy tác vụ?", "Thông báo",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialog == DialogResult.OK)
            {
                ds.Tables["tblLuong"].RejectChanges();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cmbMaNV.ResetText();
            cmbTenNV.ResetText();
            //txtHeSoLuong.ResetText();
            txtLuongCB.ResetText();
            txtTongLuong.ResetText();
            //dtpNgayBD.Refresh();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnHuy.Enabled = true;

        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            DialogResult dialog = new DialogResult();
            dialog = MessageBox.Show("Bạn có muốn thoát chương trình?", "Thông báo",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialog == DialogResult.OK)
                this.Close();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = false;
            btnHuy.Enabled = false;

            DataTable dt = (DataTable)dgLuong.DataSource;
            SqlDataAdapter da = new SqlDataAdapter();

            string sQueryTim = "Select l.*, n.TenNV from Luong l, NhanVien n where n.MaNV=l.MaNV AND (l.MaNV like N'%" + txtTimKiem.Text + "%' OR l.LuongCB like N'%" + txtTimKiem.Text + 
                "%' OR l.HeSoLuong like N'%" + txtTimKiem.Text + "%' OR l.TongLuong like N'%" + txtTimKiem.Text + "%' OR n.TenNV like N'%" + txtTimKiem.Text + "%')";
            SqlCommand cmTim = new SqlCommand(sQueryTim, pt.KetNoi());
            da.SelectCommand = cmTim;
            dt.Clear();
            da.Fill(dt);
            dgLuong.DataSource = dt;

        }

     /*   private void txtHeSoLuong_TextChanged(object sender, EventArgs e)
        {
            if(txtLuongCB.Text == "" || txtHeSoLuong.Text == "")
            {
                txtTongLuong.Text = "0";

            }
            else
            {
                double lcb = double.Parse(txtLuongCB.Text.ToString());
             //   double hsl = double.Parse(txtHeSoLuong.Text.ToString());

                double t = lcb * hsl;
                txtTongLuong.Text = t.ToString();

            }
*/
        }
    }


