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
    public partial class THONGKEHOPDONG : Form
    {
        public THONGKEHOPDONG()
        {
            InitializeComponent();
        }

        private void THONGKEHOPDONG_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet1.HOPDONG' table. You can move, or remove it, as needed.
            this.HOPDONGTableAdapter.Fill(this.DataSet1.HOPDONG);

            this.reportViewer1.RefreshReport();
        }
    }
}
