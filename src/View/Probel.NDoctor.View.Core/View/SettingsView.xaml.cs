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
namespace Probel.NDoctor.View.Core.View
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    using Probel.NDoctor.View.Core.ViewModel;

    /// <summary>
    /// Interaction logic for SettingsView.xaml
    /// </summary>
    public partial class SettingsView : Window
    {
        #region Constructors

        public SettingsView()
        {
            InitializeComponent();
            this.DataContext = new SettingsViewModel();
        }

        #endregion Constructors

        #region Methods

        private void this_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            this.list.GetBindingExpression(ListView.ItemsSourceProperty).UpdateTarget();
            Keyboard.Focus(this.focused);
        }

        #endregion Methods
    }
}