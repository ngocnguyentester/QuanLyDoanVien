namespace QuanLiNhanSu
{
    partial class DangKyForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DangKyForm));
            this.txbTenDangNhap = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label1 = new System.Windows.Forms.Label();
            this.txbMatKhau = new System.Windows.Forms.TextBox();
            this.dgvAccount = new System.Windows.Forms.DataGridView();
            this.btnXoa = new System.Windows.Forms.Button();
            this.lbThamSo = new System.Windows.Forms.Label();
            this.txtThongTinNguoiDung = new System.Windows.Forms.Label();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.lbQuyenHan = new System.Windows.Forms.Label();
            this.cmbLoaiTK = new System.Windows.Forms.ComboBox();
            this.btnLuu = new System.Windows.Forms.Button();
            this.lbID = new System.Windows.Forms.Label();
            this.numID = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numID)).BeginInit();
            this.SuspendLayout();
            // 
            // txbTenDangNhap
            // 
            this.txbTenDangNhap.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbTenDangNhap.Location = new System.Drawing.Point(240, 100);
            this.txbTenDangNhap.Margin = new System.Windows.Forms.Padding(4);
            this.txbTenDangNhap.Name = "txbTenDangNhap";
            this.txbTenDangNhap.Size = new System.Drawing.Size(306, 34);
            this.txbTenDangNhap.TabIndex = 62;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(49, 105);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 26);
            this.label1.TabIndex = 69;
            this.label1.Text = "Tên tài khoản";
            // 
            // txbMatKhau
            // 
            this.txbMatKhau.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbMatKhau.Location = new System.Drawing.Point(240, 153);
            this.txbMatKhau.Margin = new System.Windows.Forms.Padding(4);
            this.txbMatKhau.Name = "txbMatKhau";
            this.txbMatKhau.PasswordChar = '*';
            this.txbMatKhau.Size = new System.Drawing.Size(306, 34);
            this.txbMatKhau.TabIndex = 68;
            // 
            // dgvAccount
            // 
            this.dgvAccount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAccount.Location = new System.Drawing.Point(21, 312);
            this.dgvAccount.Name = "dgvAccount";
            this.dgvAccount.RowHeadersWidth = 51;
            this.dgvAccount.RowTemplate.Height = 24;
            this.dgvAccount.Size = new System.Drawing.Size(536, 228);
            this.dgvAccount.TabIndex = 66;
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnXoa.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Location = new System.Drawing.Point(299, 248);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(4);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(117, 57);
            this.btnXoa.TabIndex = 65;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // lbThamSo
            // 
            this.lbThamSo.AutoSize = true;
            this.lbThamSo.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbThamSo.Location = new System.Drawing.Point(49, 158);
            this.lbThamSo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbThamSo.Name = "lbThamSo";
            this.lbThamSo.Size = new System.Drawing.Size(99, 26);
            this.lbThamSo.TabIndex = 64;
            this.lbThamSo.Text = "Mật khẩu";
            // 
            // txtThongTinNguoiDung
            // 
            this.txtThongTinNguoiDung.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.txtThongTinNguoiDung.AutoSize = true;
            this.txtThongTinNguoiDung.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtThongTinNguoiDung.Location = new System.Drawing.Point(183, 19);
            this.txtThongTinNguoiDung.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtThongTinNguoiDung.Name = "txtThongTinNguoiDung";
            this.txtThongTinNguoiDung.Size = new System.Drawing.Size(215, 26);
            this.txtThongTinNguoiDung.TabIndex = 63;
            this.txtThongTinNguoiDung.Text = "Thông tin người dùng";
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnSua.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.Location = new System.Drawing.Point(160, 248);
            this.btnSua.Margin = new System.Windows.Forms.Padding(4);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(117, 57);
            this.btnSua.TabIndex = 60;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnThem.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Location = new System.Drawing.Point(21, 248);
            this.btnThem.Margin = new System.Windows.Forms.Padding(4);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(117, 57);
            this.btnThem.TabIndex = 61;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            // 
            // lbQuyenHan
            // 
            this.lbQuyenHan.AutoSize = true;
            this.lbQuyenHan.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbQuyenHan.Location = new System.Drawing.Point(49, 211);
            this.lbQuyenHan.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbQuyenHan.Name = "lbQuyenHan";
            this.lbQuyenHan.Size = new System.Drawing.Size(114, 26);
            this.lbQuyenHan.TabIndex = 59;
            this.lbQuyenHan.Text = "Quyền hạn";
            // 
            // cmbLoaiTK
            // 
            this.cmbLoaiTK.FormattingEnabled = true;
            this.cmbLoaiTK.Location = new System.Drawing.Point(240, 211);
            this.cmbLoaiTK.Name = "cmbLoaiTK";
            this.cmbLoaiTK.Size = new System.Drawing.Size(306, 24);
            this.cmbLoaiTK.TabIndex = 70;
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnLuu.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.Location = new System.Drawing.Point(438, 248);
            this.btnLuu.Margin = new System.Windows.Forms.Padding(4);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(117, 57);
            this.btnLuu.TabIndex = 71;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = false;
            // 
            // lbID
            // 
            this.lbID.AutoSize = true;
            this.lbID.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbID.Location = new System.Drawing.Point(49, 54);
            this.lbID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbID.Name = "lbID";
            this.lbID.Size = new System.Drawing.Size(36, 26);
            this.lbID.TabIndex = 73;
            this.lbID.Text = "ID";
            // 
            // numID
            // 
            this.numID.Location = new System.Drawing.Point(240, 54);
            this.numID.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numID.Name = "numID";
            this.numID.ReadOnly = true;
            this.numID.Size = new System.Drawing.Size(306, 22);
            this.numID.TabIndex = 74;
            this.numID.TabStop = false;
            // 
            // DangKyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 552);
            this.Controls.Add(this.numID);
            this.Controls.Add(this.lbID);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.cmbLoaiTK);
            this.Controls.Add(this.txbTenDangNhap);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txbMatKhau);
            this.Controls.Add(this.dgvAccount);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.lbThamSo);
            this.Controls.Add(this.txtThongTinNguoiDung);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.lbQuyenHan);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DangKyForm";
            this.Text = "LoginForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numID)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txbTenDangNhap;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbMatKhau;
        private System.Windows.Forms.DataGridView dgvAccount;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Label lbThamSo;
        private System.Windows.Forms.Label txtThongTinNguoiDung;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Label lbQuyenHan;
        private System.Windows.Forms.ComboBox cmbLoaiTK;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Label lbID;
        private System.Windows.Forms.NumericUpDown numID;
    }
}