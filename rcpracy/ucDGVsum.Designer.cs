namespace rcpracy
{
    partial class ucDGVsum
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
            this.SumPanel = new System.Windows.Forms.Panel();
            this.label0 = new System.Windows.Forms.Label();
            this.SumPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // SumPanel
            // 
            this.SumPanel.Controls.Add(this.label0);
            this.SumPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SumPanel.Location = new System.Drawing.Point(0, 0);
            this.SumPanel.Margin = new System.Windows.Forms.Padding(1);
            this.SumPanel.Name = "SumPanel";
            this.SumPanel.Size = new System.Drawing.Size(836, 22);
            this.SumPanel.TabIndex = 5;
            // 
            // label0
            // 
            this.label0.AutoSize = true;
            this.label0.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label0.Location = new System.Drawing.Point(38, 2);
            this.label0.Name = "label0";
            this.label0.Size = new System.Drawing.Size(44, 15);
            this.label0.TabIndex = 4;
            this.label0.Text = "Suma";
            // 
            // ucDGVsum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SumPanel);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "ucDGVsum";
            this.Size = new System.Drawing.Size(836, 22);
            this.SumPanel.ResumeLayout(false);
            this.SumPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel SumPanel;
        private System.Windows.Forms.Label label0;
    }
}
