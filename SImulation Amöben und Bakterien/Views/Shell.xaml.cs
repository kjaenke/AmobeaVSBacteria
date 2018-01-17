namespace Amoeba
{
    using ViewModels;

    public partial class Shell
    {
        public Shell()
        {
            InitializeComponent();  
            DataContext = new ShellViewModel();
        }       
    }
}
