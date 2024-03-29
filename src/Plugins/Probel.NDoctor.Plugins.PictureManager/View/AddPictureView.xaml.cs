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

namespace Probel.NDoctor.Plugins.PictureManager.View
{
    using System.Windows;
    using System.Windows.Input;

    using Probel.NDoctor.Plugins.PictureManager.ViewModel;

    /// <summary>
    /// Interaction logic for AddPictureView.xaml
    /// </summary>
    public partial class AddPictureView : Window
    {
        #region Constructors

        public AddPictureView()
        {
            InitializeComponent();
            this.DataContext = new AddPictureViewModel();
        }

        #endregion Constructors

        #region Methods

        private void CloseCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }

        #endregion Methods
    }
}