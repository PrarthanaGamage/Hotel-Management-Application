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


using Cenium.Framework.Component.Interface;
using System;

namespace Cenium.Reservations.Activities.Helpers.Prices
{
    /// <summary>
    /// Explain the purpose of the class here
    /// </summary>
	internal class PriceProxy : ProxyWrapperBase
    {
        public PriceProxy(IEntityProxy proxy) : base(proxy) { }

        public long PriceId
        {
            get { return GetValue<long>("PriceId"); }
        }

        public string Name
        {
            get { return GetValue<string>("Amount"); }
            set { SetValue("Amount", value); }
        }
        
    }

}
