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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        public static string username;
        public static string userRole;
        private void button1_Click(object sender, EventArgs e)
        {
            username = textBox1.Text;
            string userPwd = textBox2.Text;
            if(username=="" || userPwd=="")
            {
                MessageBox.Show("用户名或密码不能为空");
             }
            string constr="Data Source=LHP-PC;Initial Catalog=教学库2;Integrated Security=True";
            string selectStr="";
            try
            {
                if (radioButton1.Checked)
                {
                    userRole = "0";
                    selectStr = "Select * from 教师 where 教师号='" + username + "'";
                }
                else if (radioButton2.Checked)
                {
                    userRole = "1";
                    selectStr = "select * from 学生 where 学生号='" + username + "'";
                }
                else if (radioButton3.Checked)
                {
                    userRole = "2";
                    selectStr = "select * from 管理员 where 管理员账号='" + username + "'";
                }
                SqlConnection con = new SqlConnection(constr);
                SqlCommand cmd = new SqlCommand(selectStr, con);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                sdr.Read();

                if (sdr.GetString(1) == userPwd)
                {
                    switch (userRole)
                    {
                        case "0":
                            teacherCourseDetails tcd = new teacherCourseDetails();
                            tcd.Show(); break;
                        case "1":
                            studentQueryScore sqs = new studentQueryScore();
                            sqs.Show(); break;
                        case "2":
                            main ma = new main();
                            ma.Show(); break;
                    }
                }
                else
                {
                    MessageBox.Show("用户名或密码不正确！");
                }
            }
            catch
            {
                MessageBox.Show("操作有误，请检查输入！");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
