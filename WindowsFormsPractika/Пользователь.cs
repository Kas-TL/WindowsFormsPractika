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
    public partial class Пользователь : Form
    {
        string ConnStr = @"Data Source=sql;Initial Catalog=44П-Практика-ЗуевРН; Integrated Security=True";
        public Пользователь()
        {
            InitializeComponent();
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
            Услуги f = new Услуги();
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Сотрудники f = new Сотрудники();
            f.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Пациенты f = new Пациенты();
            f.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Результаты f = new Результаты();
            f.Show();
        }
    }
}
