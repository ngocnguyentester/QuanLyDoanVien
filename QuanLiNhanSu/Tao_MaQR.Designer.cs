namespace QuanLiNhanSu
{
    partial class Tao_MaQR
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Tao_MaQR));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnEncode = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.numPadding = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.numIconSize = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.selectIconBtn = new System.Windows.Forms.Button();
            this.DuongDan_Icon = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtND = new System.Windows.Forms.TextBox();
            this.picMaQR = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.numPadding)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numIconSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMaQR)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(223, 56);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(263, 22);
            this.textBox1.TabIndex = 59;
            // 
            // btnEncode
            // 
            this.btnEncode.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnEncode.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEncode.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEncode.Location = new System.Drawing.Point(77, 598);
            this.btnEncode.Margin = new System.Windows.Forms.Padding(4);
            this.btnEncode.Name = "btnEncode";
            this.btnEncode.Size = new System.Drawing.Size(409, 64);
            this.btnEncode.TabIndex = 58;
            this.btnEncode.Text = "&Tạo Mã";
            this.btnEncode.UseVisualStyleBackColor = false;
            this.btnEncode.Click += new System.EventHandler(this.btnEncode_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label4.Location = new System.Drawing.Point(100, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(345, 25);
            this.label4.TabIndex = 57;
            this.label4.Text = "TẠO MÃ QR CHO ĐOÀN VIÊN";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label7.Location = new System.Drawing.Point(61, 56);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 25);
            this.label7.TabIndex = 56;
            this.label7.Text = "Nội dung:";
            // 
            // numPadding
            // 
            this.numPadding.Location = new System.Drawing.Point(384, 175);
            this.numPadding.Margin = new System.Windows.Forms.Padding(4);
            this.numPadding.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numPadding.Name = "numPadding";
            this.numPadding.Size = new System.Drawing.Size(102, 22);
            this.numPadding.TabIndex = 55;
            this.numPadding.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label5.Location = new System.Drawing.Point(61, 175);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(309, 25);
            this.label5.TabIndex = 54;
            this.label5.Text = "Độ rộng bên ngoài Icon (cell):";
            // 
            // numIconSize
            // 
            this.numIconSize.Location = new System.Drawing.Point(223, 132);
            this.numIconSize.Margin = new System.Windows.Forms.Padding(4);
            this.numIconSize.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.numIconSize.Name = "numIconSize";
            this.numIconSize.Size = new System.Drawing.Size(263, 22);
            this.numIconSize.TabIndex = 53;
            this.numIconSize.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Location = new System.Drawing.Point(61, 132);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 25);
            this.label3.TabIndex = 52;
            this.label3.Text = "Icon size (%)";
            // 
            // selectIconBtn
            // 
            this.selectIconBtn.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectIconBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.selectIconBtn.Location = new System.Drawing.Point(394, 88);
            this.selectIconBtn.Margin = new System.Windows.Forms.Padding(4);
            this.selectIconBtn.Name = "selectIconBtn";
            this.selectIconBtn.Size = new System.Drawing.Size(92, 31);
            this.selectIconBtn.TabIndex = 51;
            this.selectIconBtn.Text = "Chọn";
            this.selectIconBtn.UseVisualStyleBackColor = true;
            // 
            // DuongDan_Icon
            // 
            this.DuongDan_Icon.Location = new System.Drawing.Point(223, 94);
            this.DuongDan_Icon.Margin = new System.Windows.Forms.Padding(4);
            this.DuongDan_Icon.Name = "DuongDan_Icon";
            this.DuongDan_Icon.Size = new System.Drawing.Size(165, 22);
            this.DuongDan_Icon.TabIndex = 50;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Location = new System.Drawing.Point(61, 91);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 25);
            this.label2.TabIndex = 49;
            this.label2.Text = "Icon:";
            // 
            // txtND
            // 
            this.txtND.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtND.Location = new System.Drawing.Point(242, 59);
            this.txtND.Margin = new System.Windows.Forms.Padding(4);
            this.txtND.Name = "txtND";
            this.txtND.Size = new System.Drawing.Size(0, 22);
            this.txtND.TabIndex = 47;
            // 
            // picMaQR
            // 
            this.picMaQR.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picMaQR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picMaQR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picMaQR.Location = new System.Drawing.Point(77, 205);
            this.picMaQR.Margin = new System.Windows.Forms.Padding(4);
            this.picMaQR.Name = "picMaQR";
            this.picMaQR.Size = new System.Drawing.Size(409, 369);
            this.picMaQR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picMaQR.TabIndex = 48;
            this.picMaQR.TabStop = false;
            // 
            // Tao_MaQR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 675);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnEncode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.numPadding);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numIconSize);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.selectIconBtn);
            this.Controls.Add(this.DuongDan_Icon);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.picMaQR);
            this.Controls.Add(this.txtND);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Tao_MaQR";
            this.Text = "TaoQRChoDV";
            ((System.ComponentModel.ISupportInitialize)(this.numPadding)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numIconSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMaQR)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnEncode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numPadding;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numIconSize;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button selectIconBtn;
        private System.Windows.Forms.TextBox DuongDan_Icon;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox picMaQR;
        private System.Windows.Forms.TextBox txtND;
    }
}