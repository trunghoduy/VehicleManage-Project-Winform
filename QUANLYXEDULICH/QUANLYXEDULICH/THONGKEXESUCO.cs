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
    public partial class THONGKEXESUCO : Form
    {
        public THONGKEXESUCO()
        {
            InitializeComponent();
        }

        private void THONGKEXESUCO_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet2.SUCO' table. You can move, or remove it, as needed.
            this.SUCOTableAdapter.Fill(this.DataSet2.SUCO);

            this.reportViewer1.RefreshReport();
        }
    }
}
