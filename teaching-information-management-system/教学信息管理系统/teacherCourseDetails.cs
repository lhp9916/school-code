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
    public partial class teacherCourseDetails : Form
    {
        public teacherCourseDetails()
        {
            InitializeComponent();
        }

        private void teacherCourseDetails_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=LHP-PC;Initial Catalog=教学库2;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter("select * from 课程", conn);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ModifyPwd mfp = new ModifyPwd();
            mfp.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            teacherSubmitScore tsubmits = new teacherSubmitScore();
            tsubmits.Show();
        }
    }
}
