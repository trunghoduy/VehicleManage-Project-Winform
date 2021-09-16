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
    public partial class TIMKIEMTHEOXE : Form
    {
        //chuỗi kết nối
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-12J6D6C;Initial Catalog=QUAN LY XE DU LICH;Integrated Security=True");
        //    SqlConnection conn = null;
        #region kết nối csdl
        private void ketnoicsdl()
        {
            conn.Open();
            string sql = "select * from XE ";  // lay het du lieu trong bang  xe
            SqlCommand com = new SqlCommand(sql, conn); //bat dau truy van
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com); //chuyen du lieu ve
            DataTable dt = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
            da.Fill(dt);  // đổ dữ liệu vào kho
            conn.Close();  // đóng kết nối
            dataGridView1.DataSource = dt; //đổ dữ liệu vào datagridview
        }
        #endregion
        public TIMKIEMTHEOXE()
        {
            InitializeComponent();
        }
        #region thoát form
        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form QUANLYXE = new QUANLYXE();
            QUANLYXE.Show();
        }
        #endregion
        #region Tìm kiếm theo loại xe
        public void Timkiemtheoloai()
        {
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM XE Product WHERE MaLoai LIKE N'%" + txttimkiem.Text + "%'", conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "XE");
            if (ds.Tables["XE"].Rows.Count > 0)
            {
                dataGridView1.DataSource = ds.Tables["XE"];
            }
            else
            {
                MessageBox.Show("Không tìm thấy  xe nào có biển số này!");
                txttimkiem.Text = "";
            }
            conn.Close();
        }
        #endregion
        #region load form
        private void TIMKIEMTHEOXE_Load(object sender, EventArgs e)
        {
            ketnoicsdl();
        }
        #endregion
        #region button tìm kiếm
        private void btntim_Click_1(object sender, EventArgs e)
        {
             Timkiemtheoloai();
        }
        #endregion
        #region button reload
        private void btnreload_Click(object sender, EventArgs e)
        {
            ketnoicsdl();
        }
        #endregion
    }
}
