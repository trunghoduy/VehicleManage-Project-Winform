using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUANLYXEDULICH
{
    public partial class QUANLYXE : Form
    {
        public QUANLYXE()
        {
            InitializeComponent();
        }
        #region thoát form
        private void ThoatToolStripMenuItem_Click(object sender, EventArgs e)
        {

            {
                DialogResult traloi;
                traloi = MessageBox.Show("Bạn có chắc chắn thoát không?", "Trả lời ?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (traloi == DialogResult.OK)
                {
                    Application.Exit();
                }
            }
        }
        #endregion
        #region cập nhật dữ liệu
        private void CapNhatNguoiSuDungToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form CNNGUOIDUNG = new CNNGUOIDUNG();
            CNNGUOIDUNG.Show();
        }
        private void CapNhatKhachToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form CNKHACHHANG = new CNKHACHHANG();
            CNKHACHHANG.Show();
        }

        private void CapNhatLoaiXeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form CNLOAIXE = new CNLOAIXE();
            CNLOAIXE.Show();
        }

        private void CapNhatXeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form CNXE = new CNXE();
            CNXE.Show();
        }

        private void CapNhatGiaoXeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form CNGIAOXE = new CNGIAOXE();
            CNGIAOXE.Show();
        }

        private void CapNhatNhanXeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form CNNHANXE = new CNNHANXE();
            CNNHANXE.Show();
        }

        private void CapNhatHoaDonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form CNHOADON = new CNHOADON();
            CNHOADON.Show();
        }
        private void CapNhatHopDongToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form CNHOPDONG = new CNHOPDONG();
            CNHOPDONG.Show();
        }

        private void CapNhatChiTietHopDongToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form CNCHITIETHOPDONG = new CNCHITIETHOPDONG();
            CNCHITIETHOPDONG.Show();
        }

        private void CapNhatXeSuCoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form CNXESUCO = new CNXESUCO();
            CNXESUCO.Show();
        }
        #endregion
        #region tìm kiếm loại xe
        private void TKtheoloaixeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form TIMKIEMTHEOlOAIXE = new TIMKIEMTHEOlOAIXE();
            TIMKIEMTHEOlOAIXE.Show();
        }

        private void TmKiemTheoXeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form TIMKIEMTHEOXE = new TIMKIEMTHEOXE();
            TIMKIEMTHEOXE.Show();
        }
        #endregion
        #region báo cáo thống kê
        // thống kê
        private void ThongKeHopDongToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form THONGKEHOPDONG = new THONGKEHOPDONG();
            THONGKEHOPDONG.Show();
        }

        private void ThongKeXeSuCoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form THONGKEXESUCO = new THONGKEXESUCO();
            THONGKEXESUCO.Show();
        }

        private void ThongKeKhachHangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form THONGKEKHACHHANG = new THONGKEKHACHHANG();
            THONGKEKHACHHANG.Show();
        }
        #endregion

      
    }
}
