using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RedSea_ERP_Management
{
    public partial class Wizard : Form
    {
        public Wizard()
        {
            InitializeComponent();
            if (dbname.Text.Length != 0 && servername.Text.Length != 0 && password.Text.Length != 0 && adminname.Text.Length != 0 && adminpassword.Text.Length != 0)
            {
                button1.Enabled
                    = true;
            }
        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (password.Text == Properties.Settings.Default.password)
                {
                    DBController.CreateDB(dbname.Text);
                    Properties.Settings.Default.Db_name = dbname.Text;

                    DBController.CreateTable(dbname.Text,"users", new Dictionary<string, string>()
            {
                { "id","int primary key identity  not null" }
                ,{"uname","nvarchar(200)"},{"upass","nvarchar(200)"},{"udn","nvarchar(200)"}
            });

                    DBController.CreateTable(dbname.Text, "perm", new Dictionary<string, string>()
            {
                {"u_id","int" },{"action_id","int"},{"action_allowed","bit"}
            });
                    DBController.CreateTable(dbname.Text, "orders", new Dictionary<string, string>()
            {
                {"o_id","int" },{"customer_id","int"},{"state","int"},{"o_sum","float"},{"order_dt","nvarchar(100)"},{"u_id","int"}
            });
                    DBController.CreateTable(dbname.Text, "order_pros", new Dictionary<string, string>()
      {
          {"o_id","int" },{"pro_id","int"},{"state","bit"},{"customer_id","int"}
      });
                    DBController.CreateTable(dbname.Text, "offers", new Dictionary<string, string>()
            {
                {"off_id","int" },{"supplier_id","int"},{"state","int"},{"o_sum","float"},{"order_dt","nvarchar(100)"},{"u_id","int"}
            });
                    DBController.CreateTable(dbname.Text, "offer_pros", new Dictionary<string, string>()
      {
          {"off_id","int" },{"pro_id","int"},{"state","bit"},{"supplier_id","int"}
      });

                    DBController.InsertInto(dbname.Text, "users", new Dictionary<string, string>()
            {
                {"uname",adminname.Text },{"upass",adminpassword.Text },{ "udn","admin"}
            });
                    Properties.Settings.Default.FirstTime = false;
                    Properties.Settings.Default.Save();
                    Process.Start(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"{nameof(RedSea_ERP_Management).Replace("_"," ")}.exe"));
                    Application.Exit();
                }
                else
                {
                    MessageBox.Show(new UnauthorizedAccessException().Message, "Wrong Password", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

            }
          
        }

        private void Validate(object sender, EventArgs e)
        {
            if (dbname.Text.Length != 0 && servername.Text.Length != 0 && password.Text.Length != 0 && adminname.Text.Length != 0 && adminpassword.Text.Length != 0)
            {
                button1.Enabled
                    = true;
            }
        }
    }
}
