using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace ContactBook.Service
{
    public interface IPersonService
    {
        Task AddNewPerson(string name, string address, string phone);

        Task GetPersons(ListView list);

        Task DeletePerson(object person);

        Task Search(ListView list,string name);

    }
}
