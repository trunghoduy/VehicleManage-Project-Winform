    using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUANLYXEDULICH
{
    public partial class DANGNHAP : Form
    {
        public DANGNHAP()
        {
            InitializeComponent();
        }
        #region button đăng nhập
        private void btnok_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-12J6D6C;Initial Catalog=QUAN LY XE DU LICH;Integrated Security=True");
            string sqlSelect = "select * from USERSYSTEM WHERE Username='" + txbtaikhoan.Text + "'and Password='" + txbmatkhau.Text + "'";
            conn.Open();
            SqlCommand cmd = new SqlCommand(sqlSelect, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read() == true)
            {
                this.Hide();
                Form QUANLYXE = new QUANLYXE();
                QUANLYXE.Show();
            }
            else
            {
                MessageBox.Show("Bạn đăng nhập không thành công!");
                txbtaikhoan.Text = "";
                txbmatkhau.Text = "";
                txbmatkhau.Focus();
            }
        }
        #endregion
        #region button thoát
        private void btnthoat_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Bạn có chắc chắn thoát không?", "Trả lời ?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (traloi == DialogResult.OK)
            {
                //Application.Exit();
                this.Hide();
                Form QUANLYXE = new QUANLYXE();
                QUANLYXE.Show();
            }
        }
        #endregion
        #region show password
        private void cbxhienpass_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxhienpass.Checked)
            {
                txbmatkhau.UseSystemPasswordChar = false;
            }
            else
            {
                txbmatkhau.UseSystemPasswordChar = true;
            }
        }
        #endregion
    }
}
