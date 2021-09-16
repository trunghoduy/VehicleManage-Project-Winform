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
    public partial class CNNGUOIDUNG : Form
    {
        static string path = Application.StartupPath;
        string  strConn = @"Data Source=DESKTOP-12J6D6C;Initial Catalog=QUAN LY XE DU LICH;Integrated Security=True";
        // Tạo đối tượng kết nối
        SqlConnection conn = null;
        //doi tuong de dua dữ kiệu vào DataTable 
        SqlDataAdapter da = null;
        //Tạo đói tượng hiển thị lên form
        DataTable dt = null;


        void ketnocsdl()
        {
            conn = new SqlConnection(strConn);
            string sql = "select * from USERSYSTEM ";  // lay het du lieu trong bang  xe
            SqlCommand com = new SqlCommand(sql, conn); //bat dau truy van
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com); //chuyen du lieu ve
            DataTable dt = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
            da.Fill(dt);  // đổ dữ liệu vào kho
            conn.Close();  // đóng kết nối
            dataGridView1.DataSource = dt; //đổ dữ liệu vào datagridview
        }
        private void CNNGUOIDUNG_Load(object sender, EventArgs e)
        {
            ketnocsdl();
          
        }
        bool Them;

        public CNNGUOIDUNG()
        {
            InitializeComponent();
        }

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

       
        #region load lại form
        public void loadData()
        {
            //khởi động kết nối
            conn = new SqlConnection(strConn);
            // chuyển dữ liệu lên database từ đt
            da = new SqlDataAdapter("select * from USERSYSTEM ", conn);
            dt = new DataTable();
            dt.Clear();
            da.Fill(dt);
            dataGridView1.DataSource = dt; //đổ dữ liệu vào datagridview
            //xóa trống các đối tượng trong pannel
            this.tbxTenDangNhap.ResetText();
            this.tbxMatKhau.ResetText();
            this.tbxChucVu.ResetText();
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

        private void btnThem_Click(object sender, EventArgs e)
        {
            Them = true;
            // xóa dữ liệu trog các ô trước khi thêm
            this.tbxTenDangNhap.ResetText();
            this.tbxMatKhau.ResetText();
            this.tbxChucVu.ResetText();
            //mở các chức năng
            this.btnLuu.Enabled = true;
            this.btnHuy.Enabled = true;
            // đống một số chức năng
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnthoat.Enabled = false;

        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            Them = false;
            if (dataGridView1.Rows.Count <= 1)
            {
                MessageBox.Show("không có dữ liệu sữa!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Focus();
            }
            else
            {
                int r = dataGridView1.CurrentCell.RowIndex;
                this.tbxTenDangNhap.Text = dataGridView1.Rows[r].Cells[0].Value.ToString();
                this.tbxMatKhau.Text = dataGridView1.Rows[r].Cells[1].Value.ToString();
                this.tbxChucVu.Text = dataGridView1.Rows[r].Cells[2].Value.ToString();
                //cho phép các nút hoạt động
                this.btnLuu.Enabled = true;
                this.btnHuy.Enabled = true;
                //không cho các nút hoạt động
                this.btnThem.Enabled = false;
                this.btnXoa.Enabled = false;
                this.btnthoat.Enabled = false;
            }
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            conn.Open();
            if (Them)
            {
                try
                {
                    if (tbxTenDangNhap.Text.ToString() == "")
                    {
                      ;
                    }
                    else
                        if (tbxMatKhau.Text.ToString() == "")
                    {
                        MessageBox.Show("Bạn chưa nhập mật khẩu hoặc tồn tại, nhập lại!", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbxMatKhau.Focus();
                    }
                    else
                        if (tbxChucVu.Text.ToString() == "")
                    {
                        MessageBox.Show("Bạn chưa nhập chức vụ hoặc tồn tại, nhập lại!", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                      tbxChucVu.Focus();
                    }
                    else
                    {
                        // Thực hiện lệnh
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = System.String.Concat("insert into USERSYSTEM values(" + "N'" + this.tbxTenDangNhap.Text.ToString() + "',N'" + this.tbxMatKhau.Text.ToString() + "',N'" + this.tbxChucVu.Text.ToString() + "') ");
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                        loadData();
                        MessageBox.Show("Đã thêm thành công", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (SqlException)
                {
                    MessageBox.Show("Lỗi: Thêm không thành công", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.tbxTenDangNhap.Focus();
                }
            }
            if (!Them)
            {
                try
                {
                    if (tbxTenDangNhap.Text.ToString() == "")
                    {
                        MessageBox.Show("Bạn chưa nhập từ tên đăng nhập hoặc tồn tại, nhập lại !", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbxTenDangNhap.Focus();
                    }
                    else
                        if (tbxMatKhau.Text.ToString() == "")
                    {
                        MessageBox.Show("Bạn chưa nhập mật khẩu hoặc tồn tại, nhập lại!", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbxMatKhau.Focus();
                    }
                    else
                        if (tbxChucVu.Text.ToString() == "")
                    {
                        MessageBox.Show("Bạn chưa nhập chức vụ hoặc tồn tại, nhập lại!", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbxChucVu.Focus();
                    }
                    else
                    {
                        // Thực hiện lệnh
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.Text;
                        int r = dataGridView1.CurrentCell.RowIndex;
                        this.tbxTenDangNhap.Text = dataGridView1.Rows[r].Cells[0].Value.ToString();
                        //cau lenh sql
                        cmd.CommandText = System.String.Concat("update USERSYSTEM set Password=N'" + this.tbxMatKhau.Text.ToString() + "',Quyen=N'" + this.tbxChucVu.Text.ToString()+ "'where Username ='" + this.tbxTenDangNhap.Text + "' ");
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

        private void CNNGUOIDUNG_Load()
        {
            throw new NotImplementedException();
        }

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
                    this.tbxTenDangNhap.Text = dataGridView1.Rows[r].Cells[0].Value.ToString();
                    this.tbxMatKhau.Text = dataGridView1.Rows[r].Cells[1].Value.ToString();
                    this.tbxChucVu.Text = dataGridView1.Rows[r].Cells[2].Value.ToString();
                    cmd.CommandText = System.String.Concat("delete from USERSYSTEM where Username ='" + this.tbxTenDangNhap.Text + "' ");
                    cmd.CommandType = CommandType.Text;
                    DialogResult traloi;
                    traloi = MessageBox.Show("Bạn có chắc chắn muốn xóa người dùng không?", "Trả lời ?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (traloi == DialogResult.OK)
                    {
                        //thuc hien cau lenh sql
                        cmd.ExecuteNonQuery();
                        loadData();
                        MessageBox.Show("Xóa thành công!", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //load lai bang

                    }
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Lỗi :Xóa không thành công!");
            }
            conn.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            // xóa dữ liệu trog các ô trước khi thêm
            this.tbxTenDangNhap.ResetText();
            this.tbxMatKhau.ResetText();
            this.tbxChucVu.ResetText();
            //Đóng các chức năng
            this.btnLuu.Enabled = false;
            this.btnHuy.Enabled = false;
            // mở một số chức năng
            this.btnSua.Enabled = true;
            this.btnXoa.Enabled = true;
            this.btnthoat.Enabled = true;
            this.btnThem.Enabled = true;
        }
    }
    
}
