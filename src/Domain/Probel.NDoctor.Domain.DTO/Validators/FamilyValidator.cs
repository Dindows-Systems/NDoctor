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
namespace Probel.NDoctor.Domain.DTO.Validators
{
    using System;

    using Probel.NDoctor.Domain.DTO.Objects;
    using Probel.NDoctor.Domain.DTO.Properties;

    [Serializable]
    internal class FamilyValidator : Validator<FamilyDto>
    {
        #region Methods

        public override void SetValidationLogic(FamilyDto item)
        {
            item.AddValidationRule(() => item.Current
                , () => item.Current != null && !this.HasCircularLinks(item)
                , Messages.Invalid_Family);
        }

        private bool HasCircularLinks(FamilyDto item)
        {
            if (item.Father != null && item.Id == item.Father.Id) { return true; }
            if (item.Mother != null && item.Id == item.Mother.Id) { return true; }
            foreach (var child in item.Children)
            {
                if (item.Id == child.Id) { return true; }
            }
            return false;
        }

        #endregion Methods
    }
}