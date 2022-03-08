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
 * Prarthana.G 01/31/2022    Created
 */


using System;
using System.Linq;
using System.Collections.Generic;

using Cenium.Framework.Core.Attributes;
using Cenium.Framework.Logging;
using Cenium.Reservations.Data;
using Cenium.Framework.Security;
using Cenium.Reservations.Activities.Helpers.Contacts;
using Cenium.Reservations.Activities.Helpers.Rooms;

namespace Cenium.Reservations.Activities
{

    /// <summary>
    /// The ReservationActivity class is an activity class that exposes data operation methods to the service layer. This class is responsible for applying business logic prior to making
    /// updates in the data store.
    /// </summary>
    /// <seealso cref="Cenium.Reservations.Data.Reservation"/>
    /// <seealso cref="Cenium.Reservations.Data.ReservationsEntitiesContext"/>
    [Activity("Reservation")]
    public class ReservationActivity : IDisposable
    {

        private ReservationsEntitiesContext _ctx;
        private bool _disposeContext = true;

        /// <summary>
        /// Initializes a new instance of the ReservationActivity class
        /// </summary>
        public ReservationActivity()
        {
            _ctx = new ReservationsEntitiesContext();
        }

        /// <summary>
        /// Initializes a new instance of the ReservationActivity class, sharing the context with other activities
        /// </summary>
        /// <param name="ctx">The shared context</param>
        internal ReservationActivity(ReservationsEntitiesContext ctx)
        {
            _ctx = ctx;
            _disposeContext = false;
        }


        /// <summary>
        /// Activity query method that returns an IEnumerable&lt;Reservation&gt; instance. 
        /// </summary>
        /// <returns>A strongly type IEnumerable instance </returns>
        [ActivityMethod("Query", MethodType.Query, IsDefault = true)]
        [SecureResource("reservations.administration", SecureResourcePermissionLevel.Read)]
        public IEnumerable<Reservation> Query()
        {
            Logger.TraceMethodEnter();

            var result = _ctx.Reservations.ReadOnlyQuery().OrderBy(p => p.ReservationId);

            return Logger.TraceMethodExit(result) as IEnumerable<Reservation>;
        }


        /// <summary>
        /// Gets a Reservation instance from the datastore based on Reservation keys.
        /// </summary>
        /// <param name="reservationId">The key for Reservation</param>
        /// <returns>A Reservation instance, or null if there is no entities with the given key</returns>
        [ActivityMethod("Get", MethodType.Get, IsDefault = true)]
        [SecureResource("reservations.administration", SecureResourcePermissionLevel.Read)]
        public Reservation Get(long reservationId)
        {
            Logger.TraceMethodEnter(reservationId);

            var result = _ctx.Reservations.FindByKeys(reservationId);

            return Logger.TraceMethodExit(result) as Reservation;
        }

        /// <summary>
        /// Adds a new instance of Reservation to the data store
        /// </summary>
        /// <param name="reservation">The instance to add</param>
        /// <returns>The created instance</returns>
        [ActivityMethod("ReservationWithContactInfo", MethodType.Get, IsDefault = false)]
        [SecureResource("reservations.administration", SecureResourcePermissionLevel.Read)]
        public Reservation ReservationWithContactInfo(long reservationId)
        {
            Logger.TraceMethodEnter(reservationId);

            var currentReservation = _ctx.Reservations.ReadOnlyQuery().FirstOrDefault(o => o.ReservationId == reservationId);

            var contact = ContactHelper.GetContact(currentReservation.ContactId);

            currentReservation.ContactName = contact.Name;
            currentReservation.ContactDoB = contact.DoB;

            return Logger.TraceMethodExit(currentReservation) as Reservation;
        }


        /// <summary>
        /// Adds a new instance of Reservation to the data store
        /// </summary>
        /// <param name="reservation">The instance to add</param>
        /// <returns>The created instance</returns>
        [ActivityMethod("Create", MethodType.Create, IsDefault = true)]
        [SecureResource("reservations.administration", SecureResourcePermissionLevel.Write)]
        public Cenium.Reservations.Data.Reservation Create(Reservation reservation)
        {
            Logger.TraceMethodEnter(reservation);

            reservation = _ctx.Reservations.Add(reservation);
            _ctx.SaveChanges();

            return Logger.TraceMethodExit(GetFromDatastore(reservation.ReservationId)) as Reservation;
        }


