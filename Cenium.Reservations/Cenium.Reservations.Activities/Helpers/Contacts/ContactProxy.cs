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

using Cenium.Framework.Component.Interface;
using System;

namespace Cenium.Reservations.Activities.Helpers.Contacts
{
    /// <summary>
    /// Explain the purpose of the class here
    /// </summary>
	internal class ContactProxy : ProxyWrapperBase
    {
        public ContactProxy(IEntityProxy proxy) : base(proxy) { }

        public long ContactId
        {
            get { return GetValue<long>("ContactId"); }
        }

        public string Name
        {
            get { return GetValue<string>("Name"); }
            set { SetValue("Name", value); }
        }

        public DateTime DoB
        {
            get { return GetValue<DateTime>("DoB"); }
            set { SetValue("DoB", value); }
        }

        public string Emails
        {
            get { return GetValue<string>("Emails"); }
            set { SetValue("Emails", value); }
        }
        
    }

}
