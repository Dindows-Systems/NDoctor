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
namespace Probel.NDoctor.Plugins.MeetingManager.ViewModel
{
    using System;
    using System.Windows.Input;

    using Probel.Mvvm.DataBinding;
    using Probel.NDoctor.Domain.DTO.Helpers;
    using Probel.NDoctor.Domain.DTO.Objects;
    using Probel.NDoctor.Plugins.MeetingManager.Helpers;
    using Probel.NDoctor.Plugins.MeetingManager.Properties;
    using Probel.NDoctor.View.Plugins;
    using Probel.NDoctor.View.Toolbox;

    internal class AddMeetingViewModel : MeetingViewModel
    {
        #region Fields

        private readonly PluginSettings Settings = new PluginSettings();

        #endregion Fields

        #region Constructors

        public AddMeetingViewModel()
        {
            this.FreeSlots = new TimeSlotCollection();
            this.AddAppointmentCommand = new RelayCommand(() => this.AddAppointment(), () => this.CanAddAppointment());
            this.GetFreeSlotsCommand = new RelayCommand(() => this.GetFreeSlots(), () => this.CanFindSlots());

            Countdown.Elapsed += (sender, e) => PluginContext.Host.Invoke(() =>
            {
                this.SearchCommand.TryExecute();
                Countdown.Stop();
            });
        }

        #endregion Constructors

        #region Properties

        public ICommand AddAppointmentCommand
        {
            get;
            private set;
        }

        public TimeSlotCollection FreeSlots
        {
            get;
            private set;
        }

        public ICommand GetFreeSlotsCommand
        {
            get;
            private set;
        }

        #endregion Properties

        #region Methods

        public void Refresh()
        {
            try
            {
                var tags = Component.GetTags(TagCategory.Appointment);
                AppointmentTags.Refill(tags);
            }
            catch (Exception ex) { this.Handle.Error(ex); }
        }

        protected override void ClearSlotZone()
        {
            this.FreeSlots.Clear();
        }

        private void AddAppointment()
        {
            try
            {
                var appointment = new AppointmentDto()
                {
                    StartTime = this.SelectedSlot.StartTime,
                    EndTime = this.SelectedSlot.EndTime,
                    Subject = string.Format("{0} - {1}", this.SelectedAppointmentTag.Name, this.SelectedPatient.DisplayedName),
                    User = PluginContext.Host.ConnectedUser,
                    Tag = this.SelectedAppointmentTag,
                };

                this.Component.Create(appointment, this.SelectedPatient, new PluginSettings().GetGoogleConfiguration());

                PluginContext.Host.WriteStatus(StatusType.Info, Messages.Msg_AppointmentAdded);
                this.Close();
            }
            catch (Exception ex) { this.Handle.Error(ex); }
        }

        private bool CanAddAppointment()
        {
            return this.SelectedSlot != null
                && this.SelectedAppointmentTag != null;
        }

        private void GetFreeSlots()
        {
            try
            {
                var freeSlots = this.Component.GetSlots(this.StartDate, this.EndDate, this.Settings.Workday);

                this.FreeSlots.Refill(freeSlots);
            }
            catch (Exception ex) { this.Handle.Error(ex); }
        }

        #endregion Methods
    }
}