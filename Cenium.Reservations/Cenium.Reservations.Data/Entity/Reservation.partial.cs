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


using Cenium.Framework.Data;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cenium.Reservations.Data
{
    /// <summary>
    /// Explain the purpose of the class here
    /// </summary>
	public partial class Reservation
    {

        /// <summary>
        /// Initializes a new instance of the Contact class
        /// </summary>
        public Reservation()
        {
           
        }

        [NotMapped]
        [EntityMember(IsReadOnly = true, Order = 101)]

        public string ContactName
        {
            get; set;
        }

        [NotMapped]
        [EntityMember(IsReadOnly = true, Order = 102)]

        public DateTime? ContactDoB
        {
            get; set;
        }
    }

}
