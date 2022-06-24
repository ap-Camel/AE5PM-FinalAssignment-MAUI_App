namespace TranslatorApp;
using TranslatorApp.ViewModels;

public partial class MainPage : ContentPage
{
	public MainPage(TranslationViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;

		vm.getTranslationsCommand.Execute(null);
	}

	
}

