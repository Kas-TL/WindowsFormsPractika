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

namespace WindowsFormsPractika
{
    public partial class Услуги : Form
    {
        int r = 0;
        string ConnStr = @"Data Source=sql;Initial Catalog=44П-Практика-ЗуевРН;Integrated Security=True";
        public Услуги()
        {
            FillService();
            InitializeComponent();
        }

        private void FillService()
        {
            string SqlText = "SELECT * FROM [Service]";
            SqlDataAdapter da = new SqlDataAdapter(SqlText, ConnStr);
            DataSet ds = new DataSet();
            da.Fill(ds, "[Service]");
            dataGridView1.DataSource = ds.Tables["[Service]"].DefaultView;
        }
        public void MyExecuteNonQuery(string SqlText)
        {
            SqlConnection cn;
            SqlCommand cmd;

            cn = new SqlConnection(ConnStr);
            cn.Open();
            cmd = cn.CreateCommand();
            cmd.CommandText = SqlText;
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MyClass.dolgnost == "admin")
            {
                string SqlText = "insert into [Service] ([id],[service],[price]) VALUES (" + textBox1.Text + ", \'" + textBox2.Text + "\', " + textBox3.Text + ")";
                MyExecuteNonQuery(SqlText);
                FillService();
            }
            else if (MyClass.dolgnost == "lab")
                MessageBox.Show("У вас недостаточно прав для редактирования таблицы.", "Внимание!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MyClass.dolgnost == "admin")
            {
                if (r == 0)
                {
                    int index, n;
                    string id, service, price;
                    n = dataGridView1.Rows.Count;
                    if (n == 1) return;
                    index = dataGridView1.CurrentRow.Index;
                    id = dataGridView1[0, index].Value.ToString();
                    service = dataGridView1[1, index].Value.ToString();
                    price = dataGridView1[2, index].Value.ToString();
                    textBox1.Text = id;
                    textBox2.Text = service;
                    textBox3.Text = price;
                    r = 1;
                }
                else if (r == 1)
                {
                    string SqlText = "update [Service] set id = " + textBox1.Text + ", service = \'" + textBox2.Text + "\', price = " + textBox3.Text + " where id = " + textBox1.Text;
                    MyExecuteNonQuery(SqlText);
                    FillService();
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    r = 0;
                }
            }
            else if (MyClass.dolgnost == "lab")
                MessageBox.Show("У вас недостаточно прав для редактирования таблицы.", "Внимание!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MyClass.dolgnost == "admin")
            {
                int index, n;
                string id;
                index = dataGridView1.CurrentRow.Index;
                id = Convert.ToString(dataGridView1[0, index].Value);
                string SqlText = "delete from [Service] WHERE id = " + id;
                MyExecuteNonQuery(SqlText);
                FillService();
            }
            else if (MyClass.dolgnost == "lab")
                MessageBox.Show("У вас недостаточно прав для редактирования таблицы.", "Внимание!");
        }
    }
}
