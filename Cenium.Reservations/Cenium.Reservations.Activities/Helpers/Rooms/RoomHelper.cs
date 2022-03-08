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
 * Prarthana.G 02/02/2022    Created
 */


using Cenium.Framework.Component;
using Cenium.Framework.Component.Interface;
using System;

namespace Cenium.Reservations.Activities.Helpers.Rooms
{
    /// <summary>
    /// Explain the purpose of the class here
    /// </summary>
	internal static class RoomHelper
    {
        private static IActivityFactory _roomsActivityFactory = ComponentManager.IsComponentInstalled("Rooms") ? ActivityManager.GetActivityFactory("Rooms") : null;
        private static IEntityFactory _roomsEntityFactory = ComponentManager.IsComponentInstalled("Rooms") ? EntityManager.GetEntityFactory("Rooms") : null;

        private static bool _isRoomAvailable = ((_roomsEntityFactory == null) || (_roomsActivityFactory == null)) ?
            false : _roomsActivityFactory.IsActivityAvailable("Room");

        public static void UpdateRoomInfo(RoomProxy roomProxy, long roomId)
        {
            if (!_isRoomAvailable)
                return;

            var activity = _roomsActivityFactory.Create("Room");
            if (!((activity == null) || (!activity.IsMethodAvailable("UpdateRoomInfo"))))
            {
                activity.Update("UpdateRoomInfo", roomProxy.EntityProxy);
            }
        }

        public static IEntityProxy CreateRoomProxy()
        {
            return _isRoomAvailable ? _roomsEntityFactory.Create("Room") : null;
        }
    }
}
