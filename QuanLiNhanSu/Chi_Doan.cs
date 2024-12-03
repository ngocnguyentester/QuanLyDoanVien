using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace QuanLiNhanSu
{
    public partial class Chi_Doan : Form
    {
        public Chi_Doan()
        {
            InitializeComponent();
        }
        
        PhuongThuc pt = new PhuongThuc();

        DataSet ds = new DataSet("QLPB");
        SqlDataAdapter daPhongBan;
        private void HienThiDatagrid()
        {
            string sQueryPhongBan = @"select * from PhongBan";
            daPhongBan = new SqlDataAdapter(sQueryPhongBan, pt.KetNoi());

            daPhongBan.Fill(ds, "tblPhongBan");
            dgPhongBan.DataSource = ds.Tables["tblPhongBan"];
            // Mã Phòng
            dgPhongBan.Columns["MaPhong"].HeaderText = "Mã chi đoàn";
            dgPhongBan.Columns["MaPhong"].Width = 150;
            //Tên phòng
            dgPhongBan.Columns["TenPhong"].HeaderText = "Tên chi đoàn";
            dgPhongBan.Columns["TenPhong"].Width = 250;
        }
        private void Phong_Ban_Load(object sender, EventArgs e)
        {            
            HienThiDatagrid();

            //Command thêm phòng ban
            string sThemPB = @"insert into PhongBan values(@MaPhong,@TenPhong)";
            SqlCommand cmThemPB = new SqlCommand(sThemPB, pt.KetNoi());
            cmThemPB.Parameters.Add("@MaPhong", SqlDbType.Char, 6, "MaPhong");
            cmThemPB.Parameters.Add("@TenPhong", SqlDbType.NVarChar,50, "TenPhong");
            daPhongBan.InsertCommand = cmThemPB;

            //Command sửa phòng ban
            string sSuaPB = @"update PhongBan set TenPhong=@TenPhong where MaPhong=@MaPhong";
            SqlCommand cmSuaPB = new SqlCommand(sSuaPB, pt.KetNoi());
            cmSuaPB.Parameters.Add("@MaPhong", SqlDbType.Char, 6, "MaPhong");
            cmSuaPB.Parameters.Add("@TenPhong", SqlDbType.NVarChar, 50, "TenPhong");
            daPhongBan.UpdateCommand = cmSuaPB;

            //Command xóa phòng ban
            string sXoaPB = @"delete from PhongBan where MaPhong=@MaPhong";
            SqlCommand cmXoaPB = new SqlCommand(sXoaPB, pt.KetNoi());
            cmXoaPB.Parameters.Add("@MaPhong", SqlDbType.Char, 6, "MaPhong");

            daPhongBan.DeleteCommand = cmXoaPB;

            if (dgPhongBan == null)
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

        private void dgPhongBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dr = dgPhongBan.SelectedRows[0];
            txtMaPhong.Text = dr.Cells["MaPhong"].Value.ToString();
            txtTenPhong.Text = dr.Cells["TenPhong"].Value.ToString();

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            bool check_Ten = true;

            bool check_Ma = true;
            //Kiểm tra ràng buộc
            for (int i = 0; i < dgPhongBan.RowCount - 1; i++)
            {
                if (txtMaPhong.Text.ToUpper() == dgPhongBan.Rows[i].Cells["MaPhong"].Value.ToString())
                {
                    check_Ma = false;
                }
                else if (txtTenPhong.Text.ToUpper() == dgPhongBan.Rows[i].Cells["TenPhong"].Value.ToString().Trim())
                {
                    check_Ten = false;
                }
            }
            if (check_Ma == false)
                MessageBox.Show("Mã phòng bị trùng trong danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (check_Ten == false)
                MessageBox.Show("Tên phòng đã có trong danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            else if (txtMaPhong.Text == "" || txtTenPhong.Text == "")
            {
                MessageBox.Show("Dữ liệu vừa nhập chưa hợp lệ!", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            else
            {
                DataRow row = ds.Tables["tblPhongBan"].NewRow();
                row["MaPhong"] = txtMaPhong.Text.ToUpper();
                row["TenPhong"] = txtTenPhong.Text;
                ds.Tables["tblPhongBan"].Rows.Add(row);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            bool check_Ten = true;

            for (int i = 0; i < dgPhongBan.RowCount - 1; i++)
            {
                if (txtTenPhong.Text == dgPhongBan.Rows[i].Cells["TenPhong"].Value.ToString())
                    check_Ten = false;

            }
            if (check_Ten == false)
                MessageBox.Show("Tên phòng đã có trong danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (txtMaPhong.Text != dgPhongBan.SelectedRows[0].Cells["MaPhong"].Value.ToString().Trim())
                MessageBox.Show("Không được phép sửa mã phòng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            else if (txtMaPhong.Text == "" || txtTenPhong.Text == "")
            {
                MessageBox.Show("Dữ liệu vừa nhập chưa hợp lệ!", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    DataGridViewRow dr = dgPhongBan.SelectedRows[0];
                    dgPhongBan.BeginEdit(true);

                    dr.Cells["MaPhong"].Value = txtMaPhong.Text.ToUpper();
                    dr.Cells["TenPhong"].Value = txtTenPhong.Text;
                    dgPhongBan.EndEdit();
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
                DataGridViewRow dr = dgPhongBan.SelectedRows[0];
                dgPhongBan.Rows.Remove(dr);

            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                daPhongBan.Update(ds, "tblPhongBan");
                MessageBox.Show("Đã lưu!", "Thông báo");
                dgPhongBan.Refresh();
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
                ds.Tables["tblPhongBan"].RejectChanges();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtMaPhong.ResetText();
            txtTenPhong.ResetText();
            txtMaPhong.Focus();
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

            DataTable dt = (DataTable)dgPhongBan.DataSource;
            SqlDataAdapter da = new SqlDataAdapter();

            string sQueryMaNV = "Select * from PhongBan where MaPhong like '%" + txtTimKiem.Text + "%' OR TenPhong like N'%" + txtTimKiem.Text + "%'";
            SqlCommand cmTimMaNV = new SqlCommand(sQueryMaNV, pt.KetNoi());
            da.SelectCommand = cmTimMaNV;
            dt.Clear();
            da.Fill(dt);
            dgPhongBan.DataSource = dt;
        }
    }
}
