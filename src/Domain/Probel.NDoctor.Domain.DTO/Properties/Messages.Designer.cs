﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.296
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Probel.NDoctor.Domain.DTO.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Messages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Messages() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Probel.NDoctor.Domain.DTO.Properties.Messages", typeof(Messages).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The ID type is &apos;{0}&apos; while expecting &apos;{1}&apos;.
        /// </summary>
        internal static string DalSessionException_UnknownId1 {
            get {
                return ResourceManager.GetString("DalSessionException_UnknownId1", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The start time should be smaller than the end time.
        /// </summary>
        internal static string Error_BeginBiggerThanEnd {
            get {
                return ResourceManager.GetString("Error_BeginBiggerThanEnd", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The value of hours has to be between 0 and 23.
        /// </summary>
        internal static string Error_NotSupportedDate_Hour {
            get {
                return ResourceManager.GetString("Error_NotSupportedDate_Hour", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The value of minutes has to be between 0 and 59.
        /// </summary>
        internal static string Error_NotSupportedDate_Minutes {
            get {
                return ResourceManager.GetString("Error_NotSupportedDate_Minutes", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The program seems to be in an infinite loop.
        /// </summary>
        internal static string Error_TooManyLoops {
            get {
                return ResourceManager.GetString("Error_TooManyLoops", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Impossible to convert &quot;{0}&quot; into time.
        /// </summary>
        internal static string Error_WrongTextForDate {
            get {
                return ResourceManager.GetString("Error_WrongTextForDate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to You are not granted to execute this action.
        /// </summary>
        internal static string Ex_AuthorisationException {
            get {
                return ResourceManager.GetString("Ex_AuthorisationException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Impossible to execute this action. This is a unexpected state that wasn&apos;t forseen or it will break business logic rules..
        /// </summary>
        internal static string Ex_BusinessLogicException {
            get {
                return ResourceManager.GetString("Ex_BusinessLogicException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The session you&apos;re using to query the database is closed..
        /// </summary>
        internal static string Ex_ClosedSessionException {
            get {
                return ResourceManager.GetString("Ex_ClosedSessionException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to An error occured in the DAL components. See inner exception for details..
        /// </summary>
        internal static string Ex_ComponentException {
            get {
                return ResourceManager.GetString("Ex_ComponentException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to You already configured the DAL.
        /// </summary>
        internal static string Ex_ConfigurationException {
            get {
                return ResourceManager.GetString("Ex_ConfigurationException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to An error occured during the configuration of the database.
        /// </summary>
        internal static string Ex_DalConfigurationException {
            get {
                return ResourceManager.GetString("Ex_DalConfigurationException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The ID type is &apos;{0}&apos; while expecting &apos;{1}&apos;.
        /// </summary>
        internal static string Ex_DalSessionException_UnknownId {
            get {
                return ResourceManager.GetString("Ex_DalSessionException_UnknownId", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Empty password are not accepted.
        /// </summary>
        internal static string Ex_EmptyPasswordException {
            get {
                return ResourceManager.GetString("Ex_EmptyPasswordException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to An error occured while decrypting the specified text.
        /// </summary>
        internal static string Ex_EncryptionException {
            get {
                return ResourceManager.GetString("Ex_EncryptionException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This entity already exist in the database.
        /// </summary>
        internal static string Ex_EntityAlreadyExistsException {
            get {
                return ResourceManager.GetString("Ex_EntityAlreadyExistsException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The searched item of type &apos;{0}&apos; doesn&apos;t exist in the database.
        /// </summary>
        internal static string Ex_EntityNotFoundException {
            get {
                return ResourceManager.GetString("Ex_EntityNotFoundException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No patient with id &apos;{0}&apos; was found..
        /// </summary>
        internal static string Ex_EntityNotFoundException_NoPatient {
            get {
                return ResourceManager.GetString("Ex_EntityNotFoundException_NoPatient", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The patient of right side of the relation doesn&apos;t exist in the database.
        /// </summary>
        internal static string Ex_EntityNotFoundException_NoRelationRightSide {
            get {
                return ResourceManager.GetString("Ex_EntityNotFoundException_NoRelationRightSide", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The item you want to create already exist in the database..
        /// </summary>
        internal static string Ex_ExistingItemException {
            get {
                return ResourceManager.GetString("Ex_ExistingItemException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to An error occured when communicating with Google Calendar.
        /// </summary>
        internal static string Ex_GoogleCalendarException {
            get {
                return ResourceManager.GetString("Ex_GoogleCalendarException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Google Calendar reports this error: {0}.
        /// </summary>
        internal static string Ex_GoogleCalendarExceptionFormat {
            get {
                return ResourceManager.GetString("Ex_GoogleCalendarExceptionFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The picture already has a thumbnail.
        /// </summary>
        internal static string Ex_HasThumbnail {
            get {
                return ResourceManager.GetString("Ex_HasThumbnail", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The entity you are using is detached  from the database..
        /// </summary>
        internal static string Ex_NotLoadedEntityException {
            get {
                return ResourceManager.GetString("Ex_NotLoadedEntityException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A list of the object to save has at least one null element.
        /// </summary>
        internal static string Ex_NullItemInListException {
            get {
                return ResourceManager.GetString("Ex_NullItemInListException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The nHibernate session factory is not configured..
        /// </summary>
        internal static string Ex_NullSessionFactoryException {
            get {
                return ResourceManager.GetString("Ex_NullSessionFactoryException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to An error occured during the execution of a query..
        /// </summary>
        internal static string Ex_QueryException {
            get {
                return ResourceManager.GetString("Ex_QueryException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to More than one default user was found..
        /// </summary>
        internal static string Ex_QueryException_SeveralDefaultUsers {
            get {
                return ResourceManager.GetString("Ex_QueryException_SeveralDefaultUsers", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This action wasn&apos;t executed to keep the integrity of the data..
        /// </summary>
        internal static string Ex_ReferencialIntegrityException {
            get {
                return ResourceManager.GetString("Ex_ReferencialIntegrityException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to An error occured in the session.
        /// </summary>
        internal static string Ex_SessionException {
            get {
                return ResourceManager.GetString("Ex_SessionException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The session is not open. Please open it before query the database..
        /// </summary>
        internal static string Ex_SessionNotOpenedException {
            get {
                return ResourceManager.GetString("Ex_SessionNotOpenedException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to An error occured during the validation of the DTO object..
        /// </summary>
        internal static string Ex_ValidationException {
            get {
                return ResourceManager.GetString("Ex_ValidationException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Female.
        /// </summary>
        internal static string Gender_Female {
            get {
                return ResourceManager.GetString("Gender_Female", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Male.
        /// </summary>
        internal static string Gender_Male {
            get {
                return ResourceManager.GetString("Gender_Male", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to You entered invalid data.
        /// </summary>
        internal static string Invalid_Data {
            get {
                return ResourceManager.GetString("Invalid_Data", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The date should be after 1/1/1900.
        /// </summary>
        internal static string Invalid_Date {
            get {
                return ResourceManager.GetString("Invalid_Date", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This document doesn&apos;t have prescription.
        /// </summary>
        internal static string Invalid_EmptyPrescription {
            get {
                return ResourceManager.GetString("Invalid_EmptyPrescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The tag of this item can&apos;t be null.
        /// </summary>
        internal static string Invalid_EmptyTag {
            get {
                return ResourceManager.GetString("Invalid_EmptyTag", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Can&apos;t be empty..
        /// </summary>
        internal static string Invalid_EmptyValue {
            get {
                return ResourceManager.GetString("Invalid_EmptyValue", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid family relation.
        /// </summary>
        internal static string Invalid_Family {
            get {
                return ResourceManager.GetString("Invalid_Family", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to La taille doit être comprise entre 10 et 300 cm.
        /// </summary>
        internal static string Invalid_Height {
            get {
                return ResourceManager.GetString("Invalid_Height", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This illness history is not related to any patient.
        /// </summary>
        internal static string Invalid_IllnessHistory {
            get {
                return ResourceManager.GetString("Invalid_IllnessHistory", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cette prescription ne contient aucun médicament.
        /// </summary>
        internal static string Invalid_Prescription_NoDrug {
            get {
                return ResourceManager.GetString("Invalid_Prescription_NoDrug", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A relation should contain two persons.
        /// </summary>
        internal static string Invalid_Relation {
            get {
                return ResourceManager.GetString("Invalid_Relation", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The start date should be before the end date.
        /// </summary>
        internal static string Invalid_TimeSpan {
            get {
                return ResourceManager.GetString("Invalid_TimeSpan", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Le poids doit être compris entre 1 et 500 Kg.
        /// </summary>
        internal static string Invalid_Weight {
            get {
                return ResourceManager.GetString("Invalid_Weight", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Childrens.
        /// </summary>
        internal static string Msg_Children {
            get {
                return ResourceManager.GetString("Msg_Children", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Father.
        /// </summary>
        internal static string Msg_Father {
            get {
                return ResourceManager.GetString("Msg_Father", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Mother.
        /// </summary>
        internal static string Msg_Mother {
            get {
                return ResourceManager.GetString("Msg_Mother", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Brothers and sisters.
        /// </summary>
        internal static string Msg_Sibling {
            get {
                return ResourceManager.GetString("Msg_Sibling", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Search on first name AND last name.
        /// </summary>
        internal static string SearchOn_Both {
            get {
                return ResourceManager.GetString("SearchOn_Both", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Search on first name.
        /// </summary>
        internal static string SearchOn_FirstName {
            get {
                return ResourceManager.GetString("SearchOn_FirstName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Search on last name.
        /// </summary>
        internal static string SearchOn_LastName {
            get {
                return ResourceManager.GetString("SearchOn_LastName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Appointment.
        /// </summary>
        internal static string TagType_Appointment {
            get {
                return ResourceManager.GetString("TagType_Appointment", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Child.
        /// </summary>
        internal static string TagType_Child {
            get {
                return ResourceManager.GetString("TagType_Child", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Doctor.
        /// </summary>
        internal static string TagType_Doctor {
            get {
                return ResourceManager.GetString("TagType_Doctor", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Drug.
        /// </summary>
        internal static string TagType_Drug {
            get {
                return ResourceManager.GetString("TagType_Drug", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Medical record.
        /// </summary>
        internal static string TagType_MedicalRecord {
            get {
                return ResourceManager.GetString("TagType_MedicalRecord", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Parent.
        /// </summary>
        internal static string TagType_Parent {
            get {
                return ResourceManager.GetString("TagType_Parent", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Pathology.
        /// </summary>
        internal static string TagType_Pathology {
            get {
                return ResourceManager.GetString("TagType_Pathology", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Patient.
        /// </summary>
        internal static string TagType_Patient {
            get {
                return ResourceManager.GetString("TagType_Patient", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Picture.
        /// </summary>
        internal static string TagType_Picture {
            get {
                return ResourceManager.GetString("TagType_Picture", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Prescription.
        /// </summary>
        internal static string TagType_Prescription {
            get {
                return ResourceManager.GetString("TagType_Prescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Prescription document.
        /// </summary>
        internal static string TagType_PrescriptionDocument {
            get {
                return ResourceManager.GetString("TagType_PrescriptionDocument", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} from {1} to {2} {3}.
        /// </summary>
        internal static string Title_FromTo {
            get {
                return ResourceManager.GetString("Title_FromTo", resourceCulture);
            }
        }
    }
}
