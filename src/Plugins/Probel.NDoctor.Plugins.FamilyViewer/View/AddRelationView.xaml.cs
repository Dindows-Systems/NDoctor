﻿#region Header

/*
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

#endregion Header

namespace Probel.NDoctor.Plugins.FamilyViewer.View
{
    using System.Windows;

    using Probel.NDoctor.Plugins.FamilyViewer.ViewModel;

    /// <summary>
    /// Interaction logic for AddRelationView.xaml
    /// </summary>
    public partial class AddRelationView : Window
    {
        #region Constructors

        public AddRelationView()
        {
            InitializeComponent();
            this.DataContext = new AddRelationViewModel();
        }

        #endregion Constructors

        #region Methods

        private void CloseCommandHandler(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            this.Close();
        }

        #endregion Methods
    }
}