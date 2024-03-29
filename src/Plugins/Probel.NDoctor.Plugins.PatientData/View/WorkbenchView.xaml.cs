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
namespace Probel.NDoctor.Plugins.PatientData.View
{
    using System.Windows.Controls;

    using Probel.NDoctor.Plugins.PatientData.ViewModel;

    /// <summary>
    /// Interaction logic for Workbench.xaml
    /// </summary>
    public partial class WorkbenchView : Page
    {
        #region Constructors

        public WorkbenchView()
        {
            InitializeComponent();
            this.DataContext = new WorkbenchViewModel();
        }

        #endregion Constructors
    }
}