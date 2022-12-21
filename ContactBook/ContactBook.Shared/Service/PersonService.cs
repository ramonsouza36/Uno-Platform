using ContactBook.Models;
using SQLite;
using System;
using System.IO;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace ContactBook.Service
{
    public class PersonService : IPersonService
    {
     
        private SQLiteAsyncConnection conn;

        public async Task AddNewPerson(string name, string address, string phone)
        {
            int result = 0;
            if (string.IsNullOrEmpty(name))
                throw new Exception("Valid name required");

            var databasePath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "MyData.db");
            conn = new SQLiteAsyncConnection(databasePath);
            // TODO: Insert the new person into the database
            result = await conn.InsertAsync(new Person { Name = name, Address = address, Phone = phone });
            //await PersonRepo.AddNewPerson(name, address, phone);
        }

        public async Task GetPersons(ListView list)
        {
            var databasePath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "MyData.db");
            conn = new SQLiteAsyncConnection(databasePath);
            var personList = await conn.Table<Person>().OrderBy(p => p.Name).ToListAsync();
            list.ItemsSource = personList;
        
        }

        public async Task DeletePerson(object person)
        {
            var databasePath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "MyData.db");
            conn = new SQLiteAsyncConnection(databasePath);
            // TODO: Insert the new person into the database
            await conn.DeleteAsync(person);
        }

        public async Task Search(ListView list,string name)
        {
            var databasePath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "MyData.db");
            conn = new SQLiteAsyncConnection(databasePath);
            if(name == null || name == "")
            { 
                await GetPersons(list);
                return;
            }

            var personList = await conn.Table<Person>().Where(p => p.Name == name).ToListAsync();
            list.ItemsSource = personList;
        }
    }
}

