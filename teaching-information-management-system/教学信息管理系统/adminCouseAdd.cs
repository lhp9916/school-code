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
    public partial class adminCouseAdd : Form
    {
        public adminCouseAdd()
        {
            InitializeComponent();
        }

        private void adminCouseAdd_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“教学库2DataSet.教师”中。您可以根据需要移动或删除它。
            this.教师TableAdapter.Fill(this.教学库2DataSet.教师);
            // TODO: 这行代码将数据加载到表“教学库2DataSet.教师”中。您可以根据需要移动或删除它。
            //this.教师TableAdapter.Fill(this.教学库2DataSet.教师);
            // TODO: 这行代码将数据加载到表“教学库2DataSet.教师”中。您可以根据需要移动或删除它。
           // this.教师TableAdapter.Fill(this.教学库2DataSet.教师);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection("Data Source=LHP-PC;Initial Catalog=教学库2;Integrated Security=True");
                string rkls = comboBox1.SelectedValue.ToString();
                string insql = "insert into 课程(课程号,课程名,学分,课时,教师号) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + rkls+ "')";
                SqlCommand cmd = new SqlCommand(insql, conn);
                conn.Open();
                int flag = cmd.ExecuteNonQuery();
                if (flag > 0)
                {
                   MessageBox.Show("成功添加课程信息！");
                }
                else
                {
                    MessageBox.Show( "添加课程信息失败，查看输入是否正确！");
                }
                conn.Close();
            }
            catch
            { MessageBox.Show("程序某处出现异常，请检查！"); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }
    }
}
