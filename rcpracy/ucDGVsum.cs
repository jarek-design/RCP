using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace rcpracy
{
    public partial class ucDGVsum : UserControl
    {
        public List<Label> sumLabelList = new List<Label>();
        DataGridView DGV; int startColumn; int CountColSum;
        public ucDGVsum()
        {
            InitializeComponent();
            CountColSum = 0;  
        }

       
        /// <summary>
        /// Utworzenie labels do pokazania sum. 
        /// Tworzą one ciągły obszar od pewnej kulumny
        /// </summary>
        /// <param name="DGV">dataGridView</param>
        /// <param name="startColumn">początkowa kolumna gdzie ma być sumowanie</param>
        /// <param name="CountColSum">ilość kolumn, które są sumowane.</param>
        public void Initialize (DataGridView DGV, int startColumn, int CountColSum )
            {          
            this.DGV = DGV;
            this.startColumn = startColumn;
            this.CountColSum = CountColSum;
            
            for (int ii=0; ii<CountColSum; ii++)
            {
                sumLabelList.Add(new Label() );
                LabelPositioning(sumLabelList[ii], startColumn + ii);
                sumLabelList[ii].Text = "0";
                sumLabelList[ii].Name = "uln" + ii.ToString();
                sumLabelList[ii].Size = new Size(55, 13);
                SumPanel.Controls.Add(sumLabelList[ii]);
            }
        }

        public void LabelPositioning()
        {

            for (int ii = 0; ii < CountColSum; ii++)
            {              
                LabelPositioning(sumLabelList[ii], startColumn + ii);               
            }
        }
/// <summary>
/// Wpisanie wartości sumowania
/// </summary>
/// <param name="ii"> nr kolumny</param>
/// <param name="val"> wartość sumowania</param>
        public void SetLabel(int ii, string val)
        {
            sumLabelList[ii].Text = val.ToString();
            sumLabelList[ii].Visible = true;
        }

      

        private void LabelPositioning(Label lab1, int colNumber)
        {

            if (DGV.Rows.Count > 0)
            {
                Rectangle rc = DGV.GetCellDisplayRectangle(colNumber, 0, false);
                lab1.Location = new Point(rc.Location.X, 3);

                if (rc.Location.X > 0)
                    lab1.Visible = true;
                else
                    lab1.Visible = false;
            }
            else
                lab1.Visible = false;
        }
    }
}
