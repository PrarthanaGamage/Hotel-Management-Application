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
 * Prarthana.G 02/16/2022    Created
 */


using Cenium.Framework.Client.AppResources.Metadata;
using Cenium.Framework.Client.Metadata;
using System;
using Cenium.Framework.Client.Model;
using Cenium.Contacts.Client.Windows.Helpers;

namespace Cenium.Contacts.Client.Windows.Extensions
{
    /// <summary>
    /// Explain the purpose of the class here
    /// </summary>
    [RegisterEntityPropertyExtension("contacts.entityextension.ageyears")]
    public class AgeYearsEntityExtension : IEntityPropertyExtension
    {

        private const string DoB = "DoB";
        /// <summary>
        /// Initializes a new instance of the AgeMonthsEntityExtension class
        /// </summary>
        
        public object Get(Record r)
        {
            if (r == null)
                return string.Empty;

            var dateOfBirth = r.GetValue<DateTime>(DoB);

            if (dateOfBirth > DateTime.Now)
                return string.Empty;

            if (dateOfBirth != null && dateOfBirth != DateTime.MinValue)
                return AgeCalculatorHelper.GetYears(dateOfBirth, DateTime.Today).ToString();

            return string.Empty;
        }

    }

}
