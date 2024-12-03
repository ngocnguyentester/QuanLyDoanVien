using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace QuanLiNhanSu
{
    public partial class Khoa : Form
    {
        public Khoa()
        {
            InitializeComponent();
        }

        PhuongThuc pt = new PhuongThuc();

        DataSet ds = new DataSet("QL_ChuyenMon");
        SqlDataAdapter daChuyenMon;
        SqlDataAdapter daNhanVien;
        private void HienThiDatagrid()
        {
            //----------- Dữ liệu datagrid Danh sách
            string sQueryChuyenMon = @"select cm.*, n.TenNV from ChuyenMon cm, NhanVien n where n.MaNV = cm.MaNV";
            daChuyenMon = new SqlDataAdapter(sQueryChuyenMon, pt.KetNoi());
            daChuyenMon.Fill(ds, "tblChuyenMon");
            dgChuyenMon.DataSource = ds.Tables["tblChuyenMon"];

            //Mã nhân viên
            dgChuyenMon.Columns["MaNV"].HeaderText = "Mã đoàn viên";
            dgChuyenMon.Columns["MaNV"].Width = 100;
            //Tên nhân viên
            dgChuyenMon.Columns["TenNV"].HeaderText = "Tên đoàn viên";
            dgChuyenMon.Columns["TenNV"].Width = 100;
            dgChuyenMon.Columns["TenNV"].DisplayIndex = 1;
            //Mã chuyên môn
            dgChuyenMon.Columns["MaChuyenMon"].HeaderText = "Mã khoa";
            dgChuyenMon.Columns["MaChuyenMon"].Width = 100;
            //Tên chuyên ngành
            dgChuyenMon.Columns["TenChuyenNganh"].HeaderText = "Tên khoa đoàn viên";
            dgChuyenMon.Columns["TenChuyenNganh"].Width = 200;
            //Trình độ chuyên môn
            dgChuyenMon.Columns["TrinhDoChuyenMon"].HeaderText = "Tên ngành học";
            dgChuyenMon.Columns["TrinhDoChuyenMon"].Width = 200;

        }
        private void Trinh_Do_Chuyen_Mon_Load(object sender, EventArgs e)
        {
            //----------- Dữ liệu combobox
            // Dữ liệu combobox Nhân viên
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

            //Command thêm chuyên môn
            string sThemChuyenMon = @"insert into ChuyenMon values(@MaChuyenMon,@MaNV,@TenChuyenNganh,@TrinhDoChuyenMon)";
            SqlCommand cmThemCM = new SqlCommand(sThemChuyenMon, pt.KetNoi());
            cmThemCM.Parameters.Add("@MaChuyenMon", SqlDbType.Char, 6, "MaChuyenMon");
            cmThemCM.Parameters.Add("@MaNV", SqlDbType.Char, 6, "MaNV");
            cmThemCM.Parameters.Add("@TenChuyenNganh", SqlDbType.NVarChar, 50, "TenChuyenNganh");
            cmThemCM.Parameters.Add("@TrinhDoChuyenMon", SqlDbType.NVarChar, 50, "TrinhDoChuyenMon");
            daChuyenMon.InsertCommand = cmThemCM;

            //Command sửa chuyên môn
            string sSuaCM = @"update ChuyenMon set MaNV=@MaNV,TenChuyenNganh=@TenChuyenNganh,TrinhDoChuyenMon=@TrinhDoChuyenMon where MaChuyenMon=@MaChuyenMon";
            SqlCommand cmSuaCM = new SqlCommand(sSuaCM, pt.KetNoi());
            cmSuaCM.Parameters.Add("@MaNV", SqlDbType.Char, 6, "MaNV");
            cmSuaCM.Parameters.Add("@MaChuyenMon", SqlDbType.Char, 6, "MaChuyenMon");
            cmSuaCM.Parameters.Add("@TenChuyenNganh", SqlDbType.NVarChar, 50, "TenChuyenNganh");
            cmSuaCM.Parameters.Add("@TrinhDoChuyenMon", SqlDbType.NVarChar, 50, "TrinhDoChuyenMon");
            daChuyenMon.UpdateCommand = cmSuaCM;

            //Command xóa chuyên môn
            string sXoaCM = @"delete from ChuyenMon where MaChuyenMon=@MaChuyenMon";
            SqlCommand cmXoaCM = new SqlCommand(sXoaCM, pt.KetNoi());
            cmXoaCM.Parameters.Add("@MaChuyenMon", SqlDbType.Char, 6, "MaChuyenMon");
            daChuyenMon.DeleteCommand = cmXoaCM;

            if (dgChuyenMon == null)
            {
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                btnHuy.Enabled = false;
            }
            else
            {
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnHuy.Enabled = true;
            }



        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            bool check = true;
            for (int i = 0; i < dgChuyenMon.RowCount - 1; i++)
            {
                if (txtMaChuyenMon.Text.ToUpper() == dgChuyenMon.Rows[i].Cells["MaChuyenMon"].Value.ToString().Trim())
                    check = false;
            }
            if (check == false)
                MessageBox.Show("Mã chuyên môn bị trùng trong danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            else if (txtTenChuyenNganh.Text == "" || txtMaChuyenMon.Text == "")
                MessageBox.Show("Chưa nhập tên chuyên ngành hoặc mã nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (txtTrinhDoChuyenMon.Text == "" || txtTrinhDoChuyenMon.Text == "")
                MessageBox.Show("Chưa nhập tên chuyên ngành hoặc mã nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (cmbTenNV.SelectedValue == null)
                MessageBox.Show("Chưa chọn tên nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {

                // Thêm 1 dòng vào bảng tblCHUYEN MON

                DataRow row = ds.Tables["tblChuyenMon"].NewRow();
                row["MaNV"] = cmbMaNV.SelectedValue;
                row["TenNV"] = cmbTenNV.SelectedValue;
                row["MaChuyenMon"] = txtMaChuyenMon.Text.ToUpper();
                row["TenChuyenNganh"] = txtTenChuyenNganh.Text;
                row["TrinhDoChuyenMon"] = txtTrinhDoChuyenMon.Text;
                //giá trị lấy từ bảng nhân viên -> SelectedValue
                ds.Tables["tblChuyenMon"].Rows.Add(row);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            bool check_MaCM = true;

            for (int i = 0; i < dgChuyenMon.RowCount - 1; i++)
            {
                if (txtMaChuyenMon.Text != dgChuyenMon.SelectedRows[0].Cells["MaChuyenMon"].Value.ToString().Trim())
                    check_MaCM = false;
            }
            if (check_MaCM == false)
                MessageBox.Show("Không được phép sửa mã chuyên môn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            else if (txtTenChuyenNganh.Text == "" || txtMaChuyenMon.Text == "")
                MessageBox.Show("Chưa nhập tên chuyên ngành hoặc mã chuyên môn nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            else if (txtTrinhDoChuyenMon.Text == "")
                MessageBox.Show("Chưa nhập trình độ chuyên môn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            else if (cmbTenNV.SelectedValue == null)
                MessageBox.Show("Chưa chọn tên nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            else if (cmbMaNV.SelectedValue == null)
                MessageBox.Show("Chưa chọn mã nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            else
            {
                try
                {
                    DataGridViewRow dr = dgChuyenMon.SelectedRows[0];
                    dgChuyenMon.BeginEdit(true);

                    dr.Cells["MaNV"].Value = cmbMaNV.SelectedValue;
                    dr.Cells["TenNV"].Value = cmbTenNV.SelectedValue;
                    dr.Cells["MaChuyenMon"].Value = txtMaChuyenMon.Text;
                    dr.Cells["TenChuyenNganh"].Value = txtTenChuyenNganh.Text;
                    dr.Cells["TrinhDoChuyenMon"].Value = txtTrinhDoChuyenMon.Text;

                    dgChuyenMon.EndEdit();
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
                DataGridViewRow dr = dgChuyenMon.SelectedRows[0];
                dgChuyenMon.Rows.Remove(dr);

            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                daChuyenMon.Update(ds, "tblChuyenMon");
                MessageBox.Show("Đã lưu!", "Thông báo");
                dgChuyenMon.Refresh();
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
                ds.Tables["tblChuyenMon"].RejectChanges();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtMaChuyenMon.ResetText();
            txtTenChuyenNganh.ResetText();
            txtTrinhDoChuyenMon.ResetText();
            cmbMaNV.ResetText();
            cmbTenNV.ResetText();
            txtMaChuyenMon.Focus();
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

            DataTable dt = (DataTable)dgChuyenMon.DataSource;
            SqlDataAdapter da = new SqlDataAdapter();

            string sQueryTim = "Select cm.*, n.TenNV from ChuyenMon cm, NhanVien n where cm.MaNV=n.MaNV AND (cm.MaChuyenMon like N'%" + txtTimKiem.Text + "%' OR cm.MaNV like N'%" + txtTimKiem.Text
                + "%' OR cm.TenChuyenNganh like N'%" + txtTimKiem.Text + "%' OR cm.TrinhDoChuyenMon like N'%" + txtTimKiem.Text + "%' OR n.TenNV like N'%" + txtTimKiem.Text + "%')";
            SqlCommand cmTim = new SqlCommand(sQueryTim, pt.KetNoi());
            da.SelectCommand = cmTim;
            dt.Clear();
            da.Fill(dt);
            dgChuyenMon.DataSource = dt;
        }

        private void dgChuyenMon_Click(object sender, EventArgs e)
        {
            DataGridViewRow dr = dgChuyenMon.SelectedRows[0];
            txtMaChuyenMon.Text = dr.Cells["MaChuyenMon"].Value.ToString();
            cmbMaNV.SelectedValue = dr.Cells["MaNV"].Value.ToString();
            txtTenChuyenNganh.Text = dr.Cells["TenChuyenNganh"].Value.ToString();
            txtTrinhDoChuyenMon.Text = dr.Cells["TrinhDoChuyenMon"].Value.ToString();
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }
    }
}
