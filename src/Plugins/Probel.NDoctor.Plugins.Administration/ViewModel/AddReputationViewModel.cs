﻿namespace Probel.NDoctor.Plugins.Administration.ViewModel
{
    using Probel.NDoctor.Domain.DTO.Objects;

    internal class AddReputationViewModel : BaseBoxViewModel<ReputationDto>
    {
        #region Constructors

        public AddReputationViewModel()
        {
            this.BoxItem = new ReputationDto();
        }

        #endregion Constructors

        #region Methods

        protected override void AddItem()
        {
            this.Component.Create(this.BoxItem);
        }

        #endregion Methods
    }
}