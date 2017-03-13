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
    public partial class studentElect : Form
    {
        public studentElect()
        {
            InitializeComponent();
        }

        private void studentElect_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=LHP-PC;Initial Catalog=教学库2;Integrated Security=True");
            string selectStr = "select 课程号,课程名,学分,课时 from 课程";
            SqlDataAdapter sda = new SqlDataAdapter(selectStr, conn);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void 选修_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection("Data Source=LHP-PC;Initial Catalog=教学库2;Integrated Security=True");
                string courseId = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                string xsh = Login.username;
                string insertstr = "insert into 选课(课程号,学生号) values('" + courseId + "','" + xsh + "')";
                SqlCommand cmd = new SqlCommand(insertstr, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("添加成功！");
            }
            catch
            {
                MessageBox.Show("操作有误，请请检出输入！");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string xsh = Login.username;
            SqlConnection conn = new SqlConnection("Data Source=LHP-PC;Initial Catalog=教学库2;Integrated Security=True");
            string selectStr = "select 选课.课程号,课程名,学分,课时 from 课程,选课 where 课程.课程号=选课.课程号 and 学生号='"+xsh+"'";
            SqlDataAdapter sda = new SqlDataAdapter(selectStr, conn);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            dataGridView2.DataSource = ds.Tables[0];
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string xsh = Login.username;
                int row = dataGridView2.CurrentCell.RowIndex;
                string deletesql = "delete  选课 where 课程号='" + dataGridView2.CurrentRow.Cells[0].Value.ToString() + "' and 学生号='" + xsh + "'";
                SqlConnection conn = new SqlConnection("Data Source=LHP-PC;Initial Catalog=教学库2;Integrated Security=True");
                SqlCommand com = new SqlCommand(deletesql, conn);
                conn.Open();
                com.ExecuteNonQuery();
                conn.Close();
                dataGridView2.Rows.Remove(dataGridView2.Rows[row]);
                MessageBox.Show("删除成功！");
            }
            catch
            {
                MessageBox.Show("操作有误，请检查输入！");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
