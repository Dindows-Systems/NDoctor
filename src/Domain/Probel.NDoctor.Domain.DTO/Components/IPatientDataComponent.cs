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
namespace Probel.NDoctor.Domain.DTO.Components
{
    using System.Collections.Generic;

    using Probel.NDoctor.Domain.DTO.Objects;

    public interface IPatientDataComponent : IBaseComponent
    {
        #region Methods

        /// <summary>
        /// Adds the specified doctor to the specified patient.
        /// </summary>
        /// <param name="patient">The patient.</param>
        /// <param name="doctor">The doctor.</param>
        void AddDoctorTo(LightPatientDto patient, LightDoctorDto doctor);

        /// <summary>
        /// Creates the specified profession.
        /// </summary>
        /// <param name="profession">The profession.</param>
        long Create(ProfessionDto profession);

        /// <summary>
        /// Create the specified item into the database.
        /// </summary>
        /// <param name="item">The item to add in the database</param>
        long Create(ReputationDto item);

        /// <summary>
        /// Create the specified item into the database.
        /// </summary>
        /// <param name="insurance">The insurance.</param>
        /// <returns></returns>
        long Create(InsuranceDto insurance);

        /// <summary>
        /// Create the specified item into the database
        /// </summary>
        /// <param name="reputation">The item to add in the database</param>
        long Create(PracticeDto practice);

        /// <summary>
        /// Create the specified item into the database
        /// </summary>
        /// <param name="reputation">The item to add in the database</param>
        long Create(DoctorDto doctor);

        /// <summary>
        /// Create the specified item into the database
        /// </summary>
        /// <param name="item">The item to add in the database</param>
        /// <returns>The id of the just created item</returns>
        long Create(TagDto item);

        /// <summary>
        /// Gets all insurances stored in the database. Return a light version of the insurance
        /// </summary>
        /// <returns>A list of light weight insurance</returns>
        IList<LightInsuranceDto> GetAllInsurancesLight();

        /// <summary>
        /// Gets all practices stored in the database.
        /// </summary>
        /// <returns></returns>
        IList<LightPracticeDto> GetAllPracticesLight();

        /// <summary>
        /// Gets all professions stored in the database.
        /// </summary>
        /// <returns></returns>
        IList<ProfessionDto> GetAllProfessions();

        /// <summary>
        /// Gets all reputations stored in the database.
        /// </summary>
        /// <returns></returns>
        IList<ReputationDto> GetAllReputations();

        /// <summary>
        /// Gets the doctors linked to the specified patient.
        /// </summary>
        /// <param name="patient">The patient.</param>
        /// <returns>A list of doctors</returns>
        IList<LightDoctorDto> GetDoctorOf(LightPatientDto patient);

        /// <summary>
        /// Gets the doctors linked to the specified patient.
        /// </summary>
        /// <param name="patient">The patient.</param>
        /// <returns>A list of doctors</returns>
        IList<DoctorDto> GetFullDoctorOf(LightPatientDto patient);

        /// <summary>
        /// Gets the insurance by id.
        /// </summary>
        /// <param name="p">The id.</param>
        /// <returns>The insurance</returns>
        InsuranceDto GetInsuranceById(long id);

        /// <summary>
        /// Gets the patient with the specified id.
        /// </summary>
        /// <param name="id">The p.</param>
        /// <returns>The patient</returns>
        LightPatientDto GetLightPatientById(long id);

        /// <summary>
        /// Gets the doctors that can be linked to the specified doctor.
        /// </summary>
        /// <param name="patient">The patient.</param>
        /// <param name="criteria">The criteria.</param>
        /// <param name="on">Indicate where the search should be executed.</param>
        /// <returns>
        /// A list of doctor
        /// </returns>
        IList<LightDoctorDto> GetNotLinkedDoctorsFor(LightPatientDto patient, string criteria, SearchOn on);

        /// <summary>
        /// Loads all the data of the patient.
        /// </summary>
        /// <param name="patient">The patient to load.</param>
        /// <returns>A DTO with the whole data</returns>
        /// <exception cref="Probel.NDoctor.Domain.DAL.Exceptions.ItemNotFoundException">If the patient doesn't exist</exception>
        PatientDto GetPatient(LightPatientDto patient);

        /// <summary>
        /// Loads all the data of the patient represented by the specified id.
        /// </summary>
        /// <param name="patient">The id of the patient to load.</param>
        /// <returns>A DTO with the whole data</returns>
        /// <exception cref="Probel.NDoctor.Domain.DAL.Exceptions.ItemNotFoundException">If the id is not linked to a patient</exception>
        PatientDto GetPatientById(long id);

        /// <summary>
        /// Gets the practice by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        PracticeDto GetPracticeById(long id);

        /// <summary>
        /// Gets all the tags with the specified catagory.
        /// </summary>
        /// <returns></returns>
        IList<TagDto> GetTags(TagCategory category);

        /// <summary>
        /// Gets the thumbnail of the specified patient.
        /// </summary>
        /// <param name="patientDto">The patient dto.</param>
        /// <returns></returns>
        byte[] GetThumbnail(PatientDto patientDto);

        /// <summary>
        /// Determines whether the specified patient has the specified doctor.
        /// </summary>
        /// <param name="patient">The patient.</param>
        /// <param name="doctor">The doctor.</param>
        /// <returns>
        ///   <c>true</c> if the specified patient has the doctor; otherwise, <c>false</c>.
        /// </returns>
        bool HasDoctor(LightPatientDto patient, LightDoctorDto doctor);

        /// <summary>
        /// Removes the link that existed between the specified patient and the specified doctor.
        /// </summary>
        /// <exception cref="EntityNotFoundException">If there's no link between the doctor and the patient</exception>
        /// <param name="patient">The patient.</param>
        /// <param name="doctor">The doctor.</param>
        void RemoveDoctorFor(LightPatientDto patient, LightDoctorDto doctor);

        /// <summary>
        /// Updates the patient with the new data.
        /// </summary>
        /// <param name="item">The patient.</param>
        void Update(PatientDto item);

        /// <summary>
        /// Updates the thumbnail of the specified patient.
        /// </summary>
        /// <param name="patientDto">The patient dto.</param>
        /// <param name="thumbnail">The byte array representing the thumbnail of the patient.</param>
        void UpdateThumbnail(LightPatientDto patientDto, byte[] thumbnail);

        #endregion Methods
    }
}