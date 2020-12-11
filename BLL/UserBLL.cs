using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using DTO;
namespace BLL
{
    public class UserBLL
    {
        private static UserBLL instance;

        public static UserBLL Instance 
        {
            get
            {
                if(instance == null)
                {
                    instance = new UserBLL();
                }
                return instance;
            }
        }
        private UserBLL() { }
        public void Xem(DataGridView dtgv1)
        {
            dtgv1.DataSource = UserDAL.Instance.Xem();
        }

        public bool Them( string text1, string text2, string text3)
        {
            return UserDAL.Instance.Them(text1,text2,text3);
        }

        public void Timkiem(DataGridView dtgv1, string combobox)
        {
            dtgv1.DataSource = UserDAL.Instance.Timkiem(combobox);
            
        }
        public bool Xoa(DataGridView dtgv1)
        {
            string id= dtgv1.SelectedCells[0].OwningRow.Cells["ID"].Value.ToString();
            return UserDAL.Instance.Xoa(id);
        }

        public bool Sua(DataGridView dtgv1)
        {
            string id = dtgv1.SelectedCells[0].OwningRow.Cells["Id"].Value.ToString();
            string price = dtgv1.SelectedCells[0].OwningRow.Cells["Price"].Value.ToString();
            string name = dtgv1.SelectedCells[0].OwningRow.Cells["Name"].Value.ToString();
            string amount = dtgv1.SelectedCells[0].OwningRow.Cells["Amount"].Value.ToString();
            User newuser = new User(id, price, name, amount);
            
            return UserDAL.Instance.Sua(id, newuser);
        }
        
        List<User> list = new List<User>();
        //List<User> list2 = new List<User>();
        public void DoubleclickkDtgv1(DataGridView dtgv1, DataGridView dtgv2, TextBox total)
        {
            string id = dtgv1.SelectedCells[0].OwningRow.Cells["ID"].Value.ToString();
            string price = dtgv1.SelectedCells[0].OwningRow.Cells["Price"].Value.ToString();
            string amount = dtgv1.SelectedCells[0].OwningRow.Cells["Amount"].Value.ToString();
            

            List<User> listus = new List<User>();
            listus.AddRange(UserDAL.Instance.Doubleclickk(id));
            if (dtgv2.DataSource == null)
            {
                list.AddRange(listus);
                dtgv2.DataSource = null;
                dtgv2.DataSource = list;
                dtgv1.SelectedCells[0].OwningRow.Cells["Amount"].Value = UserDAL.Instance.AmountMinus(amount);
                
            }
            else
            {
                for (int i = 0; i < list.Count; i++)
                {

                        if (list[i].Id == listus[0].Id)
                        {
                        dtgv1.SelectedCells[0].OwningRow.Cells["Amount"].Value = UserDAL.Instance.AmountMinus(amount);
                        for (int j = 0; j < dtgv2.Rows.Count; j++)
                        {
                            string iddtgv2 = dtgv2.Rows[j].Cells["Id"].Value.ToString();
                            if (id == iddtgv2)
                            {
                                string amountdtgv2 = dtgv2.Rows[i].Cells["Amount"].Value.ToString();
                                dtgv2.Rows[i].Cells["Amount"].Value = UserDAL.Instance.AmountPlus(amountdtgv2);
                            }
                        }
                        total.Text = UserDAL.Instance.PlusTotal(price,dtgv2,total.Text);
                        return;
                        }
                }
                list.AddRange(listus);
                dtgv1.SelectedCells[0].OwningRow.Cells["Amount"].Value = UserDAL.Instance.AmountMinus(amount);
                dtgv2.DataSource = null;
                dtgv2.DataSource = list;
            }
            
            total.Text = UserDAL.Instance.PlusTotal(price,dtgv2,total.Text);
            
        }
        
        public void DoubleClickDtgv2(DataGridView dtgv1, DataGridView dtgv2, TextBox total)
        {
            string id = dtgv2.SelectedCells[0].OwningRow.Cells["Id"].Value.ToString();
            string amount = dtgv2.SelectedCells[0].OwningRow.Cells["Amount"].Value.ToString();
            string price = dtgv2.SelectedCells[0].OwningRow.Cells["Price"].Value.ToString();
            int a = Int32.Parse(amount);
            if(a > 1)
            {
                dtgv2.SelectedCells[0].OwningRow.Cells["Amount"].Value = UserDAL.Instance.AmountMinus(amount);
                for (int i = 0; i < dtgv1.Rows.Count; i++)
                {
                    string iddtgv1 = dtgv1.Rows[i].Cells["Id"].Value.ToString();
                    if(id == iddtgv1)
                    {
                        string Amountdtgv1 = dtgv1.Rows[i].Cells["Amount"].Value.ToString();
                        dtgv1.Rows[i].Cells["Amount"].Value = UserDAL.Instance.AmountPlus(Amountdtgv1);
                    }
                }
                total.Text = UserDAL.Instance.MinusTotal(price, dtgv2, total.Text);
            }
            else if( a == 1)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if(id == list[i].Id)
                    {
                        list.RemoveAt(i);
                        dtgv2.DataSource = null;
                        dtgv2.DataSource = list;
                        for (int j = 0; j < dtgv1.Rows.Count; j++)
                        {
                            string iddtgv1 = dtgv1.Rows[j].Cells["Id"].Value.ToString();
                            if (id == iddtgv1)
                            {
                                string Amountdtgv1 = dtgv1.Rows[j].Cells["Amount"].Value.ToString();
                                dtgv1.Rows[j].Cells["Amount"].Value = UserDAL.Instance.AmountPlus(Amountdtgv1);
                            }
                        }
                        total.Text = UserDAL.Instance.MinusTotal(price, dtgv2, total.Text);
                    }
                }
            }      

        }
    }
}



