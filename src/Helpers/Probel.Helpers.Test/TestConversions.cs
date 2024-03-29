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
namespace Probel.Helpers.Test
{
    using System;
    using System.Collections.ObjectModel;

    using NUnit.Framework;

    using Probel.Helpers.Conversions;
    using Probel.Mvvm.DataBinding;

    public class TestConversions : TestBase
    {
        #region Methods

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConvertToObservableCollection_SpecifyANullCollection_ThrowsErgumentNullException()
        {
            ObservableCollection<object> list = null;
            list.ToObservableCollection();
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RefillTheCollection_RefillsWithNullValue_ThrowsErgumentNullException()
        {
            ObservableCollection<object> list = new ObservableCollection<object>();
            list.Refill(null);
        }

        #endregion Methods
    }
}