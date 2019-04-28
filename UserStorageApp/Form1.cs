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
   
    public partial class Form1 : Form
    {
        public static int idx;
        public Form1()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddUserForm addUser = new AddUserForm();
            addUser.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            ShowListBox();
        }

        public void ShowListBox()
        {
            using (var context = new UserRepoContext())
            {
                var users = context.Users.ToList();
                for (int i = 0; i < users.Count; i++)
                    listBox1.Items.Add(string.Format($"{users[i].Login}                 {users[i].Password}                 {users[i].Phone}                    {users[i].IsAdmin}"));
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            using (var context = new UserRepoContext())
            {
                var users = context.Users.ToList();
                listBox1.Items.Clear();
                foreach (var item in users)
                    if (item.IsAdmin==true)
                        listBox1.Items.Add(string.Format($"{item.Login}                 {item.Password}                 {item.Phone}                    {item.IsAdmin}"));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            
            using (var context = new UserRepoContext())
            {
                var users = context.Users.ToList();
                var user = new User();

                for (int i = 0; i < users.Count; i++)
                    if (i==index)
                    {
                        user = users[i]; break;
                    }
                context.Users.Remove(user);
                context.SaveChanges();

                listBox1.Items.Clear();
                ShowListBox();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UpdatingValueDB();
            AddUserForm addUser = new AddUserForm();
            addUser.Show();
        }

       
        public void UpdatingValueDB()
        {
            int i= listBox1.SelectedIndex;
            idx = i;
        }
    }
}
