namespace TranslatorApp.Views;

using TranslatorApp.ViewModels;

public partial class TranslationHistory : ContentPage
{
	public TranslationHistory(TranslationHistoryViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;

		vm.getTranslationsCommand.Execute(null);
	}
}