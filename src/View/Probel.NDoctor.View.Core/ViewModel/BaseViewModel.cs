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
namespace Probel.NDoctor.View.Core.ViewModel
{
    using System;
    using System.Threading.Tasks;
    using System.Windows.Threading;

    using log4net;

    using Probel.Helpers.Strings;
    using Probel.Helpers.WPF;
    using Probel.Mvvm.DataBinding;
    using Probel.NDoctor.View;
    using Probel.NDoctor.View.Core.Properties;
    using Probel.NDoctor.View.Plugins;
    using Probel.NDoctor.View.Plugins.Exceptions;
    using Probel.NDoctor.View.Toolbox;
    using Probel.NDoctor.View.Toolbox.Navigation;

    public abstract class BaseViewModel : RequestCloseViewModel
    {
        #region Fields

        protected readonly IErrorHandler Handle;
        protected readonly ILog Logger;

        #endregion Fields

        #region Constructors

        protected BaseViewModel()
        {
            this.Logger = LogManager.GetLogger(this.GetType());
            this.Handle = new ErrorHandlerFactory().New(this);

            if (!Designer.IsDesignMode)
            {
                if (PluginContext.Host == null) throw new NDoctorConfigurationException(Messages.Ex_NDoctorConfigurationException_HostNull);
                PluginContext.Host = PluginContext.Host;
            }
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Sets the status of the host to ready.
        /// </summary>
        public void SetStatusToReady()
        {
            if (PluginContext.Host != null) PluginContext.Host.WriteStatus(StatusType.Info, Messages.Msg_Ready);
        }

        /// <summary>
        /// Executes the specified action if the specified task is not in faulted state. Otherwise, it rethrow the exception.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="e">The e.</param>
        /// <param name="action">The action.</param>
        protected void ExecuteIfTaskIsNotFaulted(Task e, Action action)
        {
            if (!e.IsFaulted) { action(); }
            else
            {
                Dispatcher.CurrentDispatcher.BeginInvoke(new Action(() =>
                {
                    this.Logger.ErrorFormat("Thread '{0}' is in faulted state. Further information follows.", e.Id);
                    this.Handle.Fatal(e.Exception);
                }));
            }
        }

        private void IndicateError()
        {
            this.IndicateError(string.Empty);
        }

        private void IndicateError(string msg)
        {
            if (PluginContext.Host == null) return;

            PluginContext.Host.WriteStatus(StatusType.Error, Messages.Msg_ErrorOccured.FormatWith(msg));
        }

        private void IndicateWarning()
        {
            this.IndicateError(string.Empty);
        }

        private void IndicateWarning(string msg)
        {
            if (PluginContext.Host == null) return;

            PluginContext.Host.WriteStatus(StatusType.Error, Messages.Msg_WarningOccured.FormatWith(msg));
        }

        #endregion Methods
    }
}