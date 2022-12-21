using ContactBook.Models;
using ContactBook.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using SQLite;
using System;
using System.IO;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ContactBook.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            InitializeDatabase();
            
        }

        private async void InitializeDatabase()
        {
            // Ensure that the storage subsystem is initialized on webassembly
            await Windows.Storage.StorageFolder.GetFolderFromPathAsync(Windows.Storage.ApplicationData.Current.LocalFolder.Path);

            var db = TryCreateDatabase();
        }

        private static SQLiteConnection TryCreateDatabase()
        {
            // Get an absolute path to the database file
            var databasePath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "MyData.db");
            //var databasepath = "C:\\Users\\automatiza\\Desktop\\Estudos\\Uno3\\ContactBook\\ContactBook.Shared\\Data\\MyData.db";
            var exists = File.Exists(databasePath);
            var db = new SQLiteConnection(databasePath);

            if (!exists)
            {
                db.CreateTable<Person>();
            }

            return db;
        }
        private void GotoNextPage(object sender, RoutedEventArgs e) => Frame.Navigate(typeof(AddPersonPage));

        private void GoToListPage(object sender, RoutedEventArgs e) => Frame.Navigate(typeof(ListPersonPage));

    }
}
