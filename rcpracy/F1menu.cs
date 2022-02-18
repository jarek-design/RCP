using System;
using System.Windows.Forms;
using progSetup;

namespace rcpracy
{
    public partial class F1menu : Form
    {
        reportMenu.ReportMenu rmenu;
        Frejestr rej1;
        public F1menu()
        {          
            this.IsMdiContainer = true;
            InitializeComponent();
            Configuration.Instance.ini();

            licence lic1 = new licence(this, SetupFunc.ordProgram, SetupFunc.ordProgVer);
            if (lic1.progRegisterd)
                rejestracjaProgramuToolStripMenuItem.Visible = false;

            try
            {
                rejestratorToolStripMenuItem.Visible = Configuration.confData.rejestratorW;
                //addWydrukMenu();
            }
            catch
            { 
  
            }

            label1.Text = global::rcpracy.Properties.Settings.Default.RCPConnectionStr;
        }
        private void addWydrukMenu()
        {
            rmenu = new reportMenu.ReportMenu(wydrukiToolStripMenuItem);
            rmenu.createPrintMenu();
            if (wydrukiToolStripMenuItem.DropDownItems.Count > 1)
                wydrukiToolStripMenuItem.Visible = true;
        }
       
        private void rejestrToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (rej1 == null)
                rej1 = new Frejestr();
            rej1.Show();
        }

        private void pracownicyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Fpracow prac1 = new Fpracow();
            prac1.Show();
        }

        private void serwerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ustawienia ust1 = new Ustawienia();
            if (!daneToolStripMenuItem.Enabled)
                ust1.AdmDisable();
            ust1.Show();
        }

        private void rejestratorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rejestrator rej1 = new rejestrator();
            rej1.setSender(this);
            rej1.ShowDialog();
        }

        private void eksportDanychToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            
            //impRejestr import1 = new impRejestr();
            progrBar1.Visible = true;
            //import1.load(this.progrBar1);            
            if (Rozliczenie.rozlicz(progrBar1, timer1))
            {               
                export2Grat export1 = new export2Grat();
                if (export1.eksport(progrBar1))
                    MessageBox.Show("Dane zostały wysłane do systemu INSERT", "EXPORT OK");
                else
                    MessageBox.Show("Dane nie zostały wysłane do systemu INSERT", "", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
                MessageBox.Show("Rozliczenie nie zostało przeprowadzone");
            timer1.Enabled = true;            
        }

        private void rozliczeniaObecnościToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F1rozliczenia rozl = new F1rozliczenia();
            rozl.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progrBar1.Visible = false;
            timer1.Enabled = false;
        }

        private void logowanieToolStripMenuItem_Click(object sender, EventArgs e)
        {

            login l1 = new login();
            l1.SetMenu(this);

            l1.MdiParent = this;
            l1.Show();
            
        }

        public void logowanie()
        {
            this.daneToolStripMenuItem.Enabled = true;
            this.ustawieniaToolStripMenuItem.Enabled = true;
            this.wydrukiToolStripMenuItem.Enabled = true;
            this.logowanieToolStripMenuItem.Visible = false;
        }

        public void logError()
        {
            //this.daneToolStripMenuItem.Enabled = false;
            this.ustawieniaToolStripMenuItem.Enabled = true;
            this.logowanieToolStripMenuItem.Enabled = false;
            grupyToolStripMenuItem.Enabled = false;
            importPracownikówToolStripMenuItem.Enabled = false;
            rejestracjaProgramuToolStripMenuItem.Enabled = false;


        }

        private void eksportPracownikówToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //PracRemote.Send();
        }

        private void rejestracjaProgramuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            progSetup.licence.rejestracja();
        }

        private void importPracownikówToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImportPrac.import();
        }

        private void grupyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //F1Grupy grupy = new F1Grupy();
            //grupy.Show();
            (new F1Grupy()).Show();
        }  
    }
}
