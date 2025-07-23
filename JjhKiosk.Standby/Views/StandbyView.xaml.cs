using System.Windows.Controls;

namespace JjhKiosk.Standby.Views
{
    public interface IStandbyView { }
    /// <summary>
    /// Interaction logic for StandbyView
    /// </summary>
    public partial class StandbyView : UserControl, IStandbyView
    {
        
        public StandbyView()
        {
            InitializeComponent();
        }
    }
}
