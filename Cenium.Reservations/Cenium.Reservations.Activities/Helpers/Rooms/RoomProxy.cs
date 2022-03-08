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


using Cenium.Framework.Component.Interface;
using System;

namespace Cenium.Reservations.Activities.Helpers.Rooms
{
    /// <summary>
    /// Explain the purpose of the class here
    /// </summary>
	internal class RoomProxy : ProxyWrapperBase
    {
        public RoomProxy(IEntityProxy proxy) : base(proxy) { }

        public RoomProxy()
        {
            base.EntityProxy = RoomHelper.CreateRoomProxy();
        }

        public long RoomId
        {
            get { return GetValue<long>("RoomId"); }
            set { SetValue("RoomId", value); }
        }

        public string RoomStatus
        {
            get { return GetValue<string>("RoomStatus"); }
            set { SetValue("RoomStatus", value); }
        }

        public DateTime ReservedFrom
        {
            get { return GetValue<DateTime>("ReservedFrom"); }
            set { SetValue("ReservedFrom", value); }
        }

        public DateTime ReservedTill
        {
            get { return GetValue<DateTime>("ReservedTill"); }
            set { SetValue("ReservedTill", value); }
        }

    }

}
