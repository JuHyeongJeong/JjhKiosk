using CommunityToolkit.Mvvm.ComponentModel;
using JjhKiosk.DB.Server.EF.Core.Context;
using JjhKiosk.DB.Server.EF.Core.Infrastructure.Reverse;
using JjhKiosk.Support.Model;
using JjhKiosk.Support.Utils;
using Microsoft.Extensions.Configuration;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation.Regions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace JjhKiosk.Login.ViewModels
{
    public interface ILoginViewModel
    {

    }
    public partial class LoginViewModel : ObservableObject, ILoginViewModel
    {
        #region ObservableProperty
        [ObservableProperty]
        private string id;
        [ObservableProperty]
        private string pwd;
        #endregion

        #region Private
        private readonly IRegionManager _regionManager;
        private readonly IConfiguration _config;
        #endregion

        #region Public
        public DelegateCommand LoginAcceptCommand { get; init; }
        public LoginAccount _loginInfo { get; set; }
        #endregion
        public LoginViewModel(IRegionManager regionManager, IConfiguration config, LoginAccount LoginInfo)
        {
            LoginAcceptCommand = new DelegateCommand(LoginAccept);
            this._regionManager = regionManager;
            this._config = config;
            this._loginInfo = LoginInfo;

        }

        private void LoginAccept()
        {
            #region DB접근 후 계정 비교
            try
            {
                using (var jjhContext = MySqlContext.CreateJjhKioskContext(_config))
                {

                    var account = jjhContext.KioskAccounts.ToList().FirstOrDefault(x => x.UserName == Id);

                    if (account != null)
                    {
                        if (PwdHashComparer.VerifyPassword(Pwd, account.PasswordHash))
                        {
                            _loginInfo.LogonAccount = account;
                            _regionManager.RequestNavigate("ContentRegion", "StandbyView");
                        }
                        else
                        {
                            MessageBox.Show("비밀번호가 틀립니다.", "경고", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("계정이 존재하지 않습니다.", "경고", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "에러발생");
            }
            #endregion
        }
    }
}
