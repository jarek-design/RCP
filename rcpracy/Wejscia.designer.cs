namespace rcpracy
{
    partial class Wejscia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Wejscia));
            this.rcpDataSet = new rcpracy.RcpDataSet();
            this.rozTmRejBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rozTmRejTableAdapter = new rcpracy.RcpDataSetTableAdapters.rozTmRejTableAdapter();
            this.tableAdapterManager = new rcpracy.RcpDataSetTableAdapters.TableAdapterManager();
            this.rejestrTableAdapter = new rcpracy.RcpDataSetTableAdapters.rejestrTableAdapter();
            this.rozTmRejBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.rozTmRejBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.rozTmRejDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wej = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.rejestrBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.wyjście = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.rcpDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rozTmRejBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rozTmRejBindingNavigator)).BeginInit();
            this.rozTmRejBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rozTmRejDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rejestrBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // rcpDataSet
            // 
            this.rcpDataSet.DataSetName = "rcpDataSet";
            this.rcpDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // rozTmRejBindingSource
            // 
            this.rozTmRejBindingSource.DataMember = "rozTmRej";
            this.rozTmRejBindingSource.DataSource = this.rcpDataSet;
            // 
            // rozTmRejTableAdapter
            // 
            this.rozTmRejTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.pracownikTableAdapter = null;
            this.tableAdapterManager.rejestrTableAdapter = this.rejestrTableAdapter;
            this.tableAdapterManager.rozliczenieTableAdapter = null;
            this.tableAdapterManager.rozlTmpTableAdapter = null;
            this.tableAdapterManager.rozTmRejTableAdapter = this.rozTmRejTableAdapter;
            this.tableAdapterManager.UpdateOrder = rcpracy.RcpDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // rejestrTableAdapter
            // 
            this.rejestrTableAdapter.ClearBeforeFill = true;
            // 
            // rozTmRejBindingNavigator
            // 
            this.rozTmRejBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.rozTmRejBindingNavigator.BindingSource = this.rozTmRejBindingSource;
            this.rozTmRejBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.rozTmRejBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.rozTmRejBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.rozTmRejBindingNavigatorSaveItem});
            this.rozTmRejBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.rozTmRejBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.rozTmRejBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.rozTmRejBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.rozTmRejBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.rozTmRejBindingNavigator.Name = "rozTmRejBindingNavigator";
            this.rozTmRejBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.rozTmRejBindingNavigator.Size = new System.Drawing.Size(370, 25);
            this.rozTmRejBindingNavigator.TabIndex = 0;
            this.rozTmRejBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "Delete";
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
            // rozTmRejBindingNavigatorSaveItem
            // 
            this.rozTmRejBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.rozTmRejBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("rozTmRejBindingNavigatorSaveItem.Image")));
            this.rozTmRejBindingNavigatorSaveItem.Name = "rozTmRejBindingNavigatorSaveItem";
            this.rozTmRejBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.rozTmRejBindingNavigatorSaveItem.Text = "Save Data";
            this.rozTmRejBindingNavigatorSaveItem.Click += new System.EventHandler(this.rozTmRejBindingNavigatorSaveItem_Click);
            // 
            // rozTmRejDataGridView
            // 
            this.rozTmRejDataGridView.AutoGenerateColumns = false;
            this.rozTmRejDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.rozTmRejDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.wej,
            this.wyjście});
            this.rozTmRejDataGridView.DataSource = this.rozTmRejBindingSource;
            this.rozTmRejDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rozTmRejDataGridView.Location = new System.Drawing.Point(0, 25);
            this.rozTmRejDataGridView.Name = "rozTmRejDataGridView";
            this.rozTmRejDataGridView.Size = new System.Drawing.Size(370, 213);
            this.rozTmRejDataGridView.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "rejId";
            this.dataGridViewTextBoxColumn1.HeaderText = "rejId";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 30;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "rozliczId";
            this.dataGridViewTextBoxColumn2.HeaderText = "rozliczId";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 40;
            // 
            // wej
            // 
            this.wej.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.wej.DataPropertyName = "rejId";
            this.wej.DataSource = this.rejestrBindingSource;
            this.wej.DisplayMember = "czasWe";
            this.wej.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.wej.HeaderText = "Wejście";
            this.wej.MinimumWidth = 120;
            this.wej.Name = "wej";
            this.wej.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.wej.ValueMember = "idr";
            this.wej.Width = 120;
            // 
            // rejestrBindingSource
            // 
            this.rejestrBindingSource.DataMember = "rejestr";
            this.rejestrBindingSource.DataSource = this.rcpDataSet;
            // 
            // wyjście
            // 
            this.wyjście.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.wyjście.DataPropertyName = "rejId";
            this.wyjście.DataSource = this.rejestrBindingSource;
            this.wyjście.DisplayMember = "czasDo";
            this.wyjście.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.wyjście.HeaderText = "Wyjście";
            this.wyjście.MinimumWidth = 50;
            this.wyjście.Name = "wyjście";
            this.wyjście.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.wyjście.ValueMember = "idr";
            // 
            // Wejscia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 238);
            this.Controls.Add(this.rozTmRejDataGridView);
            this.Controls.Add(this.rozTmRejBindingNavigator);
            this.Name = "Wejscia";
            this.Text = "Wejscia";
            ((System.ComponentModel.ISupportInitialize)(this.rcpDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rozTmRejBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rozTmRejBindingNavigator)).EndInit();
            this.rozTmRejBindingNavigator.ResumeLayout(false);
            this.rozTmRejBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rozTmRejDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rejestrBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RcpDataSet rcpDataSet;
        private System.Windows.Forms.BindingSource rozTmRejBindingSource;
        private rcpracy.RcpDataSetTableAdapters.rozTmRejTableAdapter rozTmRejTableAdapter;
        private rcpracy.RcpDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator rozTmRejBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton rozTmRejBindingNavigatorSaveItem;
        private System.Windows.Forms.DataGridView rozTmRejDataGridView;
        private rcpracy.RcpDataSetTableAdapters.rejestrTableAdapter rejestrTableAdapter;
        private System.Windows.Forms.BindingSource rejestrBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewComboBoxColumn wej;
        private System.Windows.Forms.DataGridViewComboBoxColumn wyjście;
    }
}