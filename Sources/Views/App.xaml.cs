namespace Views;

public partial class App : Application
{

    public AppVM AppVM { get; private set; }

    public App(AppVM appVM)
	{
		InitializeComponent();
		AppVM = appVM;
		MainPage = new AppShell();
	}
}

