using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using MHelper.Models;
using MHelper.Views;
using Xamarin.Forms;

namespace MHelper.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public INavigation Navigation { get; set; }

        public ObservableCollection<Item> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public Item selectedItem;

        public ItemsViewModel()
        {
            Title = "Browse";
            Items = new ObservableCollection<Item>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        public Item SelectedItem
        {
            get { return selectedItem; }
            set
            {
                if (selectedItem != value)
                {
                    Item tempItem = value;
                    //Dynamic ViewModel and Page selection
                    BaseViewModel tempModel = null;
                    ContentPage tempPage = null;

                    OnPropertyChanged("SelectedItem");

                    switch (tempItem.Text)
                    {
                        case "Derivative":
                            tempModel = new DerivativeViewModel();
                            tempPage = new DerivativePage(tempModel);
                            break;
                        default:
                            tempModel = new DerivativeViewModel();
                            tempPage = new DerivativePage(tempModel);
                            break;
                    }

                    Navigation.PushAsync(tempPage);
                }
            }
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
