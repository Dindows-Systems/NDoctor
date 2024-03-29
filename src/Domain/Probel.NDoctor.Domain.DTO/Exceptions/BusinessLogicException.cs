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
namespace Probel.NDoctor.Domain.DTO.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    using Probel.NDoctor.Domain.DTO.Properties;

    /// <summary>
    /// The exception that is thrown when an operation try to execute an action that is an
    /// business logic error. That's this exception prevents unauthorised or unexcpected
    /// actions.
    /// </summary>
    [Serializable]
    public class BusinessLogicException : TranslateableException
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessLogicException"/> class.
        /// </summary>
        public BusinessLogicException()
            : this("Impossible to execute this action. This is a unexpected state that wasn't forseen or it will break business logic rules.", Messages.Ex_BusinessLogicException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessLogicException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public BusinessLogicException(string message, string translated)
            : base(message, translated)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessLogicException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="inner">The inner.</param>
        public BusinessLogicException(string message, string translated, Exception inner)
            : base(message, translated, inner)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessLogicException"/> class.
        /// </summary>
        /// <param name="info">The info.</param>
        /// <param name="context">The context.</param>
        protected BusinessLogicException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        #endregion Constructors
    }
}