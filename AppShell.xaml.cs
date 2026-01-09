using ProGymMobile.Views;

namespace ProGymMobile
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("ClaseFitnessRoute", typeof(ClaseFitnessPage));
        }
    }
}
