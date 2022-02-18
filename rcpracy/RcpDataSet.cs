
namespace rcpracy
{


    public partial class RcpDataSet
    {
        public object SelectedRow(System.Windows.Forms.BindingSource BS)
        {
            System.Data.DataRowView SelRowView = (System.Data.DataRowView)BS.Current;
            if (SelRowView != null)
                return SelRowView.Row;
            else
                return null;
        }
    }
}
