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
    public partial class Пациенты : Form
    {
        int r = 0;
        string ConnStr = @"Data Source=sql;Initial Catalog=44П-Практика-ЗуевРН; Integrated Security=True";
        public Пациенты()
        {
            InitializeComponent();
            FillUsers();
        }

        private void FillUsers()
        {
            string SqlText = null;
            if (MyClass.dolgnost == "lab")
                SqlText = "SELECT id, name, gender, age FROM [Users]";

            else if (MyClass.dolgnost == "admin")
                SqlText = "SELECT * FROM [Users]";
            SqlDataAdapter da = new SqlDataAdapter(SqlText, ConnStr);
            DataSet ds = new DataSet();
            da.Fill(ds, "[Users]");
            dataGridView1.DataSource = ds.Tables["[Users]"].DefaultView;
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
                string SqlText = "insert into [Users] ([name],[login],[password],[gender],[age]) VALUES (\'" + textBox1.Text + "\', \'" + textBox2.Text + "\', \'" + textBox3.Text + "\', \'" + textBox4.Text + "\', " + textBox5.Text + ")";
                MyExecuteNonQuery(SqlText);
                FillUsers();
            }
            else if (MyClass.dolgnost == "lab")
                MessageBox.Show("У вас недостаточно прав для редактирования таблицы.", "Внимание!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MyClass.dolgnost == "admin")
            {
                int index, n;
                n = dataGridView1.Rows.Count;
                if (n == 1) return;
                index = dataGridView1.CurrentRow.Index;
                string id = dataGridView1[0, index].Value.ToString(); ;
                if (r == 0)
                {
                    string name, login, password, gender, age;
                    name = dataGridView1[1, index].Value.ToString();
                    login = dataGridView1[2, index].Value.ToString();
                    password = dataGridView1[3, index].Value.ToString();
                    gender = dataGridView1[4, index].Value.ToString();
                    age = dataGridView1[5, index].Value.ToString();
                    textBox1.Text = name;
                    textBox2.Text = login;
                    textBox3.Text = password;
                    textBox4.Text = gender;
                    textBox5.Text = age;
                    r = 1;
                }
                else if (r == 1)
                {
                    string SqlText = "update [Users] set name = \'" + textBox1.Text + "\', login = \'" + textBox2.Text + "\', password = \'" + textBox3.Text + "\', gender = \'" + textBox4.Text + "\', age = " + textBox5.Text + " where id = " + id;
                    MyExecuteNonQuery(SqlText);
                    FillUsers();
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
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
                string SqlText = "delete from [Users] WHERE id = " + id;
                MyExecuteNonQuery(SqlText);
                FillUsers();
            }
            else if (MyClass.dolgnost == "lab")
                MessageBox.Show("У вас недостаточно прав для редактирования таблицы.", "Внимание!");
        }
    }
}
