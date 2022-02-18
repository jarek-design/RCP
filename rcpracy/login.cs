using System;
using System.Windows.Forms;

namespace rcpracy
{
    public partial class login : Form
    {
        F1menu menu;
   

        public login()
        {
            InitializeComponent();
        }
    
        public void SetMenu(F1menu f1m)
        {
            menu = f1m;
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            string cs = Funct.RcpConnectionStr;
            try
            {
                Authent.Authentication user = new Authent.Authentication(Funct.RcpConnectionStr);
                if (user.testUser(textBox1.Text, passEye1.Text))
                {
                    Authent.UserLogin.userName = textBox1.Text;
                    Authent.UserLogin.password = passEye1.Text;


                    menu.logowanie();
                    this.Close();
                }
                else
                    MessageBox.Show("Błędna nazwa użytkownika lub niewłaściwe hasło ", "Błędne logowanie", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            catch (Exception err )
            {
                using (System.IO.StreamWriter ErrLogfile = new System.IO.StreamWriter("DbError.log"))
                {           
                ErrLogfile.WriteLine(err.Message);
                ErrLogfile.WriteLine(err.StackTrace);
                }
                MessageBox.Show("Brak bazy danych , błędne ustawienia bazy danych lub nie zainstalowany sterownik. \r\nNależy sprawdzić ustawienia Bazy Danych RCP \r\n Zobacz plik DbError.log",
                    "Błąd Bazy danych", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                menu.logError();
                this.Close();                          
            }
            
        }

        //private void button2eye_Click(object sender, EventArgs e)
        //{
        //    if (!eyeOn)
        //    {
        //        textBox2passw.UseSystemPasswordChar = false;
        //        eyeOn = true;
        //    }
        //    else
        //    {
        //        textBox2passw.UseSystemPasswordChar = true;
        //        eyeOn = false;
        //    }
        //}

     

        //private void button2eye_MouseHover(object sender, EventArgs e)
        //{
        //    textBox2passw.UseSystemPasswordChar = false;
            
        //}

        //private void button2eye_MouseLeave(object sender, EventArgs e)
        //{
        //    if (!eyeOn)
        //    textBox2passw.UseSystemPasswordChar = true;
        //}
    }
}
