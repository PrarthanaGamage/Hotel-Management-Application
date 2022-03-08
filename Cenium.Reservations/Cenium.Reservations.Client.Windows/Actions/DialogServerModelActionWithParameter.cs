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
 * Prarthana.G 02/28/2022    Created
 */


using Cenium.Framework.Client;
using Cenium.Framework.Client.AppResources.UI;
using Cenium.Framework.Client.Model;
using Cenium.Framework.Client.Windows;
using Cenium.Framework.Client.Windows.Pages.Actions;
using System;
using System.ComponentModel;

namespace Cenium.Reservations.Client.Windows.Actions
{
    /// <summary>
    /// Explain the purpose of the class here
    /// </summary>
    [RegisterActionType("reservation.action.dialogservermodel.withparameter")]
	public class DialogServerModelActionWithParameter : DialogServerModelActionHandler
    {

        private Record _record = null;
        /// <summary>
        /// Initializes a new instance of the DialogServerModelActionWithParameter class
        /// </summary>
        public DialogServerModelActionWithParameter()
        {
            IsActionEnabled = true;
            IsActionItemRequired = true;
        }
        /// <summary>
        /// Indicates if child records should be included in action method
        /// </summary>
        public bool IncludeChildRecords { get; set; }

        /// <summary>
        /// Indicates if dialog record should be set default as dirty when opening the dialog
        /// </summary>
        public bool SetDialogRecordDirty { get; set; }

        protected override void OnExecute()
        {
            var rootRecord = GetRecord();

            if (!SetDialogRecordDirty)
            {
                var itemModel = new ItemModel();
                if (!string.IsNullOrWhiteSpace(base.ActionMethod))
                {
                    itemModel.UpdateMethod = base.ActionMethod;
                    itemModel.IncludeChildRecords = IncludeChildRecords;
                }

                itemModel.GetMethod = base.GetMethod;
                itemModel.Parameters = new object[] { rootRecord };
                itemModel.Refresh();

                var dialog = WindowManager.CreateDialogFromResource(Owner, base.DialogId, itemModel);
                if (dialog.ShowModalDialog())
                {
                    RefreshCurrent();
                }
            }
            else
            {
                WindowManager.ShowPageProgress(Owner, "Getting defaults", "Getting defaults for dialog...");
                ClientConnector.Current.GetAsync(new ServiceParameters() { ServiceMethod = base.GetMethod, ServiceMethodParameters = rootRecord }, GetDialogRecordCallback);
            }

        }

        private void RefreshCurrent()
        {
            var page = Owner as IPagePart;
            if ((page == null) || (page.PageModel == null) || (page.PageModel.Data == null))
                return;

            var rootRecord = GetRecord();
            var listViewModel = page.PageModel.Data as ListViewModel;
            if (listViewModel != null && !string.IsNullOrWhiteSpace(listViewModel.GetMethod))
            {
                WindowManager.ShowPageProgress(Owner, "Refresh", "Refreshing Current Page...");

                ClientConnector.Current.GetAsync(new ServiceParameters() { ServiceMethod = listViewModel.GetMethod, ServiceMethodParameters = rootRecord }, RefreshCurrentCallback);
            }

        }

        private void RefreshCurrentCallback(ServiceOperationResult result)
        {
            if (result != null && result.Result != null)
            {
                WindowManager.HidePageProgress(Owner);

                var rootRecord = GetRecord();
                var resultRecord = result.Result as Record;
                if (rootRecord != null && resultRecord != null)
                    rootRecord.Merge(resultRecord, true);
            }
        }

        private void GetDialogRecordCallback(ServiceOperationResult result)
        {
            if (result != null && result.Result != null)
            {
                WindowManager.HidePageProgress(Owner);
                var resultRecord = result.Result as Record;
                if (resultRecord != null)
                {
                    resultRecord.State = RecordState.Modified;

                    var itemModel = new ItemModel(resultRecord);
                    if (!string.IsNullOrWhiteSpace(base.ActionMethod))
                    {
                        itemModel.UpdateMethod = base.ActionMethod;
                        itemModel.IncludeChildRecords = IncludeChildRecords;
                    }

                    var dialog = WindowManager.CreateDialogFromResource(Owner, base.DialogId, itemModel);
                    if (dialog.ShowModalDialog())
                    {
                        RefreshCurrent();
                    }
                }
            }
        }

        /// <summary>
        /// Called when the ActionItem property changes.
        /// </summary>
        /// <remarks>
        /// This method attaches PropertyChanged event handlers to the ActionItem object if the object implements the INotifyPropertyChanged interface
        /// </remarks>
        /// <param name="oldValue">The old ActionItem value</param>
        /// <param name="newValue">The new ActionItem value</param>
        protected override void OnActionItemChanged(object oldValue, object newValue)
        {
            base.OnActionItemChanged(oldValue, newValue);
            var oldNotify = oldValue as INotifyPropertyChanged;
            var newNotify = newValue as INotifyPropertyChanged;
            var newItem = newValue as RecordItem;

            if (oldNotify != null)
            {
                DetachRecordListener(_record);
                oldNotify.PropertyChanged -= OnActionItemPropertyChanged;
            }

            if (newNotify != null)
            {
                newNotify.PropertyChanged += OnActionItemPropertyChanged;
                if (newItem != null)
                    AttachRecordListener(newItem.Item);
            }

        }

        private void OnActionItemPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            var recordItem = sender as RecordItem;
            if ((recordItem != null) && ("Item".Equals(args.PropertyName)))
            {
                DetachRecordListener(_record);
                AttachRecordListener(recordItem.Item);
            }
            Invalidate();
        }

        private void DetachRecordListener(Record record)
        {
            _record = null;
            if (record == null)
                return;
            record.PropertyChanged -= OnActionItemPropertyChanged;
        }

        private void AttachRecordListener(Record record)
        {
            _record = record;
            if (record == null)
                return;
            record.PropertyChanged += OnActionItemPropertyChanged;
        }

    }

}
