using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace reportMenu
{
    public class ReportMenu
    {
        string connectionString;
        ToolStripMenuItem wydrukiMenu;
                
        public ReportMenu(ToolStripMenuItem wydrukiMenu)
        {
            //rcpracy.Properties.Settings.

            this.wydrukiMenu = wydrukiMenu;
            connectionString = Extensions1.Gfunc.GetConnString("RCPConnectionStr");            
            
            //connectionString = 
        }

        public void createPrintMenu()
        {
            
            try
            {
                
                SqlConnection Rconnection = new SqlConnection(connectionString);

                SqlCommand Sqlcmd1 = new SqlCommand("SELECT idreport, menu FROM report where visible = 1");

                Rconnection.Open();
                Sqlcmd1.Connection = Rconnection;

                SqlDataReader dr = Sqlcmd1.ExecuteReader();
                while (dr.Read())
                {
                    AddMenu(dr["menu"].ToString(), Convert.ToInt16(dr["idreport"]));
                }
                //AddMenu("test3");
                Rconnection.Close();
            }
            catch (Exception)
            {
                MessageBox.Show(" Nie można połączyć z bazą danych. \r\n Program nie będzie działał prawidłowo","Bład w uruchomieniu wydruków",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void AddMenu(string OpisMenu, Int16 id)
        {
            ToolStripMenuItem menuItem = new ToolStripMenuItem();
            menuItem.Text = OpisMenu;
            menuItem.Tag = id;
            menuItem.Click += this.wydrukiAnalizy_Click;
            wydrukiMenu.DropDownItems.Add(menuItem);
        }

        private void wydrukiAnalizy_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
            Int16 id = (Int16)menuItem.Tag;
            reports.repStart report = new reports.repStart(Extensions1.Gfunc.GetConnString("RCPConnectionStr"));
            report.RealizWydr(id);
            report.Show();
        }

    }
}
