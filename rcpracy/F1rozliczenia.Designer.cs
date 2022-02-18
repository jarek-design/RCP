namespace rcpracy
{
    partial class F1rozliczenia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F1rozliczenia));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.rozliczenieBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.rozliczenieBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rcpDataSet = new rcpracy.RcpDataSet();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.rozliczenieBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.ButtonWejscia = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.okresComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.nazwiskaComboBox2 = new System.Windows.Forms.ToolStripComboBox();
            this.rozliczenieDataGridView = new System.Windows.Forms.DataGridView();
            this.nazwisko = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.pracownikBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.imie = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.czasDo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.rozlicz = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.rozliczenieTableAdapter = new rcpracy.RcpDataSetTableAdapters.rozliczenieTableAdapter();
            this.tableAdapterManager = new rcpracy.RcpDataSetTableAdapters.TableAdapterManager();
            this.pracownikTableAdapter = new rcpracy.RcpDataSetTableAdapters.pracownikTableAdapter();
            this.ucOkres1 = new rcpracy.ucOkres();
            ((System.ComponentModel.ISupportInitialize)(this.rozliczenieBindingNavigator)).BeginInit();
            this.rozliczenieBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rozliczenieBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rcpDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rozliczenieDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pracownikBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // rozliczenieBindingNavigator
            // 
            this.rozliczenieBindingNavigator.AddNewItem = null;
            this.rozliczenieBindingNavigator.BindingSource = this.rozliczenieBindingSource;
            this.rozliczenieBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.rozliczenieBindingNavigator.DeleteItem = null;
            this.rozliczenieBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.rozliczenieBindingNavigatorSaveItem,
            this.ButtonWejscia,
            this.toolStripSeparator1,
            this.okresComboBox1,
            this.toolStripSeparator2,
            this.nazwiskaComboBox2});
            this.rozliczenieBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.rozliczenieBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.rozliczenieBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.rozliczenieBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.rozliczenieBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.rozliczenieBindingNavigator.Name = "rozliczenieBindingNavigator";
            this.rozliczenieBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.rozliczenieBindingNavigator.Size = new System.Drawing.Size(1045, 25);
            this.rozliczenieBindingNavigator.TabIndex = 0;
            this.rozliczenieBindingNavigator.Text = "bindingNavigator1";
            // 
            // rozliczenieBindingSource
            // 
            this.rozliczenieBindingSource.DataMember = "rozliczenie";
            this.rozliczenieBindingSource.DataSource = this.rcpDataSet;
            // 
            // rcpDataSet
            // 
            this.rcpDataSet.DataSetName = "rcpDataSet";
            this.rcpDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            // rozliczenieBindingNavigatorSaveItem
            // 
            this.rozliczenieBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.rozliczenieBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("rozliczenieBindingNavigatorSaveItem.Image")));
            this.rozliczenieBindingNavigatorSaveItem.Name = "rozliczenieBindingNavigatorSaveItem";
            this.rozliczenieBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.rozliczenieBindingNavigatorSaveItem.Text = "Save Data";
            this.rozliczenieBindingNavigatorSaveItem.Click += new System.EventHandler(this.rozliczenieBindingNavigatorSaveItem_Click);
            // 
            // ButtonWejscia
            // 
            this.ButtonWejscia.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ButtonWejscia.Image = global::rcpracy.Properties.Resources.info;
            this.ButtonWejscia.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonWejscia.Name = "ButtonWejscia";
            this.ButtonWejscia.Size = new System.Drawing.Size(23, 22);
            this.ButtonWejscia.Text = "wejscia";
            this.ButtonWejscia.Click += new System.EventHandler(this.ButtonWejscia_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // okresComboBox1
            // 
            this.okresComboBox1.AutoCompleteCustomSource.AddRange(new string[] {
            "dzisiaj",
            "wczoraj",
            "tydzień",
            "miesiąc"});
            this.okresComboBox1.Items.AddRange(new object[] {
            "dzisiaj",
            "wczoraj",
            "tydzien",
            "miesiac"});
            this.okresComboBox1.Name = "okresComboBox1";
            this.okresComboBox1.Size = new System.Drawing.Size(121, 25);
            this.okresComboBox1.SelectedIndexChanged += new System.EventHandler(this.okresComboBox1_SelectedIndexChanged);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // nazwiskaComboBox2
            // 
            this.nazwiskaComboBox2.AutoCompleteCustomSource.AddRange(new string[] {
            "wszystkie osoby"});
            this.nazwiskaComboBox2.Items.AddRange(new object[] {
            "wszyscy"});
            this.nazwiskaComboBox2.Name = "nazwiskaComboBox2";
            this.nazwiskaComboBox2.Size = new System.Drawing.Size(150, 25);
            this.nazwiskaComboBox2.SelectedIndexChanged += new System.EventHandler(this.nazwiskaComboBox2_SelectedIndexChanged);
            this.nazwiskaComboBox2.Enter += new System.EventHandler(this.nazwiskaComboBox2_Enter);
            // 
            // rozliczenieDataGridView
            // 
            this.rozliczenieDataGridView.AllowUserToAddRows = false;
            this.rozliczenieDataGridView.AllowUserToOrderColumns = true;
            this.rozliczenieDataGridView.AutoGenerateColumns = false;
            this.rozliczenieDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.rozliczenieDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nazwisko,
            this.imie,
            this.dataGridViewTextBoxColumn6,
            this.czasDo,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewCheckBoxColumn1,
            this.rozlicz});
            this.rozliczenieDataGridView.DataSource = this.rozliczenieBindingSource;
            this.rozliczenieDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rozliczenieDataGridView.Location = new System.Drawing.Point(0, 25);
            this.rozliczenieDataGridView.Name = "rozliczenieDataGridView";
            this.rozliczenieDataGridView.Size = new System.Drawing.Size(1045, 374);
            this.rozliczenieDataGridView.TabIndex = 1;
            this.rozliczenieDataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.rozliczenieDataGridView_CellFormatting);
            // 
            // nazwisko
            // 
            this.nazwisko.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nazwisko.DataPropertyName = "idPrac";
            this.nazwisko.DataSource = this.pracownikBindingSource;
            this.nazwisko.DisplayMember = "Nazwisko";
            this.nazwisko.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.nazwisko.HeaderText = "Nazwisko";
            this.nazwisko.MinimumWidth = 100;
            this.nazwisko.Name = "nazwisko";
            this.nazwisko.ReadOnly = true;
            this.nazwisko.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.nazwisko.ValueMember = "pr_Id";
            // 
            // pracownikBindingSource
            // 
            this.pracownikBindingSource.DataMember = "pracownik";
            this.pracownikBindingSource.DataSource = this.rcpDataSet;
            // 
            // imie
            // 
            this.imie.DataPropertyName = "idPrac";
            this.imie.DataSource = this.pracownikBindingSource;
            this.imie.DisplayMember = "Imie";
            this.imie.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.imie.HeaderText = "Imię";
            this.imie.MinimumWidth = 150;
            this.imie.Name = "imie";
            this.imie.ReadOnly = true;
            this.imie.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.imie.ValueMember = "pr_Id";
            this.imie.Width = 199;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn6.DataPropertyName = "wejscie";
            dataGridViewCellStyle1.Format = "f";
            dataGridViewCellStyle1.NullValue = null;
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTextBoxColumn6.HeaderText = "wejscie";
            this.dataGridViewTextBoxColumn6.MinimumWidth = 140;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 140;
            // 
            // czasDo
            // 
            this.czasDo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.czasDo.DataPropertyName = "czasDo";
            dataGridViewCellStyle2.Format = "f";
            this.czasDo.DefaultCellStyle = dataGridViewCellStyle2;
            this.czasDo.HeaderText = "czasDo";
            this.czasDo.MinimumWidth = 140;
            this.czasDo.Name = "czasDo";
            this.czasDo.ReadOnly = true;
            this.czasDo.Width = 140;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "dzien";
            this.dataGridViewTextBoxColumn2.HeaderText = "dzien";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 70;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "noc";
            this.dataGridViewTextBoxColumn3.HeaderText = "noc";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 70;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "dzienNad";
            this.dataGridViewTextBoxColumn4.HeaderText = "dzienNad";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 70;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "nocNad";
            this.dataGridViewTextBoxColumn5.HeaderText = "nocNad";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 70;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "zgodny";
            this.dataGridViewCheckBoxColumn1.HeaderText = "zgodny";
            this.dataGridViewCheckBoxColumn1.MinimumWidth = 43;
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.ReadOnly = true;
            this.dataGridViewCheckBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewCheckBoxColumn1.Width = 43;
            // 
            // rozlicz
            // 
            this.rozlicz.DataPropertyName = "rozlicz";
            this.rozlicz.HeaderText = "rozlicz";
            this.rozlicz.MinimumWidth = 42;
            this.rozlicz.Name = "rozlicz";
            this.rozlicz.ReadOnly = true;
            this.rozlicz.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.rozlicz.Visible = false;
            this.rozlicz.Width = 42;
            // 
            // rozliczenieTableAdapter
            // 
            this.rozliczenieTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.pracownikTableAdapter = null;
            this.tableAdapterManager.rejestrTableAdapter = null;
            this.tableAdapterManager.rozliczenieTableAdapter = this.rozliczenieTableAdapter;
            this.tableAdapterManager.rozlTmpTableAdapter = null;
            this.tableAdapterManager.rozTmRejTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = rcpracy.RcpDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // pracownikTableAdapter
            // 
            this.pracownikTableAdapter.ClearBeforeFill = true;
            // 
            // ucOkres1
            // 
            this.ucOkres1.Location = new System.Drawing.Point(385, 85);
            this.ucOkres1.Name = "ucOkres1";
            this.ucOkres1.Size = new System.Drawing.Size(272, 189);
            this.ucOkres1.TabIndex = 2;
            this.ucOkres1.Visible = false;
            this.ucOkres1.ButtonClick += new System.EventHandler<rcpracy.ucOkres.Okres_EventArgs>(this.ucOkres1_ButtonClick);
            // 
            // F1rozliczenia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1045, 399);
            this.Controls.Add(this.ucOkres1);
            this.Controls.Add(this.rozliczenieDataGridView);
            this.Controls.Add(this.rozliczenieBindingNavigator);
            this.Name = "F1rozliczenia";
            this.Text = "Rozliczenia obecności";
            this.Load += new System.EventHandler(this.F1rozliczenia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rozliczenieBindingNavigator)).EndInit();
            this.rozliczenieBindingNavigator.ResumeLayout(false);
            this.rozliczenieBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rozliczenieBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rcpDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rozliczenieDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pracownikBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RcpDataSet rcpDataSet;
        private System.Windows.Forms.BindingSource rozliczenieBindingSource;
        private rcpracy.RcpDataSetTableAdapters.rozliczenieTableAdapter rozliczenieTableAdapter;
        private rcpracy.RcpDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator rozliczenieBindingNavigator;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton rozliczenieBindingNavigatorSaveItem;
        private System.Windows.Forms.DataGridView rozliczenieDataGridView;
        private System.Windows.Forms.BindingSource pracownikBindingSource;
        private rcpracy.RcpDataSetTableAdapters.pracownikTableAdapter pracownikTableAdapter;
        private System.Windows.Forms.ToolStripButton ButtonWejscia;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripComboBox okresComboBox1;
        private System.Windows.Forms.ToolStripComboBox nazwiskaComboBox2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private ucOkres ucOkres1;
        private System.Windows.Forms.DataGridViewComboBoxColumn nazwisko;
        private System.Windows.Forms.DataGridViewComboBoxColumn imie;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn czasDo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn rozlicz;

    }
}