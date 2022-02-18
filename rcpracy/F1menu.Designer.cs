namespace rcpracy
{
    partial class F1menu
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F1menu));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.rejestratorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.daneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rejestrToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.rozliczeniaObecnościToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eksportDanychToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pracownicyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wydrukiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logowanieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ustawieniaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serwerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grupyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importPracownikówToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rejestracjaProgramuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serwerZdalnyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eksportPracownikówToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.progrBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rejestratorToolStripMenuItem,
            this.daneToolStripMenuItem,
            this.wydrukiToolStripMenuItem,
            this.logowanieToolStripMenuItem,
            this.ustawieniaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(512, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // rejestratorToolStripMenuItem
            // 
            this.rejestratorToolStripMenuItem.Name = "rejestratorToolStripMenuItem";
            this.rejestratorToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.rejestratorToolStripMenuItem.Text = "Rejestrator";
            this.rejestratorToolStripMenuItem.Click += new System.EventHandler(this.rejestratorToolStripMenuItem_Click);
            // 
            // daneToolStripMenuItem
            // 
            this.daneToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rejestrToolStripMenuItem1,
            this.rozliczeniaObecnościToolStripMenuItem,
            this.eksportDanychToolStripMenuItem,
            this.pracownicyToolStripMenuItem});
            this.daneToolStripMenuItem.Enabled = false;
            this.daneToolStripMenuItem.Name = "daneToolStripMenuItem";
            this.daneToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.daneToolStripMenuItem.Text = "Dane";
            // 
            // rejestrToolStripMenuItem1
            // 
            this.rejestrToolStripMenuItem1.Name = "rejestrToolStripMenuItem1";
            this.rejestrToolStripMenuItem1.Size = new System.Drawing.Size(186, 22);
            this.rejestrToolStripMenuItem1.Text = "Rejestr obecności";
            this.rejestrToolStripMenuItem1.ToolTipText = "Rejestr wszystkich obecności";
            this.rejestrToolStripMenuItem1.Click += new System.EventHandler(this.rejestrToolStripMenuItem1_Click);
            // 
            // rozliczeniaObecnościToolStripMenuItem
            // 
            this.rozliczeniaObecnościToolStripMenuItem.Name = "rozliczeniaObecnościToolStripMenuItem";
            this.rozliczeniaObecnościToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.rozliczeniaObecnościToolStripMenuItem.Text = "Obecności rozliczone";
            this.rozliczeniaObecnościToolStripMenuItem.ToolTipText = "Obecności rozliczone i przesłane do Gratyfikanta";
            this.rozliczeniaObecnościToolStripMenuItem.Click += new System.EventHandler(this.rozliczeniaObecnościToolStripMenuItem_Click);
            // 
            // eksportDanychToolStripMenuItem
            // 
            this.eksportDanychToolStripMenuItem.Image = global::rcpracy.Properties.Resources.rozlicz;
            this.eksportDanychToolStripMenuItem.Name = "eksportDanychToolStripMenuItem";
            this.eksportDanychToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.eksportDanychToolStripMenuItem.Text = "Eksport danych";
            this.eksportDanychToolStripMenuItem.Visible = false;
            this.eksportDanychToolStripMenuItem.Click += new System.EventHandler(this.eksportDanychToolStripMenuItem_Click);
            // 
            // pracownicyToolStripMenuItem
            // 
            this.pracownicyToolStripMenuItem.Name = "pracownicyToolStripMenuItem";
            this.pracownicyToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.pracownicyToolStripMenuItem.Text = "Lista pracowników";
            this.pracownicyToolStripMenuItem.Click += new System.EventHandler(this.pracownicyToolStripMenuItem_Click);
            // 
            // wydrukiToolStripMenuItem
            // 
            this.wydrukiToolStripMenuItem.Enabled = false;
            this.wydrukiToolStripMenuItem.Name = "wydrukiToolStripMenuItem";
            this.wydrukiToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.wydrukiToolStripMenuItem.Text = "Wydruki";
            this.wydrukiToolStripMenuItem.Visible = false;
            // 
            // logowanieToolStripMenuItem
            // 
            this.logowanieToolStripMenuItem.Name = "logowanieToolStripMenuItem";
            this.logowanieToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.logowanieToolStripMenuItem.Text = "Logowanie";
            this.logowanieToolStripMenuItem.Click += new System.EventHandler(this.logowanieToolStripMenuItem_Click);
            // 
            // ustawieniaToolStripMenuItem
            // 
            this.ustawieniaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serwerToolStripMenuItem,
            this.grupyToolStripMenuItem,
            this.importPracownikówToolStripMenuItem,
            this.rejestracjaProgramuToolStripMenuItem,
            this.serwerZdalnyToolStripMenuItem});
            this.ustawieniaToolStripMenuItem.Enabled = false;
            this.ustawieniaToolStripMenuItem.Name = "ustawieniaToolStripMenuItem";
            this.ustawieniaToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.ustawieniaToolStripMenuItem.Text = "Ustawienia";
            // 
            // serwerToolStripMenuItem
            // 
            this.serwerToolStripMenuItem.Name = "serwerToolStripMenuItem";
            this.serwerToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.serwerToolStripMenuItem.Text = "Parametry programu";
            this.serwerToolStripMenuItem.Click += new System.EventHandler(this.serwerToolStripMenuItem_Click);
            // 
            // grupyToolStripMenuItem
            // 
            this.grupyToolStripMenuItem.Name = "grupyToolStripMenuItem";
            this.grupyToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.grupyToolStripMenuItem.Text = "Grupy";
            this.grupyToolStripMenuItem.Click += new System.EventHandler(this.grupyToolStripMenuItem_Click);
            // 
            // importPracownikówToolStripMenuItem
            // 
            this.importPracownikówToolStripMenuItem.Name = "importPracownikówToolStripMenuItem";
            this.importPracownikówToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.importPracownikówToolStripMenuItem.Text = "Import pracowników";
            this.importPracownikówToolStripMenuItem.Click += new System.EventHandler(this.importPracownikówToolStripMenuItem_Click);
            // 
            // rejestracjaProgramuToolStripMenuItem
            // 
            this.rejestracjaProgramuToolStripMenuItem.Name = "rejestracjaProgramuToolStripMenuItem";
            this.rejestracjaProgramuToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.rejestracjaProgramuToolStripMenuItem.Text = "Rejestracja programu";
            this.rejestracjaProgramuToolStripMenuItem.Click += new System.EventHandler(this.rejestracjaProgramuToolStripMenuItem_Click);
            // 
            // serwerZdalnyToolStripMenuItem
            // 
            this.serwerZdalnyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eksportPracownikówToolStripMenuItem});
            this.serwerZdalnyToolStripMenuItem.Enabled = false;
            this.serwerZdalnyToolStripMenuItem.Name = "serwerZdalnyToolStripMenuItem";
            this.serwerZdalnyToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.serwerZdalnyToolStripMenuItem.Text = "Serwer zdalny";
            // 
            // eksportPracownikówToolStripMenuItem
            // 
            this.eksportPracownikówToolStripMenuItem.Enabled = false;
            this.eksportPracownikówToolStripMenuItem.Name = "eksportPracownikówToolStripMenuItem";
            this.eksportPracownikówToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.eksportPracownikówToolStripMenuItem.Text = "eksport pracowników";
            this.eksportPracownikówToolStripMenuItem.Click += new System.EventHandler(this.eksportPracownikówToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.progrBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 290);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(512, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // progrBar1
            // 
            this.progrBar1.Margin = new System.Windows.Forms.Padding(14, 3, 1, 3);
            this.progrBar1.Name = "progrBar1";
            this.progrBar1.Size = new System.Drawing.Size(150, 16);
            this.progrBar1.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 3000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 244);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            // 
            // F1menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 312);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "F1menu";
            this.Text = "Rejestracja obecności";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem daneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rejestrToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem pracownicyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ustawieniaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serwerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eksportDanychToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importPracownikówToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rejestratorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rozliczeniaObecnościToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar progrBar1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem logowanieToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wydrukiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serwerZdalnyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eksportPracownikówToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rejestracjaProgramuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem grupyToolStripMenuItem;
        private System.Windows.Forms.Label label1;
    }
}

