using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OZ_Bookstore_database
{
    public partial class Books : Form
    {
        public Books()
        {
            InitializeComponent();
        }

        private void Books_FormClosing(object sender, FormClosingEventArgs e)
        {
            Main.main.Show();
        }

        private void Books_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void loadData()
        {
            this.издательстваTableAdapter.Fill(this.databaseDataSet.Издательства);
            this.книгиTableAdapter.Fill(this.databaseDataSet.Книги);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Все изменения в системе будут сохранены в базе данных.\r\n" +
                "Продолжить сохранение?",
                "Подтвердите сохранение",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
                try
                {
                    книгиTableAdapter.Update(databaseDataSet.Книги);
                    MessageBox.Show("Изменения сохранены");
                    loadData();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        //сброс
        private void button2_Click(object sender, EventArgs e)
        {
            книгиBindingSource.Filter ="";
            loadData();
        }
        // найти
        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                книгиBindingSource.Filter = "[Название] LIKE'%" + textBox1.Text + "%'";
            }
            else if (radioButton2.Checked)
            {
                книгиBindingSource.Filter = "[Название_Оригинал] LIKE'%" + textBox1.Text + "%'";
            }
            else if (radioButton3.Checked)
            {
                книгиBindingSource.Filter = "[Издательство] LIKE'%" + textBox1.Text + "%'";
            }
            else if (radioButton4.Checked)
            {
                try{
                    int year = int.Parse(textBox1.Text);
                    книгиBindingSource.Filter = "[Год издания] =" + year + "";
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (radioButton5.Checked)
            {
                try
                {
                    int size = int.Parse(textBox1.Text);
                    книгиBindingSource.Filter = "[Страниц] =" + size + "";
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (radioButton6.Checked)
            {
                книгиBindingSource.Filter = "[ISBN] LIKE'%" + textBox1.Text + "%'";
            }

        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
    }
}
