using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entity_Model
{
    public partial class Form2 : Form
    {
        TqEntities dbcontext = new TqEntities();
        public Form2()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                product prod = new product();
                prod.id = Convert.ToInt32(txtId.Text);
                prod.name = txtName.Text;
                prod.price = Convert.ToInt32(txtPrice.Text);
                dbcontext.products.Add(prod);
                dbcontext.SaveChanges();
                MessageBox.Show("Saved");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                product prod =dbcontext.products.Find( Convert.ToInt32(txtId.Text));
                if (prod != null)
                {
                    prod.name = txtName.Text;
                    prod.price = Convert.ToInt32(txtPrice.Text);
                    dbcontext.SaveChanges();
                    MessageBox.Show("Updated");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                product prod = dbcontext.products.Find(Convert.ToInt32(txtId.Text));
                if (prod != null)
                {
                    txtName.Text=prod.name;
                    txtPrice.Text = prod.price.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDlete_Click(object sender, EventArgs e)
        {
            try
            {
                product prod = dbcontext.products.Find(Convert.ToInt32(txtId.Text));
                if (prod != null)
                {
                    dbcontext.products.Remove(prod);
                    dbcontext.SaveChanges();
                    MessageBox.Show("Removed");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dbcontext.products.ToList();
        }
    }
}
