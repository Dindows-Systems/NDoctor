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

namespace Probel.NDoctor.View.Plugins
{
    using Probel.NDoctor.View.Plugins.Cfg;

    public interface IPluginLoader
    {
        #region Properties

        /// <summary>
        /// Gets or sets the plugin configuration.
        /// </summary>
        /// <value>
        /// The plugin configuration.
        /// </value>
        PluginsConfigurationFolder PluginConfiguration
        {
            get;
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Retrieves the plugins from the repository.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="host">The host.</param>
        void RetrievePlugins(PluginContainer container, IPluginHost host);

        #endregion Methods
    }
}