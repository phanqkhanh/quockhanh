using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
namespace DAL
{
    public class UserDAL
    {
        private static UserDAL instance;
        public static UserDAL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserDAL();
                }
                return instance;
            }
        }
        private UserDAL() { }
        public List<User> Xem()
        {
            List<User> users = new List<User>();
            string query = "SELECT ID AS 'Mã SP',Price AS 'Giá Tiền', MetaDescription AS 'Tên sản phẩm',Amount AS 'Số lượng' FROM dbo.Products";
            DataTable data = DataProvider.Instance.Excutequery(query);
            foreach (DataRow item in data.Rows)
            {
                string id = item["Mã SP"].ToString();
                string price = item["Giá Tiền"].ToString();
                string name = item["Tên sản phẩm"].ToString();
                string amount = item["Số lượng"].ToString();
                User newuser = new User(id, price, name,amount);
                users.Add(newuser);
            }
            return users;
        }
        public List<User> Timkiem(string combobox)
        {

            List<User> users = new List<User>();

            string query = $"SELECT ID AS 'Mã SP',Price AS 'Giá Tiền', MetaDescription AS 'Tên sản phẩm',Amount AS 'Số lượng' FROM dbo.Products WHERE MetaDescription LIKE '{combobox}%'";
            DataTable data = DataProvider.Instance.Excutequery(query);
            foreach (DataRow item in data.Rows)
            {
                string id = item["Mã SP"].ToString();
                string price = item["Giá Tiền"].ToString();
                string name = item["Tên sản phẩm"].ToString();
                string amount = item["Số lượng"].ToString();
                User newuser = new User(id, price, name,amount);
                users.Add(newuser);
            }
            return users;
        }



        public bool Sua(string id, User user)
        {
            string query = $"Update dbo.Products set Price = '{user.Price}', MetaDescription = '{user.Name}', Amount ='{user.Amount}' Where ID = {id}";
            if (DataProvider.Instance.ExecuteNonquery(query) > 0)
            {
                return true;
            }
            return false;
        }
        public bool Xoa(string id)
        {
            string query = $"delete dbo.Products  where ID = {id}";
            if (DataProvider.Instance.ExecuteNonquery(query) > 0)
            {
                return true;
            }
            return false;
        }
        public bool Them(string price, string name, string amount)
        {
            string query = $"Insert into dbo.Products(Price, MetaDescription, Amount) values('{price}', '{name}',{amount})";
            if (DataProvider.Instance.ExecuteNonquery(query) > 0)
            {
                return true;
            }
            return false;
        }
        
        
        public List<User> Doubleclickk(string id)
        {
            List<User> list = new List<User>();
            string query = $"SELECT ID AS 'Mã SP',Price AS 'Giá Tiền', MetaDescription AS 'Tên sản phẩm', Amount AS'Số lượng' FROM dbo.Products Where ID ={id}";
            DataTable data = DataProvider.Instance.Excutequery(query);
            //string i = data.Columns["Mã SP"].ToString();
            foreach (DataRow item in data.Rows)
            {
                string idd = item["Mã SP"].ToString();
                string price = item["Giá Tiền"].ToString();
                string name = item["Tên sản phẩm"].ToString();
                string amount = item["Số lượng"].ToString();
                amount = "1";

                User us = new User(idd, price, name, amount);
                list.Add(us);
            }
            return list;
        }
        public int AmountMinus(string amount)
        {
            int a = Int32.Parse(amount);
            return a = a - 1;
        }
        public int AmountPlus(string amount)
        {
            int a = Int32.Parse(amount);
            return a = a + 1;
        }
        int tong = 0;
        int tongsoluong = 0;
        public string PlusTotal(string price, DataGridView dtgv2, string total)
        {
            int txtTotal = Int32.Parse(total);
            int soluong = 0;
            
            int a = Int32.Parse(price);
            
            int amountProduct = dtgv2.Rows.Count;
            for (int i = 0; i < dtgv2.Rows.Count; i++)
            {
                string b = dtgv2.Rows[i].Cells["Amount"].Value.ToString();
                int c = Int32.Parse(b)-1;
                soluong += c;
            }
            tongsoluong = amountProduct + soluong;
            if(tongsoluong == 3 )
            {
                tong = tong + a - 100000;
                return tong.ToString();
            }
            else if(tongsoluong == 5)
            {
                tong = tong + a - 100000;
                return tong.ToString();
            }
            tong = tong + a;
            return tong.ToString();
        }
        
        public string MinusTotal(string price, DataGridView dtgv2, string total)
        {
            int txtTotal = Int32.Parse(total);
            int soluong = 0;

            int a = Int32.Parse(price);

            int amountProduct = dtgv2.Rows.Count;
            for (int i = 0; i < dtgv2.Rows.Count; i++)
            {
                string b = dtgv2.Rows[i].Cells["Amount"].Value.ToString();
                int c = Int32.Parse(b) - 1;
                soluong += c;
            }
            tongsoluong = amountProduct + soluong;
            if (tongsoluong == 2 )
            {
                tong = tong - a +100000;
                return tong.ToString();
            }
            else if (tongsoluong == 4 )
            {
                tong = tong - a +100000;
                return tong.ToString();
            }
            tong = tong - a;
            return tong.ToString();
        }
    }
}
