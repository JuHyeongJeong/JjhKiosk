using JjhKiosk.DB.Server.EF.Core.Context;
using JjhKiosk.Support.ControlBase;
using JjhKiosk.Support.Event;
using JjhKiosk.Support.Model;
using Microsoft.Extensions.Configuration;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JjhKiosk.MenuCategory.ViewModels
{
    public interface ICategoryListViewModel { }
    public class CategoryListViewModel : BindableBase, ICategoryListViewModel
    {
        private int currentPage = 0;
        private const int ItemsPerPage = 6;
        private readonly IEventAggregator eventAggregator;
        private readonly IConfiguration _config;
        private readonly LoginAccount _loginInfo;
        private MenuItemCategory selectedCategory;

        public MenuItemCategory SelectedCategory
        {
            get => selectedCategory;
            set => SetProperty(ref selectedCategory, value);
        }

        public IEnumerable<MenuItemCategory> CurrentItems => MenuCategoryList.Skip(currentPage * ItemsPerPage).Take(ItemsPerPage);
        public ObservableCollection<MenuItemCategory> MenuCategoryList { get; set; }
        public DelegateCommand NextPageCommand { get; }
        public DelegateCommand PreviousPageCommand { get; }
        public DelegateCommand SelectedItemChangedCommand { get; }

        public CategoryListViewModel(IEventAggregator eventAggregator, IConfiguration config, LoginAccount LoginInfo)
        {
            this.eventAggregator = eventAggregator;
            this._config = config;
            this._loginInfo = LoginInfo;
            ItemInit();
            SelectedItemChangedCommand = new DelegateCommand(OnSelectedItemChanged);
            NextPageCommand = new DelegateCommand(NextPage, CanGoNext).ObservesProperty(() => CurrentItems);
            PreviousPageCommand = new DelegateCommand(PreviousPage, CanGoPrevious).ObservesProperty(() => CurrentItems);
        }

        private void OnSelectedItemChanged()
        {
            if(SelectedCategory == null)
            {
                SelectedCategory = CurrentItems.FirstOrDefault();
            }
            eventAggregator.GetEvent<PassCategoryInfoEvent>().Publish(SelectedCategory);
        }

        private void ItemInit()
        {
            MenuCategoryList = new ObservableCollection<MenuItemCategory>();
            using (var jjhContext = MySqlContext.CreateJjhKioskContext(_config))
            {
                var items = jjhContext.KioskMenuCategories.ToList().Where(x => x.StoreId == _loginInfo.LogonAccount.StoreId);

                if (items.Any())
                {
                    foreach (var item in items)
                    {
                        MenuCategoryList.Add(new MenuItemCategory() { Name = item.MenuCategoryName, MenuCategoryID = item.MenuCategoryId, StoreID = item.StoreId });
                    }
                }
            }

            if (SelectedCategory == null)
            {
                SelectedCategory = MenuCategoryList.FirstOrDefault();
                OnSelectedItemChanged();
            }
        }

        private void NextPage()
        {
            if ((currentPage + 1) * ItemsPerPage < MenuCategoryList.Count)
            {
                currentPage++;
                RaisePropertyChanged(nameof(CurrentItems));
                RaisePropertyChanged(nameof(IsNextButtonVisible));
                RaisePropertyChanged(nameof(IsPreviousButtonVisible));
            }
        }

        private void PreviousPage()
        {
            if (currentPage > 0)
            {
                currentPage--;
                RaisePropertyChanged(nameof(CurrentItems));
                RaisePropertyChanged(nameof(IsNextButtonVisible));
                RaisePropertyChanged(nameof(IsPreviousButtonVisible));
            }

        }


        private bool CanGoNext() => (currentPage + 1) * ItemsPerPage < MenuCategoryList.Count;
        private bool CanGoPrevious() => currentPage > 0;

        public bool IsNextButtonVisible => CanGoNext();
        public bool IsPreviousButtonVisible => CanGoPrevious();
    }
}
