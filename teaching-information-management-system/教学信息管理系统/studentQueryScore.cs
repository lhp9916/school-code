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
    public partial class studentQueryScore : Form
    {
        public studentQueryScore()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=LHP-PC;Initial Catalog=教学库2;Integrated Security=True");
            string stuID = Login.username;
            string selectStr = "select 课程名,学分,成绩 from 课程,选课  where 课程.课程号=选课.课程号 and 选课.学生号='"+stuID+"'";
            SqlDataAdapter sda = new SqlDataAdapter(selectStr, conn);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ModifyPwd mdfp = new ModifyPwd();
            mdfp.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            studentElect stue = new studentElect();
            stue.Show();
        }
    }
}
