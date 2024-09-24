using System.Data;

namespace RedSea_ERP_Management
{
    public partial class Form1 : Form
    {
        InteractiveServer IS = new InteractiveServer();
        public Form1()
        {
            InitializeComponent();
            timer1.Start();
            label1.Text = DBController.GetInfos(Properties.Settings.Default.Db_name, new string[] { "udn" }, "users", $"uname='{Properties.Settings.Default.def_uname}'").Rows[0][0].ToString();
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 3;

        }

        private void button7_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 4;

        }

        private void button8_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 5;

        }

        private void button9_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 6;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = IS.GetData(DateTime.Now.ToString("ddd yyyy/MM/dd \n hh:mm:ss tt")).ToString();

        }

        private void button10_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.FirstTime = true;
            Properties.Settings.Default.Save();
        }
    }
}
