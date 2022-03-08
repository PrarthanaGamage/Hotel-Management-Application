/*
 * Copyright (c) Cenium AS. All Right Reserved
 *
 * This source is subject to the Cenium License.
 * Please see the License.txt file for more information.
 * All other rights reserved.
 * 
 * http://www.cenium.com
 * 
 * Change History:
 * 
 * User        Date          Comment
 * ----------- ------------- --------------------------------------------------------------------------------------------
 * Prarthana.G 03/01/2022    Created
 */


using Cenium.Contacts.Data;
using Cenium.Framework.Activities;
using System;
using System.Linq;

namespace Cenium.Contacts.Activities.ResourceHelpers
{
    /// <summary>
    /// Explain the purpose of the class here
    /// </summary>
	[ActivityResultExtension("Reservations/Reservation/Get/{ReservationId}", "ReservationContactExt")]
    [ActivityResultExtension("Reservations/Reservation/Delete", "ReservationContactExt")]
    [ActivityResultExtension("Reservations/Reservation/Update", "ReservationContactExt")]
    [ActivityResultExtension("Reservations/Reservation/Create", "ReservationContactExt")]
    public class ReservationResultHandlerFactory : AbstractActivityResultHandlerFactory
    {

        /// <summary>
        /// Initializes a new instance of the ItemResultHandlerFactory class
        /// </summary>
        public ReservationResultHandlerFactory() : base(typeof(ReservationContact), "Reservations.Reservation", "ReservationContactExt") { }

        protected override IActivityResultExtensionHandler CreateHandler() => new ItemResultHandler();

        private class ItemResultHandler : ResultHandlerBase, IActivityResultExtensionHandler
        {
            public object Get(string parentEntity, object parentKey)
            {
                var id = GetKey(parentKey);
                var ReservationContact = Context.ReservationContacts.ReadOnlyQuery().FirstOrDefault(i => i.ReservationContactId == id);

                return (ReservationContact != null) ? ReservationContact : new ReservationContact { ReservationId = id, NickName = string.Empty };
            }

            public void CreateOrUpdate(string parentEntity, object parentKey, object entity)
            {
                var id = GetKey(parentKey);
                var reservationContact = entity as ReservationContact;

                if (id == 0L || reservationContact == null)
                    return;

                // Make sure to clear department, if serving group cleared
                //if (!item.ServingGroupId.HasValue)
                //    item.ServingDepartmentId = null;

                if (reservationContact.ReservationContactId == 0L)
                {
                    reservationContact.ReservationId = id;
                    reservationContact.NickName = string.Empty;
                    Context.ReservationContacts.Add(reservationContact);
                }
                else
                {
                    // Remove indication flags, if manually updated
                    var existingReservationContact = Context.ReservationContacts.ReadOnlyQuery().FirstOrDefault(i => i.ReservationContactId == reservationContact.ReservationContactId);
                    if (existingReservationContact?.ReservationContactId != reservationContact.ReservationContactId)
                    {
                        reservationContact.NickName = string.Empty;
                    }

                    Context.ReservationContacts.Modify(reservationContact);
                }

                Context.SaveChanges();
            }

            public void Delete(string parentEntity, object parentKey, object entity)
            {
            }
        }
    }

}
