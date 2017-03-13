using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 教学信息管理系统
{
    public partial class ModifyPwd : Form
    {
        public ModifyPwd()
        {
            InitializeComponent();
        }

        private void ModifyPwd_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = Login.username;
            string userRole = Login.userRole;
            string newPwd1 = textBox2.Text;
            string newPwd2=textBox3.Text;
            if(newPwd1=="" || newPwd2=="" ||username=="")
            {
                MessageBox.Show("用户名或密码不能为空");
             }
            else if(textBox2.Text!=textBox3.Text)
            {
                MessageBox.Show("两次输入的密码不一致，请重新输入！");
            }
            string constr="Data Source=LHP-PC;Initial Catalog=教学库2;Integrated Security=True";
            string selectStr="";
            string updetestr="";
            try
            {
                switch(userRole)
                {
                    case "0":
                    selectStr = "Select * from 教师 where 教师号='" + username + "'";
                    updetestr = "update 教师 set 密码='" + newPwd1 + "'  where 教师号='" + username + "'";
                    break;
                
                    case "1":
                    selectStr = "select * from 学生 where 学生号='" + username + "'";
                    updetestr = "update 学生 set 密码='" + newPwd1 + "'  where 学生号='" + username + "'";
                    break;
                 
                    case "2":
                    selectStr = "select * from 管理员 where 管理员账号='" + username + "'";
                    updetestr = "update 管理员 set 密码='" + newPwd1 + "'  where 管理员账号='" + username + "'";
                    break;
                }
                SqlConnection con = new SqlConnection(constr);
                SqlCommand selectcmd = new SqlCommand(selectStr, con);
                SqlCommand updeecmd = new SqlCommand(updetestr, con);
                con.Open();
                selectcmd.ExecuteNonQuery();
                int flag= updeecmd.ExecuteNonQuery();
                if (flag > 0)
                {
                    MessageBox.Show("密码修改成功！");
                }
                else
                {
                    MessageBox.Show("密码修改失败！");
                }
                con.Close();
            }
            catch
            {
                MessageBox.Show("程序异常，请检查输入！");
            }
              
                
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox3.Text = "";
        }
    }
}
