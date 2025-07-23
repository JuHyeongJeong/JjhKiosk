using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using JjhKiosk.DB.Server.EF.Core.Context;
using JjhKiosk.DB.Server.EF.Core.Infrastructure.Reverse.Models;
using JjhKiosk.Support.Enum;
using JjhKiosk.Support.Event;
using JjhKiosk.Support.Interface;
using JjhKiosk.Support.Model;
using JjhKiosk.Support.Utils;
using Microsoft.Extensions.Configuration;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;

namespace JjhKiosk.MenuList.ViewModels
{
    public interface IMenuListViewModel { }
    public class MenuListViewModel : BindableBase, IMenuListViewModel
    {
        private int currentPage = 0;
        private const int ItemsPerPage = 25;
        private readonly IEventAggregator _eventAggregator;
        private readonly IConfiguration _config;

        private IMenuItem selectedItem;
        private ObservableCollection<MenuItem> currentItems;
        private ObservableCollection<MenuItem> menuItemList;
        public IMenuItem SelectedItem
        {
            get => selectedItem;
            set => SetProperty(ref selectedItem, value);
        }
        public ObservableCollection<MenuItem> CurrentItems
        {
            get => currentItems;
            set => SetProperty(ref currentItems, value);
        }
        public ObservableCollection<MenuItem> MenuItemList
        {
            get => menuItemList;
            set
            {
                if (SetProperty(ref menuItemList, value))
                {
                    UpdateCurrentItems();
                }
            }
        }
        public LoginAccount _loginInfo { get; }
        public ObservableCollection<IMenuItem> _allMenus { get; }
        public DelegateCommand NextPageCommand { get; }
        public DelegateCommand PreviousPageCommand { get; }
        public DelegateCommand SelectedItemChangedCommand { get; }
        public MenuListViewModel(IEventAggregator eventAggregator, IConfiguration config, LoginAccount LoginInfo, ObservableCollection<IMenuItem> allMenus)
        {
            this._eventAggregator = eventAggregator;
            this._config = config;
            this._loginInfo = LoginInfo;
            this._allMenus = allMenus;
            NextPageCommand = new DelegateCommand(NextPage, CanGoNext).ObservesProperty(() => MenuItemList);
            PreviousPageCommand = new DelegateCommand(PreviousPage, CanGoPrevious).ObservesProperty(() => MenuItemList);
            CurrentItems = new ObservableCollection<MenuItem>();
            MenuItemList = new ObservableCollection<MenuItem>();
            SelectedItemChangedCommand = new DelegateCommand(OnSelectedItemChanged);
            OnGetMenuInit();
            _eventAggregator.GetEvent<PassCategoryInfoEvent>().Subscribe(OnGetCategoryInfo);

        }

        //전 메뉴 리스트 DB에서 로딩하고 메모리에 저장.
        private void OnGetMenuInit()
        {
            using (var jjhContext = MySqlContext.CreateJjhKioskContext(_config))
            {
                var categories = jjhContext.KioskMenuCategories.ToList().Where(x => x.StoreId == _loginInfo.LogonAccount.StoreId);
                var items = jjhContext.KioskMenuLists.ToList().Where(x => categories.Contains(x.MenuCategory));
                if (items.Any())
                {
                    //using (var jjhContextOptions = MySqlContext.CreateJjhKioskContext(_config))
                    //{
                    foreach (var item in items)
                    {
                        MenuItemBuilder menuBuilder = new MenuItemBuilder();
                        //var menu = new MenuItem() { Name = item.MenuName, Price = (int)item.Price, MenuIcon = item.ImagePath, MenuCategory = item.MenuCategoryId, MenuType = item.MenuTypeId, Qty = 0 };
                        var menu = menuBuilder.SetName(item.MenuName)
                            .SetPrice((int)item.Price)
                            .SetMenuImage(item.ImagePath)
                            .SetMenuCategory(item.MenuCategoryId)
                            .SetMenuType(item.MenuTypeId)
                            .SetQty(0)
                            .SetOptionSelection(null)
                            .Build();
                        ObservableCollection<IMenuOptionItem> optionItems = new ObservableCollection<IMenuOptionItem>();
                        var options = jjhContext.KioskMenuOptionGroups.Where(x => x.MenuTypeId == menu.MenuType).ToList();

                        if (options != null)
                        {
                            foreach (var option in options)
                            {
                                var optionLinkers = jjhContext.KioskMenuOptionLinkers.Where(x => x.OptionGroupId == option.OptionGroupId).ToList();
                                ObservableCollection<IOptionSelection> selections = new ObservableCollection<IOptionSelection>();
                                if (optionLinkers != null)
                                {
                                    foreach (var optionLinker in optionLinkers)
                                    {
                                        OptionSelectionBuilder optionSelectionBuilder = new OptionSelectionBuilder();
                                        var optionSelection = jjhContext.KioskMenuOptionMembers.FirstOrDefault(x => x.OptionMemberId == optionLinker.OptionMemberId);
                                        //selections.Add(new OptionSelection() { IsSelected = false, SelectionName = optionSelection.OptionMemberName, SelectionPrice = optionSelection.OptionMemberPrice });
                                        selections.Add(optionSelectionBuilder.SetSelectionName(optionSelection.OptionMemberName)
                                            .SetSelectionPrice(optionSelection.OptionMemberPrice)
                                            .SetSelectionIsSelect(false)
                                            .Build());
                                    }
                                }
                                //var optionGroup = new MenuOptionItem() { OptionName = option.OptionGroupName, OptionPrice = 0, OptionType = (OptionType)option.OptionTypeId, OptionSelections = selections ?? null };
                                MenuOptionItemBuilder menuOptionBuilder = new MenuOptionItemBuilder();
                                var optionGroup = menuOptionBuilder.SetOptionName(option.OptionGroupName)
                                    .SetOptionType((OptionType)option.OptionTypeId)
                                    .SetOptionPrice(0)
                                    .SetOptionSelection(selections ?? null)
                                    .Build();
                                optionItems.Add(optionGroup);
                            }
                        }
                        menu.OptionSelections = optionItems;
                        _allMenus.Add(menu);
                    }
                }

            }
        }

