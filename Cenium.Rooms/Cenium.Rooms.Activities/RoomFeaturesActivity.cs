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
using Cenium.Rooms.Data;
using Cenium.Framework.Security;

namespace Cenium.Rooms.Activities
{

    /// <summary>
    /// The RoomFeaturesActivity class is an activity class that exposes data operation methods to the service layer. This class is responsible for applying business logic prior to making
    /// updates in the data store.
    /// </summary>
    /// <seealso cref="Cenium.Rooms.Data.RoomFeature"/>
    /// <seealso cref="Cenium.Rooms.Data.RoomsEntitiesContext"/>
    [Activity("RoomFeature")]
    public class RoomFeaturesActivity : IDisposable
    {

        private RoomsEntitiesContext _ctx;
        private bool _disposeContext = true;

        /// <summary>
        /// Initializes a new instance of the RoomFeaturesActivity class
        /// </summary>
        public RoomFeaturesActivity()
        {
            _ctx = new RoomsEntitiesContext();
        }

        /// <summary>
        /// Initializes a new instance of the RoomFeaturesActivity class, sharing the context with other activities
        /// </summary>
        /// <param name="ctx">The shared context</param>
        internal RoomFeaturesActivity(RoomsEntitiesContext ctx)
        {
            _ctx = ctx;
            _disposeContext = false;
        }


        /// <summary>
        /// Activity query method that returns an IEnumerable&lt;RoomFeature&gt; instance. 
        /// </summary>
        /// <returns>A strongly type IEnumerable instance </returns>
        [ActivityMethod("Query", MethodType.Query, IsDefault = true)]
        [SecureResource("rooms.administration", SecureResourcePermissionLevel.Read)]
        public IEnumerable<RoomFeature> Query()
        {
            Logger.TraceMethodEnter();

            var result = _ctx.RoomFeatures.ReadOnlyQuery().OrderBy(p => p.RoomFeatureId);

            return Logger.TraceMethodExit(result) as IEnumerable<RoomFeature>;
        }


        /// <summary>
        /// Gets a RoomFeature instance from the datastore based on RoomFeature keys.
        /// </summary>
        /// <param name="roomFeatureId">The key for RoomFeature</param>
        /// <returns>A RoomFeature instance, or null if there is no entities with the given key</returns>
        [ActivityMethod("Get", MethodType.Get, IsDefault = true)]
        [SecureResource("rooms.administration", SecureResourcePermissionLevel.Read)]
        public RoomFeature Get(long roomFeatureId)
        {
            Logger.TraceMethodEnter(roomFeatureId);

            var result = _ctx.RoomFeatures.FindByKeys(roomFeatureId);

            return Logger.TraceMethodExit(result) as RoomFeature;
        }


        /// <summary>
        /// Adds a new instance of RoomFeature to the data store
        /// </summary>
        /// <param name="roomFeature">The instance to add</param>
        /// <returns>The created instance</returns>
        [ActivityMethod("Create", MethodType.Create, IsDefault = true)]
        [SecureResource("rooms.administration", SecureResourcePermissionLevel.Write)]
        public Cenium.Rooms.Data.RoomFeature Create(RoomFeature roomFeature)
        {
            Logger.TraceMethodEnter(roomFeature);

            roomFeature = _ctx.RoomFeatures.Add(roomFeature);
            _ctx.SaveChanges();

            return Logger.TraceMethodExit(GetFromDatastore(roomFeature.RoomFeatureId)) as RoomFeature;
        }


        /// <summary>
        /// Updates a RoomFeature instance in the data store
        /// </summary>
        /// <param name="roomFeature">The instance to update</param>
        /// <returns>The updated instance</returns>
        [ActivityMethod("Update", MethodType.Update, IsDefault = true)]
        [SecureResource("rooms.administration", SecureResourcePermissionLevel.Write)]
        public Cenium.Rooms.Data.RoomFeature Update(RoomFeature roomFeature)
        {
            Logger.TraceMethodEnter(roomFeature);

            roomFeature = _ctx.RoomFeatures.Modify(roomFeature);
            _ctx.SaveChanges();

            return Logger.TraceMethodExit(GetFromDatastore(roomFeature.RoomFeatureId)) as RoomFeature;
        }


        /// <summary>
        /// Deletes a RoomFeature instance from the data store
        /// </summary>
        /// <param name="roomFeature">The instance to delete</param>
        [ActivityMethod("Delete", MethodType.Delete, IsDefault = true)]
        [SecureResource("rooms.administration", SecureResourcePermissionLevel.Write)]
        public void Delete(RoomFeature roomFeature)
        {
            Logger.TraceMethodEnter(roomFeature);

            _ctx.RoomFeatures.Remove(roomFeature);
            _ctx.SaveChanges();

            Logger.TraceMethodExit();
        }


        /// <summary>
        /// Retrieves a single entity instance from the data store
        /// </summary>
        /// <param name="roomFeatureId">The key for RoomFeature</param>
        /// <returns>A single RoomFeature instance, or null if the instance doesn't exist</returns>
        protected RoomFeature GetFromDatastore(long roomFeatureId)
        {
            return _ctx.RoomFeatures.ReadOnlyQuery().Where(p => p.RoomFeatureId == roomFeatureId).FirstOrDefault();
        }

        /// <summary>
        /// Releases all resources used by this RoomFeaturesActivity instance.
        /// </summary>
        public void Dispose()
        {
            if ((_ctx != null) && (_disposeContext))
                _ctx.Dispose();
            _ctx = null;
        }



    }

}
