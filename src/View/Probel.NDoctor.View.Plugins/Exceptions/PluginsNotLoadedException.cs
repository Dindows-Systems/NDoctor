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
namespace Probel.NDoctor.View.Plugins.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    using Probel.NDoctor.View.Plugins.Properties;

    /// <summary>
    /// The exception that is thrown when the plugins aren't loaded into memory
    /// </summary>
    [Serializable]
    public class PluginsNotLoadedException : PluginException
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PluginsNotLoadedException"/> class.
        /// </summary>
        public PluginsNotLoadedException()
            : this(Messages.Ex_PluginNotLoadedException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PluginsNotLoadedException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public PluginsNotLoadedException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PluginsNotLoadedException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="inner">The inner.</param>
        public PluginsNotLoadedException(string message, Exception inner)
            : base(message, inner)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PluginsNotLoadedException"/> class.
        /// </summary>
        /// <param name="info">The object that holds the serialized object data.</param>
        /// <param name="context">The contextual information about the source or destination.</param>
        protected PluginsNotLoadedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        #endregion Constructors
    }
}