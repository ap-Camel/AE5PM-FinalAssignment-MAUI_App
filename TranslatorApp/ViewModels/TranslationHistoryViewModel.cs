using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TranslatorApp.Models;
using TranslatorApp.Services;

namespace TranslatorApp.ViewModels
{
    public class TranslationHistoryViewModel
    {

        LocalDbServices localDb;
        
        public ObservableCollection<Translation> translations { get; }

        public ICommand getTranslationsCommand { private set; get; }
        public ICommand deleteHistoryCommand { private set; get; }  



        private async Task getTranslations()
        {
            List<Translation> translationsList = await localDb.GetAllTranslations();

            foreach(Translation t in translationsList)
            {
                translations.Add(t);
            }
        }

        private async Task deleteHistory()
        {
            await localDb.deleteHistory();
            translations.Clear();   
        }

        public TranslationHistoryViewModel(LocalDbServices localDb)
        {
            this.localDb = localDb;

            translations = new ObservableCollection<Translation>();

            getTranslationsCommand = new Command(async () => await getTranslations());
            deleteHistoryCommand = new Command(async () => await deleteHistory());

        }
    }
}
