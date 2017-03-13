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
    public partial class adminStudentDetails : Form
    {
        public adminStudentDetails()
        {
            InitializeComponent();
        }
        SqlConnection conn;
        SqlDataAdapter sda;
        private void adminStudentDetails_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection("Data Source=LHP-PC;Initial Catalog=教学库2;Integrated Security=True");
            sda = new SqlDataAdapter("select * from 学生", conn);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int row = dataGridView1.CurrentCell.RowIndex;
                string updatesql = "update 学生 set 密码='" + dataGridView1.CurrentRow.Cells[1].Value.ToString() + "'," + "姓名='" + dataGridView1.CurrentRow.Cells[2].Value.ToString() + "'," + "性别='" + dataGridView1.CurrentRow.Cells[3].Value.ToString() + "'," + "专业='" + dataGridView1.CurrentRow.Cells[4].Value.ToString() + "'," + "年级='" + dataGridView1.CurrentRow.Cells[5].Value.ToString() + "'" + "  where 学生号='" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'";
                SqlCommand com = new SqlCommand(updatesql, conn);
                conn.Open();
                com.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("更新成功！");
            }
            catch
            {
                MessageBox.Show("操作有误！请检查输入。");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int row = dataGridView1.CurrentCell.RowIndex;
                string deletesql = "delete  学生 where 学生号='" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'";

                SqlCommand com = new SqlCommand(deletesql, conn);
                conn.Open();
                com.ExecuteNonQuery();
                conn.Close();
                dataGridView1.Rows.Remove(dataGridView1.Rows[row]);
                MessageBox.Show("删除成功！");
            }
            catch
            {
                MessageBox.Show("操作有误！");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
