using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static QRCoder.QRCodeGenerator;

using System.Windows.Forms;

using System.IO;

using System.Drawing.Imaging;
namespace QuanLiNhanSu
{
    public partial class Tao_MaQR : Form
    {
        public Tao_MaQR()
        {
            InitializeComponent();
        }

        private void Tao_MaQR_Load(object sender, EventArgs e)
        {
        }

        /*
         ECC – Error Correction Capability: là 1 phần dữ liệu dùng để sửa lỗi xảy ra trong quá trình quét QR code. 
        Tăng tỉ lệ này thì khả năng sửa lỗi tốt hơn tuy nhiên dung lượng lại chiếm nhiều hơn. Gồm các mức:
            – Level L: 7%
            – Level M: 15%
            – Level Q: 25%
            – Level H: 30%
        --> Đoạn code nếu muốn người dùng tự chọn mức độ ECC:
        combobox cbLevel để chứa cái level
            QRCodeGenerator.ECCLevel eccLevel = (QRCodeGenerator.ECCLevel)cbLevel.SelectedIndex;
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(textBoxQRCode.Text, eccLevel);
         */

        //Chuyển hình thành file bitmap

       private Bitmap getIconBitmap()
        {
          
          Bitmap img = null;
            if (File.Exists(DuongDan_Icon.Text))
            {
                try
                {
                    img = new Bitmap(DuongDan_Icon.Text);
                }
                catch (Exception)
                {
                }
            }
            return img;
        }

        //Chọn Icon
        private void selectIconBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDlg = new OpenFileDialog();
            openFileDlg.Title = "Chọn icon";
            openFileDlg.Multiselect = false; //Không cho chọn nhiều file 
            DialogResult dr = openFileDlg.ShowDialog();
            if (dr == DialogResult.OK)
            {
                DuongDan_Icon.Text = openFileDlg.FileName;
            }
            else
            {
                DuongDan_Icon.Text = "";
            }
        }

        private void btnEncode_Click(object sender, EventArgs e)
        {


            //Cấp vùng nhớ để tạo mã bằng class QRCodeGenerator nằm trong thư viện QRCoder
            QRCodeGenerator taoMaQR = new QRCodeGenerator();

            //Tạo mã bằng CreateQrCode
            QRCoder.QRCode qrCode = new QRCoder.QRCode(taoMaQR.CreateQrCode(txtND.Text, ECCLevel.H));

            int iconSize = (int)numIconSize.Value; //Kích thước Icon 
            int padding = (int)numPadding.Value; //Độ rộng bên ngoài cho Icon

            picMaQR.Image = qrCode.GetGraphic(20, Color.Black, Color.White, getIconBitmap(), iconSize, padding);  //Tạo hình ảnh mã gán vào picturebox
        }

        private void selectIconBtn_Click_1(object sender, EventArgs e)
        {
            //Cấp vùng nhớ để tạo mã bằng class QRCodeGenerator nằm trong thư viện QRCoder
            QRCodeGenerator taoMaQR = new QRCodeGenerator();

            //Tạo mã bằng CreateQrCode
            QRCoder.QRCode qrCode = new QRCoder.QRCode(taoMaQR.CreateQrCode(txtND.Text, ECCLevel.H));

            int iconSize = (int)numIconSize.Value; //Kích thước Icon 
            int padding = (int)numPadding.Value; //Độ rộng bên ngoài cho Icon

            picMaQR.Image = qrCode.GetGraphic(20, Color.Black, Color.White, getIconBitmap(), iconSize, padding);  //Tạo hình ảnh mã gán vào picturebox
        }

        private void picMaQR_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void numPadding_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void numIconSize_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void DuongDan_Icon_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtND_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
    

