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
namespace Probel.NDoctor.Plugins.PatientData.ViewModel
{
    using System;
    using System.Windows.Input;

    using Probel.Helpers.WPF;
    using Probel.Mvvm.DataBinding;
    using Probel.NDoctor.Domain.DTO.Components;
    using Probel.NDoctor.Domain.DTO.Exceptions;
    using Probel.NDoctor.Domain.DTO.Objects;
    using Probel.NDoctor.Plugins.PatientData.Properties;
    using Probel.NDoctor.View.Core.ViewModel;
    using Probel.NDoctor.View.Plugins;
    using Probel.NDoctor.View.Toolbox;

    internal class AddPracticeViewModel : BaseViewModel
    {
        #region Fields

        private IPatientDataComponent component;
        private bool isPopupOpened;
        private PracticeDto practice;

        #endregion Fields

        #region Constructors

        public AddPracticeViewModel()
        {
            this.Practice = new PracticeDto();

            this.AddCommand = new RelayCommand(() => this.Add(), () => this.CanAdd());
            this.ShowPopupCommand = new RelayCommand(() => this.IsPopupOpened = true);

            if (!Designer.IsDesignMode)
            {
                this.component = PluginContext.ComponentFactory.GetInstance<IPatientDataComponent>();
                PluginContext.Host.UserConnected += (sender, e) => this.component = PluginContext.ComponentFactory.GetInstance<IPatientDataComponent>();
            }
        }

        #endregion Constructors

        #region Properties

        public ICommand AddCommand
        {
            get;
            private set;
        }

        public bool IsPopupOpened
        {
            get { return this.isPopupOpened; }
            set
            {
                this.Practice = new PracticeDto();

                this.isPopupOpened = value;
                this.OnPropertyChanged(() => IsPopupOpened);
            }
        }

        public PracticeDto Practice
        {
            get { return this.practice; }
            set
            {
                this.practice = value;
                this.OnPropertyChanged(() => Practice);
            }
        }

        public ICommand ShowPopupCommand
        {
            get;
            private set;
        }

        #endregion Properties

        #region Methods

        private void Add()
        {
            try
            {
                this.component.Create(this.Practice);

                PluginContext.Host.WriteStatus(StatusType.Info, Messages.Title_OperationDone);
                this.IsPopupOpened = false;
            }
            catch (ExistingItemException ex) { this.Handle.Warning(ex, ex.Message); }
            catch (Exception ex) { this.Handle.Error(ex, Messages.Msg_ErrorOccured); }
            finally { this.Close(); }
        }

        private bool CanAdd()
        {
            return !string.IsNullOrWhiteSpace(this.Practice.Name);
        }

        #endregion Methods
    }
}