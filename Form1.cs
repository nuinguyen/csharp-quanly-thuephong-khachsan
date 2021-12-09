using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using BTL.DAO;
using CrystalDecisions.CrystalReports.Engine;
using BTL.Reports;
using CrystalDecisions.Shared;

namespace BTL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            //Console.OutputEncoding = Encoding.UTF8;
            InitializeComponent();
            LoadKhachHang();
            LoadNhanVien();
            LoadPhong();
            LoadDichVu();
            LoadHoaDon();
            LoadDatPhong(null);
            LoadDatDichVu();
        }

        ///       THÊM BT NHÓM     \\\\\\\\\\
        ///       




















        //// ĐÓNG\\\\\\\


        //////   ĐẶT DICH VU   \\\\\\
        // Hàm hiện Dịch Vụ
        void LoadDatDichVu()
        {
            string query = "select * from tblDichVu";
            DataProvider provider = new DataProvider();
            dgv_dsdv.DataSource = provider.ExecuteQuery(query);

             // Hien Ma P
            string querymap = "select * from tblChiTietPhong";
            tb_mapddv.DataSource = provider.ExecuteQuery(querymap);
            tb_mapddv.DisplayMember = "MaP";
            tb_mapddv.ValueMember = "MaP";

            tb_mahdddv.ReadOnly= tb_maddv.ReadOnly = tb_dongiaddv.ReadOnly = true;
        }
        private void tb_mapddv_SelectedIndexChanged(object sender, EventArgs e)
        {        
            //Hien Ma HĐ
            DataProvider provider = new DataProvider();
            try
            {
            string querymahd = "select MaHD from  tblChiTietPhong where tblChiTietPhong.MaP='" + tb_mapddv.SelectedValue.ToString() + "'";
            tb_mahdddv.Text = provider.ExecuteQuery(querymahd).Rows[0][0].ToString();
            //MessageBox.Show(tb_mapddv.SelectedValue.ToString().ToString());
            }
            catch (Exception )
            {
            }
        }
        private void dgv_dsddv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgv_dsdv.CurrentRow.Index;
            tb_maddv.Text = dgv_dsdv.Rows[i].Cells[0].Value.ToString();
            tb_dongiaddv.Text = dgv_dsdv.Rows[i].Cells[3].Value.ToString();
        }
        private void bt_addddv_Click(object sender, EventArgs e)
        {
            string query = "select * from tblDichVu  where MaDV = '" + tb_maddv.Text + "'";
            //MessageBox.Show(tb_dmp.Text.ToString());
            DataProvider provider = new DataProvider();
            dgv_dsddv.AutoGenerateColumns = false;
            dgv_dsddv.Rows.Add(provider.ExecuteQuery(query).Rows[0][0].ToString(), provider.ExecuteQuery(query).Rows[0][1].ToString(), tb_soluongddv.Text, provider.ExecuteQuery(query).Rows[0][3].ToString(), provider.ExecuteQuery(query).Rows[0][2].ToString());

        }
        private void bt_deleteddv_Click(object sender, EventArgs e)
        {
            int i;
            i = dgv_dsddv.CurrentRow.Index;
            //MessageBox.Show(i.ToString());
            dgv_dsddv.Rows.RemoveAt(i);
        }


        //----ĐĂNG KÝ DV----\\\

        private void bt_registerddv_Click(object sender, EventArgs e)
        {

            //int i = dgv_dsdp.CurrentRow.Index;
            int j = dgv_dsddv.RowCount;
          
            DataProvider provider = new DataProvider();
            /*            provider.ExecuteQuery(query);
            */
            //MessageBox.Show(dgv_dsddv.Rows[0].Cells[2].Value.ToString().ToString());

            for (int i = 0; i < j - 1; i++)
            {
                string query = "insert into tblChiTietDichVu values('"
               + tb_mahdddv.Text + "','"
               + dgv_dsddv.Rows[i].Cells[0].Value.ToString() + "','"
               + tb_mapddv.SelectedValue.ToString() + "','"
               + dgv_dsddv.Rows[i].Cells[2].Value.ToString() + "','"
               + dgv_dsddv.Rows[i].Cells[3].Value.ToString() + "')";
                provider.ExecuteQuery(query);
            }
            dgv_dsddv.DataSource = null;
            tb_mahdddv.Text = tb_maddv.Text= tb_dongiaddv.Text = "";
            MessageBox.Show("Cám ơn bạn đã đặt Dịch Vụ".ToString());

        }


        //////   ĐẶT PHÒNG   \\\\\\

        private void bt_themdphong_Click(object sender, EventArgs e)
        {
                string query = "select * from tblPhong  where MaP = '" + tb_madp.Text + "'";
                //MessageBox.Show(tb_dmp.Text.ToString());
                DataProvider provider = new DataProvider();
                dgv_dsdp.AutoGenerateColumns = false;
                dgv_dsdp.Rows.Add(provider.ExecuteQuery(query).Rows[0][0].ToString(), provider.ExecuteQuery(query).Rows[0][1].ToString(), provider.ExecuteQuery(query).Rows[0][2].ToString(), provider.ExecuteQuery(query).Rows[0][4].ToString(), tb_ngaythuedp.Text);
        }
        private void bt_xoadp_Click(object sender, EventArgs e)
        {
            int i;
            i = dgv_dsdp.CurrentRow.Index;
            dgv_dsdp.Rows.RemoveAt(i);
        }
        void LoadDatPhong(string tinhtrang)
        {
            string query;
            if(tinhtrang == null)
            {
                 query = "select * from tblPhong";
            }
            else
            {
                 query = "select * from tblPhong where TinhTrang=N'" + tinhtrang + "'";
            }
            DataProvider provider = new DataProvider();
            //dgv_p.DataSource = provider.ExecuteQuery(query);
            
            List<Button> lsBtnXD = new List<Button>();

            foreach (DataRow row in provider.ExecuteQuery(query).Rows)
            {
                Color bColor = new Color();
                switch (row["TinhTrang"])
                {
                    case "Trống":
                        bColor = Color.Green;
                        break;
                    case "Đã Đặt":
                        bColor = Color.Red;
                        break;
                }

                lsBtnXD.Add(new Button() { Text = row["TenP"].ToString() +" "+ row["LoaiP"].ToString(), BackColor = bColor, Dock = DockStyle.Fill });
            }
            for (int i = 0; i < lsBtnXD.Count; i++)
            {
                lsBtnXD[i].Click += btn_Click;
                /*lsBtnXD[i].Leave += btn_Leave;*/
                tlp_dsphong.Controls.Add(lsBtnXD[i]);
            }

            // Hien Ma KH

            string querymakh = "select * from tblKhachHang";
            tb_makhdp.DataSource = provider.ExecuteQuery(querymakh);
            tb_makhdp.DisplayMember = "tblKhachHang";
            tb_makhdp.ValueMember = "MaKH";

            // Hien Ma NV

            string querymanv = "select * from tblNhanVien";
            tb_manvdp.DataSource = provider.ExecuteQuery(querymanv);
            tb_manvdp.DisplayMember = "tblNhanVien";
            tb_manvdp.ValueMember = "MaNV";

            //bt_deletedp.Enabled = false;

            tb_madp.ReadOnly = tb_dongiadp.ReadOnly  = true;


        }
        private void bt_ptrong_Click(object sender, EventArgs e)
        {
            tlp_dsphong.Controls.Clear();
            LoadDatPhong("Trống");
        }
        private void bt_pdadat_Click(object sender, EventArgs e)
        {
            tlp_dsphong.Controls.Clear();
            LoadDatPhong("Đã Đặt");
        }
        private void bt_tatcap_Click(object sender, EventArgs e)
        {
            tlp_dsphong.Controls.Clear();
            LoadDatPhong(null);
        }
        Queue<Button> btnQ = new Queue<Button>();

        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btnQ.Enqueue(btn);
            string[] v = btn.Text.Split(' ');
            //MessageBox.Show(v[1].ToString());
            string query = "select * from tblPhong  where TenP = '" + v[0] + "' and LoaiP =N'" + v[1]+"';";
            DataProvider provider = new DataProvider();

            if (provider.ExecuteQuery(query).Rows[0][3].ToString()=="Đã Đặt")
            {
                MessageBox.Show("Phòng đã có khách đặt".ToString());
            }
            else
            {
            tb_madp.Text = provider.ExecuteQuery(query).Rows[0][0].ToString();
            tb_dongiadp.Text = provider.ExecuteQuery(query).Rows[0][4].ToString();
            }
         
        }
        //----ĐĂNG KÝ PHONG----\\\

        private void bt_registerdp_Click(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;

            //int i = dgv_dsdp.CurrentRow.Index;
            int j=dgv_dsdp.RowCount;
            //MessageBox.Show(j.ToString());
            string query = "insert into tblHoaDon values('"
                 + tb_mahddp.Text + "','"
                 + tb_makhdp.Text + "','"
                 + tb_manvdp.Text + "','"
                 + now + "','"
                 + tb_ngaynhandp.Value + "','"
                 + tb_ngaynhandp.Value.AddDays((double)tb_ngaythuedp.Value) + "','"
                 + "Chưa Thanh Toán" + "')";
            DataProvider provider = new DataProvider();
            provider.ExecuteQuery(query);

            for (int i = 0; i < j - 1; i++)
            {
                string query1 = "insert into tblChiTietPhong values('"
               + tb_mahddp.Text + "','"
               + dgv_dsdp.Rows[i].Cells[0].Value.ToString() + "','"
               + dgv_dsdp.Rows[i].Cells[4].Value.ToString() + "','"
               + dgv_dsdp.Rows[i].Cells[3].Value.ToString() + "')";
                provider.ExecuteQuery(query1);
            }

            for (int i = 0; i < j - 1; i++)
            {
                string query2 = "update tblPhong  set TinhTrang=N'"
                    + "Đã Đặt" + "'  where MaP='" + dgv_dsdp.Rows[i].Cells[0].Value.ToString() + "'";
                provider.ExecuteQuery(query2);
            }
            tb_mahddp.Text = "";
            dgv_dsdp.DataSource = null;
            tb_madp.Text = "";
            tb_dongiadp.Text = "";
            tlp_dsphong.Controls.Clear();
            LoadDatPhong(null);
            MessageBox.Show("Cám ơn bạn đã đặt Phòng".ToString());
            
        }






        // Hàm hiện Khach Hàng
        void LoadKhachHang()
        {
            string query = "select * from tblKhachHang";
            DataProvider provider = new DataProvider();
            dgv_kh.DataSource = provider.ExecuteQuery(query);
        }

        // Hàm xét Giới tính
        string SexKhachHang()
        {
            string sexkh = rbt_sexkh1.Checked ? rbt_sexkh1.Text : rbt_sexkh2.Text;
            return sexkh;
        }

        // Hàm Thêm and Sửa Khách Hàng
        void InsertKhachHang()
        {
            int i = dgv_kh.CurrentRow.Index;
            string mak = dgv_kh.Rows[i].Cells[0].Value.ToString();
            string query;
            if (bt_addkh.Text == "Thêm")
            {
            query="insert into tblKhachHang values('"
                    +tb_makh.Text+ "',N'" 
                    + tb_namekh.Text + "','" 
                    + SexKhachHang() + "','" 
                    + tb_cmndkh.Text + "','" 
                    + tb_phonekh.Text + "',N'" 
                    + tb_addresskh.Text + "')";
            }
            else
            {
            query = "update tblKhachHang set MaKH='" 
                    + tb_makh.Text + "',TenKH=N'" 
                    + tb_namekh.Text + "',GioiTinh=N'" 
                    + SexKhachHang() + "',CMND='" 
                    + tb_cmndkh.Text + "',SDT='" 
                    + tb_phonekh.Text + "',DiaChi=N'" 
                    + tb_addresskh.Text + "'  where MaKH='" + mak + "'";
            }
            DataProvider provider = new DataProvider();
            provider.ExecuteQuery(query);
            LoadKhachHang();
            EscKhachHang();
        }
        // Hành Thoát
        void EscKhachHang()
        {
            tb_makh.Text = "";
            tb_namekh.Text = "";
            tb_phonekh.Text = "";
            tb_addresskh.Text = "";
            tb_cmndkh.Text = "";
            rbt_sexkh1.Checked = false;
            rbt_sexkh2.Checked = false;
            bt_addkh.Text = "Thêm";
            tb_makh.ReadOnly = false;
            dgv_kh.Enabled = bt_editkh.Enabled = bt_deletekh.Enabled = true;
        }
        void DeleteKhachHang()
        {
            int i;
            i = dgv_kh.CurrentRow.Index;
            string mak = dgv_kh.Rows[i].Cells[0].Value.ToString();
            string query = "delete From tblKhachHang where MaKH= '" + mak + "'";
            //MessageBox.Show(g.ToString());
            DataProvider provider = new DataProvider();
            provider.ExecuteQuery(query);
            LoadKhachHang();
        }
        // Lệnh Add
        private void bt_addkh_Click(object sender, EventArgs e)
        {
            InsertKhachHang();
        }

       
        // Lệnh Lấy thông tin kHach Hàng để Sửa
        private void bt_editkh_Click(object sender, EventArgs e)
        {
            int i;
            i = dgv_kh.CurrentRow.Index;
            tb_makh.ReadOnly=true;
            tb_makh.Text = dgv_kh.Rows[i].Cells[0].Value.ToString();
            tb_namekh.Text = dgv_kh.Rows[i].Cells[1].Value.ToString();
            tb_cmndkh.Text = dgv_kh.Rows[i].Cells[3].Value.ToString();
            tb_phonekh.Text = dgv_kh.Rows[i].Cells[4].Value.ToString();
            tb_addresskh.Text = dgv_kh.Rows[i].Cells[5].Value.ToString();
            string sex = dgv_kh.Rows[i].Cells[2].Value.ToString();
            if (sex == "Nam")
            {
                rbt_sexkh1.Checked = true;
            }
            else
            {
                rbt_sexkh2.Checked = true;

            }
            bt_addkh.Text = "Ghi Nhận";
            dgv_kh.Enabled = bt_deletekh.Enabled = bt_editkh.Enabled = false;
        }
        // Lệnh thoát
        private void bt_esckh_Click(object sender, EventArgs e)
        {
            EscKhachHang();
        }
        // Lệnh Xóa Khách hàng
        private void bt_deletekh_Click(object sender, EventArgs e)
        {
            DeleteKhachHang();
        }

        //////       NHÂN VIÊN    \\\\\\\\
        ///
        // Hàm hiện Khach Hàng
        void LoadNhanVien()
        {
            string query = "select * from tblNhanVIen";
            DataProvider provider = new DataProvider();
            dgv_nv.DataSource = provider.ExecuteQuery(query);
        }
        // Hàm xét Giới tính
        string SexNhanVien()
        {
            string sexnv = rbt_sexnv1.Checked ? rbt_sexnv1.Text : rbt_sexnv2.Text;
            return sexnv;
        }

        // Hàm Thêm and Sửa Khách Hàng
        void InsertNhanVien()
        {
            int i = dgv_nv.CurrentRow.Index;
            string manv = dgv_nv.Rows[i].Cells[0].Value.ToString();
            string query;
            if (bt_addnv.Text == "Thêm")
            {
                query = "insert into tblNhanVien values('" 
                    + tb_manv.Text + "',N'" 
                    + tb_namenv.Text + "',N'" 
                    + SexNhanVien() + "','" 
                    + tb_phonenv.Text + "',N'" 
                    + tb_addressnv.Text + "','" 
                    + tb_moneynv.Text + "')";
            }
            else
            {
                query = "update tblNhanVien set MaNv='" 
                    + tb_manv.Text + "',TenNV=N'" 
                    + tb_namenv.Text + "',GioiTinh='" 
                    + SexNhanVien() + "',SDT='" 
                    + tb_phonenv.Text + "',DiaChi=N'" 
                    + tb_addressnv.Text + "',Luong='" 
                    + tb_moneynv.Text + "'  where MaNv='" 
                    + manv + "'";
            }
            DataProvider provider = new DataProvider();
            provider.ExecuteQuery(query);
            LoadNhanVien();
            EscNhanVien();
        }
        // Hành Thoát
        void EscNhanVien()
        {
            tb_manv.Text = "";
            tb_namenv.Text = "";
            tb_moneynv.Text = "";
            tb_addressnv.Text = "";
            tb_phonenv.Text = "";
            rbt_sexnv1.Checked=rbt_sexnv2.Checked = false;
            bt_addnv.Text = "Thêm";
            tb_manv.ReadOnly = false;
            dgv_nv.Enabled = bt_editnv.Enabled = bt_deletenv.Enabled = true;
        }
        void DeleteNhanVien()
        {
            int i;
            i = dgv_nv.CurrentRow.Index;
            string manv = dgv_nv.Rows[i].Cells[0].Value.ToString();
            string query = "delete From tblNhanVien where MaNv= '" + manv + "'";
            //MessageBox.Show(g.ToString());
            DataProvider provider = new DataProvider();
            provider.ExecuteQuery(query);
            LoadNhanVien();
        }

        private void bt_addnv_Click(object sender, EventArgs e)
        {
            InsertNhanVien();
        }

        private void bt_editnv_Click(object sender, EventArgs e)
        {
            int i;
            i = dgv_nv.CurrentRow.Index;
            tb_manv.ReadOnly = true;
            tb_manv.Text = dgv_nv.Rows[i].Cells[0].Value.ToString();
            tb_namenv.Text = dgv_nv.Rows[i].Cells[1].Value.ToString();
            tb_phonenv.Text = dgv_nv.Rows[i].Cells[3].Value.ToString();
            tb_addressnv.Text = dgv_nv.Rows[i].Cells[4].Value.ToString();
            tb_moneynv.Text = dgv_nv.Rows[i].Cells[5].Value.ToString();
            string sex = dgv_nv.Rows[i].Cells[2].Value.ToString();
            if (sex == "Nam")
            {
                rbt_sexnv1.Checked = true;
            }
            else
            {
                rbt_sexnv2.Checked = true;

            }
            bt_addnv.Text = "Ghi Nhận";
            dgv_nv.Enabled = bt_deletenv.Enabled = bt_editnv.Enabled = false;
        }

        private void bt_deletenv_Click(object sender, EventArgs e)
        {
            DeleteNhanVien();
        }

        private void bt_escnv_Click(object sender, EventArgs e)
        {
            EscNhanVien();
        }


        //////       Phòng    \\\\\\\\
        ///
        // Hàm hiện Phòng
        void LoadPhong()
        {
            string query = "select * from tblPhong";
            DataProvider provider = new DataProvider();
            dgv_p.DataSource = provider.ExecuteQuery(query);
            tb_statusp.Items.Clear();
            tb_statusp.Items.Add("Trống");
            tb_statusp.Items.Add("Đã Đặt");
        }
      
        // Hàm xét Giới tính
        string TypePhong()
        {
            string typep = rbt_typep1.Checked ? rbt_typep1.Text : rbt_typep2.Text;
            return typep;
        }

        // Hàm Thêm and Sửa Khách Hàng
        void InsertPhong()
        {
            int i = dgv_p.CurrentRow.Index;
            string map = dgv_p.Rows[i].Cells[0].Value.ToString();
            string query;
            if (bt_addp.Text == "Thêm")
            {
                query = "insert into tblPhong values('"
                    + tb_map.Text + "',N'"
                    + tb_namep.Text + "',N'"
                    + TypePhong() + "',N'"
                    + tb_statusp.Text + "','"
                    + tb_pricep.Text + "')";
            }
            else
            {
                query = "update tblPhong set MaP='"
                    + tb_map.Text + "',TenP=N'"
                    + tb_namep.Text + "',LoaiP=N'"
                    + TypePhong() + "',TinhTrang=N'"
                    + tb_statusp.Text + "',DonGia='"
                    + tb_pricep.Text + "'  where MaP='"
                    + map + "'";
            }
            tb_map.ReadOnly = false;
            DataProvider provider = new DataProvider();
            provider.ExecuteQuery(query);
            LoadPhong();
            EscPhong();
        }
        // Hành Thoát
        void EscPhong()
        {
            tb_map.Text = "";
            tb_namep.Text = "";
            tb_pricep.Text = "";
            tb_statusp.Text = "";
            rbt_typep1.Checked = rbt_typep2.Checked = false;
            bt_addp.Text = "Thêm";
            tb_manv.ReadOnly = false;
            dgv_p.Enabled = bt_editp.Enabled = bt_deletep.Enabled = true;
        }
        void DeletePhong()
        {
            int i;
            i = dgv_p.CurrentRow.Index;
            string map = dgv_p.Rows[i].Cells[0].Value.ToString();
            string query = "delete From tblPhong where MaP= '" + map + "'";
            //MessageBox.Show(g.ToString());
            DataProvider provider = new DataProvider();
            provider.ExecuteQuery(query);
            LoadPhong();
        }

        private void bt_addp_Click(object sender, EventArgs e)
        {
            InsertPhong();
            tlp_dsphong.Controls.Clear();
            LoadDatPhong(null);
        }

        private void bt_editp_Click(object sender, EventArgs e)
        {
            int i;
            i = dgv_p.CurrentRow.Index;
            tb_map.ReadOnly = true;
            tb_map.Text = dgv_p.Rows[i].Cells[0].Value.ToString();
            tb_namep.Text = dgv_p.Rows[i].Cells[1].Value.ToString();
            tb_statusp.Text = dgv_p.Rows[i].Cells[3].Value.ToString();
            tb_pricep.Text = dgv_p.Rows[i].Cells[4].Value.ToString();
            string type = dgv_p.Rows[i].Cells[2].Value.ToString();
            if (type == "Đơn")
            {
                rbt_typep1.Checked = true;
            }
            else
            {
                rbt_typep2.Checked = true;

            }
            bt_addp.Text = "Ghi Nhận";
            dgv_p.Enabled = bt_deletep.Enabled = bt_editp.Enabled = false;
        }

        private void bt_deletep_Click(object sender, EventArgs e)
        {
            DeletePhong();
            tlp_dsphong.Controls.Clear();
            LoadDatPhong(null);
        }

        private void bt_escp_Click(object sender, EventArgs e)
        {
            EscPhong();
        }


        //////       DỊCH VỤ    \\\\\\\\
        ///
        // Hàm hiện Phòng
        void LoadDichVu()
        {
            string query = "select * from tblDichVu";
            DataProvider provider = new DataProvider();
            dgv_dv.DataSource = provider.ExecuteQuery(query);
            tb_unitdv.Items.Clear();
            tb_unitdv.Items.Add("VNĐ/Lần");
            tb_unitdv.Items.Add("VNĐ/Giờ");
            tb_unitdv.Items.Add("VNĐ/Ngày");
        }

        // Hàm Thêm and Sửa Khách Hàng
        void InsertDichVu()
        {
            int i = dgv_dv.CurrentRow.Index;
            string madv = dgv_dv.Rows[i].Cells[0].Value.ToString();
            string query;
            if (bt_adddv.Text == "Thêm")
            {
                query = "insert into tblDichVu values('"
                    + tb_madv.Text + "',N'"
                    + tb_namedv.Text + "',N'"
                    + tb_unitdv.Text + "','"
                    + tb_pricedv.Text + "')";
            }
            else
            {
                query = "update tblDichVu set MaDV='"
                    + tb_madv.Text + "',TenDV=N'"
                    + tb_namedv.Text + "',DonViTinh=N'"
                    + tb_unitdv.Text + "',DonGia='"
                    + tb_pricedv.Text + "'  where MaDV='"
                    + madv + "'";
            }
            DataProvider provider = new DataProvider();
            provider.ExecuteQuery(query);
            LoadDichVu();
            EscDichVu();
        }
        // Hành Thoát
        void EscDichVu()
        {
            tb_madv.Text = "";
            tb_namedv.Text = "";
            tb_pricedv.Text = "";
            tb_unitdv.Text = "";
            bt_adddv.Text = "Thêm";
            tb_madv.ReadOnly = false;
            dgv_dv.Enabled = bt_editdv.Enabled = bt_deletedv.Enabled = true;
        }
        void DeleteDichVu()
        {
            int i;
            i = dgv_dv.CurrentRow.Index;
            string madv = dgv_dv.Rows[i].Cells[0].Value.ToString();
            string query = "delete From tblDichVu where MaDV= '" + madv + "'";
            //MessageBox.Show(g.ToString());
            DataProvider provider = new DataProvider();
            provider.ExecuteQuery(query);
            LoadDichVu();
        }

        private void bt_adddv_Click(object sender, EventArgs e)
        {
            InsertDichVu();
            LoadDatDichVu();
        }

        private void bt_editdv_Click(object sender, EventArgs e)
        {
            int i;
            i = dgv_dv.CurrentRow.Index;
            tb_madv.ReadOnly = true;
            tb_madv.Text = dgv_dv.Rows[i].Cells[0].Value.ToString();
            tb_namedv.Text = dgv_dv.Rows[i].Cells[1].Value.ToString();
            tb_unitdv.Text = dgv_dv.Rows[i].Cells[2].Value.ToString();
            tb_pricedv.Text = dgv_dv.Rows[i].Cells[3].Value.ToString();
            
            bt_adddv.Text = "Ghi Nhận";
            dgv_dv.Enabled = bt_deletedv.Enabled = bt_editdv.Enabled = false;

        }

        private void bt_deletedv_Click(object sender, EventArgs e)
        {
            DeleteDichVu();
        }

        private void bt_escdv_Click(object sender, EventArgs e)
        {
            EscDichVu();
        }

        //////   ĐẶT HoaDon   \\\\\\

        void LoadHoaDon()
        {
            string query = "select * from tblHoaDon";
            DataProvider provider = new DataProvider();
            dgv_hd.DataSource = provider.ExecuteQuery(query);
            bt_hdfinish.Enabled = bt_hdprinter.Enabled = false;
            bt_pay.Enabled = dgv_hd.Enabled = true;
        }

        private void bt_pay_Click(object sender, EventArgs e)
        {
            if(bt_pay.Text=="Thanh Toán")
            {
                int i;
                i = dgv_hd.CurrentRow.Index;
                string mahd = dgv_hd.Rows[i].Cells[0].Value.ToString();
                string query = "select * from tblChiTietPhong where MaHD='" + mahd + "'";
                string query1 = "select * from tblChiTietDichVu where MaHD='" + mahd + "'";
                DataProvider provider = new DataProvider();
                dgv_dshddp.DataSource = provider.ExecuteQuery(query);
                dgv_dshdddv.DataSource = provider.ExecuteQuery(query1);
                /* create proc sp_summ
                 (
                 @id varchar(10)
                 )
                 as
                 begin
                 declare @gtri1 int
                 set @gtri1 = (select sum(SoNgayThue * DonGia) from tblChiTietPhong where MaHD = @id)
                 declare @gtri2 int;
                 set @gtri2 = (select sum(SoLuong * DonGia) from tblChiTietDichVu where MaHD = @id)
                 if @gtri2 is NULL
                 set @gtri2 = 0
                 declare @sum int;
                 set @sum = @gtri1 + @gtri2;
                 select @sum
                 end*/
                string query2 = "exec sp_summ @id='" + mahd + "'";
                tb_hdsum.Text = provider.ExecuteQuery(query2).Rows[0][0].ToString();
                bt_hdfinish.Enabled = bt_hdprinter.Enabled = true;
                dgv_hd.Enabled = false;
                bt_pay.Text = "Hủy";
            }
            else
            {
                bt_pay.Text = "Thanh Toán";
                dgv_dshdddv.DataSource = null;
                dgv_dshddp.DataSource = null;
                dgv_hd.Enabled = true;
                tb_hdsum.Text = "";
            }

        }

        private void bt_searchmakh_Click(object sender, EventArgs e)
        {
            DataProvider provider = new DataProvider();
                string queryhd = "select * from  tblHoaDon where MaKH like '%" + tb_hdmakh.Text + "%'";
                dgv_hd.DataSource = provider.ExecuteQuery(queryhd);
                //MessageBox.Show(tb_hdmakh.SelectedValue.ToString().ToString());
        }

        private void bt_hdfinish_Click(object sender, EventArgs e)
        {
            int i;
            i = dgv_hd.CurrentRow.Index;
            string mahd = dgv_hd.Rows[i].Cells[0].Value.ToString();
            DataProvider provider = new DataProvider();
            string query2 = "update tblhoaDOn  set TinhTrang=N'"
                    + "Đã Thanh Toán" + "'  where MaHD='" + mahd + "'";
                provider.ExecuteQuery(query2);
            MessageBox.Show("Thank You".ToString());
            dgv_dshdddv.DataSource=null;
            dgv_dshddp.DataSource=null;
            LoadHoaDon();
        }

        private void bt_hdprinter_Click(object sender, EventArgs e)
        {
            int i;
            i = dgv_hd.CurrentRow.Index;
            string mahd = dgv_hd.Rows[i].Cells[0].Value.ToString();

            HoaDon hd = new HoaDon();
            TextObject bc = (TextObject) hd.Section4.ReportObjects["tb_moneybchd"];
            decimal tongtien = Convert.ToDecimal(tb_hdsum.Text);
            MessageBox.Show(bc.Text.ToString());

            bc.Text = "123";            

            BaocaoHD bchd = new BaocaoHD(mahd);
      
            bchd.Show();
        }

        private void bt_printkh_Click(object sender, EventArgs e)
        {
            BaocaoKH bckh = new BaocaoKH();
            bckh.Show();
        }

        private void bt_printnv_Click(object sender, EventArgs e)
        {
            BaocaoNV bcnv = new BaocaoNV();
            bcnv.Show();
        }

        private void bt_printdv_Click(object sender, EventArgs e)
        {
            BaocaoDV bcdv = new BaocaoDV();
            bcdv.Show();
        }

        private void bt_printp_Click(object sender, EventArgs e)
        {
          
            BaocaoP bcp = new BaocaoP();
            bcp.Show();
        }
    }
}
