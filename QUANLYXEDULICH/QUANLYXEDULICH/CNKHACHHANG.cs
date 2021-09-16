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
    public partial class CNKHACHHANG : Form
    {
        static string path = Application.StartupPath;
        string  strConn = @"Data Source=DESKTOP-12J6D6C;Initial Catalog=QUAN LY XE DU LICH;Integrated Security=True";
        // Tạo đối tượng kết nối
        SqlConnection conn = null;
        //doi tuong de dua dữ kiệu vào DataTable dtTuDien
        SqlDataAdapter da = null;
        //Tạo đói tượng hiển thị lên form
        DataTable dt = null;
        #region load form
        private void CNKHACHHANG_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(strConn);
            string sql = "select * from KHACHHANG ";  // lay het du lieu trong bang  xe
            SqlCommand com = new SqlCommand(sql, conn); //bat dau truy van
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com); //chuyen du lieu ve
            DataTable dt = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
            da.Fill(dt);  // đổ dữ liệu vào kho
            conn.Close();  // đóng kết nối
            dataGridView1.DataSource = dt; //đổ dữ liệu vào datagridview
        }
        #endregion
        public CNKHACHHANG()
        {
            InitializeComponent();
        }
        #region thoát form
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
        #region load lại form
        public void loadData()
        {
            //khởi động kết nối
            conn = new SqlConnection(strConn);
            // chuyển dữ liệu lên database từ đt
            da = new SqlDataAdapter("select * from KHACHHANG ", conn);
            dt = new DataTable();
            dt.Clear();
            da.Fill(dt);
            dataGridView1.DataSource = dt; //đổ dữ liệu vào datagridview
        
            //xóa trống các đối tượng trong pannel
            this.tbxMaKhach.ResetText();
            this.tbxTenKhach.ResetText();
            this.tbxCMND.ResetText();
            this.tbxDiaChi.ResetText();
            this.tbxSoDienThoai.ResetText();
            this.tbxSoTaiKhoan.ResetText();
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
        #region Thêm thông tin
        bool Them;
        private void btnThem_Click(object sender, EventArgs e)
        {
            Them = true;
            //xóa trống các đối tượng trong pannel
            this.tbxMaKhach.ResetText();
            this.tbxTenKhach.ResetText();
            this.tbxCMND.ResetText();
            this.tbxDiaChi.ResetText();
            this.tbxSoDienThoai.ResetText();
            this.tbxSoTaiKhoan.ResetText();
            //không thao tác trên các nút lưu/hủy
            this.btnLuu.Enabled = true;
            this.btnHuy.Enabled = true;
            //cho thao tác thêm , sửa, xóa,thoát
           
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnthoat.Enabled = false;
        }
#endregion
        #region Button Sưa thông tin
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
                this.tbxMaKhach.Text = dataGridView1.Rows[r].Cells[0].Value.ToString();
                this.tbxTenKhach.Text = dataGridView1.Rows[r].Cells[1].Value.ToString();
                this.tbxCMND.Text = dataGridView1.Rows[r].Cells[2].Value.ToString();
                this.tbxDiaChi.Text = dataGridView1.Rows[r].Cells[3].Value.ToString();
                this.tbxSoDienThoai.Text = dataGridView1.Rows[r].Cells[4].Value.ToString();
                this.tbxSoTaiKhoan.Text = dataGridView1.Rows[r].Cells[5].Value.ToString();
                //cho phép các nút hoạt động
                this.btnLuu.Enabled = true;
                this.btnHuy.Enabled = true;
                //không cho các nút hoạt động
                this.btnThem.Enabled = false;
                this.btnXoa.Enabled = false;
                this.btnthoat.Enabled = false;
            }
        }
