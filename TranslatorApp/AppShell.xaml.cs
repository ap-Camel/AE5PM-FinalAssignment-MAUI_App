using TranslatorApp.Views;

namespace TranslatorApp;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(TranslationHistory), typeof(TranslationHistory));
	}
}
