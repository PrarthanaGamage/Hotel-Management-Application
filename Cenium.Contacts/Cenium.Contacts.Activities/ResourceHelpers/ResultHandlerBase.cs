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
using System;

namespace Cenium.Contacts.Activities.ResourceHelpers
{
    /// <summary>
    /// Explain the purpose of the class here
    /// </summary>
	internal class ResultHandlerBase : IDisposable
    {
        private ContactsEntitiesContext _ctx = null;

        protected long GetKey(object key)
        {
            if ((key == null) || (!(key is long)))
                return 0L;

            return (long)key;
        }

        protected ContactsEntitiesContext Context
        {
            get
            {
                if (_ctx == null)
                    _ctx = new ContactsEntitiesContext();
                return _ctx;
            }
        }

        public void Dispose()
        {
            if (_ctx != null)
                _ctx.Dispose();
            _ctx = null;
        }
    }

}
