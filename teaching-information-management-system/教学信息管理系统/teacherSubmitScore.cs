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
    public partial class teacherSubmitScore : Form
    {
        public teacherSubmitScore()
        {
            InitializeComponent();
        }

        private void teacherSubmitScore_Load(object sender, EventArgs e)
        {
            string jsh = Login.username;
            SqlConnection con = new SqlConnection("Data Source=LHP-PC;Initial Catalog=教学库2;Integrated Security=True");
            string selectStr = "select 学生.学生号,姓名,课程.课程号,年级,专业,成绩 FROM 学生,选课,课程 WHERE 学生.学生号=选课.学生号 AND 选课.课程号=课程.课程号 and 课程.教师号='"+jsh+"'";
            SqlDataAdapter sda = new SqlDataAdapter(selectStr, con);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LHP-PC;Initial Catalog=教学库2;Integrated Security=True");
            string updateStr;
            string stunub;
            string coureID;
            string score;
            int i;
            for (i = 0; i < dataGridView1.Rows.Count; i++)
            {
                stunub = dataGridView1.Rows[i].Cells[0].Value.ToString();
                coureID = dataGridView1.Rows[i].Cells[2].Value.ToString();
                score = dataGridView1.Rows[i].Cells[5].Value.ToString();
                updateStr = "update 选课 set 成绩 ='" + score + "'  where 学生号='" + stunub +  "'  and 课程号='"+coureID+"'";
                SqlCommand cmd = new SqlCommand(updateStr, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
           
            MessageBox.Show("成绩录入成功！");
            
        }
    }
}
