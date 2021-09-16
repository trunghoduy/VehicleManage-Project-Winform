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
    public partial class CNHOADON : Form
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
            string sql = "select * from HOA_DON ";  // lay het du lieu trong bang loai xe
            SqlCommand com = new SqlCommand(sql, conn); //bat dau truy van
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com); //chuyen du lieu ve
            DataTable dt = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
            da.Fill(dt);  // đổ dữ liệu vào kho
            conn.Close();  // đóng kết nối
            dataGridView1.DataSource = dt; //đổ dữ liệu vào datagridview
        }
        #endregion
        public CNHOADON()
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
        #region load form
        private void CNHOADON_Load(object sender, EventArgs e)
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
            da = new SqlDataAdapter("select * from HOA_DON ", conn);
            dt = new DataTable();
            dt.Clear();
            da.Fill(dt);
            dataGridView1.DataSource = dt; //đổ dữ liệu vào datagridview
             //xóa trống các đối tượng trong pannel
            this.tbxHinhThucTT.ResetText();
            this.tbxTongThanhToan.ResetText();
            this.tbxPhiPhatSinh.ResetText();
            this.tbxMaHopDong.ResetText();
            this.tbxLiDo.ResetText();
            this.tbxNgayLap.ResetText();
            this.tbxSoHoaDon.ResetText();
            this.tbxSoTienTT.ResetText();
            this.tbxtongXethue.ResetText();
            this.tbxTenKeToan.ResetText();
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
        #region button Hủy thông tin
        private void btnHuy_Click(object sender, EventArgs e)
        {
            // xóa dữ lieu trong các ô
            this.tbxHinhThucTT.ResetText();
            this.tbxTongThanhToan.ResetText();
            this.tbxPhiPhatSinh.ResetText();
            this.tbxMaHopDong.ResetText();
            this.tbxLiDo.ResetText();
            this.tbxNgayLap.ResetText();
            this.tbxSoHoaDon.ResetText();
            this.tbxSoTienTT.ResetText();
            this.tbxtongXethue.ResetText();
            this.tbxTenKeToan.ResetText();

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

            // xóa dữ lieu trong các ô
            this.tbxHinhThucTT.ResetText();
            this.tbxTongThanhToan.ResetText();
            this.tbxPhiPhatSinh.ResetText();
            this.tbxMaHopDong.ResetText();
            this.tbxLiDo.ResetText();
            this.tbxNgayLap.ResetText();
            this.tbxSoHoaDon.ResetText();
            this.tbxSoTienTT.ResetText();
            this.tbxtongXethue.ResetText();
            this.tbxTenKeToan.ResetText();

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
            them = false;
            if (dataGridView1.Rows.Count <= 1)
            {
                MessageBox.Show("không có dữ liệu sữa!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Focus();
            }
            else
            {
                int r = dataGridView1.CurrentCell.RowIndex;
                this.tbxSoHoaDon.Text = dataGridView1.Rows[r].Cells[0].Value.ToString();
                this.tbxMaHopDong.Text = dataGridView1.Rows[r].Cells[1].Value.ToString();
                this.tbxNgayLap.Text = dataGridView1.Rows[r].Cells[2].Value.ToString();
                this.tbxHinhThucTT.Text = dataGridView1.Rows[r].Cells[3].Value.ToString();
                this.tbxtongXethue.Text = dataGridView1.Rows[r].Cells[4].Value.ToString();
                this.tbxPhiPhatSinh.Text = dataGridView1.Rows[r].Cells[5].Value.ToString();
                this.tbxLiDo.Text = dataGridView1.Rows[r].Cells[6].Value.ToString();
                this.tbxTongThanhToan.Text = dataGridView1.Rows[r].Cells[7].Value.ToString();
                this.tbxSoTienTT.Text = dataGridView1.Rows[r].Cells[8].Value.ToString();
                this.tbxTenKeToan.Text = dataGridView1.Rows[r].Cells[9].Value.ToString();
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
                    this.tbxSoHoaDon.Text = dataGridView1.Rows[r].Cells[1].Value.ToString();
                    this.tbxNgayLap.Text = dataGridView1.Rows[r].Cells[2].Value.ToString();
                    this.tbxHinhThucTT.Text = dataGridView1.Rows[r].Cells[3].Value.ToString();
                    this.tbxtongXethue.Text = dataGridView1.Rows[r].Cells[4].Value.ToString();
                    this.tbxLiDo.Text = dataGridView1.Rows[r].Cells[5].Value.ToString();
                    this.tbxPhiPhatSinh.Text = dataGridView1.Rows[r].Cells[6].Value.ToString();
                    this.tbxTongThanhToan.Text = dataGridView1.Rows[r].Cells[7].Value.ToString();
                    this.tbxSoTienTT.Text = dataGridView1.Rows[r].Cells[8].Value.ToString();
                    this.tbxTenKeToan.Text = dataGridView1.Rows[r].Cells[9].Value.ToString();
                    cmd.CommandText = System.String.Concat("delete from HOA_DON where SoHD ='" + this.tbxSoHoaDon.Text + "' ");
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
        #region button lưu thông tin
        private void btnLuu_Click(object sender, EventArgs e)
        {
            conn.Open();
            if (them)
            {
                try
                {
                    if (tbxSoHoaDon.Text.ToString() == "")
                    {
                        MessageBox.Show("Bạn chưa nhập số hóa đơn hoặc tồn tại, nhập lại !", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbxSoHoaDon.Focus();
                    }
                    else if (tbxMaHopDong.Text.ToString() == "")
                    {
                        MessageBox.Show("Bạn chưa nhập mã hợp đồng hoặc tồn tại, nhập lại !", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbxMaHopDong.Focus();
                    }
                    else if (tbxNgayLap.Text.ToString() == "")
                    {
                        MessageBox.Show("Bạn chưa nhập thong tin ngày lập hợp đồng hoặc tồn tại, nhập lại !", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbxNgayLap.Focus();
                    }
                    else if (tbxHinhThucTT.Text.ToString() == "")
                    {
                        MessageBox.Show("Bạn chưa nhập hình thức thanh toán hoặc tồn tại, nhập lại !", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbxHinhThucTT.Focus();
                    }
                    else if (tbxtongXethue.Text.ToString() == "")
                    {
                        MessageBox.Show("Bạn chưa nhập tổng số xe thuê hoặc tồn tại, nhập lại !", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbxtongXethue.Focus();
                    }
                    else if (tbxPhiPhatSinh.Text.ToString() == "")
                    {
                        MessageBox.Show("Bạn chưa nhập phí phát sinh hoặc tồn tại, nhập lại !", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbxPhiPhatSinh.Focus();
                    }
                    else if (tbxLiDo.Text.ToString() == "")
                    {
                        MessageBox.Show("Bạn chưa nhập lí do hoặc tồn tại, nhập lại !", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbxLiDo.Focus();
                    }
                    else if (tbxTongThanhToan.Text.ToString() == "")
                    {
                        MessageBox.Show("Bạn chưa nhập tổng thanh toán hoặc tồn tại, nhập lại !", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbxTongThanhToan.Focus();
                    }
                    else if (tbxSoTienTT.Text.ToString() == "")
                    {
                        MessageBox.Show("Bạn chưa nhập số tiền thanh toán hoặc tồn tại, nhập lại !", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbxSoTienTT.Focus();
                    }
                    else if (tbxTenKeToan.Text.ToString() == "")
                    {
                        MessageBox.Show("Bạn chưa nhập tên kế toán hoặc tồn tại, nhập lại !", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbxTenKeToan.Focus();
                    }
                    else
                    {
                        // thực hiện lệnh 
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = System.String.Concat("insert into HOA_DON values(" + "N'" + this.tbxSoHoaDon.Text.ToString() + "'," + "N'" + this.tbxMaHopDong.Text.ToString() + "',N'"
                                                                + this.tbxNgayLap.Text.ToString() + "',N'" + this.tbxHinhThucTT.Text.ToString() + "',N'"
                                                                + this.tbxtongXethue.Text.ToString() + "',N'" + this.tbxPhiPhatSinh.Text.ToString() + "',N'"
                                                                + this.tbxLiDo.Text.ToString() + "',N'" + this.tbxTongThanhToan.Text.ToString() + "',N'" 
                                                                + this.tbxSoTienTT.Text.ToString() + "',N'" + this.tbxTenKeToan.Text.ToString() + "')");
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
                    if (tbxSoHoaDon.Text.ToString() == "")
                    {
                        MessageBox.Show("Bạn chưa nhập số hóa đơn hoặc tồn tại, nhập lại !", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbxSoHoaDon.Focus();
                    }
                    else if (tbxMaHopDong.Text.ToString() == "")
                    {
                        MessageBox.Show("Bạn chưa nhập mã hợp đồng hoặc tồn tại, nhập lại !", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbxMaHopDong.Focus();
                    }
                    else if (tbxNgayLap.Text.ToString() == "")
                    {
                        MessageBox.Show("Bạn chưa nhập thong tin ngày lập hợp đồng hoặc tồn tại, nhập lại !", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbxNgayLap.Focus();
                    }
                    else if (tbxHinhThucTT.Text.ToString() == "")
                    {
                        MessageBox.Show("Bạn chưa nhập hình thức thanh toán hoặc tồn tại, nhập lại !", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbxHinhThucTT.Focus();
                    }
                    else if (tbxtongXethue.Text.ToString() == "")
                    {
                        MessageBox.Show("Bạn chưa nhập tổng số xe thuê hoặc tồn tại, nhập lại !", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbxtongXethue.Focus();
                    }
                    else if (tbxPhiPhatSinh.Text.ToString() == "")
                    {
                        MessageBox.Show("Bạn chưa nhập phí phát sinh hoặc tồn tại, nhập lại !", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbxPhiPhatSinh.Focus();
                    }
                    else if (tbxLiDo.Text.ToString() == "")
                    {
                        MessageBox.Show("Bạn chưa nhập lí do hoặc tồn tại, nhập lại !", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbxLiDo.Focus();
                    }
                    else if (tbxTongThanhToan.Text.ToString() == "")
                    {
                        MessageBox.Show("Bạn chưa nhập tổng thanh toán hoặc tồn tại, nhập lại !", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbxTongThanhToan.Focus();
                    }
                    else if (tbxSoTienTT.Text.ToString() == "")
                    {
                        MessageBox.Show("Bạn chưa nhập số tiền thanh toán hoặc tồn tại, nhập lại !", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbxSoTienTT.Focus();
                    }
                    else if (tbxTenKeToan.Text.ToString() == "")
                    {
                        MessageBox.Show("Bạn chưa nhập tên kế toán hoặc tồn tại, nhập lại !", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbxTenKeToan.Focus();
                    }
                    else
                    {
                        // thực hiện lệnh 
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.Text;
                        int r = dataGridView1.CurrentCell.RowIndex;
                        this.tbxSoHoaDon.Text = dataGridView1.Rows[r].Cells[0].Value.ToString();
                        // câu lệnh truy vấn
                        cmd.CommandText = System.String.Concat("update HOA_DON set MaHD=N'" + this.tbxMaHopDong.Text.ToString()
                                                               + "',NgayLap=N'" + this.tbxNgayLap.Text.ToString() + "',HinhThucThanhToan=N'" + this.tbxHinhThucTT.Text.ToString()
                                                               + "',TongXeThue=N'" + this.tbxtongXethue.Text.ToString() + "',PhiPhatSinh=N'" + this.tbxPhiPhatSinh.Text.ToString()
                                                               + "',LiDo=N'" + this.tbxLiDo.Text.ToString() + "',TongThanhToan=N'" + this.tbxTongThanhToan.Text.ToString()
                                                               + "',SoTienThanhToan=N'" + this.tbxSoTienTT.Text.ToString() + "',TenKeToan=N'" + this.tbxTenKeToan.Text.ToString() + "'where SoHD ='" + this.tbxSoHoaDon.Text + "' ");
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
