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
    public partial class Авторизация : Form
    {
        string ConnStr = @"Data Source=sql;Initial Catalog=44П-Практика-ЗуевРН;Integrated Security=True";
        public Авторизация()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string dolgnost, login, name, password;
            login = textBox1.Text;
            SqlCommand cmd;
            SqlConnection cn = new SqlConnection(ConnStr);
            cn.Open();
            cmd = cn.CreateCommand();
            cmd.CommandText = "select dolgnost from [Workers] where \'" + login + "\' = login";
            dolgnost = (string)cmd.ExecuteScalar();
            cmd.CommandText = "select name from [Workers] where \'" + login + "\' = login";
            name = (string)cmd.ExecuteScalar();
            cmd.CommandText = "select password from [Workers] where \'" + login + "\' = login";
            password = (string)cmd.ExecuteScalar();
            cn.Close();

            if ((MyClass.dolgnost == null) || (password != textBox2.Text))
                MessageBox.Show("Неправильно введён логин или пароль, повторите ввод.", "Внимание!");
            else
            {
                Пользователь f = new Пользователь();
                f.Show();
                if (MyClass.dolgnost == "lab")
                {
                    f.label4.Text = name;
                    f.label3.Text = "Лаборант";
                    f.pictureBox1.Image = Image.FromFile("//main/RDP/44П/зуеврн/Desktop/MDK_01_01/Practika/Forma/WindowsFormsPractika/laborant_1.jpg");
                }
                else if (MyClass.dolgnost == "admin")
                {
                    f.label4.Text = name;
                    f.label3.Text = "Администратор";
                    f.pictureBox1.Image = Image.FromFile("//main/RDP/44П/зуеврн/Desktop/MDK_01_01/Practika/Forma/WindowsFormsPractika/Administrator.png");
                }
            }

        }
    }
    class MyClass
    {

        public static string dolgnost { get; set; }
    }
}
