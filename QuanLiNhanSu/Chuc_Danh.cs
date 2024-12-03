using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLiNhanSu
{
    public partial class Chuc_Vu : Form
    {
        public Chuc_Vu()
        {
            InitializeComponent();
        }
        
        PhuongThuc pt = new PhuongThuc();

        DataSet ds = new DataSet("QLCV");
        SqlDataAdapter daChucVu;

        private void HienThiDatagrid()
        {
            //----------- Dữ liệu datagrid Danh sách
            string sQueryChucVu = @"select * from ChucVu";
            daChucVu = new SqlDataAdapter(sQueryChucVu, pt.KetNoi());
            daChucVu.Fill(ds, "tblChucVu");
            dgChuc_Vu.DataSource = ds.Tables["tblChucVu"];
            //Mã chức vụ
            dgChuc_Vu.Columns["MaChucVu"].HeaderText = "Mã chức danh";
            dgChuc_Vu.Columns["MaChucVu"].Width = 100;
            //Tên chức vụ
            dgChuc_Vu.Columns["TenChucVu"].HeaderText = "Tên chức danh";
            dgChuc_Vu.Columns["TenChucVu"].Width = 200;

        }

        private void Chuc_Vu_Load(object sender, EventArgs e)
        {
            
            HienThiDatagrid();

            //Command thêm chức vụ
            string sThemCV = @"insert into ChucVu values(@MaChucVu,@TenChucVu)";
            SqlCommand cmThemCV = new SqlCommand(sThemCV, pt.KetNoi());
            cmThemCV.Parameters.Add("@MaChucVu", SqlDbType.Char, 6, "MaChucVu");
            cmThemCV.Parameters.Add("@TenChucVu", SqlDbType.NVarChar, 70, "TenChucVu");

            daChucVu.InsertCommand = cmThemCV;

            //Command sửa chức vụ
            string sSuaCV = @"update ChucVu set TenChucVu=@TenChucVu where MaChucVu=@MaChucVu";
            SqlCommand cmSuaCV = new SqlCommand(sSuaCV, pt.KetNoi());
            cmSuaCV.Parameters.Add("@MaChucVu", SqlDbType.Char, 6, "MaChucVu");
            cmSuaCV.Parameters.Add("@TenChucVu", SqlDbType.NVarChar, 70, "TenChucVu");

            daChucVu.UpdateCommand = cmSuaCV;

            //Command xóa chức vụ
            string sXoaCV = @"delete from ChucVu where MaChucVu=@MaChucVu";
            SqlCommand cmXoaCV = new SqlCommand(sXoaCV, pt.KetNoi());
            cmXoaCV.Parameters.Add("@MaChucVu", SqlDbType.Char, 6, "MaChucVu");

            daChucVu.DeleteCommand = cmXoaCV;

            if (dgChuc_Vu == null)
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
            bool check_Ma = true;
            bool check_Ten = true;

            //Kiểm tra ràng buộc
            for (int i = 0; i < dgChuc_Vu.RowCount - 1; i++)
            {
                if (txtMaChucVu.Text.ToUpper() == dgChuc_Vu.Rows[i].Cells["MaChucVu"].Value.ToString().Trim())
                    check_Ma = false;
                else if (txtTenChucVu.Text == dgChuc_Vu.Rows[i].Cells["TenChucVu"].Value.ToString())
                    check_Ten = false;
            }
            if (txtTenChucVu.Text == "" || txtMaChucVu.Text == "")
            {
                MessageBox.Show("Dữ liệu vừa nhập chưa hợp lệ!", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            else if (check_Ma == false)
            {
                MessageBox.Show("Mã chức vụ bị trùng trong danh sách!", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            else if (check_Ten == false)
            {
                MessageBox.Show("Tên chức vụ đã có trong danh sách!", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }

            else
            {
                DataRow row = ds.Tables["tblChucVu"].NewRow();
                row["MaChucVu"] = txtMaChucVu.Text.ToUpper();
                row["TenChucVu"] = txtTenChucVu.Text;
                ds.Tables["tblChucVu"].Rows.Add(row);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            bool check_Ten = true;

            for (int i = 0; i < dgChuc_Vu.RowCount - 1; i++)
            {
                if(txtTenChucVu.Text == dgChuc_Vu.Rows[i].Cells["TenChucVu"].Value.ToString())
                    check_Ten = false;

            }
            if (check_Ten == false)
                MessageBox.Show("Tên chức vụ đã có trong danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (txtMaChucVu.Text != dgChuc_Vu.SelectedRows[0].Cells["MaChucVu"].Value.ToString().Trim())
                MessageBox.Show("Không được phép sửa mã chức vụ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (txtTenChucVu.Text == "" || txtMaChucVu.Text == "")
            {
                MessageBox.Show("Dữ liệu vừa nhập chưa hợp lệ!", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    DataGridViewRow dr = dgChuc_Vu.SelectedRows[0];
                    dgChuc_Vu.BeginEdit(true);

                    dr.Cells["MaChucVu"].Value = txtMaChucVu.Text;
                    dr.Cells["TenChucVu"].Value = txtTenChucVu.Text;


                    dgChuc_Vu.EndEdit();
                    MessageBox.Show("Đã cập nhật!", "Thông báo");
                }
                catch { }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dialog = new DialogResult();
            dialog = MessageBox.Show("Bạn có chắc chắn muốn xóa dòng này?", "Thông báo",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialog == DialogResult.OK)
            {
                DataGridViewRow dr = dgChuc_Vu.SelectedRows[0];
                dgChuc_Vu.Rows.Remove(dr);

            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                daChucVu.Update(ds, "tblChucVu");
                MessageBox.Show("Đã lưu!", "Thông báo");
                dgChuc_Vu.Refresh();
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
                ds.Tables["tblChucVu"].RejectChanges();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtMaChucVu.ResetText();
            txtTenChucVu.ResetText();
            txtMaChucVu.Focus();
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

            DataTable dt = (DataTable)dgChuc_Vu.DataSource;
            SqlDataAdapter da = new SqlDataAdapter();

            string sQueryTim = "Select * from ChucVu where MaChucVu like N'%" + txtTimKiem.Text + "%' OR TenChucVu like N'%" + txtTimKiem.Text + "%'";
            SqlCommand cmTim = new SqlCommand(sQueryTim, pt.KetNoi());
            da.SelectCommand = cmTim;
            dt.Clear();
            da.Fill(dt);
            dgChuc_Vu.DataSource = dt;
        }

        private void dgChuc_Vu_Click(object sender, EventArgs e)
        {
            DataGridViewRow dr = dgChuc_Vu.SelectedRows[0];
            txtMaChucVu.Text = dr.Cells["MaChucVu"].Value.ToString();
            txtTenChucVu.Text = dr.Cells["TenChucVu"].Value.ToString();

        }
    }
}
