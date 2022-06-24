using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TranslatorApp.Models;
using TranslatorApp.Services;
using TranslatorApp.Views;

namespace TranslatorApp.ViewModels
{
    public partial class TranslationViewModel : BaseViewModel
    {

        ApiServices api;
        LocalDbServices localDb;    



        [ObservableProperty]
        string translateFrom;

        [ObservableProperty]
        string translateTo;


        public ICommand translateCommand { private set; get; }
        public ICommand getTranslationsCommand { private set; get; }
        public ICommand goToHistoryCommand { private set; get; }


        
        private async Task translate()
        {
            try
            {
                IsBusy = true;

                if(translateFrom != null || translateFrom != String.Empty)
                {
                    TranslateTo = await api.getTranslation(TranslateFrom);
                    await localDb.AddNewTranslation(TranslateTo, TranslateFrom);
                }
            }
            catch (Exception ex)
            {

                throw;
            } finally
            {
                IsBusy = false;
            }
        }

        private async Task getTranslations() 
        {
            List<Translation> list = await localDb.GetAllTranslations();
        }

        private async Task goToHistory()
        {
            await Shell.Current.GoToAsync(nameof(TranslationHistory));
        }


        public TranslationViewModel(ApiServices api, LocalDbServices localDb)
        {
            this.api = api;
            this.localDb = localDb;

            TranslateFrom = "from";
            TranslateTo = "to";

            translateCommand = new Command(async () => await translate());
            getTranslationsCommand = new Command(async () => await getTranslations());
            goToHistoryCommand = new Command(async () => await goToHistory());
        }
    }
}
