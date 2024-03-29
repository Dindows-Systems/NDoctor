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

namespace Probel.NDoctor.Domain.DAL.Entities
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents a task in the authorisation managment.
    /// A Role has one or many tasks
    /// </summary>
    public class Task : Entity
    {
        #region Properties

        /// <summary>
        /// Gets or sets the name of the task.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public virtual string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the notes to explain the database.
        /// </summary>
        /// <value>
        /// The notes.
        /// </value>
        public virtual string Notes
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the reference name.
        /// /!\ Don't change this value because it is linked to hardcoded values
        /// </summary>
        /// <value>
        /// The name of the ref.
        /// </value>
        public virtual string RefName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the roles binded to this role.
        /// </summary>
        /// <value>
        /// The tasks.
        /// </value>
        public virtual IList<Role> Roles
        {
            get; set;
        }

        #endregion Properties
    }
}