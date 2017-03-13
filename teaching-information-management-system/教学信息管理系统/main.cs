using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 教学信息管理系统
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            adminStudentAdd asa = new adminStudentAdd();
            asa.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            adminTeacherAdd ata = new adminTeacherAdd();
            ata.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            adminCouseAdd aca = new adminCouseAdd();
            aca.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            adminStudentDetails asd = new adminStudentDetails();
            asd.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            adminTeacherDetails adtd = new adminTeacherDetails();
            adtd.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            adminCourseDetail adcd = new adminCourseDetail();
            adcd.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            adminstudentScore adsscore = new adminstudentScore();
            adsscore.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            adminSearchNumber adsn = new adminSearchNumber();
            adsn.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            adminSearchScore adssc = new adminSearchScore();
            adssc.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            ModifyPwd mdfp = new ModifyPwd();
            mdfp.Show();
        }

        private void main_Load(object sender, EventArgs e)
        {
            string name = Login.username;
            label1.Text = "欢迎管理员" + name + "进入本系统！";
        }
    }
}
