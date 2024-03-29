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
namespace Probel.NDoctor.Plugins.BmiRecord.ViewModel
{
    using System;
    using System.Windows.Input;

    using Probel.Helpers.Assertion;
    using Probel.Helpers.WPF;
    using Probel.Mvvm.DataBinding;
    using Probel.NDoctor.Domain.DTO.Components;
    using Probel.NDoctor.Domain.DTO.Objects;
    using Probel.NDoctor.Plugins.BmiRecord.Properties;
    using Probel.NDoctor.View;
    using Probel.NDoctor.View.Core.ViewModel;
    using Probel.NDoctor.View.Plugins;
    using Probel.NDoctor.View.Toolbox;

    internal class AddBmiViewModel : BaseViewModel
    {
        #region Fields

        private IBmiComponent component = null;
        private BmiDto currentBmi = new BmiDto();

        #endregion Fields

        #region Constructors

        public AddBmiViewModel()
        {
            if (!Designer.IsDesignMode)
            {
                this.component = PluginContext.ComponentFactory.GetInstance<IBmiComponent>();
                PluginContext.Host.UserConnected += (sender, e) => this.component = PluginContext.ComponentFactory.GetInstance<IBmiComponent>();
            }

            this.AddCommand = new RelayCommand(() => this.AddBmi(), () => this.CanAddBmi());

            if (PluginContext.Host.SelectedPatient != null)
            {
                this.CurrentBmi.Height = PluginContext.Host.SelectedPatient.Height;
                this.CurrentBmi.Date = DateTime.Today;
            }
        }

        #endregion Constructors

        #region Properties

        public ICommand AddCommand
        {
            get;
            private set;
        }

        public BmiDto CurrentBmi
        {
            get { return this.currentBmi; }
            set
            {
                this.currentBmi = value;
                this.OnPropertyChanged(() => CurrentBmi);
            }
        }

        #endregion Properties

        #region Methods

        private void AddBmi()
        {
            Assert.IsNotNull(PluginContext.Host, "PluginContext.Host");
            Assert.IsNotNull(PluginContext.Host.SelectedPatient, "SelectedPatient");
            Assert.IsNotNull(this.CurrentBmi, "CurrentBmi");

            try
            {
                this.component.CreateBmi(this.CurrentBmi, PluginContext.Host.SelectedPatient);
                PluginContext.Host.WriteStatus(StatusType.Info, Messages.Msg_BmiAdded);
                this.CurrentBmi = new BmiDto();
            }
            catch (Exception ex)
            {
                this.Handle.Error(ex, Messages.Msg_ErrAddBmi);
            }
            this.Close();
        }

        private bool CanAddBmi()
        {
            return this.CurrentBmi.Date <= DateTime.Now
                && this.CurrentBmi.Height > 0
                && this.CurrentBmi.Weight > 0
                && PluginContext.Host.SelectedPatient != null;
        }

        #endregion Methods
    }
}