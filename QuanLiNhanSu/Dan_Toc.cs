using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLiNhanSu
{
    public partial class Dan_Toc : Form
    {
        public Dan_Toc()
        {
            InitializeComponent();
        }

        PhuongThuc pt = new PhuongThuc();

        DataSet ds = new DataSet("QLDT");
        SqlDataAdapter daDanToc;

        private void HienThiDatagrid()
        {
            string sQueryDanToc = @"select * from DanToc";
            daDanToc = new SqlDataAdapter(sQueryDanToc, pt.KetNoi());
            daDanToc.Fill(ds, "tblDanToc");
            dgDanToc.DataSource = ds.Tables["tblDanToc"];

            //Tên chức vụ
            dgDanToc.Columns["TenDanToc"].HeaderText = "Tên dân tộc";
            dgDanToc.Columns["TenDanToc"].Width = 200;
            //Mã chức vụ
            dgDanToc.Columns["MaDanToc"].HeaderText = "Mã dân tộc";
            dgDanToc.Columns["MaDanToc"].Width = 100;

        }
        private void Dan_Toc_Load(object sender, EventArgs e)
        {
            HienThiDatagrid();

            //Command thêm dân tộc
            string sThemDT = @"insert into ChucVu values(@MaDanToc,@TenDanToc)";
            SqlCommand cmThemDT = new SqlCommand(sThemDT, pt.KetNoi());
            cmThemDT.Parameters.Add("@MaDanToc", SqlDbType.Char, 6, "MaDanToc");
            cmThemDT.Parameters.Add("@TenDanToc", SqlDbType.NVarChar, 50, "TenDanToc");

            daDanToc.InsertCommand = cmThemDT;

            //Command sửa dân tộc
            string sSuaDT = @"update ChucVu set TenDanToc=@TenDanToc where MaDanToc=@MaDanToc";
            SqlCommand cmSuaDT = new SqlCommand(sSuaDT, pt.KetNoi());
            cmSuaDT.Parameters.Add("@MaDanToc", SqlDbType.Char, 6, "MaDanToc");
            cmSuaDT.Parameters.Add("@TenDanToc", SqlDbType.NVarChar, 50, "TenDanToc");

            daDanToc.UpdateCommand = cmSuaDT;

            //Command xóa dân tộc
            string sXoaDT = @"delete from ChucVu where MaDanToc=@MaDanToc";
            SqlCommand cmXoaDT = new SqlCommand(sXoaDT, pt.KetNoi());
            cmXoaDT.Parameters.Add("@MaDanToc", SqlDbType.Char, 6, "MaDanToc");

            daDanToc.DeleteCommand = cmXoaDT;
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = false;
            btnHuy.Enabled = false;

            DataTable dt = (DataTable)dgDanToc.DataSource;
            SqlDataAdapter da = new SqlDataAdapter();

            string sQueryTim = "Select * from DanToc where MaDanToc like N'%" + txtTimKiem.Text + "%' OR TenDanToc like N'%" + txtTimKiem.Text + "%'";
            SqlCommand cmTim = new SqlCommand(sQueryTim, pt.KetNoi());
            da.SelectCommand = cmTim;
            dt.Clear();
            da.Fill(dt);
            dgDanToc.DataSource = dt;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            bool check_Ten = true;
            bool check_Ma = true;

            for (int i = 0; i < dgDanToc.RowCount - 1; i++)
            {
                if (txtMaDanToc.Text.ToUpper() == dgDanToc.Rows[i].Cells["MaDanToc"].Value.ToString().Trim())
                    check_Ma = false;
                else if (txtTenDanToc.Text == dgDanToc.Rows[i].Cells["TenDanToc"].Value.ToString())
                    check_Ten = false;

            }
            if (check_Ten == false)
                MessageBox.Show("Tên dân tộc đã có trong danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            if (txtMaDanToc.Text == "" || txtTenDanToc.Text == "")
            {
                MessageBox.Show("Dữ liệu vừa nhập chưa hợp lệ!", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            else if (check_Ma == false)
            {
                MessageBox.Show("Mã dân tộc bị trùng trong danh sách!", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            else
            {
                DataRow row = ds.Tables["tblDanToc"].NewRow();
                row["MaDanToc"] = txtMaDanToc.Text.ToUpper();
                row["TenDanToc"] = txtTenDanToc.Text;
                ds.Tables["tblDanToc"].Rows.Add(row);

                txtMaDanToc.ResetText();
                txtTenDanToc.ResetText();
                
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            bool check_Ten = true;

            for (int i = 0; i < dgDanToc.RowCount - 1; i++)
            {
                if (txtTenDanToc.Text == dgDanToc.Rows[i].Cells["TenDanToc"].Value.ToString())
                    check_Ten = false;

            }
            if (txtMaDanToc.Text == "" || txtTenDanToc.Text == "")
            {
                MessageBox.Show("Dữ liệu vừa nhập chưa hợp lệ!", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            else if (txtMaDanToc.Text != dgDanToc.SelectedRows[0].Cells["MaDanToc"].Value.ToString().Trim())
            {
                MessageBox.Show("Không được phép sửa mã dân tộc!", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            else if (check_Ten == false)
            {
                MessageBox.Show("Tên dân tộc đã có trong danh sách!", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }

            else
            {
                try
                {
                    DataGridViewRow dr = dgDanToc.SelectedRows[0];
                    dgDanToc.BeginEdit(true);

                    dr.Cells["MaDanToc"].Value = txtMaDanToc.Text;
                    dr.Cells["TenDanToc"].Value = txtTenDanToc.Text;

                    dgDanToc.EndEdit();
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
                DataGridViewRow dr = dgDanToc.SelectedRows[0];
                dgDanToc.Rows.Remove(dr);

            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                daDanToc.Update(ds, "tblLuong");
                MessageBox.Show("Đã lưu!", "Thông báo");
                dgDanToc.Refresh();
                //HienThiDatagrid();
            }
            catch
            {
                return;
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            DialogResult dialog = new DialogResult();
            dialog = MessageBox.Show("Bạn có muốn thoát chương trình?", "Thông báo",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialog == DialogResult.OK)
                this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult dialog = new DialogResult();
            dialog = MessageBox.Show("Bạn có chắc chắn muốn hủy tác vụ?", "Thông báo",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialog == DialogResult.OK)
            {
                ds.Tables["tblDanToc"].RejectChanges();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtMaDanToc.ResetText();
            txtTenDanToc.ResetText();
            txtMaDanToc.Focus();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnHuy.Enabled = true;
        }

        private void dgDanToc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dr = dgDanToc.SelectedRows[0];
            txtMaDanToc.Text = dr.Cells["MaDanToc"].Value.ToString();
            txtTenDanToc.Text = dr.Cells["TenDanToc"].Value.ToString();
        }
    }
}
