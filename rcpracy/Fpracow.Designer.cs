namespace rcpracy
{
    partial class Fpracow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Fpracow));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pracownikBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.txtFileButton = new System.Windows.Forms.ToolStripButton();
            this.importButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.helpToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.printToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.pracownikDataGridView = new System.Windows.Forms.DataGridView();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.grupaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rcpDataSet = new rcpracy.RcpDataSet();
            this.pracownikBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pracownikTableAdapter = new rcpracy.RcpDataSetTableAdapters.pracownikTableAdapter();
            this.tableAdapterManager = new rcpracy.RcpDataSetTableAdapters.TableAdapterManager();
            this.grupaTableAdapter = new rcpracy.RcpDataSetTableAdapters.grupaTableAdapter();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wymiarPracy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rfidId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3prId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grupaPrac = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pracownikBindingNavigator)).BeginInit();
            this.pracownikBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pracownikDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grupaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rcpDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pracownikBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // pracownikBindingNavigator
            // 
            this.pracownikBindingNavigator.AddNewItem = null;
            this.pracownikBindingNavigator.BindingSource = this.pracownikBindingSource;
            this.pracownikBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.pracownikBindingNavigator.DeleteItem = null;
            this.pracownikBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.txtFileButton,
            this.importButton1,
            this.toolStripSeparator1,
            this.saveToolStripButton,
            this.helpToolStripButton,
            this.printToolStripButton,
            this.toolStripSeparator});
            this.pracownikBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.pracownikBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.pracownikBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.pracownikBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.pracownikBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.pracownikBindingNavigator.Name = "pracownikBindingNavigator";
            this.pracownikBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.pracownikBindingNavigator.Size = new System.Drawing.Size(993, 25);
            this.pracownikBindingNavigator.TabIndex = 0;
            this.pracownikBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // txtFileButton
            // 
            this.txtFileButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.txtFileButton.Image = global::rcpracy.Properties.Resources.exp2excel;
            this.txtFileButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.txtFileButton.Name = "txtFileButton";
            this.txtFileButton.Size = new System.Drawing.Size(23, 22);
            this.txtFileButton.Text = "lista pracowników- zbiór tekstowy";
            this.txtFileButton.Click += new System.EventHandler(this.txtFileButton_Click);
            // 
            // importButton1
            // 
            this.importButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.importButton1.Image = global::rcpracy.Properties.Resources.importNazwisk;
            this.importButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.importButton1.Name = "importButton1";
            this.importButton1.Size = new System.Drawing.Size(23, 22);
            this.importButton1.Text = "Import pracowników";
            this.importButton1.ToolTipText = "Import pracowników";
            this.importButton1.Click += new System.EventHandler(this.toolButton1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.saveToolStripButton.Text = "&Save";
            this.saveToolStripButton.Click += new System.EventHandler(this.pracownikBindingNavigatorSaveItem_Click);
            // 
            // helpToolStripButton
            // 
            this.helpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.helpToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("helpToolStripButton.Image")));
            this.helpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.helpToolStripButton.Name = "helpToolStripButton";
            this.helpToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.helpToolStripButton.Text = "He&lp";
            // 
            // printToolStripButton
            // 
            this.printToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.printToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripButton.Image")));
            this.printToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printToolStripButton.Name = "printToolStripButton";
            this.printToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.printToolStripButton.Text = "&Print";
            this.printToolStripButton.Visible = false;
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // pracownikDataGridView
            // 
            this.pracownikDataGridView.AutoGenerateColumns = false;
            this.pracownikDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.pracownikDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.wymiarPracy,
            this.Column1,
            this.rfidId,
            this.Column3prId,
            this.grupaPrac});
            this.pracownikDataGridView.DataSource = this.pracownikBindingSource;
            this.pracownikDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pracownikDataGridView.Location = new System.Drawing.Point(0, 25);
            this.pracownikDataGridView.Name = "pracownikDataGridView";
            this.pracownikDataGridView.Size = new System.Drawing.Size(993, 310);
            this.pracownikDataGridView.TabIndex = 1;
            this.pracownikDataGridView.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.pracownikDataGridView_CellBeginEdit);
            this.pracownikDataGridView.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.pracownikDataGridView_CellValidated);
            this.pracownikDataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.pracownikDataGridView_CellEndEdit);
            this.pracownikDataGridView.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.pracownikDataGridView_CellValidated);
            this.pracownikDataGridView.Paint += new System.Windows.Forms.PaintEventHandler(this.pracownikDataGridView_Paint);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "csv";
            this.saveFileDialog1.FileName = "pracownicy";
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // grupaBindingSource
            // 
            this.grupaBindingSource.DataMember = "grupa";
            this.grupaBindingSource.DataSource = this.rcpDataSet;
            // 
            // rcpDataSet
            // 
            this.rcpDataSet.DataSetName = "rcpDataSet";
            this.rcpDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pracownikBindingSource
            // 
            this.pracownikBindingSource.DataMember = "pracownik";
            this.pracownikBindingSource.DataSource = this.rcpDataSet;
            // 
            // pracownikTableAdapter
            // 
            this.pracownikTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.grupaTableAdapter = null;
            this.tableAdapterManager.pracownikTableAdapter = this.pracownikTableAdapter;
            this.tableAdapterManager.rejestrTableAdapter = null;
            this.tableAdapterManager.rozliczenieTableAdapter = null;
            this.tableAdapterManager.rozlTmpTableAdapter = null;
            this.tableAdapterManager.rozTmRejTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = rcpracy.RcpDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // grupaTableAdapter
            // 
            this.grupaTableAdapter.ClearBeforeFill = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Nazwisko";
            this.dataGridViewTextBoxColumn3.HeaderText = "Nazwisko";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 160;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Imie";
            this.dataGridViewTextBoxColumn2.HeaderText = "Imie";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 160;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "NIP";
            this.dataGridViewTextBoxColumn4.HeaderText = "NIP";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 160;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Visible = false;
            this.dataGridViewTextBoxColumn4.Width = 160;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "PESEL";
            this.dataGridViewTextBoxColumn5.HeaderText = "PESEL";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 160;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Visible = false;
            this.dataGridViewTextBoxColumn5.Width = 160;
            // 
            // wymiarPracy
            // 
            this.wymiarPracy.DataPropertyName = "wymiarPracy";
            this.wymiarPracy.HeaderText = "wymiar Pracy ";
            this.wymiarPracy.Name = "wymiarPracy";
            this.wymiarPracy.ToolTipText = "wymiar pracy w minutach";
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column1.FillWeight = 70F;
            this.Column1.HeaderText = "wymiar w godz";
            this.Column1.MinimumWidth = 90;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.ToolTipText = "wymiar parcy przeliczony na godziny";
            this.Column1.Width = 101;
            // 
            // rfidId
            // 
            this.rfidId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.rfidId.DataPropertyName = "rfidId";
            dataGridViewCellStyle1.NullValue = null;
            this.rfidId.DefaultCellStyle = dataGridViewCellStyle1;
            this.rfidId.HeaderText = "RCP ID";
            this.rfidId.Name = "rfidId";
            this.rfidId.ToolTipText = "id związane z Rejestratorami";
            this.rfidId.Width = 68;
            // 
            // Column3prId
            // 
            this.Column3prId.DataPropertyName = "pr_Id";
            dataGridViewCellStyle2.NullValue = null;
            this.Column3prId.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column3prId.HeaderText = "Gratyf Id";
            this.Column3prId.Name = "Column3prId";
            this.Column3prId.ReadOnly = true;
            this.Column3prId.ToolTipText = "Identyfikator Pracownika w bazie danych Gratyfikanta";
            this.Column3prId.Width = 70;
            // 
            // grupaPrac
            // 
            this.grupaPrac.DataPropertyName = "grupa";
            this.grupaPrac.DataSource = this.grupaBindingSource;
            this.grupaPrac.DisplayMember = "nazwa";
            this.grupaPrac.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.grupaPrac.HeaderText = "grupa";
            this.grupaPrac.Name = "grupaPrac";
            this.grupaPrac.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.grupaPrac.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.grupaPrac.ValueMember = "idGrup";
            // 
            // Fpracow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 335);
            this.Controls.Add(this.pracownikDataGridView);
            this.Controls.Add(this.pracownikBindingNavigator);
            this.Name = "Fpracow";
            this.Text = "Pracownicy";
            this.Load += new System.EventHandler(this.Fpracow_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Fpracow_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pracownikBindingNavigator)).EndInit();
            this.pracownikBindingNavigator.ResumeLayout(false);
            this.pracownikBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pracownikDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grupaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rcpDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pracownikBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RcpDataSet rcpDataSet;
        private System.Windows.Forms.BindingSource pracownikBindingSource;
        private rcpracy.RcpDataSetTableAdapters.pracownikTableAdapter pracownikTableAdapter;
        private rcpracy.RcpDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator pracownikBindingNavigator;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.DataGridView pracownikDataGridView;
        private System.Windows.Forms.ToolStripButton importButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton txtFileButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripButton printToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton helpToolStripButton;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.BindingSource grupaBindingSource;
        private rcpracy.RcpDataSetTableAdapters.grupaTableAdapter grupaTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn wymiarPracy;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn rfidId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3prId;
        private System.Windows.Forms.DataGridViewComboBoxColumn grupaPrac;
    }
}