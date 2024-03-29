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
namespace Probel.NDoctor.View.Core.ViewModel
{
    using System;
    using System.Windows.Input;

    using Probel.Mvvm.DataBinding;
    using Probel.Mvvm.Gui;
    using Probel.NDoctor.Domain.DTO.Components;
    using Probel.NDoctor.View.Plugins;

    public class DebugViewModel : RequestCloseViewModel
    {
        #region Fields

        private const string APPKEY = "AppKey";
        private const string ISDEBUG = "IsDebug";
        private const string THUMBNAIL = "AreThumbnailsCreated";

        private readonly ICommand cancelCommand;
        private readonly ICommand newAppKeyCommand;
        private readonly ICommand saveCommand;

        private string appKey;
        private bool areThumbnailCreated;
        private bool isDebugModeActivated;
        private IDbSettingsComponent Settings = PluginContext.ComponentFactory.GetInstance<IDbSettingsComponent>();

        #endregion Fields

        #region Constructors

        public DebugViewModel()
        {
            this.saveCommand = new RelayCommand(() => this.Save());
            this.newAppKeyCommand = new RelayCommand(() => this.NewAppKey());
            this.cancelCommand = new RelayCommand(() => this.Cancel());
        }

        #endregion Constructors

        #region Properties

        public string AppKey
        {
            get { return this.appKey; }
            set
            {
                this.appKey = value;
                this.OnPropertyChanged(() => AppKey);
            }
        }

        public bool AreThumbnailCreated
        {
            get { return this.areThumbnailCreated; }
            set
            {
                this.areThumbnailCreated = value;
                this.OnPropertyChanged(() => AreThumbnailCreated);
            }
        }

        public ICommand CancelCommand
        {
            get { return this.cancelCommand; }
        }

        public bool IsDebugModeActivated
        {
            get { return this.isDebugModeActivated; }
            set
            {
                this.isDebugModeActivated = value;
                this.OnPropertyChanged(() => IsDebugModeActivated);
            }
        }

        public ICommand NewAppKeyCommand
        {
            get { return this.newAppKeyCommand; }
        }

        public ICommand SaveCommand
        {
            get { return this.saveCommand; }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Refreshes the data of this instance.
        /// </summary>
        public void Refresh()
        {
            this.IsDebugModeActivated = bool.Parse(this.Settings[ISDEBUG]);
            this.AreThumbnailCreated = bool.Parse(this.Settings[THUMBNAIL]);
            this.AppKey = this.Settings[APPKEY];
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        protected void Save()
        {
            this.Settings[ISDEBUG] = this.IsDebugModeActivated.ToString();
            this.Settings[THUMBNAIL] = this.AreThumbnailCreated.ToString();
            this.Settings[APPKEY] = this.AppKey;
            this.Close();
        }

        private void Cancel()
        {
            this.Close();
        }

        private void NewAppKey()
        {
            var dr = ViewService.MessageBox.Question("Do you want to reset the AppKey of the application?");
            if (dr)
            {
                this.AppKey = Guid.NewGuid().ToString();
            }
        }

        #endregion Methods
    }
}