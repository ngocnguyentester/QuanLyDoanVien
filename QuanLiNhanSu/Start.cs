using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiNhanSu
{
    public partial class frmStart : Form
    {
        public frmStart()
        {
            InitializeComponent();
            timer1.Start();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            pgKhoiDongChuongTrinh.PerformStep();
            if (pgKhoiDongChuongTrinh.Value == 100)
            {
                timer1.Stop();
                this.Hide();
                Trang_chu TrangChu = new Trang_chu();
                TrangChu.ShowDialog();
            }
        }

    }
}
