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
namespace Probel.NDoctor.Plugins.Authorisation
{
    using System;
    using System.ComponentModel.Composition;
    using System.Windows.Input;
    using System.Windows.Media;

    using Probel.Helpers.Assertion;
    using Probel.Helpers.Strings;
    using Probel.Mvvm;
    using Probel.Mvvm.DataBinding;
    using Probel.Mvvm.Gui;
    using Probel.NDoctor.Domain.DTO;
    using Probel.NDoctor.Domain.DTO.Components;
    using Probel.NDoctor.Plugins.Authorisation.Helpers;
    using Probel.NDoctor.Plugins.Authorisation.Properties;
    using Probel.NDoctor.Plugins.Authorisation.View;
    using Probel.NDoctor.Plugins.Authorisation.ViewModel;
    using Probel.NDoctor.View;
    using Probel.NDoctor.View.Plugins;
    using Probel.NDoctor.View.Plugins;
    using Probel.NDoctor.View.Plugins.MenuData;

    [Export(typeof(IPlugin))]
    [PartMetadata(Keys.Constraint, ">3.0.0.0")]
    [PartMetadata(Keys.PluginId, "{584D7616-248E-4985-AC3F-66C07958E646}")]
    public class PluginManager : Plugin
    {
        #region Fields

        private const string imgUri = @"\Probel.NDoctor.Plugins.Authorisation;component/Images\{0}.png";

        private IAuthorisationComponent component;
        private PageEventArgs.DisplayedPage displayed;
        private ICommand navigateCommand;

        #endregion Fields

        #region Constructors

        [ImportingConstructor]
        public PluginManager()
            : base()
        {
            this.component = PluginContext.ComponentFactory.GetInstance<IAuthorisationComponent>();
            PluginContext.Host.UserConnected += (sender, e) => this.component = PluginContext.ComponentFactory.GetInstance<IAuthorisationComponent>();

            this.ConfigureAutoMapper();
        }

        #endregion Constructors

        #region Properties

        private ManageUserView ManageUserView
        {
            get { return LazyLoader.Get<ManageUserView>(); }
        }

        private WorkbenchView WorkbenView
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
            Assert.IsNotNull(PluginContext.Host, "PluginContext.Host");
            this.ConfigureViewService();
            this.BuildButtons();
            this.BuildContextMenu();
        }

        /// <summary>
        /// Builds the buttons for the main menu.
        /// </summary>
        private void BuildButtons()
        {
            this.navigateCommand = new RelayCommand(() => this.NavigateRole(), () => PluginContext.Host.ConnectedUser != null && PluginContext.DoorKeeper.IsUserGranted(To.Administer));

            var navigateButton = new RibbonButtonData(Messages.Title_AuthorisationManager
                    , imgUri.FormatWith("Admin")
                    , navigateCommand) { Order = 4 };

            PluginContext.Host.AddToApplicationMenu(navigateButton);
        }

        /// <summary>
        /// Builds the context menu the ribbon for this plugin.
        /// </summary>
        private void BuildContextMenu()
        {
            var ngroup = new RibbonGroupData(Messages.Menu_Navigation, 1);
            var cgroup = new RibbonGroupData(Messages.Menu_Actions, 2);

            var tab = new RibbonTabData() { Header = Messages.Menu_File, ContextualTabGroupHeader = Messages.Title_AuthorisationManager };
            tab.GroupDataCollection.Add(cgroup);
            tab.GroupDataCollection.Add(ngroup);

            this.ContextualMenu = new RibbonContextualTabGroupData(Messages.Title_AuthorisationManager, tab) { Background = Brushes.OrangeRed, IsVisible = false, };
            PluginContext.Host.AddContextualMenu(this.ContextualMenu);
            PluginContext.Host.AddTab(tab);

            ICommand roleCommand = new RelayCommand(() => this.NavigateRole(), () => this.CanNavigateRole());
            ngroup.ButtonDataCollection.Add(new RibbonButtonData(Messages.Title_RoleManager, imgUri.FormatWith("Admin"), roleCommand) { Order = 1, });

            ICommand userCommand = new RelayCommand(() => this.NavigateUser(), () => this.CanNavigateUser());
            ngroup.ButtonDataCollection.Add(new RibbonButtonData(Messages.Title_UserManager, imgUri.FormatWith("UserSetup"), userCommand) { Order = 2, });

            ICommand addRoleCommand = new RelayCommand(() => ViewService.Manager.ShowDialog<AddRoleViewModel>());
            cgroup.ButtonDataCollection.Add(new RibbonButtonData(Messages.Title_AddRole, imgUri.FormatWith("New"), addRoleCommand) { Order = 2, });
        }

        private bool CanNavigateRole()
        {
            return this.displayed != PageEventArgs.DisplayedPage.RoleManager
                && PluginContext.DoorKeeper.IsUserGranted(To.Administer);
        }

        private bool CanNavigateUser()
        {
            return this.displayed != PageEventArgs.DisplayedPage.UserManager
                && PluginContext.DoorKeeper.IsUserGranted(To.Administer);
        }

        private bool CanSaveRole()
        {
            return PluginContext.DoorKeeper.IsUserGranted(To.Administer);
        }

        /// <summary>
        /// Configures the mapping for AutoMapper.
        /// </summary>
        private void ConfigureAutoMapper()
        {
            //Add the mapping here...
        }

        private void ConfigureViewService()
        {
            LazyLoader.Set<WorkbenchView>(() => new WorkbenchView());
            LazyLoader.Set<ManageUserView>(() => new ManageUserView());
            LazyLoader.Set<EditAssignedRoleView>(() => new EditAssignedRoleView());

            ViewService.Configure(e =>
            {
                e.Bind<AddRoleView, AddRoleViewModel>()
                 .OnClosing(() => this.WorkbenView.As<WorkbenchViewModel>().Refresh());

                e.Bind<EditRoleView, EditRoleViewModel>()
                 .OnClosing(() => this.WorkbenView.As<WorkbenchViewModel>().Refresh());

                e.Bind<EditAssignedRoleView, EditAssignedRoleViewModel>()
                 .OnShow(vm => vm.Refresh())
                 .OnClosing(() =>
                 {
                     this.WorkbenView.As<WorkbenchViewModel>().Refresh();
                     this.ManageUserView.As<ManageUserViewModel>().Refresh();
                 });
            });
        }

        private void NavigateRole()
        {
            if (PluginContext.Host.Navigate(this.WorkbenView))
            {
                this.WorkbenView.As<WorkbenchViewModel>().Refresh();
                this.displayed = PageEventArgs.DisplayedPage.RoleManager;

                this.ContextualMenu.IsVisible = true;
                this.ContextualMenu.TabDataCollection[0].IsSelected = true;
            }
        }

        private void NavigateUser()
        {
            if (PluginContext.Host.Navigate(this.ManageUserView))
            {
                this.ManageUserView.As<ManageUserViewModel>().Refresh();
                this.displayed = PageEventArgs.DisplayedPage.UserManager;
                Notifyer.OnShowing(this, PageEventArgs.DisplayedPage.UserManager);

                this.ContextualMenu.IsVisible = true;
                this.ContextualMenu.TabDataCollection[0].IsSelected = true;
            }
        }

        #endregion Methods
    }
}