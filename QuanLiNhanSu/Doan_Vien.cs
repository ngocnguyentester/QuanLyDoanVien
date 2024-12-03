using QuanLiNhanSu.DUNGCHUNG;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace QuanLiNhanSu
{
    public partial class Doan_Vien : Form
    {
        public Doan_Vien()
        {
            InitializeComponent();
        }

        PhuongThuc pt = new PhuongThuc();

        DataSet ds = new DataSet("dsQLNS");
        SqlDataAdapter daChucVu;
        SqlDataAdapter daNhanVien;
        SqlDataAdapter daDanToc;
        SqlDataAdapter daPhongBan;

        private void btnThem_Click(object sender, EventArgs e)
        {
            bool check_MaNV = true;
            bool check_SDT = true;
            bool check_CCCD = true;

            for (int i = 0; i < dgNhanVien.RowCount - 1; i++)
            {
                if (txtMaNV.Text.ToUpper() == dgNhanVien.Rows[i].Cells["MaNV"].Value.ToString().Trim())
                    check_MaNV = false;
                else if (txtSDT.Text == dgNhanVien.Rows[i].Cells["DienThoai"].Value.ToString().Trim())
                    check_SDT = false;
                else if (txtCCCD.Text == dgNhanVien.Rows[i].Cells["CCCD"].Value.ToString().Trim())
                    check_CCCD = false;

            }
            if (check_MaNV == false)
                MessageBox.Show("Mã đoàn viên bị trùng trong danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (check_SDT == false)
                MessageBox.Show("Số điện thoại bị trùng trong danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (check_CCCD == false)
                MessageBox.Show("CCCD bị trùng trong danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            else if (txtTenNV.Text == "" || txtMaNV.Text == "")
                MessageBox.Show("Chưa nhập tên hoặc mã đoàn viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            else if (radNam.Checked == false && radNu.Checked == false)
                MessageBox.Show("Chưa chọn giới tính!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            
            else if (cmbDanToc.SelectedItem == null)
                MessageBox.Show("Chưa chọn dân tộc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            else if (txtSDT.Text == "")
                MessageBox.Show("Chưa nhập số điện thoại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (txtSDT.Text.Length != 10)
                MessageBox.Show("Số điện thoại nhập đủ 10 số! Hãy kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            else if (txtCCCD.Text == "")
                MessageBox.Show("Chưa nhập CMDD hoặc CCCD!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (txtCCCD.Text.Length != 12)
                MessageBox.Show("CCCD nhập đủ 12 số! Hãy kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            else if (txtDiaChi.Text == "")
                MessageBox.Show("Chưa nhập địa chỉ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            else if (txtQueQuan.Text == "")
                MessageBox.Show("Chưa nhập quê quán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            else if (txtEmail.Text == "")
                MessageBox.Show("Chưa nhập email!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            else if (cmbHonNhan.SelectedItem == null)
                MessageBox.Show("Chưa chọn tình trạng hôn nhân!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            else if (cmbTrangThai.SelectedItem == null)
                MessageBox.Show("Chưa chọn trạng thái tại trường!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            else if (cmbTenChucVu.SelectedItem == null)
                MessageBox.Show("Chưa chọn chức danh!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            
            else
            {
                
                // Thêm 1 dòng vào bảng tblNhanVien
                DataRow row = ds.Tables["tblNhanVien"].NewRow();
                row["MaNV"] = txtMaNV.Text.ToUpper();
                row["TenNV"] = txtTenNV.Text;
                row["NgaySinh"] = dtpNgaySinh.Text;
                if (radNu.Checked == true)
                    row["GioiTinh"] = "Nữ";
                else
                    row["GioiTinh"] = "Nam";
                row["MaDanToc"] = cmbDanToc.SelectedValue;
                row["DienThoai"] = txtSDT.Text;
                row["CCCD"] = txtCCCD.Text;
                row["DiaChi"] = txtDiaChi.Text;
                row["QueQuan"] = txtQueQuan.Text;
                row["Email"] = txtEmail.Text;
                row["HonNhan"] = cmbHonNhan.SelectedItem;
                row["TrangThai"] = cmbTrangThai.SelectedItem;
                row["MaChucVu"] = cmbMaChucVu.SelectedValue;
                row["TenChucVu"] = cmbTenChucVu.SelectedValue;
                row["MaPhong"] = cmbMaPhongBan.SelectedValue;
                row["TenPhong"] = cmbTenPhongBan.SelectedValue;
                ds.Tables["tblNhanVien"].Rows.Add(row);

                txtMaNV.ResetText();
                txtTenNV.ResetText();
                radNam.Checked = false;
                radNu.Checked = false;
                txtSDT.ResetText();
                txtCCCD.ResetText();
                txtDiaChi.ResetText();
                txtQueQuan.ResetText();
                txtEmail.ResetText();
                txtMaNV.Focus();
            }
        }

        //Nút Đóng
        private void btnDong_Click(object sender, EventArgs e)
        {
            
            DialogResult dialog = new DialogResult();
            dialog = MessageBox.Show("Bạn có muốn thoát chương trình?", "Thông báo",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialog == DialogResult.OK)
                this.Close();
        }

        //Nút lưu
        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                daNhanVien.Update(ds, "tblNhanVien");
                MessageBox.Show("Đã lưu!", "Thông báo");
                dgNhanVien.Refresh();
                //HienThiDatagrid();
            }
            catch
            {
                return;
            }
            
        }

        //Nút sửa
        private void btnSua_Click(object sender, EventArgs e)
        {

            if (txtMaNV.Text != dgNhanVien.SelectedRows[0].Cells["MaNV"].Value.ToString().Trim())
                MessageBox.Show("Không được phép sửa mã nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            else if (txtTenNV.Text == "" || txtMaNV.Text == "")
                MessageBox.Show("Chưa nhập tên hoặc mã nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            else if (radNam.Checked == false && radNu.Checked == false)
                MessageBox.Show("Chưa chọn giới tính!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            else if (cmbDanToc.SelectedValue == null)
                MessageBox.Show("Chưa chọn dân tộc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            else if (txtSDT.Text == "")
                MessageBox.Show("Chưa nhập số điện thoại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (txtSDT.Text.Length != 10)
                MessageBox.Show("Số điện thoại nhập đủ 10 số! Hãy kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            else if (txtCCCD.Text == "")
                MessageBox.Show("Chưa nhập CCCCD!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (txtCCCD.Text.Count() != 12)
                MessageBox.Show("CCCD nhập đủ 12 số! Hãy kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            else if (txtDiaChi.Text == "")
                MessageBox.Show("Chưa nhập địa chỉ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            else if (txtQueQuan.Text == "")
                MessageBox.Show("Chưa nhập quê quán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            else if (txtEmail.Text == "")
                MessageBox.Show("Chưa nhập email!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            else if (cmbHonNhan.SelectedItem == null)
                MessageBox.Show("Chưa chọn tình trạng hôn nhân!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            else if (cmbTrangThai.SelectedItem == null)
                MessageBox.Show("Chưa chọn trạng thái làm việc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            else if (cmbTenChucVu.SelectedValue == null)
                MessageBox.Show("Chưa chọn chức vụ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            else
            {
                try
                {
                    DataGridViewRow dr = dgNhanVien.SelectedRows[0];
                    dgNhanVien.BeginEdit(true);

                    dr.Cells["MaNV"].Value = txtMaNV.Text;
                    dr.Cells["TenNV"].Value = txtTenNV.Text;
                    dr.Cells["NgaySinh"].Value = dtpNgaySinh.Text;
                    if (radNam.Checked == true)
                        dr.Cells["GioiTinh"].Value = "Nam";
                    else
                        dr.Cells["GioiTinh"].Value = "Nữ";
                    dr.Cells["MaDanToc"].Value = cmbDanToc.SelectedValue;
                    dr.Cells["DienThoai"].Value = txtSDT.Text;
                    dr.Cells["CCCD"].Value = txtCCCD.Text;
                    dr.Cells["DiaChi"].Value = txtDiaChi.Text;
                    dr.Cells["QueQuan"].Value = txtQueQuan.Text;
                    dr.Cells["Email"].Value = txtEmail.Text;
                    dr.Cells["HonNhan"].Value = cmbHonNhan.SelectedItem;
                    dr.Cells["TrangThai"].Value = cmbTrangThai.SelectedItem;
                    dr.Cells["MaPhong"].Value = cmbMaPhongBan.SelectedValue;
                    dr.Cells["MaChucVu"].Value = cmbMaChucVu.SelectedValue;
                    dgNhanVien.EndEdit();
                    MessageBox.Show("Đã cập nhật!", "Thông báo");
                }
                catch { }
               
                
            }

        }

        //Nút hủy
        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult dialog = new DialogResult();
            dialog = MessageBox.Show("Bạn có chắc chắn muốn hủy tác vụ?", "Thông báo",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialog == DialogResult.OK)
            {
                ds.Tables["tblNhanVien"].RejectChanges();
            }
        }

        //Nút reset
        private void btnReset_Click(object sender, EventArgs e)
        {
            txtMaNV.ResetText();
            txtTenNV.ResetText();
            radNam.Checked = false;
            radNu.Checked = false;
            txtSDT.ResetText();
            txtCCCD.ResetText();
            txtDiaChi.ResetText();
            txtQueQuan.ResetText();
            txtEmail.ResetText();
            txtMaNV.Focus();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnHuy.Enabled = true;
            
        }

        //Nút xóa
        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dialog = new DialogResult();
            dialog = MessageBox.Show("Bạn có chắc chắn muốn xóa dòng này?", "Thông báo",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialog == DialogResult.OK)
            {
                DataGridViewRow dr = dgNhanVien.SelectedRows[0];
                dgNhanVien.Rows.Remove(dr);

            }

        }

        //Form load
        private void Nhan_Vien_Load(object sender, EventArgs e)
        {            

            // check quyền
            if (HeThong.QuyenHan != "admin")
            {
                btnThem.Visible = false;
                btnSua.Visible = false;
                btnXoa.Visible = false;
            }

            //----------- Gán combo box
            //Hôn nhân
            cmbHonNhan.Items.Add("Độc thân");
            cmbHonNhan.Items.Add("Đã kết hôn");
            cmbHonNhan.SelectedItem = "Độc thân";
            //Trạng thái
            cmbTrangThai.Items.Add("Đang học tại trường");
            cmbTrangThai.Items.Add("Đã ra trường");
            cmbTrangThai.SelectedItem = "Đang học tại trường";

            //Lọc
            cmbLoc.Items.Add("Mã đoàn viên");
            cmbLoc.Items.Add("Tên đoàn viên");
            cmbLoc.Items.Add("Lớp/Chi đoàn");

            cmbLoc.SelectedItem = "Mã đoàn viên";

            //----------- Dữ liệu combobox
            // Dữ liệu combobox Dân tộc
            string sQueryDanToc = @"select * from DanToc";
            daDanToc = new SqlDataAdapter(sQueryDanToc, pt.KetNoi());
            daDanToc.Fill(ds, "tblDanToc");
            cmbDanToc.DataSource = ds.Tables["tblDanToc"];
            cmbDanToc.DisplayMember = "TenDanToc";
            cmbDanToc.ValueMember = "MaDanToc";

            // Dữ liệu combobox Phòng ban
            string sQueryPhongBan = @"select * from PhongBan";
            daPhongBan = new SqlDataAdapter(sQueryPhongBan, pt.KetNoi());
            daPhongBan.Fill(ds, "tblPhongBan");
            cmbMaPhongBan.DataSource = ds.Tables["tblPhongBan"];
            cmbMaPhongBan.DisplayMember = "MaPhong";
            cmbMaPhongBan.ValueMember = "MaPhong";

            cmbTenPhongBan.DataSource = ds.Tables["tblPhongBan"];
            cmbTenPhongBan.DisplayMember = "TenPhong";
            cmbTenPhongBan.ValueMember = "TenPhong";

            // Dữ liệu combobox Chức vụ
            string sQueryChucVu = @"select * from ChucVu";
            daChucVu = new SqlDataAdapter(sQueryChucVu, pt.KetNoi());
            daChucVu.Fill(ds, "tblChucVu");

            cmbMaChucVu.DataSource = ds.Tables["tblChucVu"];
            cmbMaChucVu.DisplayMember = "MaChucVu";
            cmbMaChucVu.ValueMember = "MaChucVu";

            cmbTenChucVu.DataSource = ds.Tables["tblChucVu"];
            cmbTenChucVu.DisplayMember = "TenChucVu";
            cmbTenChucVu.ValueMember = "TenChucVu";

            HienThiDatagrid();


            //----------- Command Thêm nhân viên
            string sThemNV = @"insert into NhanVien values(@MaNV, @TenNV, @NgaySinh, @GioiTinh,
            @MaDanToc, @DienThoai, @CCCD, @DiaChi, @QueQuan, @Email, @HonNhan, @TrangThai, @MaPhong, @MaChucVu)";
            SqlCommand cmThemNV = new SqlCommand(sThemNV, pt.KetNoi());
            cmThemNV.Parameters.Add("@MaNV", SqlDbType.Char, 6, "MaNV");
            cmThemNV.Parameters.Add("@TenNV", SqlDbType.NVarChar, 70, "TenNV");
            cmThemNV.Parameters.Add("@NgaySinh", SqlDbType.Date, 10, "NgaySinh");
            cmThemNV.Parameters.Add("@GioiTinh", SqlDbType.NVarChar, 3, "GioiTinh");
            cmThemNV.Parameters.Add("@MaDanToc", SqlDbType.Char, 6, "MaDanToc");
            cmThemNV.Parameters.Add("@DienThoai", SqlDbType.Char, 10, "DienThoai");
            cmThemNV.Parameters.Add("@CCCD", SqlDbType.Char, 12, "CCCD");
            cmThemNV.Parameters.Add("@DiaChi", SqlDbType.NVarChar, 150, "DiaChi");
            cmThemNV.Parameters.Add("@QueQuan", SqlDbType.NVarChar, 50, "QueQuan");
            cmThemNV.Parameters.Add("@Email", SqlDbType.NVarChar, 50, "Email");
            cmThemNV.Parameters.Add("@HonNhan", SqlDbType.NVarChar, 50, "HonNhan");
            cmThemNV.Parameters.Add("@TrangThai", SqlDbType.NVarChar, 50, "TrangThai");
            cmThemNV.Parameters.Add("@MaPhong", SqlDbType.Char, 6, "MaPhong");
            cmThemNV.Parameters.Add("@MaChucVu", SqlDbType.Char, 6, "MaChucVu");

            daNhanVien.InsertCommand = cmThemNV;

            // -----------Command Sửa nhân viên
            string sSuaNV = @"update NhanVien set TenNV=@TenNV, NgaySinh=@NgaySinh, GioiTinh=@GioiTinh,
            MaDanToc=@MaDanToc, DienThoai=@DienThoai, CCCD=@CCCD, DiaChi=@DiaChi, QueQuan=@QueQuan, Email=@Email, HonNhan=@HonNhan,
            TrangThai=@TrangThai, MaPhong=@MaPhong, MaChucVu=@MaChucVu WHERE MaNV=@MaNV";
            SqlCommand cmSuaNV = new SqlCommand(sSuaNV, pt.KetNoi());
            cmSuaNV.Parameters.Add("@MaNV", SqlDbType.Char, 6, "MaNV");
            cmSuaNV.Parameters.Add("@TenNV", SqlDbType.NVarChar, 70, "TenNV");
            cmSuaNV.Parameters.Add("@NgaySinh", SqlDbType.Date, 10, "NgaySinh");
            cmSuaNV.Parameters.Add("@GioiTinh", SqlDbType.NVarChar, 3, "GioiTinh");
            cmSuaNV.Parameters.Add("@MaDanToc", SqlDbType.Char, 6, "MaDanToc");
            cmSuaNV.Parameters.Add("@DienThoai", SqlDbType.Char, 10, "DienThoai");
            cmSuaNV.Parameters.Add("@CCCD", SqlDbType.Char, 12, "CCCD");
            cmSuaNV.Parameters.Add("@DiaChi", SqlDbType.NVarChar, 150, "DiaChi");
            cmSuaNV.Parameters.Add("@QueQuan", SqlDbType.NVarChar, 50, "QueQuan");
            cmSuaNV.Parameters.Add("@Email", SqlDbType.NVarChar, 50, "Email");
            cmSuaNV.Parameters.Add("@HonNhan", SqlDbType.NVarChar, 50, "HonNhan");
            cmSuaNV.Parameters.Add("@TrangThai", SqlDbType.NVarChar, 50, "TrangThai");
            cmSuaNV.Parameters.Add("@MaPhong", SqlDbType.Char, 6, "MaPhong");
            cmSuaNV.Parameters.Add("@MaChucVu", SqlDbType.Char, 6, "MaChucVu");

            daNhanVien.UpdateCommand = cmSuaNV;

            // -----------Command Xóa nhân viên
            string sXoaNV = @"delete from NhanVien where MaNV=@MaNV";
            SqlCommand cmXoaNV = new SqlCommand(sXoaNV, pt.KetNoi());
            cmXoaNV.Parameters.Add("@MaNV", SqlDbType.Char, 6, "MaNV");
            daNhanVien.DeleteCommand = cmXoaNV;
/*
            if (dgNhanVien == null)
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
            }   */ 
        }

        //Khi tìm kiếm -> không sửa, xóa, thêm, hủy
        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = false;
            btnHuy.Enabled = false;

            DataTable dt = (DataTable)dgNhanVien.DataSource;
            SqlDataAdapter da = new SqlDataAdapter();

            if (cmbLoc.SelectedItem.ToString() == "Mã đoàn viên")
            {
                string sQueryMaNV = "SELECT * FROM NhanVien WHERE MaNV like '%" + txtTimKiem.Text + "%'";
                SqlCommand cmTimMaNV = new SqlCommand(sQueryMaNV, pt.KetNoi());
                da.SelectCommand = cmTimMaNV;
               
            }
            else if (cmbLoc.SelectedItem.ToString() == "Tên đoàn viên")
            {
                string sQueryTenNV = "SELECT * FROM NhanVien WHERE TenNV like N'%" + txtTimKiem.Text + "%'";
                SqlCommand cmTimTenNV = new SqlCommand(sQueryTenNV, pt.KetNoi());
                da.SelectCommand = cmTimTenNV;
                
            }
            else if (cmbLoc.SelectedItem.ToString() == "Lớp/Chi đoàn")
            {
                string sQueryPhong = "select n.*, pb.TenPhong from NhanVien n, PhongBan pb where n.MaPhong = pb.MaPhong AND (n.MaPhong like N'%" + txtTimKiem.Text + "%' OR pb.TenPhong like N'%" + txtTimKiem.Text + "%')";
                SqlCommand cmTimPhong = new SqlCommand(sQueryPhong, pt.KetNoi());
                da.SelectCommand = cmTimPhong;

            }
            /*cmbLoc.Items.Add("Mã đoàn viên");
            cmbLoc.Items.Add("Tên đoàn viên");
            cmbLoc.Items.Add("Lớp/Chi đoàn");*/

            dt.Clear();
            da.Fill(dt);
            dgNhanVien.DataSource = dt;

        }

        private void HienThiDatagrid()
        {
            //----------- Dữ liệu datagrid Danh sách
            string sQuerryTenPhong = @"select n.*, pb.TenPhong, c.TenChucVu from NhanVien n, PhongBan pb, ChucVu c where n.MaPhong = pb.MaPhong AND n.MaChucVu=c.MaChucVu";
            daNhanVien = new SqlDataAdapter(sQuerryTenPhong, pt.KetNoi());
            daNhanVien.Fill(ds, "tblNhanVien");
            dgNhanVien.DataSource = ds.Tables["tblNhanVien"];

            // Mã nhân viên
            dgNhanVien.Columns["MaNV"].HeaderText = "Mã đoàn viên";
            dgNhanVien.Columns["MaNV"].Width = 100;
            // Tên nhân viên
            dgNhanVien.Columns["TenNV"].HeaderText = "Tên đoàn viên";
            dgNhanVien.Columns["TenNV"].Width = 170;
            // Ngày sinh
            dgNhanVien.Columns["NgaySinh"].HeaderText = "Ngày sinh";
            dgNhanVien.Columns["NgaySinh"].Width = 100;
            // Giới tính
            dgNhanVien.Columns["GioiTinh"].HeaderText = "Giới tính";
            dgNhanVien.Columns["GioiTinh"].Width = 100;
            // Mã dân tộc
            dgNhanVien.Columns["MaDanToc"].HeaderText = "Mã dân tộc";
            dgNhanVien.Columns["MaDanToc"].Width = 100;
            // Điện thoại
            dgNhanVien.Columns["DienThoai"].HeaderText = "Điện thoại";
            dgNhanVien.Columns["DienThoai"].Width = 100;
            // CMND_CCCD
            dgNhanVien.Columns["CCCD"].HeaderText = "CCCD";
            dgNhanVien.Columns["CCCD"].Width = 100;
            // Địa chỉ
            dgNhanVien.Columns["DiaChi"].HeaderText = "Địa chỉ";
            dgNhanVien.Columns["DiaChi"].Width = 100;
            // Quê quán
            dgNhanVien.Columns["QueQuan"].HeaderText = "Quê quán";
            dgNhanVien.Columns["QueQuan"].Width = 100;
            // Email
            dgNhanVien.Columns["Email"].HeaderText = "Email";
            dgNhanVien.Columns["Email"].Width = 170;
            // Hôn nhân
            dgNhanVien.Columns["HonNhan"].HeaderText = "Hôn nhân";
            dgNhanVien.Columns["HonNhan"].Width = 100;
            // Trạng thái
            dgNhanVien.Columns["TrangThai"].HeaderText = "Trạng thái";
            dgNhanVien.Columns["TrangThai"].Width = 100;
            // Mã phòng
            dgNhanVien.Columns["MaPhong"].HeaderText = "Mã lớp/ Mã chi đoàn";
            dgNhanVien.Columns["MaPhong"].Width = 100;
            //// Tên phòng
            dgNhanVien.Columns["TenPhong"].HeaderText = "Tên lớp/ chi đoàn";
            dgNhanVien.Columns["TenPhong"].Width = 200;
            dgNhanVien.Columns["TenPhong"].DisplayIndex = 13;
            // Mã chức vụ
            dgNhanVien.Columns["MaChucVu"].HeaderText = "Mã chức danh";
            dgNhanVien.Columns["MaChucVu"].Width = 100;
            // Ten chức vụ
            dgNhanVien.Columns["TenChucVu"].HeaderText = "Tên chức danh";
            dgNhanVien.Columns["TenChucVu"].Width = 100;

        }

        private void dgNhanVien_Click(object sender, EventArgs e)
        {
            DataGridViewRow dr = dgNhanVien.SelectedRows[0];
            txtMaNV.Text = dr.Cells["MaNV"].Value.ToString();
            txtTenNV.Text = dr.Cells["TenNV"].Value.ToString();
            dtpNgaySinh.Text = dr.Cells["NgaySinh"].Value.ToString();
            if (dr.Cells["GioiTinh"].Value.ToString() == "Nam")
                radNam.Checked = true;
            else
                radNu.Checked = true;
            cmbDanToc.SelectedValue = dr.Cells["MaDanToc"].Value.ToString();
            txtSDT.Text = dr.Cells["DienThoai"].Value.ToString();
            txtCCCD.Text = dr.Cells["CCCD"].Value.ToString();
            txtDiaChi.Text = dr.Cells["DiaChi"].Value.ToString();
            txtQueQuan.Text = dr.Cells["QueQuan"].Value.ToString();
            txtEmail.Text = dr.Cells["Email"].Value.ToString();
            cmbHonNhan.SelectedItem = dr.Cells["HonNhan"].Value.ToString();
            cmbTrangThai.SelectedItem = dr.Cells["TrangThai"].Value.ToString();
            cmbMaPhongBan.SelectedValue = dr.Cells["MaPhong"].Value.ToString();
            cmbMaChucVu.SelectedValue = dr.Cells["MaChucVu"].Value.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Tao_MaQR Tao_MaQR = new Tao_MaQR();
            Tao_MaQR.ShowDialog();
        }
    }
}
