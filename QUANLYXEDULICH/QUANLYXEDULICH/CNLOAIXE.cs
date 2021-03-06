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
    public partial class CNLOAIXE : Form
    {
        static string path = Application.StartupPath;
        string strConn = @"Data Source=DESKTOP-12J6D6C;Initial Catalog=QUAN LY XE DU LICH;Integrated Security=True";
        // Tạo đối tượng kết nối
        SqlConnection conn = null;
        //doi tuong de dua dữ kiệu vào DataTable 
        SqlDataAdapter da = null;
        //Tạo đói tượng hiển thị lên form
        DataTable dt = null;
        #region kết nối csdl
        private void ketnoicsdl()
        {
            // Khởi động kết nối 
            conn = new SqlConnection(strConn);
            string sql = "select * from LOAIXE ";  // lay het du lieu trong bang loai xe
            SqlCommand com = new SqlCommand(sql, conn); //bat dau truy van
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com); //chuyen du lieu ve
            DataTable dt = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
            da.Fill(dt);  // đổ dữ liệu vào kho
            conn.Close();  // đóng kết nối
            dataGridView1.DataSource = dt; //đổ dữ liệu vào datagridview
        }
        #endregion
        public CNLOAIXE()
        {
            InitializeComponent();
        }
        #region button thoát form
        private void btnthoat_Click(object sender, EventArgs e)
        {
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
        }
        #endregion
        #region load form
        private void CNLOAIXE_Load(object sender, EventArgs e)
        {
            ketnoicsdl();
        }
        #endregion
        #region load lại form
        public void loadData()
        {
            //khởi động kết nối
            conn = new SqlConnection(strConn);
            // chuyển dữ liệu lên database từ đt
            da = new SqlDataAdapter("select * from LOAIXE ", conn);
            dt = new DataTable();
            dt.Clear();
            da.Fill(dt);
            dataGridView1.DataSource = dt; //đổ dữ liệu vào datagridview
              //xóa dữ liệu trong các ô
            this.tbxMaLoaiXe.ResetText();
            this.tbxLoaiXe.ResetText();
            this.tbxSoLuongCho.ResetText();
            this.tbxSoLuongXe.ResetText();
            //không thao tác trên các nút lưu/hủy
            this.btnLuu.Enabled = false;
            this.btnHuy.Enabled = false;
            //cho thao tác thêm , sửa, xóa,thoát
            this.btnThem.Enabled = true;
            this.btnSua.Enabled = true;
            this.btnXoa.Enabled = true;
            this.btnthoat.Enabled = true;
        }
        #endregion
        #region Button hủy thông tin
        private void btnHuy_Click(object sender, EventArgs e)
        {
            //xóa dữ liệu trng các ô
            this.tbxLoaiXe.ResetText();
            this.tbxMaLoaiXe.ResetText();
            this.tbxSoLuongCho.ResetText();
            this.tbxSoLuongXe.ResetText();
            //Đóng các chức năng
            this.btnLuu.Enabled = false;
            this.btnHuy.Enabled = false;
            // mở một số chức năng
            this.btnSua.Enabled = true;
            this.btnXoa.Enabled = true;
            this.btnthoat.Enabled = true;
            this.btnThem.Enabled = true;
        }
#endregion
        #region Button thêm thông tin
        bool them;
        private void btnThem_Click(object sender, EventArgs e)
        {
            them = true;
            //xóa dữ liệu trng các ô
            this.tbxLoaiXe.ResetText();
            this.tbxMaLoaiXe.ResetText();
            this.tbxSoLuongCho.ResetText();
            this.tbxSoLuongXe.ResetText();
            //Đóng các chức năng
            this.btnLuu.Enabled = true;
            this.btnHuy.Enabled = true;
            // mở một số chức năng
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnthoat.Enabled = false;
        }
