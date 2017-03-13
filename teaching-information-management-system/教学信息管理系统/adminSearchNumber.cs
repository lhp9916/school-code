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
    public partial class adminSearchNumber : Form
    {
        public adminSearchNumber()
        {
            InitializeComponent();
        }

        private void adminSearchNumber_Load(object sender, EventArgs e)
        {
           SqlConnection conn = new SqlConnection("Data Source=LHP-PC;Initial Catalog=教学库2;Integrated Security=True");
           SqlDataAdapter sda = new SqlDataAdapter("select * from 选课人数", conn);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }
    }
}
