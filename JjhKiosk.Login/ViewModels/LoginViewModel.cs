using JjhKiosk.DB.Server.EF.Core.Infrastructure.Reverse;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace JjhKiosk.Login.ViewModels
{
    public class LoginViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;

        public DelegateCommand TestCommand { get; init; }
        public JjhKioskDbContext _dbContext { get; }

        public LoginViewModel(IRegionManager regionManager, JjhKioskDbContext dbContext)
        {
            TestCommand = new DelegateCommand(Test);
            this._regionManager = regionManager;
            _dbContext = dbContext;
        }

        private void Test()
        {
            var a = _dbContext.KioskAccounts.ToList().FirstOrDefault() ;
            _regionManager.RequestNavigate("ContentRegion", "StandbyView");
        }
    }
}
