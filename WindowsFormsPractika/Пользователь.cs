using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsPractika
{
    public partial class Пользователь : Form
    {
        public Пользователь()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Услуги f = new Услуги();
            f.Show();
        }
    }
}