#endregion
        #region Button sửa thông tin
        private void btnSua_Click(object sender, EventArgs e)
        {
            them = false;
            if (dataGridView1.Rows.Count <= 1)
            {
                MessageBox.Show("không có dữ liệu sữa!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Focus();
            }
            else
            {
                int r = dataGridView1.CurrentCell.RowIndex;
                this.tbxMaLoaiXe.Text = dataGridView1.Rows[r].Cells[0].Value.ToString();
                this.tbxLoaiXe.Text = dataGridView1.Rows[r].Cells[1].Value.ToString();
                this.tbxSoLuongCho.Text = dataGridView1.Rows[r].Cells[2].Value.ToString();
                this.tbxSoLuongXe.Text = dataGridView1.Rows[r].Cells[3].Value.ToString();
               
                //Đóng các chức năng
                this.btnLuu.Enabled = true;
                this.btnHuy.Enabled = true;
                // mở một số chức năng
                this.btnSua.Enabled = false;
                this.btnXoa.Enabled = false;
                this.btnthoat.Enabled = false;
                this.btnThem.Enabled = false;
            }
        }
#endregion
        #region Button xóa thông tin
        private void btnXoa_Click(object sender, EventArgs e)
        {
            conn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                if (dataGridView1.Rows.Count <= 1)
                {
                    MessageBox.Show("Không có dữ liệu để xóa !", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Focus();
                }
                else
                {
                    int r = dataGridView1.CurrentCell.RowIndex;
                    this.tbxMaLoaiXe.Text = dataGridView1.Rows[r].Cells[0].Value.ToString();
                    this.tbxLoaiXe.Text = dataGridView1.Rows[r].Cells[1].Value.ToString();
                    this.tbxSoLuongCho.Text = dataGridView1.Rows[r].Cells[2].Value.ToString();
                    this.tbxSoLuongXe.Text = dataGridView1.Rows[r].Cells[3].Value.ToString();
                    cmd.CommandText = System.String.Concat("delete from LOAIXE where  MaLoai='" + this.tbxMaLoaiXe.Text + "' ");
                    cmd.CommandType = CommandType.Text;
                    DialogResult traloi;
                    traloi = MessageBox.Show("Bạn có chắc chắn muốn xóa người dùng không?", "Trả lời ?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (traloi == DialogResult.OK)
                    {
                        //thuc hien cau lenh sql
                        cmd.ExecuteNonQuery();
                        loadData();
                        MessageBox.Show("Xóa thành công!", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Lỗi :Xóa không thành công!");
            }
            conn.Close();
        }
#endregion
        #region button lƯu thông tin
        private void btnLuu_Click(object sender, EventArgs e)

        { 
             conn.Open();
            if (them)
            {
                try
                {
                    if (tbxMaLoaiXe.Text.ToString() == "")
                    {
                        MessageBox.Show("Bạn chưa nhập mã loại xe hoặc tồn tại, nhập lại !", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbxMaLoaiXe.Focus();
                    }
                    else if (tbxLoaiXe.Text.ToString() == "")
                    {
                        MessageBox.Show("Bạn chưa nhập loại xe hoặc tồn tại, nhập lại !", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbxLoaiXe.Focus();
                    }
                    else if (tbxSoLuongCho.Text.ToString() == "")
                    {
                        MessageBox.Show("Bạn chưa nhập số lượng chổ ngồi hoặc tồn tại, nhập lại !", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbxSoLuongCho.Focus();
                    }
                    else if (tbxSoLuongXe.Text.ToString() == "")
                    {
                        MessageBox.Show("Bạn chưa nhập số lượng xe hoặc tồn tại, nhập lại !", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbxSoLuongXe.Focus();
                    }
                    else
                    {
                        // thực hiện lệnh 
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = System.String.Concat("insert into LOAIXE values(" + "N'" + this.tbxMaLoaiXe.Text.ToString() + "'," + "N'" + this.tbxLoaiXe.Text.ToString() + "',N'"
                                                                + this.tbxSoLuongCho.Text.ToString() + "',N'" + this.tbxSoLuongXe.Text.ToString() + "')");
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                        loadData();
                        MessageBox.Show("Đã thêm thành công", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                catch (SqlException)
                {
                    MessageBox.Show("Lỗi: Thêm không thành công", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.tbxMaLoaiXe.Focus();
                }
            }
            if (!them)
            {
                try
                {
                    if (tbxMaLoaiXe.Text.ToString() == "")
                    {
                        MessageBox.Show("Bạn chưa nhập mã loại xe hoặc tồn tại, nhập lại !", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbxMaLoaiXe.Focus();
                    }
                    else if (tbxLoaiXe.Text.ToString() == "")
                    {
                        MessageBox.Show("Bạn chưa nhập loại xe hoặc tồn tại, nhập lại !", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbxLoaiXe.Focus();
                    }
                    else if (tbxSoLuongCho.Text.ToString() == "")
                    {
                        MessageBox.Show("Bạn chưa nhập số lượng chổ ngồi hoặc tồn tại, nhập lại !", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbxSoLuongCho.Focus();
                    }
                    else if (tbxSoLuongXe.Text.ToString() == "")
                    {
                        MessageBox.Show("Bạn chưa nhập số lượng xe hoặc tồn tại, nhập lại !", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbxSoLuongXe.Focus();
                    }
                    else
                    {
                        // thực hiện lệnh 
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.Text;
                        int r = dataGridView1.CurrentCell.RowIndex;
                        this.tbxMaLoaiXe.Text = dataGridView1.Rows[r].Cells[0].Value.ToString();
                        // câu lệnh truy vấn
                        cmd.CommandText = System.String.Concat("update LOAIXE set Loai=N'" + this.tbxLoaiXe.Text.ToString()
                                                               + "',SoCho=N'" + this.tbxSoLuongCho.Text.ToString() + "',SoLuong=N'" + this.tbxSoLuongXe.Text.ToString()                                                               
                                                               + "'where MaLoai ='" + this.tbxMaLoaiXe.Text + "' ");
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                        loadData();
                        MessageBox.Show("Đã sửa thành công", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch
                {
                    MessageBox.Show("Lỗi: Sửa không thành công", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            conn.Close();
        }
#endregion
    }
}
