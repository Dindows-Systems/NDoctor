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

namespace Probel.NDoctor.View.Core.Translations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Probel.NDoctor.View.Core.Properties;

    public static class PluginCfgText
    {
        #region Properties

        public static string Explanations
        {
            get { return Messages.Gb_Explanations; }
        }

        public static string IsActive
        {
            get { return Messages.Lbl_IsActive; }
        }

        public static string IsMandatory
        {
            get { return Messages.Lbl_IsMandatory; }
        }

        public static string IsRecommended
        {
            get { return Messages.Lbl_IsRecommended; }
        }

        public static string Plugins
        {
            get { return Messages.Gb_Plugins; }
        }

        #endregion Properties
    }
}