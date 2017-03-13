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
    public partial class adminStudentAdd : Form
    {
        public adminStudentAdd()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (textBox1.Text == "" || textBox2.Text == "")
                {
                    MessageBox.Show("学号或者姓名不能为空！");
                }
                SqlConnection conn = new SqlConnection("Data Source=LHP-PC;Initial Catalog=教学库2;Integrated Security=True");
                string sex = "";
                if (radioButton1.Checked)
                {
                    sex = "男";
                }
                else if (radioButton2.Checked)
                { sex = "女"; }

                string insql = "insert 学生(学生号,密码,姓名,性别,年级,专业) values('" + textBox1.Text + "','" + textBox1.Text + "','" + textBox2.Text + "','" + sex + "','" + comboBox1.SelectedItem + "','" + comboBox2.SelectedItem + "')";
                SqlCommand insertCmd = new SqlCommand(insql, conn);
                conn.Open();
                int flag = insertCmd.ExecuteNonQuery();
                if (flag > 0)
                {
                    label7.Text = "成功添加学生信息！";
                }
                else
                {
                    label7.Text = "添加失败，查看输入是否正确";
                }
                conn.Close();
            }
            catch { MessageBox.Show("操作有误，请检查输入！"); }
        }

 
    }
}
