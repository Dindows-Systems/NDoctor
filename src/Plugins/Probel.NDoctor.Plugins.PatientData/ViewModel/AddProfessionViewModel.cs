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
    using Probel.NDoctor.View.Toolbox.Translations;

    internal class AddProfessionViewModel : BaseViewModel
    {
        #region Fields

        private IPatientDataComponent component;
        private ProfessionDto profession;

        #endregion Fields

        #region Constructors

        public AddProfessionViewModel()
        {
            this.Profession = new ProfessionDto();

            this.AddCommand = new RelayCommand(() => this.Add(), () => this.CanAdd());

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

        public ProfessionDto Profession
        {
            get { return this.profession; }
            set
            {
                this.profession = value;
                this.OnPropertyChanged(() => Profession);
            }
        }

        #endregion Properties

        #region Methods

        private void Add()
        {
            try
            {
                this.component.Create(this.Profession);
                PluginContext.Host.WriteStatus(StatusType.Info, BaseText.InsertDone);
            }
            catch (ExistingItemException ex) { this.Handle.Warning(ex, ex.Message); }
            catch (Exception ex) { this.Handle.Error(ex, BaseText.ErrorOccured); }
            finally { this.Close(); }
        }

        private bool CanAdd()
        {
            return !string.IsNullOrWhiteSpace(this.Profession.Name);
        }

        #endregion Methods
    }
}