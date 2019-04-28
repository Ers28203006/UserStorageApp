using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserStoradge.DataAccess;
using UserStoradge.Models;

namespace UserStorageApp
{
    public partial class AddUserForm : Form
    {
        public AddUserForm()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool isAdmin;
            bool.TryParse(comboBox2.Text, out isAdmin);
            User user = new User
            {
                Login = textBox2.Text,
                Password = textBox3.Text,
                Address = textBox4.Text,
                Phone = textBox5.Text,
                IsAdmin = isAdmin
            };
            using (var context=new UserRepoContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
            Form1 form = new Form1();
            form.ShowListBox();
            Close();
        }

        private void AddUserForm_Load(object sender, EventArgs e)
        {

            comboBox2.Items.Add(true);
            comboBox2.Items.Add(false);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            using (var context = new UserRepoContext())
            {
                var users = context.Users.ToList();
                var user = new User();

                for (int i = 0; i < users.Count; i++)
                    if (i == Form1.idx)
                    {
                        user = users[i]; break;
                    }
                context.Users.Attach(user);
                user.Login = textBox2.Text;
                user.Password = textBox2.Text;
                user.Address = textBox2.Text;
                user.Phone = textBox2.Text;
                bool isAdmin;
                bool.TryParse(comboBox2.Text, out isAdmin);
                user.IsAdmin = isAdmin;
                context.SaveChanges();
                form.ShowListBox();
                Close();
            }
        }
    }
}
