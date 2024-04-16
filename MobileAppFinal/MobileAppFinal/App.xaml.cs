using MobileAppFinal.Models;
using SQLite;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileAppFinal
{
    public partial class App : Application
    {
        public static SQLiteConnection Database;

        public App()
        {
            InitializeComponent();

            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ToDoDatabase.db3");
            Database = new SQLiteConnection(dbPath);
            Database.CreateTable<ToDoItem>();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
