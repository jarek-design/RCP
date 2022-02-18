namespace rcpracy
{
    partial class F1Grupy
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
            System.Windows.Forms.Label doOdebrLabel;
            System.Windows.Forms.Label godzNadlLabel;
            System.Windows.Forms.Label pracaSobLabel;
            System.Windows.Forms.Label pracaNiedzLabel;
            System.Windows.Forms.Label gratyfLabel;
            System.Windows.Forms.Label nazwaLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F1Grupy));
            this.grupaBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.grupaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            
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
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.grupaBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.doOdebrCheckBox = new System.Windows.Forms.CheckBox();
            this.godzNadlCheckBox = new System.Windows.Forms.CheckBox();
            this.pracaSobCheckBox = new System.Windows.Forms.CheckBox();
            this.pracaNiedzCheckBox = new System.Windows.Forms.CheckBox();
            this.gratyfCheckBox = new System.Windows.Forms.CheckBox();
            this.nazwaTextBox = new System.Windows.Forms.TextBox();
            this.grupaTableAdapter = new rcpracy.RcpDataSetTableAdapters.grupaTableAdapter();
            this.tableAdapterManager = new rcpracy.RcpDataSetTableAdapters.TableAdapterManager();
            doOdebrLabel = new System.Windows.Forms.Label();
            godzNadlLabel = new System.Windows.Forms.Label();
            pracaSobLabel = new System.Windows.Forms.Label();
            pracaNiedzLabel = new System.Windows.Forms.Label();
            gratyfLabel = new System.Windows.Forms.Label();
            nazwaLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grupaBindingNavigator)).BeginInit();
            this.grupaBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grupaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rcpDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // doOdebrLabel
            // 
            doOdebrLabel.AutoSize = true;
            doOdebrLabel.ForeColor = System.Drawing.SystemColors.ControlDark;
            doOdebrLabel.Location = new System.Drawing.Point(27, 79);
            doOdebrLabel.Name = "doOdebrLabel";
            doOdebrLabel.Size = new System.Drawing.Size(158, 13);
            doOdebrLabel.TabIndex = 3;
            doOdebrLabel.Text = "Możliwość godzin do odebrania:";
            doOdebrLabel.Visible = false;
            // 
            // godzNadlLabel
            // 
            godzNadlLabel.AutoSize = true;
            godzNadlLabel.Location = new System.Drawing.Point(27, 109);
            godzNadlLabel.Name = "godzNadlLabel";
            godzNadlLabel.Size = new System.Drawing.Size(166, 13);
            godzNadlLabel.TabIndex = 5;
            godzNadlLabel.Text = "Możliwość godzin nadliczbowych:";
            // 
            // pracaSobLabel
            // 
            pracaSobLabel.AutoSize = true;
            pracaSobLabel.Location = new System.Drawing.Point(27, 139);
            pracaSobLabel.Name = "pracaSobLabel";
            pracaSobLabel.Size = new System.Drawing.Size(133, 13);
            pracaSobLabel.TabIndex = 7;
            pracaSobLabel.Text = "Możliwość pracy w soboty:";
            // 
            // pracaNiedzLabel
            // 
            pracaNiedzLabel.AutoSize = true;
            pracaNiedzLabel.Location = new System.Drawing.Point(27, 169);
            pracaNiedzLabel.Name = "pracaNiedzLabel";
            pracaNiedzLabel.Size = new System.Drawing.Size(143, 13);
            pracaNiedzLabel.TabIndex = 9;
            pracaNiedzLabel.Text = "Możliwość pracy w niedziele:";
            // 
            // gratyfLabel
            // 
            gratyfLabel.AutoSize = true;
            gratyfLabel.Location = new System.Drawing.Point(27, 199);
            gratyfLabel.Name = "gratyfLabel";
            gratyfLabel.Size = new System.Drawing.Size(121, 13);
            gratyfLabel.TabIndex = 11;
            gratyfLabel.Text = "Eksport do Gratyfikanta:";
            // 
            // nazwaLabel
            // 
            nazwaLabel.AutoSize = true;
            nazwaLabel.Location = new System.Drawing.Point(27, 49);
            nazwaLabel.Name = "nazwaLabel";
            nazwaLabel.Size = new System.Drawing.Size(41, 13);
            nazwaLabel.TabIndex = 13;
            nazwaLabel.Text = "nazwa:";
            // 
            // grupaBindingNavigator
            // 
            this.grupaBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.grupaBindingNavigator.BindingSource = this.grupaBindingSource;
            this.grupaBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.grupaBindingNavigator.CountItemFormat = "z  {0}";
            this.grupaBindingNavigator.DeleteItem = null;
            this.grupaBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.grupaBindingNavigatorSaveItem});
            this.grupaBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.grupaBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.grupaBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.grupaBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.grupaBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.grupaBindingNavigator.Name = "grupaBindingNavigator";
            this.grupaBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.grupaBindingNavigator.Size = new System.Drawing.Size(325, 25);
            this.grupaBindingNavigator.TabIndex = 0;
            this.grupaBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Nowa Grupa";
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
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(32, 22);
            this.bindingNavigatorCountItem.Text = "z  {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Liczba grup";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Pierwszy";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Poprzedni";
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
            this.bindingNavigatorPositionItem.ToolTipText = "aktualna grupa";
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
            this.bindingNavigatorMoveNextItem.Text = "Następny";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Ostatni";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "Kasowanie";
            this.bindingNavigatorDeleteItem.Click += new System.EventHandler(this.bindingNavigatorDeleteItem_Click);
            // 
            // grupaBindingNavigatorSaveItem
            // 
            this.grupaBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.grupaBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("grupaBindingNavigatorSaveItem.Image")));
            this.grupaBindingNavigatorSaveItem.Name = "grupaBindingNavigatorSaveItem";
            this.grupaBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.grupaBindingNavigatorSaveItem.Text = "Zapis Danych";
            this.grupaBindingNavigatorSaveItem.Click += new System.EventHandler(this.grupaBindingNavigatorSaveItem_Click);
            // 
            // doOdebrCheckBox
            // 
            this.doOdebrCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.grupaBindingSource, "doOdebr", true));
            this.doOdebrCheckBox.Enabled = false;
            this.doOdebrCheckBox.Location = new System.Drawing.Point(283, 74);
            this.doOdebrCheckBox.Name = "doOdebrCheckBox";
            this.doOdebrCheckBox.Size = new System.Drawing.Size(22, 24);
            this.doOdebrCheckBox.TabIndex = 4;
            this.doOdebrCheckBox.UseVisualStyleBackColor = true;
            this.doOdebrCheckBox.Visible = false;
            this.doOdebrCheckBox.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // godzNadlCheckBox
            // 
            this.godzNadlCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.grupaBindingSource, "godzNadl", true));
            this.godzNadlCheckBox.Location = new System.Drawing.Point(283, 104);
            this.godzNadlCheckBox.Name = "godzNadlCheckBox";
            this.godzNadlCheckBox.Size = new System.Drawing.Size(46, 24);
            this.godzNadlCheckBox.TabIndex = 6;
            this.godzNadlCheckBox.UseVisualStyleBackColor = true;
            this.godzNadlCheckBox.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // pracaSobCheckBox
            // 
            this.pracaSobCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.grupaBindingSource, "pracaSob", true));
            this.pracaSobCheckBox.Location = new System.Drawing.Point(283, 134);
            this.pracaSobCheckBox.Name = "pracaSobCheckBox";
            this.pracaSobCheckBox.Size = new System.Drawing.Size(46, 24);
            this.pracaSobCheckBox.TabIndex = 8;
            this.pracaSobCheckBox.UseVisualStyleBackColor = true;
            this.pracaSobCheckBox.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // pracaNiedzCheckBox
            // 
            this.pracaNiedzCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.grupaBindingSource, "pracaNiedz", true));
            this.pracaNiedzCheckBox.Location = new System.Drawing.Point(283, 164);
            this.pracaNiedzCheckBox.Name = "pracaNiedzCheckBox";
            this.pracaNiedzCheckBox.Size = new System.Drawing.Size(46, 24);
            this.pracaNiedzCheckBox.TabIndex = 10;
            this.pracaNiedzCheckBox.UseVisualStyleBackColor = true;
            this.pracaNiedzCheckBox.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // gratyfCheckBox
            // 
            this.gratyfCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.grupaBindingSource, "gratyf", true));
            this.gratyfCheckBox.Location = new System.Drawing.Point(283, 194);
            this.gratyfCheckBox.Name = "gratyfCheckBox";
            this.gratyfCheckBox.Size = new System.Drawing.Size(46, 24);
            this.gratyfCheckBox.TabIndex = 12;
            this.gratyfCheckBox.UseVisualStyleBackColor = true;
            this.gratyfCheckBox.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // nazwaTextBox
            // 
            this.nazwaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.grupaBindingSource, "nazwa", true));
            this.nazwaTextBox.Location = new System.Drawing.Point(88, 46);
            this.nazwaTextBox.Name = "nazwaTextBox";
            this.nazwaTextBox.Size = new System.Drawing.Size(208, 20);
            this.nazwaTextBox.TabIndex = 14;
            this.nazwaTextBox.TextChanged += new System.EventHandler(this.TextBox_Changed);
            // 
            // grupaTableAdapter
            // 
            this.grupaTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.grupaTableAdapter = this.grupaTableAdapter;
            this.tableAdapterManager.pracownikTableAdapter = null;
            this.tableAdapterManager.rejestrTableAdapter = null;
            this.tableAdapterManager.rozliczenieTableAdapter = null;
            this.tableAdapterManager.rozlTmpTableAdapter = null;
            this.tableAdapterManager.rozTmRejTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = rcpracy.RcpDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // F1Grupy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 269);
            this.Controls.Add(doOdebrLabel);
            this.Controls.Add(this.doOdebrCheckBox);
            this.Controls.Add(godzNadlLabel);
            this.Controls.Add(this.godzNadlCheckBox);
            this.Controls.Add(pracaSobLabel);
            this.Controls.Add(this.pracaSobCheckBox);
            this.Controls.Add(pracaNiedzLabel);
            this.Controls.Add(this.pracaNiedzCheckBox);
            this.Controls.Add(gratyfLabel);
            this.Controls.Add(this.gratyfCheckBox);
            this.Controls.Add(nazwaLabel);
            this.Controls.Add(this.nazwaTextBox);
            this.Controls.Add(this.grupaBindingNavigator);
            this.Name = "F1Grupy";
            this.Text = "Grupy";
            this.Load += new System.EventHandler(this.F1Grupy_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.F1Grupy_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.grupaBindingNavigator)).EndInit();
            this.grupaBindingNavigator.ResumeLayout(false);
            this.grupaBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grupaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rcpDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RcpDataSet rcpDataSet;
        private System.Windows.Forms.BindingSource grupaBindingSource;
        private rcpracy.RcpDataSetTableAdapters.grupaTableAdapter grupaTableAdapter;
        private rcpracy.RcpDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator grupaBindingNavigator;
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
        private System.Windows.Forms.ToolStripButton grupaBindingNavigatorSaveItem;
        private System.Windows.Forms.CheckBox doOdebrCheckBox;
        private System.Windows.Forms.CheckBox godzNadlCheckBox;
        private System.Windows.Forms.CheckBox pracaSobCheckBox;
        private System.Windows.Forms.CheckBox pracaNiedzCheckBox;
        private System.Windows.Forms.CheckBox gratyfCheckBox;
        private System.Windows.Forms.TextBox nazwaTextBox;
    }
}