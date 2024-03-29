﻿/*
    This file is part of NDoctor.

    NDoctor is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    NDoctor is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with NDoctor.  If not, see <http://www.gnu.org/licenses/>.
*/
namespace Probel.NDoctor.Plugins.UserSession.ViewModel
{
    using System;
    using System.Windows;
    using System.Windows.Input;

    using Probel.Mvvm.DataBinding;
    using Probel.Mvvm.Gui;
    using Probel.NDoctor.Domain.DTO;
    using Probel.NDoctor.Domain.DTO.Components;
    using Probel.NDoctor.Domain.DTO.Exceptions;
    using Probel.NDoctor.Domain.DTO.Objects;
    using Probel.NDoctor.Plugins.UserSession.Properties;
    using Probel.NDoctor.View.Core.ViewModel;
    using Probel.NDoctor.View.Plugins;
    using Probel.NDoctor.View.Toolbox;

    internal class AddUserViewModel : BaseViewModel
    {
        #region Fields

        private IUserSessionComponent component = PluginContext.ComponentFactory.GetInstance<IUserSessionComponent>();
        private string password;
        private string passwordCheck;
        private LightUserDto user = new LightUserDto();

        #endregion Fields

        #region Constructors

        public AddUserViewModel()
            : base()
        {
            PluginContext.Host.UserConnected += (sender, e) => this.component = PluginContext.ComponentFactory.GetInstance<IUserSessionComponent>();
            this.AddCommand = new RelayCommand(() => this.Add(), () => this.CanAdd());
        }

        #endregion Constructors

        #region Properties

        public ICommand AddCommand
        {
            get;
            private set;
        }

        public bool IsDefaultUser
        {
            get
            {
                return (this.User != null)
                    ? this.user.IsDefault
                    : false;
            }
            set
            {
                if (this.User == null) return;
                if (value == true)
                {
                    var dr = ViewService.MessageBox.Question(Messages.Msg_WarnDefaultUser);
                    if (!dr) return;
                }
                this.User.IsDefault = value;
                this.OnPropertyChanged(() => IsDefaultUser);
            }
        }

        public string Password
        {
            get { return this.password; }
            set
            {
                this.password = value;
                this.OnPropertyChanged(() => Password);
            }
        }

        public string PasswordCheck
        {
            get { return this.passwordCheck; }
            set
            {
                this.passwordCheck = value;
                this.OnPropertyChanged(() => PasswordCheck);
            }
        }

        public LightUserDto User
        {
            get { return this.user; }
            set
            {
                this.user = value;
                this.OnPropertyChanged(() => User);
            }
        }

        #endregion Properties

        #region Methods

        private void Add()
        {
            var dr = ViewService.MessageBox.Question(Messages.Msg_AskAddUser);
            if (!dr) return;

            try
            {
                this.component.Create(this.User, this.Password);

                PluginContext.Host.WriteStatus(StatusType.Info, Messages.Msg_UserAdded);
                this.Close();
            }
            catch (ExistingItemException ex) { this.Handle.Warning(ex, ex.TranslatedMessage); }
            catch (Exception ex) { this.Handle.Error(ex); }
        }

        private bool CanAdd()
        {
            return PluginContext.DoorKeeper.IsUserGranted(To.Everyone)
                && !(string.IsNullOrWhiteSpace(this.User.FirstName)
                  || string.IsNullOrWhiteSpace(this.User.LastName)
                  || string.IsNullOrWhiteSpace(this.Password)
                  || this.Password != this.PasswordCheck);
        }

        #endregion Methods
    }
}