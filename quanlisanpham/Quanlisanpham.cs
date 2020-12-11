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
using BLL;
namespace quanlisanpham
{
    public partial class Quanlisanpham : Form
    {
        
        public Quanlisanpham()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Them them = new Them();
            them.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnxem_Click(object sender, EventArgs e)
        {
            UserBLL.Instance.Xem(dtgv1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                UserBLL.Instance.Xoa(dtgv1);
                MessageBox.Show("Xóa thành công");
                btnxem_Click(sender, e);
            }
            catch (Exception)
            {

                MessageBox.Show("Lỗi");
                btnxem_Click(sender, e);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Mời bạn chọn loại sản phẩm cần tìm");
            }
            else
            {
                UserBLL.Instance.Timkiem(dtgv1, comboBox1.Text);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                UserBLL.Instance.Sua(dtgv1);
                MessageBox.Show("Sửa thành công");
                btnxem_Click(sender, e);
            }
            catch (Exception)
            {

                MessageBox.Show("Lỗi");
                btnxem_Click(sender, e);
            }
        }
        List<User> users = new List<User>();
        List<DataGirdView> row = new List<DataGirdView>();
        private void dtgv1_DoubleClick(object sender, EventArgs e)
        {
            UserBLL.Instance.DoubleclickkDtgv1(dtgv1, dtgv2,txttotal);
        }

        private void dtgv2_DoubleClick(object sender, EventArgs e)
        {
            UserBLL.Instance.DoubleClickDtgv2(dtgv1, dtgv2, txttotal);
        }
    }
}
