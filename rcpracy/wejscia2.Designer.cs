namespace rcpracy
{
    partial class wejscia2
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.rcpDataSet = new rcpracy.RcpDataSet();
            this.rejestrBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rejestrTableAdapter = new rcpracy.RcpDataSetTableAdapters.rejestrTableAdapter();
            this.tableAdapterManager = new rcpracy.RcpDataSetTableAdapters.TableAdapterManager();
            this.rejestrDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.rcpDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rejestrBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rejestrDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // rcpDataSet
            // 
            this.rcpDataSet.DataSetName = "rcpDataSet";
            this.rcpDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // rejestrBindingSource
            // 
            this.rejestrBindingSource.DataMember = "rejestr";
            this.rejestrBindingSource.DataSource = this.rcpDataSet;
            // 
            // rejestrTableAdapter
            // 
            this.rejestrTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.pracownikTableAdapter = null;
            this.tableAdapterManager.rejestrTableAdapter = this.rejestrTableAdapter;
            this.tableAdapterManager.rozliczenieTableAdapter = null;
            this.tableAdapterManager.rozlTmpTableAdapter = null;
            this.tableAdapterManager.rozTmRejTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = rcpracy.RcpDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // rejestrDataGridView
            // 
            this.rejestrDataGridView.AutoGenerateColumns = false;
            this.rejestrDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.rejestrDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.rejestrDataGridView.DataSource = this.rejestrBindingSource;
            this.rejestrDataGridView.Dock = System.Windows.Forms.DockStyle.Top;
            this.rejestrDataGridView.Location = new System.Drawing.Point(0, 0);
            this.rejestrDataGridView.Name = "rejestrDataGridView";
            this.rejestrDataGridView.Size = new System.Drawing.Size(455, 228);
            this.rejestrDataGridView.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "idr";
            this.dataGridViewTextBoxColumn1.HeaderText = "idr";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 10;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "rozliczId";
            dataGridViewCellStyle1.Format = "f";
            dataGridViewCellStyle1.NullValue = null;
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTextBoxColumn5.HeaderText = "rozliczId";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 30;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 30;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "czasWe";
            dataGridViewCellStyle2.Format = "f";
            dataGridViewCellStyle2.NullValue = null;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn3.HeaderText = "czasWe";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 70;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 71;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "czasDo";
            dataGridViewCellStyle3.Format = "f";
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn4.HeaderText = "czasDo";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 70;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 228);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(455, 32);
            this.panel1.TabIndex = 2;
            // 
            // wejscia2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 260);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.rejestrDataGridView);
            this.Name = "wejscia2";
            this.Text = "wejscia2";
          
            ((System.ComponentModel.ISupportInitialize)(this.rcpDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rejestrBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rejestrDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private RcpDataSet rcpDataSet;
        private System.Windows.Forms.BindingSource rejestrBindingSource;
        private rcpracy.RcpDataSetTableAdapters.rejestrTableAdapter rejestrTableAdapter;
        private rcpracy.RcpDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridView rejestrDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.Panel panel1;
    }
}