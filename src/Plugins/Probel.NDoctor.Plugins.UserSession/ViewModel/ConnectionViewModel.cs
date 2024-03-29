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
    using System.Collections.ObjectModel;
    using System.Windows;
    using System.Windows.Input;

    using Probel.Mvvm.DataBinding;
    using Probel.Mvvm.Gui;
    using Probel.NDoctor.Domain.DTO.Components;
    using Probel.NDoctor.Domain.DTO.Objects;
    using Probel.NDoctor.Plugins.UserSession.Properties;
    using Probel.NDoctor.View.Core.ViewModel;
    using Probel.NDoctor.View.Plugins;

    internal class ConnectionViewModel : BaseViewModel
    {
        #region Fields

        private IUserSessionComponent component = PluginContext.ComponentFactory.GetInstance<IUserSessionComponent>();
        private string password = string.Empty;
        private LightUserDto selectedUser;

        #endregion Fields

        #region Constructors

        public ConnectionViewModel()
            : base()
        {
            PluginContext.Host.UserConnected += (sender, e) => this.component = PluginContext.ComponentFactory.GetInstance<IUserSessionComponent>();

            this.Users = new ObservableCollection<LightUserDto>();

            this.ConnectCommand = new RelayCommand(() => this.Connect());

            this.NavigateAddUserCommand = new RelayCommand(() => ViewService.Manager.ShowDialog<AddUserViewModel>());
            this.Refresh();
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets the connect command.
        /// </summary>
        public ICommand ConnectCommand
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets a value indicating whether nDoctor has users in the database.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance has users; otherwise, <c>false</c>.
        /// </value>
        public bool HasUsers
        {
            get { return this.Users != null && this.Users.Count > 0; }
        }

        /// <summary>
        /// Displays a View to add a new user
        /// </summary>
        public ICommand NavigateAddUserCommand
        {
            get;
            private set;
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

        public LightUserDto SelectedUser
        {
            get { return this.selectedUser; }
            set
            {
                this.selectedUser = value;
                this.OnPropertyChanged(() => SelectedUser);
            }
        }

        public ObservableCollection<LightUserDto> Users
        {
            get;
            set;
        }

        #endregion Properties

        #region Methods

        public void Refresh()
        {
            var users = this.component.GetAllUsers();
            this.Users.Refill(users);
            this.OnPropertyChanged(() => HasUsers);
        }

        private void Connect()
        {
            var isConnected = this.component.CanConnect(this.SelectedUser, this.Password);

            if (isConnected)
            {
                PluginContext.Host.ShowMainMenu();
                PluginContext.Host.ConnectedUser = this.SelectedUser;
                PluginContext.Host.SelectedPatient = null;
                PluginContext.Host.NavigateToStartPage();
                this.Logger.Info("User logged in.");
            }
            else { ViewService.MessageBox.Warning(Messages.Msg_ErrorWrongPassword); }
        }

        #endregion Methods
    }
}