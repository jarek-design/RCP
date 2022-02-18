using System.Windows.Forms;

namespace rcpracy
{
    public partial class GodzMinColumn : DataGridViewColumn
    {
        // custom control zamieniające minuty na godz:min
        int minuty;
        public GodzMinColumn(int min)
        {
            minuty = min;
            InitializeComponent();

        }

        public override DataGridViewCell CellTemplate
        {
            get
            {
                return base.CellTemplate;
            }
            set
            {
                // Ensure that the cell used for the template is a CalendarCell.
                if (value != null &&
                    !value.GetType().IsAssignableFrom(typeof(GodzMinCell)))
                {
                    throw new System.InvalidCastException("Błąd.Ma być godzina i minuta");
                }
                base.CellTemplate = value;
            }
        }
       
    }

    public class GodzMinCell : DataGridViewTextBoxCell
    {
        public GodzMinCell()
            : base()
        {
           
            
        }
    }
}
