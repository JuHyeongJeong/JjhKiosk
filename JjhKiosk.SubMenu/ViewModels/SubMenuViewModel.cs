using JjhKiosk.Support.Event;
using JjhKiosk.Support.Interface;
using JjhKiosk.Support.Model;
using JjhKiosk.Support.Utils;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JjhKiosk.SubMenu.ViewModels
{
    public interface ISubMenuViewModel { }

    public class SubMenuViewModel : BindableBase, ISubMenuViewModel
    {
        private readonly IEventAggregator _eventAggregator;

        private IMenuItem selectedItem;
        public IMenuItem SelectedItem
        {
            get => selectedItem;
            set => SetProperty(ref selectedItem, value);
        }


        public DelegateCommand CancelCommand { get; init; }
        public DelegateCommand SelectCommand { get; init; }
        public SubMenuViewModel(IEventAggregator eventAggregator)
        {
            this._eventAggregator = eventAggregator;
            CancelCommand = new DelegateCommand(OnClickCancel);
            SelectCommand = new DelegateCommand(OnClickSelect);
            _eventAggregator.GetEvent<PassMenuInfoEvent>().Subscribe(OnGetMenuInfo);
        }

        private void OnClickSelect()
        {
            _eventAggregator.GetEvent<OptionPopupOpenCloseEvent>().Publish(false);


        }

        //팝업켜지는 동시에 item을 받아서 메뉴수정함.
        private void OnGetMenuInfo(IMenuItem item)
        {
            if(item is MenuItem menu)
            {
                var menuItemClone = new MenuItemCloner();
                SelectedItem = menuItemClone.DeepClone(menu);
            }
            
        }

        private void OnClickCancel()
        {
            _eventAggregator.GetEvent<OptionPopupOpenCloseEvent>().Publish(false);
        }
    }
}
