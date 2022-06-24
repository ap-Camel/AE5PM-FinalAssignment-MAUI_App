namespace TranslatorApp;

using TranslatorApp.Services;

public partial class App : Application
{
    public static LocalDbServices localDb { get; private set; }
    public App(LocalDbServices LocalDb)
	{
		InitializeComponent();

		MainPage = new AppShell();
		localDb = LocalDb;
	}
}
