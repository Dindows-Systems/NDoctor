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

namespace Probel.NDoctor.View.Toolbox.Helpers
{
    /// <summary>
    /// This object is used with databinding to keep the "by reference" feature when developer pass
    /// a string or a value object
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ReferencedObject<T>
    {
        #region Constructors

        public ReferencedObject(T value)
        {
            this.Value = value;
        }

        #endregion Constructors

        #region Properties

        public T Value
        {
            get;
            set;
        }

        #endregion Properties
    }
}