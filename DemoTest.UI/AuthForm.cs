using DemoTest.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DemoTest.Context.Models;

namespace DemoTest.UI
{
    public partial class AuthForm : Form
    {
        public AuthForm()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            using (var db = new DemoTestDBContext())
            {
                var user = db.Users.Include(x => x.Role).FirstOrDefault(x => x.Login == txtLogin.Text
                && x.Password == txtPassword.Text);

                if(user == null)
                {
                    MessageBox.Show("Неправильно набран логин/пароль","Ошибка авторизации",MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    CurrectUser.User = user;
                    MessageBox.Show("Добро пожаловать, "+user.FIO, "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    MainForm mf = new MainForm();
                    mf.Owner = this;
                    this.Hide();
                    mf.ShowDialog();
                    this.Close();
                }    
            }
        }
    }
}
