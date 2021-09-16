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
    public partial class CNHOPDONG : Form
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
            string sql = "select * from HOPDONG ";  // lay het du lieu trong bang loai xe
            SqlCommand com = new SqlCommand(sql, conn); //bat dau truy van
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com); //chuyen du lieu ve
            DataTable dt = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
            da.Fill(dt);  // đổ dữ liệu vào kho
            conn.Close();  // đóng kết nối
            dataGridView1.DataSource = dt; //đổ dữ liệu vào datagridview
        }
        #endregion
        public CNHOPDONG()
        {
            InitializeComponent();
        }
        #region load lại form
        public void loadData()
        {
            //khởi động kết nối
            conn = new SqlConnection(strConn);
            // chuyển dữ liệu lên database từ đt
            da = new SqlDataAdapter("select * from HOPDONG ", conn);
            dt = new DataTable();
            dt.Clear();
            da.Fill(dt);
            dataGridView1.DataSource = dt; //đổ dữ liệu vào datagridview
            //xóa trống các đối tượng trong pannel
            this.tbxMaHopDong.ResetText();
            this.txbMaKhacHang.ResetText();
            this.txbNgayLap.ResetText();
            this.txbDieuKhoan.ResetText();
            this.txbNoiDung.ResetText();
            this.txbTienTTTruoc.ResetText();
            this.txbTongTienTT.ResetText();
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
        #region load form
        private void CNHOPDONG_Load(object sender, EventArgs e)
        {
            ketnoicsdl();
        }
#endregion
        #region Button Hủy thông tin
        private void btnHuy_Click(object sender, EventArgs e)
        {
            //xóa dữ liệu trong các ô
            this.tbxMaHopDong.ResetText();
            this.txbMaKhacHang.ResetText();
            this.txbNgayLap.ResetText();
            this.txbDieuKhoan.ResetText();
            this.txbNoiDung.ResetText();
            this.txbTienTTTruoc.ResetText();
            this.txbTongTienTT.ResetText();
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
        #region button thêm thông tin
        bool them;
        private void btnThem_Click(object sender, EventArgs e)
        {
            them = true;
            //xóa dữ liệu trong các ô
            this.tbxMaHopDong.ResetText();
            this.txbMaKhacHang.ResetText();
            this.txbNgayLap.ResetText();
            this.txbDieuKhoan.ResetText();
            this.txbNoiDung.ResetText();
            this.txbTienTTTruoc.ResetText();
            this.txbTongTienTT.ResetText();
            //Đóng các chức năng
            this.btnLuu.Enabled = true;
            this.btnHuy.Enabled = true;
            // mở một số chức năng
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnthoat.Enabled = false;
        }
#endregion
        #region button sửa thông tin
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count <= 1)
            {
                MessageBox.Show("không có dữ liệu sữa!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Focus();
            }
            else
            {
                int r = dataGridView1.CurrentCell.RowIndex;
                this.tbxMaHopDong.Text = dataGridView1.Rows[r].Cells[0].Value.ToString();
                this.txbMaKhacHang.Text = dataGridView1.Rows[r].Cells[1].Value.ToString();
                this.txbNgayLap.Text = dataGridView1.Rows[r].Cells[2].Value.ToString();
                this.txbNoiDung.Text = dataGridView1.Rows[r].Cells[3].Value.ToString();
                this.txbDieuKhoan.Text = dataGridView1.Rows[r].Cells[4].Value.ToString();
                this.txbTongTienTT.Text = dataGridView1.Rows[r].Cells[5].Value.ToString();
                this.txbTienTTTruoc.Text = dataGridView1.Rows[r].Cells[6].Value.ToString();
                //Đóng các chức năng
                this.btnLuu.Enabled = true;
                this.btnHuy.Enabled = true;
                // mở một số chức năng
                this.btnSua.Enabled = false;
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
                    this.tbxMaHopDong.Text = dataGridView1.Rows[r].Cells[0].Value.ToString();
                    this.txbMaKhacHang.Text = dataGridView1.Rows[r].Cells[1].Value.ToString();
                    this.txbNgayLap.Text = dataGridView1.Rows[r].Cells[2].Value.ToString();
                    this.txbNoiDung.Text = dataGridView1.Rows[r].Cells[3].Value.ToString();
                    this.txbDieuKhoan.Text = dataGridView1.Rows[r].Cells[4].Value.ToString();
                    this.txbTongTienTT.Text = dataGridView1.Rows[r].Cells[5].Value.ToString();
                    this.txbTienTTTruoc.Text = dataGridView1.Rows[r].Cells[6].Value.ToString();
                    cmd.CommandText = System.String.Concat("delete from HOPDONG where MaHD ='" + this.tbxMaHopDong.Text + "' ");
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
        #region Button Lưu thông tin
        private void btnLuu_Click(object sender, EventArgs e)
        {
            conn.Open();
            if (them)
            {
                try
                {
                    if (tbxMaHopDong.Text.ToString() == "")
                    {
                        MessageBox.Show("Bạn chưa nhập mã hợp đồng hoặc tồn tại, nhập lại !", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbxMaHopDong.Focus();
                    }
                    else if (txbMaKhacHang.Text.ToString() == "")
                    {
                        MessageBox.Show("Bạn chưa nhập mã khách hàng hoặc tồn tại, nhập lại !", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txbMaKhacHang.Focus();
                    }
                    else if (txbNgayLap.Text.ToString() == "")
                    {
                        MessageBox.Show("Bạn chưa nhập thong tin ngày lập hợp đồng hoặc tồn tại, nhập lại !", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txbNgayLap.Focus();
                    }
                    else if (txbDieuKhoan.Text.ToString() == "")
                    {
                        MessageBox.Show("Bạn chưa nhập điều khoản hợp đồng hoặc tồn tại, nhập lại !", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txbDieuKhoan.Focus();
                    }
                    else if (txbNoiDung.Text.ToString() == "")
                    {
                        MessageBox.Show("Bạn chưa nhập nội dung hợp đồng hoặc tồn tại, nhập lại !", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txbNoiDung.Focus();
                    }
                    else if (txbTongTienTT.Text.ToString() == "")
                    {
                        MessageBox.Show("Bạn chưa nhập tổng tiền thanh toán hoặc tồn tại, nhập lại !", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txbTongTienTT.Focus();
                    }
                    else if (txbTienTTTruoc.Text.ToString() == "")
                    {
                        MessageBox.Show("Bạn chưa nhập tiền thanh toán trước hoặc tồn tại, nhập lại !", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txbTienTTTruoc.Focus();
                    }
                    else
                    {
                        // thực hiện lệnh 
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = System.String.Concat("insert into HOPDONG values(" + "N'" + this.tbxMaHopDong.Text.ToString() + "',N'"
                                                                + this.txbMaKhacHang.Text.ToString() + "',N'" + this.txbNgayLap.Text.ToString() + "',N'"
                                                                + this.txbNoiDung.Text.ToString() + "',N'" + this.txbDieuKhoan.Text.ToString() + "',N'"
                                                                + this.txbTongTienTT.Text.ToString() + "',N'" + this.txbTienTTTruoc.Text.ToString() + "')");
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                        loadData();
                        MessageBox.Show("Đã thêm thành công", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                catch (SqlException)
                {
                    MessageBox.Show("Lỗi: Thêm không thành công", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.tbxMaHopDong.Focus();
                }
            }
            if (!them)
            {
                try
                {
                    if (tbxMaHopDong.Text.ToString() == "")
                    {
                        MessageBox.Show("Bạn chưa nhập mã hợp đồng hoặc tồn tại, nhập lại !", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbxMaHopDong.Focus();
                    }
                    else if (txbMaKhacHang.Text.ToString() == "")
                    {
                        MessageBox.Show("Bạn chưa nhập mã khách hàng hoặc tồn tại, nhập lại !", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txbMaKhacHang.Focus();
                    }
                    else if (txbNgayLap.Text.ToString() == "")
                    {
                        MessageBox.Show("Bạn chưa nhập thong tin ngày lập hợp đồng hoặc tồn tại, nhập lại !", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txbNgayLap.Focus();
                    }
                    else if (txbDieuKhoan.Text.ToString() == "")
                    {
                        MessageBox.Show("Bạn chưa nhập điều khoản hợp đồng hoặc tồn tại, nhập lại !", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txbDieuKhoan.Focus();
                    }
                    else if (txbNoiDung.Text.ToString() == "")
                    {
                        MessageBox.Show("Bạn chưa nhập nội dung hợp đồng hoặc tồn tại, nhập lại !", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txbNoiDung.Focus();
                    }
                    else if (txbTongTienTT.Text.ToString() == "")
                    {
                        MessageBox.Show("Bạn chưa nhập tổng tiền thanh toán hoặc tồn tại, nhập lại !", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txbTongTienTT.Focus();
                    }
                    else if (txbTienTTTruoc.Text.ToString() == "")
                    {
                        MessageBox.Show("Bạn chưa nhập tiền thanh toán trước hoặc tồn tại, nhập lại !", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txbTienTTTruoc.Focus();
                    }
                    else
                    {
                        // thực hiện lệnh 
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.Text;
                        int r = dataGridView1.CurrentCell.RowIndex;
                        this.tbxMaHopDong.Text = dataGridView1.Rows[r].Cells[0].Value.ToString();
                        // câu lệnh truy vấn
                        cmd.CommandText = System.String.Concat("update HOPDONG set MaKH=N'" + this.txbMaKhacHang.Text.ToString()
                                                               + "',Ngay=N'" + this.txbNgayLap.Text.ToString() + "',NoiDung=N'" + this.txbNoiDung.Text.ToString()
                                                               + "',DieuKhoan=N'" + this.txbDieuKhoan.Text.ToString() + "',TongTienTT=N'" + this.txbTongTienTT.Text.ToString()
                                                               + "',TienTTTruoc=N'" + this.txbTienTTTruoc.Text.ToString() + "'where MaHD ='" + this.tbxMaHopDong.Text + "' ");
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
