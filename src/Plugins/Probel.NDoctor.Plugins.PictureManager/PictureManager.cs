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
namespace Probel.NDoctor.Plugins.PictureManager
{
    using System;
    using System.ComponentModel.Composition;
    using System.Windows.Input;
    using System.Windows.Media;

    using Probel.Helpers.Strings;
    using Probel.Mvvm;
    using Probel.Mvvm.DataBinding;
    using Probel.Mvvm.Gui;
    using Probel.NDoctor.Domain.DTO;
    using Probel.NDoctor.Plugins.PictureManager.Properties;
    using Probel.NDoctor.Plugins.PictureManager.View;
    using Probel.NDoctor.Plugins.PictureManager.ViewModel;
    using Probel.NDoctor.View;
    using Probel.NDoctor.View.Plugins;
    using Probel.NDoctor.View.Plugins;
    using Probel.NDoctor.View.Plugins.MenuData;

    [Export(typeof(IPlugin))]
    [PartMetadata(Keys.Constraint, ">3.0.0.0")]
    [PartMetadata(Keys.PluginId, "{8A4CF3E8-DA69-4568-8387-6F175457DD02}")]
    public class PictureManager : Plugin
    {
        #region Fields

        private const string imgUri = @"\Probel.NDoctor.Plugins.PictureManager;component/Images\{0}.png";

        private ICommand navigateCommand;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PictureManager"/> class.
        /// </summary>
        /// <param name="version">The version.</param>
        /// <param name="host">The host.</param>
        [ImportingConstructor]
        public PictureManager()
            : base()
        {
        }

        #endregion Constructors

        #region Properties

        public WorkbenchView View
        {
            get { return LazyLoader.Get<WorkbenchView>(); }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Initialises this plugin. Basicaly it should configure the menus into the PluginHost
        /// Every task that could throw exception should be in this method and not in the ctor.
        /// </summary>
        public override void Initialise()
        {
            PluginContext.Host.Invoke(() =>
            {
                LazyLoader.Set<WorkbenchView>(() => new WorkbenchView());

                this.BuildButtons();
                this.BuildContextMenu();
                this.ConfigureWindowManager();
            });
        }

        private void BuildButtons()
        {
            this.navigateCommand = new RelayCommand(() => Navigate(), () => this.CanNavigate());

            var navigateButton = new RibbonButtonData(Messages.Title_PictureManager
                    , imgUri.FormatWith("Picture")
                    , navigateCommand) { Order = 5 };

            PluginContext.Host.AddInHome(navigateButton, Groups.Managers);
        }

        private void BuildContextMenu()
        {
            var addPicButton = new RibbonButtonData(Messages.Title_BtnAddPic, imgUri.FormatWith("Add"), this.GetAddPicCommand());
            var addTypeButton = new RibbonButtonData(Messages.Title_AddPicType, imgUri.FormatWith("Add"), this.GetAddCategoryCommand());
            var cgroup = new RibbonGroupData(Messages.Menu_Actions);

            cgroup.ButtonDataCollection.Add(addPicButton);
            cgroup.ButtonDataCollection.Add(addTypeButton);

            var tab = new RibbonTabData(Messages.Menu_File, cgroup) { ContextualTabGroupHeader = Messages.Title_Pictures };
            PluginContext.Host.AddTab(tab);

            this.ContextualMenu = new RibbonContextualTabGroupData(Messages.Title_Pictures, tab) { Background = Brushes.OrangeRed, IsVisible = false };
            PluginContext.Host.AddContextualMenu(this.ContextualMenu);
        }

        private bool CanNavigate()
        {
            return PluginContext.Host.SelectedPatient != null
                && PluginContext.DoorKeeper.IsUserGranted(To.Read);
        }

        private void ConfigureWindowManager()
        {
            ViewService.Configure(e =>
            {
                e.Bind<AddPictureView, AddPictureViewModel>()
                 .OnShow(vm => vm.RefreshCommand.TryExecute())
                 .OnClosing(vm => this.RefreshWorkbenchView(vm.HasAddPicture));
                e.Bind<AddTagView, AddTagViewModel>()
                    .OnClosing(() => this.View.As<WorkbenchViewModel>().Refresh());
            });
        }

        private ICommand GetAddCategoryCommand()
        {
            ICommand cmd = null;
            PluginContext.Host.Invoke(() => cmd = this.View.As<WorkbenchViewModel>().AddTypeCommand);
            return cmd;
        }

        private ICommand GetAddPicCommand()
        {
            ICommand cmd = null;
            PluginContext.Host.Invoke(() => cmd = this.View.As<WorkbenchViewModel>().AddPictureCommand);
            return cmd;
        }

        private void Navigate()
        {
            try
            {
                if (PluginContext.Host.Navigate(this.View))
                {
                    this.View.As<WorkbenchViewModel>().RefreshForNavigation();
                    this.ShowContextMenu();
                }
            }
            catch (Exception ex)
            {
                this.Handle.Error(ex, Messages.Msg_FailToLoadMedicalPictures.FormatWith(ex.Message));
            }
        }

        private void RefreshWorkbenchView(bool doRefresh)
        {
            if (doRefresh)
            {
                this.View.As<WorkbenchViewModel>().Refresh();
            }
        }

        #endregion Methods
    }
}