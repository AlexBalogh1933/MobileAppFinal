using System.Collections.ObjectModel;
using Xamarin.Forms;
using MobileAppFinal.Models;

namespace MobileAppFinal
{
    public partial class MainPage : ContentPage
    {
        private ObservableCollection<ToDoItem> _toDoItems;

        public MainPage()
        {
            InitializeComponent();

            _toDoItems = new ObservableCollection<ToDoItem>();
            LoadToDoItems();

            // Bind the CollectionView to the ObservableCollection
            ToDoCollectionView.ItemsSource = _toDoItems;
        }

        private void LoadToDoItems()
        {
            var items = App.Database.Table<ToDoItem>().ToList();
            _toDoItems.Clear();

            foreach (var item in items)
            {
                _toDoItems.Add(item);
            }
        }

        private void AddToDoButton_Clicked(object sender, System.EventArgs e)
        {
            var newItem = new ToDoItem { Title = NewToDoEntry.Text, IsCompleted = false };
            App.Database.Insert(newItem);
            _toDoItems.Add(newItem);

            // Clear the entry after adding the new item
            NewToDoEntry.Text = string.Empty;
        }

        private void DeleteToDoItemButton_Clicked(object sender, System.EventArgs e)
        {
            if (sender is Button button && button.BindingContext is ToDoItem item)
            {
                App.Database.Delete(item);
                _toDoItems.Remove(item);
            }
        }

        private void ToggleCompletionCheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (sender is CheckBox checkBox && checkBox.BindingContext is ToDoItem item)
            {
                item.IsCompleted = e.Value;
                App.Database.Update(item);
            }
        }
    }
}
