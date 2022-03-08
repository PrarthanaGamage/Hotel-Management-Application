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


using System;

namespace Cenium.Contacts.Client.Windows.Helpers
{
    /// <summary>
    /// Explain the purpose of the class here
    /// </summary>
	internal static  class AgeCalculatorHelper
    {
        public static int GetYears(DateTime dateOfBirth, DateTime currentDate)
        {
            DateTime age = GetSubtractedAge(dateOfBirth, currentDate);
            return age.Year - 1;
        }

        public static int GetMonths(DateTime dateOfBirth, DateTime currentDate)
        {
            DateTime age = GetSubtractedAge(dateOfBirth, currentDate);
            return age.Month - 1;
        }

        private static DateTime GetSubtractedAge(DateTime dateOfBirth, DateTime currentDate)
        {
            TimeSpan difference = currentDate.Subtract(dateOfBirth);

            return DateTime.MinValue + difference;
        }
    }

}
