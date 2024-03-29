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
namespace Probel.NDoctor.Domain.DAL.Components
{
    using System;
    using System.Collections.Generic;

    using NHibernate;

    using Probel.NDoctor.Domain.DAL.Subcomponents;
    using Probel.NDoctor.Domain.DTO.Components;
    using Probel.NDoctor.Domain.DTO.Objects;

    public class ImportComponent : BaseComponent, IImportComponent
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ImportComponent"/> class.
        /// </summary>
        /// <param name="session">The session.</param>
        public ImportComponent(ISession session)
            : base(session)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ImportComponent"/> class.
        /// </summary>
        public ImportComponent()
            : base()
        {
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Creates the specified patients.
        /// </summary>
        /// <param name="patients"></param>
        public void Create(IEnumerable<PatientFullDto> patients)
        {
            new Creator(this.Session).Create(patients);
        }

        private void ForEach<T>(IList<T> collection, Action<T> merge)
        {
            for (int i = 0; i < collection.Count; i++)
            {
                merge(collection[i]);
            }
        }

        private void Reload<T>(T item)
        {
            if (item != null)
            {
                var loaded = (T)this.Session.Get<T>(((dynamic)item).Id);

                if (loaded != null) { item = loaded; }
                else { this.Session.Save(item); }
            }
        }

        #endregion Methods
    }
}