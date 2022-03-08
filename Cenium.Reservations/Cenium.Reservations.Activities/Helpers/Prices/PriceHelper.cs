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
 * Prarthana.G 03/03/2022    Created
 */


using Cenium.Framework.Component;
using Cenium.Framework.Component.Interface;
using System;

namespace Cenium.Reservations.Activities.Helpers.Prices
{
    /// <summary>
    /// Explain the purpose of the class here
    /// </summary>
	internal static class PriceHelper
    {

        /// <summary>
        /// Initializes a new instance of the PriceHelper class
        /// </summary>
        private static IActivityFactory _pricesActivityFactory = ComponentManager.IsComponentInstalled("Prices") ? ActivityManager.GetActivityFactory("Prices") : null;
        private static IEntityFactory _pricesEntityFactory = ComponentManager.IsComponentInstalled("Prices") ? EntityManager.GetEntityFactory("Prices") : null;

        private static bool _isPriceAvailable = ((_pricesEntityFactory == null) || (_pricesActivityFactory == null)) ?
            false : _pricesActivityFactory.IsActivityAvailable("Price");

        public static PriceProxy GetPrice(long priceId)
        {
            if (!_isPriceAvailable)
                return null;

            var activity = _pricesActivityFactory.Create("Price");
            if (!((activity == null) || (!activity.IsMethodAvailable("Get"))))
            {
                var result = activity.Get("Get", priceId);
                if (result != null)
                {
                    return new PriceProxy(result);
                }
            }

            return null;
        }


    }

}