        private void OnSelectedItemChanged()
        {
            if (SelectedItem != null)
            {
                _eventAggregator.GetEvent<PassMenuInfoEvent>().Publish(SelectedItem);
                _eventAggregator.GetEvent<OptionPopupOpenCloseEvent>().Publish(true);
                SelectedItem = null;
            }
        }

        private void UpdateCurrentItems()
        {
            int startIndex = currentPage * ItemsPerPage;

            // If the start index is beyond the Items count, reset to first page
            if (startIndex >= menuItemList.Count)
            {
                currentPage = 0;
                startIndex = 0;
            }

            // Clear the current items and update them with the new page data
            CurrentItems.Clear();
            for (int i = startIndex; i < startIndex + ItemsPerPage && i < menuItemList.Count; i++)
            {
                CurrentItems.Add(menuItemList[i]);
            }

            // Update commands' ability to execute
            NextPageCommand.RaiseCanExecuteChanged();
            PreviousPageCommand.RaiseCanExecuteChanged();
        }

        //메뉴 카테고리가 선택되었을 때 Subscribe했던 이벤트가 작동하면서 실행됨.
        private void OnGetCategoryInfo(MenuItemCategory category)
        {
            //Category가 바뀌면서 하위 아이템을 변경하는 메서드.
            ItemInit(category);
        }


        private void ItemInit(MenuItemCategory category)
        {
            MenuItemList.Clear();
            //using (var jjhContext = MySqlContext.CreateJjhKioskContext(_config))
            //{
            //    var items = jjhContext.KioskMenuLists.ToList().Where(x => x.MenuCategoryId == category.MenuCategoryID);

            //    if (items.Any())
            //    {
            //        foreach (var item in items)
            //        {
            //            MenuItemList.Add(new MenuItem() { Name = item.MenuName, Price = (int)item.Price, MenuIcon = item.ImagePath });
            //        }
            //    }
            //}

            var items = _allMenus.Where(x => x.MenuCategory == category.MenuCategoryID);

            if (items.Any())
            {
                foreach (var item in items)
                {
                    if (item is MenuItem menuitem)
                        MenuItemList.Add(menuitem);
                }
            }
            //선택한 Item 세팅
            UpdateCurrentItems();
        }

        private void NextPage()
        {
            if ((currentPage + 1) * ItemsPerPage < MenuItemList.Count)
            {
                currentPage++;
                UpdateCurrentItems();
            }
        }

        private void PreviousPage()
        {
            if (currentPage > 0)
            {
                currentPage--;
                UpdateCurrentItems();
            }

        }


        private bool CanGoNext() => (currentPage + 1) * ItemsPerPage < MenuItemList.Count;
        private bool CanGoPrevious() => currentPage > 0;

        public bool IsNextButtonVisible => CanGoNext();
        public bool IsPreviousButtonVisible => CanGoPrevious();

    }
}
