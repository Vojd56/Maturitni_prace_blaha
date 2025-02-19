namespace MauiApp1
{
    public partial class AppShell : Shell
    {
        public ScheduleViewModel ScheduleVM { get; private set; }

        public AppShell()
        {
            InitializeComponent();
            ScheduleVM = new ScheduleViewModel();
            BindingContext = ScheduleVM;
        }
    }
}
