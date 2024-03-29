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
namespace Probel.NDoctor.Plugins.PictureManager.ViewModel
{
    using System;
    using System.Windows.Input;

    using Probel.Helpers.WPF;
    using Probel.Mvvm.DataBinding;
    using Probel.NDoctor.Domain.DTO;
    using Probel.NDoctor.Domain.DTO.Components;
    using Probel.NDoctor.Domain.DTO.Exceptions;
    using Probel.NDoctor.Domain.DTO.Objects;
    using Probel.NDoctor.Plugins.PictureManager.Properties;
    using Probel.NDoctor.View;
    using Probel.NDoctor.View.Core.ViewModel;
    using Probel.NDoctor.View.Plugins;
    using Probel.NDoctor.View.Toolbox;

    internal class AddTagViewModel : BaseViewModel
    {
        #region Fields

        private IPictureComponent component;
        private bool isPopupOpened;
        private TagDto selectedTag;

        #endregion Fields

        #region Constructors

        public AddTagViewModel()
        {
            this.SelectedTag = new TagDto(TagCategory.Picture);

            if (!Designer.IsDesignMode)
            {
                this.component = PluginContext.ComponentFactory.GetInstance<IPictureComponent>();
                PluginContext.Host.UserConnected += (sender, e) => this.component = PluginContext.ComponentFactory.GetInstance<IPictureComponent>();
            }

            this.ShowPopupCommand = new RelayCommand(() => this.IsPopupOpened = true);
            this.AddCommand = new RelayCommand(() => this.Add(), () => this.CanAdd());
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
                this.isPopupOpened = value;
                this.OnPropertyChanged(() => IsPopupOpened);
            }
        }

        public TagDto SelectedTag
        {
            get { return this.selectedTag; }
            set
            {
                this.selectedTag = value;
                this.OnPropertyChanged(() => SelectedTag);
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
                this.component.Create(this.SelectedTag);

                PluginContext.Host.WriteStatus(StatusType.Info, Messages.Title_OperationDone);
                this.SelectedTag = new TagDto(TagCategory.Picture);
                this.IsPopupOpened = false;
            }
            catch (ExistingItemException ex) { this.Handle.Warning(ex, ex.Message); }
            catch (Exception ex) { this.Handle.Error(ex, Messages.Msg_ErrorOccured); }
            finally { this.Close(); }
        }

        private bool CanAdd()
        {
            return this.SelectedTag != null
                && !string.IsNullOrWhiteSpace(this.SelectedTag.Name)
                && this.SelectedTag.Category == TagCategory.Picture
                && PluginContext.DoorKeeper.IsUserGranted(To.Write);
        }

        #endregion Methods
    }
}