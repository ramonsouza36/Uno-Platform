using System.Collections.Generic;
using System.Threading.Tasks;
using ContactBook.Models;
using ContactBook.Service;
using Windows.UI.Xaml.Controls;

namespace ContactBook.ViewModels
{
    public class PersonViewModel
    {
        protected IPersonService PersonService { get; }

        public PersonViewModel(IPersonService personService)
        {
            PersonService = personService;
        }

        public async Task AddNewPerson(string name, string address, string phone)
        {

            await PersonService.AddNewPerson(name, address, phone);
        }

        public async Task ListPersons(ListView list)
        {
            await PersonService.GetPersons(list);
        }

        public async Task Delete(object person)
        {
            await PersonService.DeletePerson(person);
        }

        public async Task SearchPerson(ListView list,string name)
        {
            await PersonService.Search(list, name);
        }

    }
}
