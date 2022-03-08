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
 * Prarthana.G 01/27/2022    Created
 */


using System;
using System.Linq;
using System.Collections.Generic;

using Cenium.Framework.Core.Attributes;
using Cenium.Framework.Logging;
using Cenium.Rooms.Data;
using Cenium.Framework.Security;

namespace Cenium.Rooms.Activities
{

    /// <summary>
    /// The RoomActivity class is an activity class that exposes data operation methods to the service layer. This class is responsible for applying business logic prior to making
    /// updates in the data store.
    /// </summary>
    /// <seealso cref="Cenium.Rooms.Data.Room"/>
    /// <seealso cref="Cenium.Rooms.Data.RoomsEntitiesContext"/>
    [Activity("Room")]
    public class RoomActivity : IDisposable
    {

        private RoomsEntitiesContext _ctx;
        private bool _disposeContext = true;

        /// <summary>
        /// Initializes a new instance of the RoomActivity class
        /// </summary>
        public RoomActivity()
        {
            _ctx = new RoomsEntitiesContext();
        }

        /// <summary>
        /// Initializes a new instance of the RoomActivity class, sharing the context with other activities
        /// </summary>
        /// <param name="ctx">The shared context</param>
        internal RoomActivity(RoomsEntitiesContext ctx)
        {
            _ctx = ctx;
            _disposeContext = false;
        }


        /// <summary>
        /// Activity query method that returns an IEnumerable&lt;Room&gt; instance. 
        /// </summary>
        /// <returns>A strongly type IEnumerable instance </returns>
        [ActivityMethod("Query", MethodType.Query, IsDefault = true)]
        [ActivityResult("RoomFeatures")]
        [ActivityResult("RoomFeatures.Feature")]
        [ActivityResult("RoomTypes")]
        [SecureResource("rooms.administration", SecureResourcePermissionLevel.Read)]
        public IEnumerable<Room> Query()
        {
            Logger.TraceMethodEnter();

            var result = _ctx.Rooms.ReadOnlyQuery().OrderBy(p => p.RoomId);

            return Logger.TraceMethodExit(result) as IEnumerable<Room>;
        }


        /// <summary>
        /// Gets a Room instance from the datastore based on Room keys.
        /// </summary>
        /// <param name="roomId">The key for Room</param>
        /// <returns>A Room instance, or null if there is no entities with the given key</returns>
        [ActivityMethod("Get", MethodType.Get, IsDefault = true)]
        [ActivityResult("RoomFeatures")]
        [ActivityResult("RoomFeatures.Feature")]
        [ActivityResult("RoomTypes")]
        [SecureResource("rooms.administration", SecureResourcePermissionLevel.Read)]
        public Room Get(long roomId)
        {
            Logger.TraceMethodEnter(roomId);

            var result = _ctx.Rooms.FindByKeys(roomId);

            return Logger.TraceMethodExit(result) as Room;
        }


        /// <summary>
        /// Adds a new instance of Room to the data store
        /// </summary>
        /// <param name="room">The instance to add</param>
        /// <returns>The created instance</returns>
        [ActivityMethod("Create", MethodType.Create, IsDefault = true)]
        [ActivityResult("RoomFeatures")]
        [ActivityResult("RoomFeatures.Feature")]
        [ActivityResult("RoomTypes")]
        [SecureResource("rooms.administration", SecureResourcePermissionLevel.Write)]
        public Cenium.Rooms.Data.Room Create(Room room)
        {
            Logger.TraceMethodEnter(room);

            //room = _ctx.Rooms.Add(room);
            //_ctx.SaveChanges();

            
            _ctx.Rooms.AttachChildCollection<RoomFeature>(room, "RoomFeatures");
            room = _ctx.Rooms.Add(room);
            _ctx.Rooms.SynchronizeChildCollection<RoomFeature>(room, "RoomFeatures");
            _ctx.SaveChanges();  //persist to database

            return Logger.TraceMethodExit(GetFromDatastore(room.RoomId)) as Room;
        }


        /// <summary>
        /// Updates a Room instance in the data store
        /// </summary>
        /// <param name="room">The instance to update</param>
        /// <returns>The updated instance</returns>
        [ActivityMethod("Update", MethodType.Update, IsDefault = true)]
        [ActivityResult("RoomFeatures")]
        [ActivityResult("RoomFeatures.Feature")]
        [ActivityResult("RoomTypes")]
        [SecureResource("rooms.administration", SecureResourcePermissionLevel.Write)]
        public Cenium.Rooms.Data.Room Update(Room room)
        {
            Logger.TraceMethodEnter(room);

            //room = _ctx.Rooms.Modify(room);
            //_ctx.SaveChanges();

            _ctx.Rooms.AttachChildCollection<RoomFeature>(room, "RoomFeatures");
            room = _ctx.Rooms.Modify(room);
            _ctx.Rooms.SynchronizeChildCollection<RoomFeature>(room, "RoomFeatures");
            _ctx.SaveChanges();  //persist to database

            return Logger.TraceMethodExit(GetFromDatastore(room.RoomId)) as Room;
        }


        /// <summary>
        /// Deletes a Room instance from the data store
        /// </summary>
        /// <param name="room">The instance to delete</param>
        [ActivityMethod("Delete", MethodType.Delete, IsDefault = true)]
        [SecureResource("rooms.administration", SecureResourcePermissionLevel.Write)]
        public void Delete(Room room)
        {
            Logger.TraceMethodEnter(room);

            _ctx.Rooms.Remove(room);
            _ctx.SaveChanges();

            Logger.TraceMethodExit();
        }

        /// <summary>
        /// Occupies a Room instance from the data store
        /// </summary>
        /// <param name="room">The instance to check-in</param>
        [ActivityMethod("UpdateRoomInfo", MethodType.Update, IsDefault = true)]
        [SecureResource("rooms.administration", SecureResourcePermissionLevel.Write)]
        public Room UpdateRoomInfo(Room room)
        {
            Logger.TraceMethodEnter(room);

            var roomStatus = room.RoomStatus;

            var currentRoom = _ctx.Rooms.Query().FirstOrDefault(o => o.RoomId == room.RoomId); //where => return a list
            if (room != null)

            {
                currentRoom.RoomStatus = roomStatus;
                currentRoom = _ctx.Rooms.Modify(currentRoom);
                _ctx.SaveChanges();
            }

            return Logger.TraceMethodExit(GetFromDatastore(room.RoomId)) as Room;
        }


        /// <summary>
        /// Retrieves a single entity instance from the data store
        /// </summary>
        /// <param name="roomId">The key for Room</param>
        /// <returns>A single Room instance, or null if the instance doesn't exist</returns>
        protected Room GetFromDatastore(long roomId)
        {
            return _ctx.Rooms.ReadOnlyQuery().Where(p => p.RoomId == roomId).FirstOrDefault();
        }

        /// <summary>
        /// Releases all resources used by this RoomActivity instance.
        /// </summary>
        public void Dispose()
        {
            if ((_ctx != null) && (_disposeContext))
                _ctx.Dispose();
            _ctx = null;
        }



    }

}
