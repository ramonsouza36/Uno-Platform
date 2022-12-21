using ContactBook.Models;
using ContactBook.Service;
using ContactBook.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ContactBook.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddPersonPage : Page
    {
        public static PersonService PersonService { get; set; }
        private readonly PersonViewModel personViewModel = new(PersonService);
        public AddPersonPage()
        {
            this.InitializeComponent();
            var container = ((App)App.Current).Container;

            // Request an instance of the ViewModel and set it to the DataContext
            DataContext = ActivatorUtilities.GetServiceOrCreateInstance(container, typeof(PersonViewModel));
            personViewModel = (PersonViewModel)DataContext;
        }

        private async void OnButtonClick(object sender, RoutedEventArgs args)
        {
            await personViewModel.AddNewPerson(personName.Text, personAddress.Text, personPhone.Text); 
        }
            
        //private void GotoNextPage(object sender, RoutedEventArgs e) => Frame.Navigate(typeof(BlankPage2)); // in BlankPage1
    }
}
