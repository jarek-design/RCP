using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Authent
{
    public partial class passEye : UserControl
    {
        bool eyeOn = false;
     

        public passEye()
        {
            InitializeComponent();
        }


        private void button2eye_Click(object sender, EventArgs e)
        {
            if (!eyeOn)
            {
                passwordVisible();
                eyeOn = true;
            }
            else
            {
                passwordHide();
                eyeOn = false;
            }
        }



        private void button2eye_MouseHover(object sender, EventArgs e)
        {
            passwordVisible();
        }

        private void passwordVisible()
        {
            textBox2passw.UseSystemPasswordChar = false;
            button2Eye.FlatAppearance.BorderSize = 1;
            button2Eye.FlatAppearance.BorderColor = Color.Gray;
        }

        private void button2eye_MouseLeave(object sender, EventArgs e)
        {
            if (!eyeOn)
            {
                passwordHide();
            }

        }

        private void passwordHide()
        {
            textBox2passw.UseSystemPasswordChar = true;
            button2Eye.FlatAppearance.BorderSize = 0;
            button2Eye.FlatAppearance.BorderColor = SystemColors.Control;
        }


        [EditorBrowsable(EditorBrowsableState.Always)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Bindable(true)]

        public override string Text
        {
            get
            {
                return textBox2passw.Text;
            }

            set
            {
                textBox2passw.Text = value;
            }
        }
       
    }
}
