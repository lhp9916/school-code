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
    public partial class adminTeacherAdd : Form
    {
        public adminTeacherAdd()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }
        //添加按钮事件
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //创建连接对象
                string sex = "";
                if (radioButton1.Checked)
                {
                    sex = "男";
                }
                else if (radioButton2.Checked)
                { sex = "女"; }
                SqlConnection conn = new SqlConnection("Data Source=LHP-PC;Initial Catalog=教学库2;Integrated Security=True");
                string insql = "insert into 教师(教师号,密码,姓名,性别,院系) values('" + textBox1.Text + "','" + textBox1.Text + "','" + textBox2.Text + "','" + sex + "','" + comboBox1.SelectedItem + "')";
                SqlCommand com = new SqlCommand(insql, conn);
                conn.Open();
                int flag = com.ExecuteNonQuery();
                if (flag > 0)
                {
                    label6.Text = "成功添加教师信息！";
                }
                else
                {
                    label6.Text = "添加失败，查看输入是否正确";
                }
                conn.Close();
            }
            catch { MessageBox.Show("程序某个地方有问题，请检查！"); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            label6.Text = "";
        }
    }
}
