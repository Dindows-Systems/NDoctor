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

namespace Probel.NDoctor.View.Core.Helpers
{
    using System;
    using System.Windows.Data;
    using System.Windows.Media;

    [ValueConversion(typeof(string), typeof(Brush))]
    internal class StatusConverter : IValueConverter
    {
        #region Methods

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string text = value.ToString().ToLower();

            if (!string.IsNullOrWhiteSpace(text))
            {
                text = text.ToLower();

                if (text == "fatal") { return Brushes.Red; }
                else if (text == "error") { return Brushes.OrangeRed; }
                else if (text == "warn") { return Brushes.Orange; }
                else if (text == "info") { return Brushes.SkyBlue; }
                else if (text == "debug") { return Brushes.LightGreen; }
                else { return Brushes.White; }
            }
            else { return Brushes.Gainsboro; }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion Methods
    }
}