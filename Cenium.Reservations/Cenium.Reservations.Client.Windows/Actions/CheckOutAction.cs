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
 * Prarthana.G 02/21/2022    Created
 */


using Cenium.Framework.Client;
using Cenium.Framework.Client.AppResources.UI;
using Cenium.Framework.Client.Model;
using Cenium.Framework.Client.Windows;
using Cenium.Framework.Client.Windows.Pages.Actions;
using Cenium.Framework.ComponentModel;
using System;
using System.Windows;

namespace Cenium.Reservations.Client.Windows.Actions
{
    /// <summary>
    /// Explain the purpose of the class here
    /// </summary>
    [RegisterActionType("reservations.checkoutaction")]
    public class CheckOutAction : AbstractActionHandler
    {
        private Record _record = null;

        /// <summary>
        /// Initializes a new instance of the CheckInAction class
        /// </summary>
        public CheckOutAction()
        {
            IsActionEnabled = true;
            IsActionItemRequired = true;
        }

        protected override bool EvaluateConditions()
        {
            bool test = base.EvaluateConditions();
            if (test)
            {
                if (ClientConnector.Current.CheckUserAccess("Reservations/Reservation/CheckOut/{ReservationId}"))
                {
                    return true;
                }
            }

            return false;
        }

        protected override void OnExecute()
        {
            var record = GetRecord();

            if (record == null)
            {
                MessageBox.Show("Unable to find!");
                return;
            }
            else if (record.State == RecordState.Added || record.IsDirty)
            {
                MessageBox.Show("Please save changes!");
                return;
            }
            else
            {
                CheckOutProcess(record);
            }
        }

        private void CheckOutProcess(Record record)
        {
            string executingMessageTitle = "Checking Out, Please wait...";
            string executingmMessage = "Checking Out Reservation...";

            CheckOutImplementation(record, executingMessageTitle, executingmMessage);
        }

        private void CheckOutImplementation(Record request, string executingMessageTitle, string executingmMessage)
        {
            WindowManager.ShowPageProgress(Owner, executingMessageTitle, executingmMessage);
            try
            {
                ClientConnector.Current.GetAsync(new ServiceParameters
                {
                    ServiceMethod = "Reservations/Reservation/CheckOut/{ReservationId}",
                    ServiceMethodParameters = request,
                }, Finished);
            }
            catch (Exception exception)
            {
                WindowManager.HidePageProgress(Owner);

                MessageBox.Show(string.Format("{0}\n{1}\n{2}", "Error occured when doing Check Out!",
                    "Error Messsage:", exception.Message),
                    "Check Out Failed!");
            }
        }

        private void Finished(ServiceOperationResult result)
        {
            WindowManager.HidePageProgress(Owner);
            if (!result.IsError)
            {
                Record record = GetRecord();
                if (record == null)
                {
                    return;
                }
                var newRecord = result.Result as Record;

                if (newRecord != null)

                {
                    record.Merge(newRecord, true);
                    record.State = newRecord.State;
                }
            }

            else
            {
                EventDispatchManager.ExecuteOnUIThread(
                    (Action)delegate ()
                    {
                        MessageBox.Show(string.Format("{0}\n{1}\n{2}", "An error occured when doing check out!",
                            "Error Message: ", result.Error.Message),
                            "Check Out did not complete.", MessageBoxButton.OK, MessageBoxImage.Error);
                    });

            }
            Invalidate();
        }

        protected Record GetRecord()
        {
            if (Owner == null)
                return null;

            if (ActionItem != null)
            {
                var record = ActionItem as RecordItem;
                return record.Item;
            }
            return null;
        }
    }
}
