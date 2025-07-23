using CommunityToolkit.Mvvm.ComponentModel;
using JjhKiosk.Support.ControlBase;
using JjhKiosk.Support.Enum;
using JjhKiosk.Title.UI.Views;
using Prism.Commands;
using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace JjhKiosk.Title.ViewModels
{
    public interface IBannerViewModel { }
    public partial class BannerViewModel : ObservableObject, IBannerViewModel
    {
        [ObservableProperty]
        private ContentControlBase _currentView = default!;

        private EventWaitHandle taskHandle;
        protected EventWaitHandle TaskHandle => taskHandle;
        public IContainerProvider ContainerProvider { get; }

        private SlideType _slideType;

        private Task task;

        public DelegateCommand ProgramChangedCommand { get; init; }

        public BannerViewModel(IContainerProvider containerProvider)
        {
            ContainerProvider = containerProvider;

            CurrentView = (ContentControlBase)ContainerProvider.Resolve<BannerControl1>();
            taskHandle = new EventWaitHandle(initialState: false, EventResetMode.ManualReset);

            Run();
        }

        private ContentControlBase GetView()
        {
            if (CurrentView is BannerControl1)
            {
                return (ContentControlBase)ContainerProvider.Resolve<BannerControl2>();
            }
            else if(CurrentView is BannerControl2)
            {
                return (ContentControlBase)ContainerProvider.Resolve<BannerControl3>();
            }
            else
            {
                return (ContentControlBase)ContainerProvider.Resolve<BannerControl1>();
            }
        }

        public SlideType SlideType
        {
            get { return _slideType; }
            set
            {
                _slideType = value;
                OnPropertyChanged();
            }
        }

        public async void Run()
        {
            //베너 회전 테스크
            task = Task.Run(() =>
            {
                while (true)
                {
                    try
                    {
                        if (TaskHandle.WaitOne(5000))
                            continue;

                        if (Application.Current != null && Application.Current.Dispatcher != null)
                        {
                            Application.Current.Dispatcher.Invoke(() =>
                            {
                                SlideType = SlideType.RightToLeft;
                                CurrentView = GetView();
                            });
                        }
                        
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Banner rotation Task exception");
                    }
                }
            });

            await task;
        }

    }
}
