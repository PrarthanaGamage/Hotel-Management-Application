/*
 * Copyright (c) Cenium AS. All Right Reserved
 *
 * This source is subject to the Cenium License.
 * Please see the License.txt file for more information.
 * All other rights reserved.
 * 
 * http://www.cenium.com
 * 
 * This code was generated from a template. Changes to this file may cause incorrect behavior 
 * and will be lost if the code is regenerated. 
*/


using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

using Cenium.Framework.Data;
using Cenium.Framework.Core.Attributes;
using Cenium.Framework.Context;
using Cenium.Framework.ComponentModel;



namespace Cenium.Reservations.Data
{

    [Entity]
    [Table("Reservations_Reservations")]
    [PropertyContextEntity("PropertyContextId")]
    public partial class Reservation
    {


        #region Variables

        private long _reservationId;
        private System.DateTime _checkInDate;
        private System.DateTime _checkOutDate;
        private string _reservationStatus = "Created";
        private string _note;
        private Nullable<long> _roomId;
        private long _contactId;
        private Nullable<decimal> _priceId;
        private long _propertyContextId;
        private string _roomName;
        private string _customerName;
        private Nullable<decimal> _price = 0m;
        private string _roomType;
        private Guid _tenantId = Guid.Empty;

        #endregion


        #region Primitive Properties

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [EntityMember(IsReadOnly = true, Order = 0, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        public virtual long ReservationId
        {
            get { return _reservationId; }
            set { _reservationId = value; }
        }

        [Required]
        [EntityMember(IsReadOnly = false, Order = 1, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        [DateTimeFormat(DateTimeFormat.DateTime)]
        public virtual System.DateTime CheckInDate
        {
            get { return _checkInDate; }
            set { _checkInDate = value; }
        }

        [Required]
        [EntityMember(IsReadOnly = false, Order = 2, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        [DateTimeFormat(DateTimeFormat.DateTime)]
        public virtual System.DateTime CheckOutDate
        {
            get { return _checkOutDate; }
            set { _checkOutDate = value; }
        }

        [EntityMember(IsReadOnly = false, Order = 3, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        public virtual string ReservationStatus
        {
            get { return _reservationStatus; }
            set { _reservationStatus = value; }
        }

        [EntityMember(IsReadOnly = false, Order = 4, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        public virtual string Note
        {
            get { return _note; }
            set { _note = value; }
        }

        [EntityMember(IsReadOnly = false, Order = 5, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        public virtual Nullable<long> RoomId
        {
            get { return _roomId; }
            set { _roomId = value; }
        }

        [Required]
        [EntityMember(IsReadOnly = false, Order = 6, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        public virtual long ContactId
        {
            get { return _contactId; }
            set { _contactId = value; }
        }

        [EntityMember(IsReadOnly = false, Order = 7, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        public virtual Nullable<decimal> PriceId
        {
            get { return _priceId; }
            set { _priceId = value; }
        }

        [Required]
        [EntityMember(IsReadOnly = false, Order = 8, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        public virtual long PropertyContextId
        {
            get { return _propertyContextId; }
            set { _propertyContextId = value; }
        }

        [EntityMember(IsReadOnly = false, Order = 9, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        public virtual string RoomName
        {
            get { return _roomName; }
            set { _roomName = value; }
        }

        [EntityMember(IsReadOnly = false, Order = 10, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        public virtual string CustomerName
        {
            get { return _customerName; }
            set { _customerName = value; }
        }

        [EntityMember(IsReadOnly = false, Order = 11, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        public virtual Nullable<decimal> Price
        {
            get { return _price; }
            set { _price = value; }
        }

        [EntityMember(IsReadOnly = false, Order = 12, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        public virtual string RoomType
        {
            get { return _roomType; }
            set { _roomType = value; }
        }


        #endregion


        #region Framework Properties

        /// <summary>
        /// Tenant identifier, for internal framework usage only
        /// </summary>
        [EntityMember(IsReadOnly = true, IsHidden = true, Order = 13, IsQueryable = false, IsSortable = false)]
        public virtual Guid TenantId
        {
            get { return _tenantId; }
            set { _tenantId = value; }
        }

        /// <summary>
        /// Concurrency control version number
        /// </summary>
        [Timestamp]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [EntityMember(IsReadOnly = true, Order = 14, IsHidden = true, IsQueryable = false, IsSortable = false)]
        public virtual byte[] RowVersion
        {
            get;
            set;
        }


        #endregion

    }

}
