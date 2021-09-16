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
    public partial class THONGKEKHACHHANG : Form
    {
        public THONGKEKHACHHANG()
        {
            InitializeComponent();
        }

        private void THONGKEKHACHHANG_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet3.KHACHHANG' table. You can move, or remove it, as needed.
            this.KHACHHANGTableAdapter.Fill(this.DataSet3.KHACHHANG);

            this.reportViewer1.RefreshReport();
        }
    }
}
