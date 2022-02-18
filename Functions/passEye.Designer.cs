namespace Authent
{
    partial class passEye
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(passEye));
            this.button2Eye = new System.Windows.Forms.Button();
            this.textBox2passw = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button2Eye
            // 
            this.button2Eye.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.button2Eye.FlatAppearance.BorderSize = 0;
            this.button2Eye.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2Eye.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.button2Eye.Image = ((System.Drawing.Image)(resources.GetObject("button2Eye.Image")));
            this.button2Eye.Location = new System.Drawing.Point(233, 3);
            this.button2Eye.Margin = new System.Windows.Forms.Padding(0);
            this.button2Eye.Name = "button2Eye";
            this.button2Eye.Size = new System.Drawing.Size(28, 19);
            this.button2Eye.TabIndex = 7;
            this.button2Eye.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2Eye.UseVisualStyleBackColor = true;
            this.button2Eye.Click += new System.EventHandler(this.button2eye_Click);
            this.button2Eye.MouseLeave += new System.EventHandler(this.button2eye_MouseLeave);
            this.button2Eye.MouseHover += new System.EventHandler(this.button2eye_MouseHover);
            // 
            // textBox2passw
            // 
            this.textBox2passw.Location = new System.Drawing.Point(0, 0);
            this.textBox2passw.Margin = new System.Windows.Forms.Padding(1);
            this.textBox2passw.Name = "textBox2passw";
            this.textBox2passw.Size = new System.Drawing.Size(227, 20);
            this.textBox2passw.TabIndex = 6;
            this.textBox2passw.UseSystemPasswordChar = true;
            // 
            // passEye
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button2Eye);
            this.Controls.Add(this.textBox2passw);
            this.Name = "passEye";
            this.Size = new System.Drawing.Size(268, 25);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2Eye;
        private System.Windows.Forms.TextBox textBox2passw;
    }
}
