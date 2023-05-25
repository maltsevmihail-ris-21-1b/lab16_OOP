using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab16_OOP
{
    public partial class DeleteForm : Form
    {
        public DeleteForm()
        {
            InitializeComponent();
        }

        private void DeleteForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Program.IsInt(textBox1.Text))
            {
                if (Program.list.Remove(Int32.Parse(textBox1.Text) - 1))
                {
                    this.Close();
                }
                else
                {
                    var errorForm = new ErrorFoem();
                    errorForm.ShowDialog();
                }
            }
            else
            {
                var errorForm = new ErrorFoem();
                errorForm.ShowDialog();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
