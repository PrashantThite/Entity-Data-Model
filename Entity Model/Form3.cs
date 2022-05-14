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
    public partial class Form3 : Form
    {
        TqEntities1 dbcontext = new TqEntities1();

        public Form3()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Student stud = new Student();
                stud.RollNo=Convert.ToInt32(txtRollNo.Text);
                stud.Name = txtName.Text;
                stud.Stream= txtStream.Text;
                stud.Percentage = Convert.ToInt32(txtPercent.Text);
                dbcontext.Students.Add(stud);
                dbcontext.SaveChanges();
                MessageBox.Show("Saved");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Student stud = dbcontext.Students.Find(Convert.ToInt32(txtRollNo.Text));
                if (stud != null)
                {
                    stud.Name = txtName.Text;
                    stud.Stream = txtStream.Text;
                    stud.Percentage = Convert.ToInt32(txtPercent.Text);
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
                Student stud = dbcontext.Students.Find(Convert.ToInt32(txtRollNo.Text));
                if (stud != null)
                {
                    txtName.Text = stud.Name;
                     txtStream.Text= stud.Stream;
                    txtPercent.Text = stud.Percentage.ToString();
                }
                else
                {
                    MessageBox.Show(" No record found ");
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
                Student stud = dbcontext.Students.Find(Convert.ToInt32(txtRollNo.Text));
                if (stud != null)
                {
                    dbcontext.Students.Remove(stud);
                    dbcontext.SaveChanges();
                    MessageBox.Show("Deleated");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dbcontext.Students.ToList();
        }
    }
}
