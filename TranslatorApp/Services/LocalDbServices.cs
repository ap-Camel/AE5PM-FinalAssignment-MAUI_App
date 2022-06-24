using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite;
using TranslatorApp.Models;

namespace TranslatorApp.Services
{
    public class LocalDbServices
    {
        string _dbPath;
        public string StatusMessage { get; set; }


        SQLiteAsyncConnection conn;
        private async Task Init()
        {
            // TODO: Add code to initialize the repository
            // 

            if (conn != null)
                return;

            conn = new SQLiteAsyncConnection(_dbPath);
            await conn.CreateTableAsync<Translation>();
        }

        public LocalDbServices(string dbPath)
        {
            _dbPath = dbPath;
        }

        public async Task AddNewTranslation(string translateTo, string translateFrom)
        {
            try
            {
                // TODO: Call Init()

                await Init();

                //basic validation to ensure a name was entered
                if (string.IsNullOrEmpty(translateTo) || string.IsNullOrEmpty(translateFrom))
                    throw new Exception("Valid name required");

                // TODO: Insert the new person into the database

                var result = await conn.InsertAsync(new Translation { translateTo = translateTo, translatefrom = translateFrom });

                StatusMessage = string.Format("{0} record(s) added (Name: {1}), (name2: {2})", result, translateFrom, translateTo);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", translateFrom, ex.Message);
            }

        }


        public async Task<List<Translation>> GetAllTranslations()
        {
            // TODO: Init then retrieve a list of Person objects from the database into a list
            try
            {
                await Init();
                return await conn.Table<Translation>().ToListAsync();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }

            return new List<Translation>();
        }

        public async Task deleteHistory()
        {
            try
            {
                await Init();
                await conn.DeleteAllAsync<Translation>();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        //SQLiteConnection conn = new SQLiteConnection(filename);
    }
}
