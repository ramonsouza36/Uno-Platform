using ContactBook.Service;
using ContactBook.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// O modelo de item de Página em Branco está documentado em https://go.microsoft.com/fwlink/?LinkId=234238

namespace ContactBook.Views
{
    /// <summary>
    /// Uma página vazia que pode ser usada isoladamente ou navegada dentro de um Quadro.
    /// </summary>
    public sealed partial class ListPersonPage : Page
    {
        public static PersonService PersonService { get; set; }
        private readonly PersonViewModel personViewModel = new(PersonService);
        public ListPersonPage()
        {
            this.InitializeComponent();
            var container = ((App)App.Current).Container;

            // Request an instance of the ViewModel and set it to the DataContext
            DataContext = ActivatorUtilities.GetServiceOrCreateInstance(container, typeof(PersonViewModel));
            personViewModel = (PersonViewModel)DataContext;
            personViewModel.ListPersons(personList);
            
        }

        public async void OnDelete(object sender, RoutedEventArgs e)
        {
            
            Button button = sender as Button;
            var person = button.DataContext;
            await personViewModel.Delete(person);
        }

        private async void OnSearch(object sender, RoutedEventArgs args)
        {
            var personName = search.Text;
            await personViewModel.SearchPerson(personList, personName);
        }

        private void OnEdit(object sender, RoutedEventArgs args)
        {
            Button button = sender as Button;
            var editPage = new EditPersonPage(button);
            editPage.DataContext = button.DataContext;
            // personViewModel.SearchPerson(personList, personName);
            Frame.Navigate(typeof(EditPersonPage));
        }

        private void GoToEditPage(object sender, RoutedEventArgs e) => Frame.Navigate(typeof(EditPersonPage),sender as Button);
    }
}