#endregion
        #region button xóa thông tin
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
                    this.tbxMaKhach.Text = dataGridView1.Rows[r].Cells[0].Value.ToString();
                    this.tbxTenKhach.Text = dataGridView1.Rows[r].Cells[1].Value.ToString();
                    this.tbxCMND.Text = dataGridView1.Rows[r].Cells[2].Value.ToString();
                    this.tbxDiaChi.Text = dataGridView1.Rows[r].Cells[3].Value.ToString();
                    this.tbxSoDienThoai.Text = dataGridView1.Rows[r].Cells[4].Value.ToString();
                    this.tbxSoTaiKhoan.Text = dataGridView1.Rows[r].Cells[5].Value.ToString();
                    cmd.CommandText = System.String.Concat("delete from KHACHHANG where MaKH ='" + this.tbxMaKhach.Text + "' ");
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
        #region button Hủy thông tin
        private void btnHuy_Click(object sender, EventArgs e)
        {
            //xóa dữ liệu trong các ô
            this.tbxCMND.ResetText();
            this.tbxDiaChi.ResetText();
            this.tbxMaKhach.ResetText();
            this.tbxSoDienThoai.ResetText();
            this.tbxSoTaiKhoan.ResetText();
            this.tbxTenKhach.ResetText();
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
        #region button Lưu thông tin
        private void btnLuu_Click_1(object sender, EventArgs e)
        {
            conn.Open();
            if (Them)
            {
                try
                {
                    if (tbxMaKhach.Text.ToString() == "")
                    {
                        MessageBox.Show("Bạn chưa nhập mã khách hàng hoặc tồn tại, nhập lại !", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbxMaKhach.Focus();
                    }
                    else
                        if (tbxTenKhach.Text.ToString() == "")
                    {
                        MessageBox.Show("Bạn chưa nhập tên khách hàng hoặc tồn tại, nhập lại!", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbxTenKhach.Focus();
                    }
                    else
                        if (tbxCMND.Text.ToString() == "")
                    {
                        MessageBox.Show("Bạn chưa nhập CMND hoặc tồn tại, nhập lại!", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbxCMND.Focus();
                    }
                    else
                        if (tbxDiaChi.Text.ToString() == "")
                    {
                        MessageBox.Show("Bạn chưa nhập địa chỉ hoặc tồn tại, nhập lại!", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbxDiaChi.Focus();
                    }
                    else
                        if (tbxSoDienThoai.Text.ToString() == "")
                    {
                        MessageBox.Show("Bạn chưa nhập số điện thoại khách hàng hoặc tồn tại, nhập lại!", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbxSoDienThoai.Focus();
                    }
                    else
                        if (tbxSoTaiKhoan.Text.ToString() == "")
                    {
                        MessageBox.Show("Bạn chưa nhập số tài khoản khách hàng hoặc tồn tại, nhập lại!", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbxSoTaiKhoan.Focus();
                    }
                    else
                    {
                        // Thực hiện lệnh
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = System.String.Concat("insert into KHACHHANG values(" + "N'" + this.tbxMaKhach.Text.ToString() + "',N'" + this.tbxTenKhach.Text.ToString() + "',N'" + this.tbxCMND.Text.ToString() + "',N'" + this.tbxDiaChi.Text.ToString() + "',N'" + this.tbxSoDienThoai.Text.ToString() + "',N'" + this.tbxSoTaiKhoan.Text.ToString() + "') ");
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                        loadData();
                        MessageBox.Show("Đã thêm thành công", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (SqlException)
                {
                    MessageBox.Show("Lỗi: Thêm không thành công", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.tbxMaKhach.Focus();
                }
            }
            if (!Them)
            {
                try
                {
                    if (tbxMaKhach.Text.ToString() == "")
                    {
                        MessageBox.Show("Bạn chưa nhập mã khách hàng hoặc tồn tại, nhập lại !", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbxMaKhach.Focus();
                    }
                    else
                       if (tbxTenKhach.Text.ToString() == "")
                    {
                        MessageBox.Show("Bạn chưa nhập tên khách hàng hoặc tồn tại, nhập lại!", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbxTenKhach.Focus();
                    }
                    else
                       if (tbxCMND.Text.ToString() == "")
                    {
                        MessageBox.Show("Bạn chưa nhập CMND hoặc tồn tại, nhập lại!", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbxCMND.Focus();
                    }
                    else
                       if (tbxDiaChi.Text.ToString() == "")
                    {
                        MessageBox.Show("Bạn chưa nhập địa chỉ hoặc tồn tại, nhập lại!", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbxDiaChi.Focus();
                    }
                    else
                       if (tbxSoDienThoai.Text.ToString() == "")
                    {
                        MessageBox.Show("Bạn chưa nhập số điện thoại khách hàng hoặc tồn tại, nhập lại!", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbxSoDienThoai.Focus();
                    }
                    else
                       if (tbxSoTaiKhoan.Text.ToString() == "")
                    {
                        MessageBox.Show("Bạn chưa nhập số tài khoản khách hàng hoặc tồn tại, nhập lại!", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbxSoTaiKhoan.Focus();
                    }
                    else
                    {
                        // Thực hiện lệnh
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.Text;
                        int r = dataGridView1.CurrentCell.RowIndex;
                        this.tbxMaKhach.Text = dataGridView1.Rows[r].Cells[0].Value.ToString();
                        //cau lenh sql
                        cmd.CommandText = System.String.Concat("update KHACHHANG set TenKH=N'" + this.tbxTenKhach.Text.ToString() + "',CMND=N'" + this.tbxCMND.Text.ToString() + "',DiaChi=N'" + this.tbxDiaChi.Text.ToString() + "',SoDT=N'" + this.tbxSoDienThoai.Text.ToString() + "',SoTK=N'" + this.tbxSoTaiKhoan.Text.ToString() + "'where MaKH ='" + this.tbxMaKhach.Text + "' ");
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