        /// <summary>
        /// Updates a Reservation instance in the data store
        /// </summary>
        /// <param name="reservation">The instance to update</param>
        /// <returns>The updated instance</returns>
        [ActivityMethod("Update", MethodType.Update, IsDefault = true)]
        [SecureResource("reservations.administration", SecureResourcePermissionLevel.Write)]
        public Cenium.Reservations.Data.Reservation Update(Reservation reservation)
        {
            Logger.TraceMethodEnter(reservation);

            reservation = _ctx.Reservations.Modify(reservation);
            _ctx.SaveChanges();

            return Logger.TraceMethodExit(GetFromDatastore(reservation.ReservationId)) as Reservation;
        }


        /// <summary>
        /// Deletes a Reservation instance from the data store
        /// </summary>
        /// <param name="reservation">The instance to delete</param>
        [ActivityMethod("Delete", MethodType.Delete, IsDefault = true)]
        [SecureResource("reservations.administration", SecureResourcePermissionLevel.Write)]
        public void Delete(Reservation reservation)
        {
            Logger.TraceMethodEnter(reservation);

            _ctx.Reservations.Remove(reservation);
            _ctx.SaveChanges();

            Logger.TraceMethodExit();
        }

        /// <summary>
        /// Checks-in a Reservation instance from the data store
        /// </summary>
        /// <param name="reservation">The instance to check-in</param>
        [ActivityMethod("CheckIn", MethodType.Get, IsDefault = true)]
        [SecureResource("reservations.administration", SecureResourcePermissionLevel.Write)]
        public Reservation CheckIn(long reservationId)
        {
            Logger.TraceMethodEnter(reservationId);

            var currentReservation = _ctx.Reservations.Query().FirstOrDefault(o => o.ReservationId == reservationId); //where => return a list
            if(reservationId != null)

            {
                currentReservation.ReservationStatus = "Checked-In";
                _ctx.SaveChanges();


                RoomProxy room_proxy = new RoomProxy(RoomHelper.CreateRoomProxy());
                room_proxy.RoomId = (long)currentReservation.RoomId;
                room_proxy.RoomStatus = "Occupied";
            }
            
            return Logger.TraceMethodExit(currentReservation) as Reservation;
        }

        /// <summary>
        /// Checks-in a Reservation instance from the data store
        /// </summary>
        /// <param name="reservation">The instance to check-in</param>
        [ActivityMethod("CheckOut", MethodType.Get, IsDefault = true)]
        [SecureResource("reservations.administration", SecureResourcePermissionLevel.Write)]
        public Reservation CheckOut(long reservationId)
        {
            Logger.TraceMethodEnter(reservationId);

            var currentReservation = _ctx.Reservations.Query().FirstOrDefault(o => o.ReservationId == reservationId); //where => return a list
            if (reservationId != null)

            {
                currentReservation.ReservationStatus = "Checked-Out";
                _ctx.SaveChanges();


                RoomProxy room_proxy = new RoomProxy(RoomHelper.CreateRoomProxy());
                room_proxy.RoomId = (long)currentReservation.RoomId;
                room_proxy.RoomStatus = "Occupied";
            }

            return Logger.TraceMethodExit(currentReservation) as Reservation;
        }

        /// <summary>
        /// Retrieves a single entity instance from the data store
        /// </summary>
        /// <param name="reservationId">The key for Reservation</param>
        /// <returns>A single Reservation instance, or null if the instance doesn't exist</returns>
        protected Reservation GetFromDatastore(long reservationId)
        {
            return _ctx.Reservations.ReadOnlyQuery().Where(p => p.ReservationId == reservationId).FirstOrDefault();
        }

        /// <summary>
        /// Releases all resources used by this ReservationActivity instance.
        /// </summary>
        public void Dispose()
        {
            if ((_ctx != null) && (_disposeContext))
                _ctx.Dispose();
            _ctx = null;
        }



    }

}
