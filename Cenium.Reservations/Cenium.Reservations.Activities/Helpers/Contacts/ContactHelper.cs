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
 * Prarthana.G 02/01/2022    Created
 */


using Cenium.Framework.Component;
using Cenium.Framework.Component.Interface;
using System;

namespace Cenium.Reservations.Activities.Helpers.Contacts
{
    /// <summary>
    /// Explain the purpose of the class here
    /// </summary>
	internal static class ContactHelper
    {
        private static IActivityFactory _contactsActivityFactory = ComponentManager.IsComponentInstalled("Contacts") ? ActivityManager.GetActivityFactory("Contacts") : null;
        private static IEntityFactory _contactsEntityFactory = ComponentManager.IsComponentInstalled("Contacts") ? EntityManager.GetEntityFactory("Contacts") : null;

        private static bool _isContactAvailable = ((_contactsEntityFactory == null) || (_contactsActivityFactory == null)) ?
            false : _contactsActivityFactory.IsActivityAvailable("Contact");

        public static ContactProxy GetContact(long contactId)
        {
            if (!_isContactAvailable)
                return null;

            var activity = _contactsActivityFactory.Create("Contact");
            if (!((activity == null) || (!activity.IsMethodAvailable("Get"))))
            {
                var result = activity.Get("Get", contactId);
                if (result != null)
                {
                    return new ContactProxy(result);
                }
            }

            return null;
        }


        //public static ContactProxy GetContact(long contactId)
        //{
        //    if (!_isContactAvailable)
        //        return null;

        //    var activity = _contactsActivityFactory.Create("Contact");
        //    var result = ((activity == null) || (!activity.IsMethodAvailable("Get"))) ? null : activity.Get("Get", contactId);
        //    return (result == null) ? null : new ContactProxy(result);
        //}

    }

}
