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
    public partial class CNCHITIETHOPDONG : Form
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
            string sql = "select * from CHITIETHOPDONG ";  // lay het du lieu trong bang chi tiết họp đồng
            SqlCommand com = new SqlCommand(sql, conn); //bat dau truy van
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com); //chuyen du lieu ve
            DataTable dt = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
            da.Fill(dt);  // đổ dữ liệu vào kho
            conn.Close();  // đóng kết nối
            dataGridView1.DataSource = dt; //đổ dữ liệu vào datagridview
        }
        #endregion
        public CNCHITIETHOPDONG()
        {
            InitializeComponent();
        }
        #region load lại form
        public void loadData()
        {
            //khởi động kết nối
            conn = new SqlConnection(strConn);
            // chuyển dữ liệu lên database từ đt
            da = new SqlDataAdapter("select * from CHITIETHOPDONG ", conn);
            dt = new DataTable();
            dt.Clear();
            da.Fill(dt);
            dataGridView1.DataSource = dt; //đổ dữ liệu vào datagridview
            //xóa trống các đối tượng trong pannel
            this.tbxMaChiTietHH.ResetText();
            this.tbxMaHopDong.ResetText();
            this.tbxMaLoaiXe.ResetText();
            this.tbxSoLuongGheNgoi.ResetText();
            this.tbxNgayNhanXe.ResetText();
            this.tbxNgayTraXe.ResetText();
            this.tbxGia.ResetText();
            this.tbxGhiChu.ResetText();
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
        #region kết nối csdl
        private void CNCHITIETHOPDONG_Load(object sender, EventArgs e)
        {
            ketnoicsdl();
        }
        #endregion
        #region button Hủy thông tin
        private void btnHuy_Click(object sender, EventArgs e)
        {
            //xóa dữ liệu trong các ô
            this.tbxMaChiTietHH.ResetText();
            this.tbxMaHopDong.ResetText();
            this.tbxMaLoaiXe.ResetText();
            this.tbxSoLuongGheNgoi.ResetText();
            this.tbxNgayNhanXe.ResetText();
            this.tbxNgayTraXe.ResetText();
            this.tbxGia.ResetText();
            this.tbxGhiChu.ResetText();
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
        #region button thêm hợp đồng
        bool them;
        private void btnThem_Click(object sender, EventArgs e)
        {
            them = true;
            //xóa dữ liệu trong các ô
            this.tbxMaChiTietHH.ResetText();
            this.tbxMaHopDong.ResetText();
            this.tbxMaLoaiXe.ResetText();
            this.tbxSoLuongGheNgoi.ResetText();
            this.tbxNgayNhanXe.ResetText();
            this.tbxNgayTraXe.ResetText();
            this.tbxGia.ResetText();
            this.tbxGhiChu.ResetText();
            //Đóng các chức năng
            this.btnLuu.Enabled = true;
            this.btnHuy.Enabled = true;
            // mở một số chức năng
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnthoat.Enabled = false;
        }
        #endregion hợp đồng
        #region button Sửa hợp đồng
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
                // show thồn tin hợp đồng cần sửa
                int r = dataGridView1.CurrentCell.RowIndex;
                this.tbxMaChiTietHH.Text = dataGridView1.Rows[r].Cells[0].Value.ToString();
                this.tbxMaHopDong.Text = dataGridView1.Rows[r].Cells[1].Value.ToString();
                this.tbxMaLoaiXe.Text = dataGridView1.Rows[r].Cells[2].Value.ToString();
                this.tbxSoLuongGheNgoi.Text = dataGridView1.Rows[r].Cells[3].Value.ToString();
                this.tbxGia.Text = dataGridView1.Rows[r].Cells[4].Value.ToString();
                this.tbxNgayNhanXe.Text = dataGridView1.Rows[r].Cells[5].Value.ToString();
                this.tbxNgayTraXe.Text = dataGridView1.Rows[r].Cells[6].Value.ToString();
                this.tbxGhiChu.Text = dataGridView1.Rows[r].Cells[7].Value.ToString();
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
        #region button Lưu hợp đồng
        private void btnLuu_Click(object sender, EventArgs e)
        {
            conn.Open();
            if (them)
            {
                try
                {
                    if (tbxMaChiTietHH.Text.ToString() == "")
                    {
                        MessageBox.Show("Bạn chưa nhập mã chi tiết hợp đồng hoặc tồn tại, nhập lại !", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbxMaChiTietHH.Focus();
                    }
                    else if (tbxMaHopDong.Text.ToString() == "")
                    {
                        MessageBox.Show("Bạn chưa nhập mã hợp đồng hoặc tồn tại, nhập lại !", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbxMaHopDong.Focus();
                    }
                    else if (tbxMaLoaiXe.Text.ToString() == "")
                    {
                        MessageBox.Show("Bạn chưa nhập mã loại xe hoặc tồn tại, nhập lại !", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbxMaLoaiXe.Focus();
                    }
                    else if (tbxSoLuongGheNgoi.Text.ToString() == "")
                    {
                        MessageBox.Show("Bạn chưa nhập số lượng ghế ngồi hoặc tồn tại, nhập lại !", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbxSoLuongGheNgoi.Focus();
                    }
                    else if (tbxGia.Text.ToString() == "")
                    {
                        MessageBox.Show("Bạn chưa nhập giá hoặc tồn tại, nhập lại !", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbxGia.Focus();
                    }
                    else if (tbxNgayNhanXe.Text.ToString() == "")
                    {
                        MessageBox.Show("Bạn chưa nhập ngày nhận xe hoặc tồn tại, nhập lại !", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbxNgayNhanXe.Focus();
                    }
                    else if (tbxNgayTraXe.Text.ToString() == "")
                    {
                        MessageBox.Show("Bạn chưa nhập ngày trả xe hoặc tồn tại, nhập lại !", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbxNgayTraXe.Focus();
                    }
                    else if (tbxGhiChu.Text.ToString() == "")
                    {
                        MessageBox.Show("Bạn chưa nhập thông tin ghi chú hoặc tồn tại, nhập lại !", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbxGhiChu.Focus();
                    }
                    else
                    {
                        // thực hiện lệnh 
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = System.String.Concat("insert into CHITIETHOPDONG values(" + "N'" + this.tbxMaChiTietHH.Text.ToString() + "',N'"
                                                                + this.tbxMaHopDong.Text.ToString() + "',N'" + this.tbxMaLoaiXe.Text.ToString() + "',N'"
                                                                + this.tbxSoLuongGheNgoi.Text.ToString() + "',N'" + this.tbxGia.Text.ToString() + "',N'"
                                                                + this.tbxNgayNhanXe.Text.ToString() + "',N'" + this.tbxNgayTraXe.Text.ToString() + "',N'"
                                                                + this.tbxGhiChu.Text.ToString() + "') ");
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                        loadData();
                        MessageBox.Show("Đã thêm thành công", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                catch (SqlException)
                {
                    MessageBox.Show("Lỗi: Thêm không thành công", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.tbxMaChiTietHH.Focus();
                }
            }
            if (!them)
            {
                try
                {
                    if (tbxMaChiTietHH.Text.ToString() == "")
                    {
                        MessageBox.Show("Bạn chưa nhập mã chi tiết hợp đồng hoặc tồn tại, nhập lại !", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbxMaChiTietHH.Focus();
                    }
                    else if (tbxMaHopDong.Text.ToString() == "")
                    {
                        MessageBox.Show("Bạn chưa nhập mã hợp đồng hoặc tồn tại, nhập lại !", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbxMaHopDong.Focus();
                    }
                    else if (tbxMaLoaiXe.Text.ToString() == "")
                    {
                        MessageBox.Show("Bạn chưa nhập mã loại xe hoặc tồn tại, nhập lại !", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbxMaLoaiXe.Focus();
                    }
                    else if (tbxSoLuongGheNgoi.Text.ToString() == "")
                    {
                        MessageBox.Show("Bạn chưa nhập số lượng ghế ngồi hoặc tồn tại, nhập lại !", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbxSoLuongGheNgoi.Focus();
                    }
                    else if (tbxGia.Text.ToString() == "")
                    {
                        MessageBox.Show("Bạn chưa nhập giá hoặc tồn tại, nhập lại !", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbxGia.Focus();
                    }
                    else if (tbxNgayNhanXe.Text.ToString() == "")
                    {
                        MessageBox.Show("Bạn chưa nhập ngày nhận xe hoặc tồn tại, nhập lại !", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbxNgayNhanXe.Focus();
                    }
                    else if (tbxNgayTraXe.Text.ToString() == "")
                    {
                        MessageBox.Show("Bạn chưa nhập ngày trả xe hoặc tồn tại, nhập lại !", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbxNgayTraXe.Focus();
                    }
                    else if (tbxGhiChu.Text.ToString() == "")
                    {
                        MessageBox.Show("Bạn chưa nhập thông tin ghi chú hoặc tồn tại, nhập lại !", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbxGhiChu.Focus();
                    }
                    else
                    {
                        // thực hiện lệnh 
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.Text;
                        int r = dataGridView1.CurrentCell.RowIndex;
                        this.tbxMaChiTietHH.Text = dataGridView1.Rows[r].Cells[0].Value.ToString();
                        // câu lệnh truy vấn
                        cmd.CommandText = System.String.Concat("update CHITIETHOPDONG set MaHD=N'" + this.tbxMaHopDong.Text.ToString() + "',MaLoai=N'" + this.tbxMaLoaiXe.Text.ToString()
                                                               + "',SoCho=N'" + this.tbxSoLuongGheNgoi.Text.ToString() + "',Gia=N'" + this.tbxGia.Text.ToString()
                                                               + "',NgayNhan=N'" + this.tbxNgayNhanXe.Text.ToString() + "',Ngaytra=N'" + this.tbxNgayTraXe.Text.ToString()
                                                               + "',GhiChu=N'" + this.tbxGhiChu.Text.ToString() + "'where MaChiTietHD ='" + this.tbxMaChiTietHH.Text + "' ");
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
        #region button Xóa
        private void btnXoa_Click(object sender, EventArgs e){
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
                    this.tbxMaChiTietHH.Text = dataGridView1.Rows[r].Cells[0].Value.ToString();
                    this.tbxMaHopDong.Text = dataGridView1.Rows[r].Cells[1].Value.ToString();
                    this.tbxMaLoaiXe.Text = dataGridView1.Rows[r].Cells[2].Value.ToString();
                    this.tbxSoLuongGheNgoi.Text = dataGridView1.Rows[r].Cells[3].Value.ToString();
                    this.tbxGia.Text = dataGridView1.Rows[r].Cells[4].Value.ToString();
                    this.tbxNgayNhanXe.Text = dataGridView1.Rows[r].Cells[5].Value.ToString();
                    this.tbxNgayTraXe.Text = dataGridView1.Rows[r].Cells[6].Value.ToString();
                    this.tbxGhiChu.Text = dataGridView1.Rows[r].Cells[7].Value.ToString();
                    cmd.CommandText = System.String.Concat("delete from CHITIETHOPDONG where MaChiTietHD ='" + this.tbxMaChiTietHH.Text + "' ");
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
    }
}
