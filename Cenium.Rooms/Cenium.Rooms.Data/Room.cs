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



namespace Cenium.Rooms.Data
{

    [Entity]
    [Table("Rooms_Rooms")]
    public partial class Room
    {


        #region Variables

        private long _roomId;
        private string _roomNo;
        private string _roomStatus;
        private bool _isAvailable;
        private Nullable<System.DateTime> _reservedFrom;
        private Nullable<System.DateTime> _reservedTill;
        private ICollection<RoomFeature> _roomFeatures;
        private long _roomTypeId;
        private RoomType _roomType;
        private Guid _tenantId = Guid.Empty;

        #endregion


        #region Primitive Properties

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [EntityMember(IsReadOnly = true, Order = 0, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        public virtual long RoomId
        {
            get { return _roomId; }
            set { _roomId = value; }
        }

        [EntityMember(IsReadOnly = false, Order = 1, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        public virtual string RoomNo
        {
            get { return _roomNo; }
            set { _roomNo = value; }
        }

        [Required]
        [EntityMember(IsReadOnly = false, Order = 2, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        public virtual string RoomStatus
        {
            get { return _roomStatus; }
            set { _roomStatus = value; }
        }

        [Required]
        [EntityMember(IsReadOnly = false, Order = 3, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        public virtual bool IsAvailable
        {
            get { return _isAvailable; }
            set { _isAvailable = value; }
        }

        [EntityMember(IsReadOnly = false, Order = 4, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        [DateTimeFormat(DateTimeFormat.Date)]
        public virtual Nullable<System.DateTime> ReservedFrom
        {
            get { return _reservedFrom; }
            set { _reservedFrom = value; }
        }

        [EntityMember(IsReadOnly = false, Order = 5, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        [DateTimeFormat(DateTimeFormat.Date)]
        public virtual Nullable<System.DateTime> ReservedTill
        {
            get { return _reservedTill; }
            set { _reservedTill = value; }
        }


        #endregion


        #region Navigation Properties

        [EntityMember(IsReadOnly = false, Order = 6)]
        public virtual ICollection<RoomFeature> RoomFeatures
        {
            get { return _roomFeatures; }
            set { _roomFeatures = value; }
        }

        /// <summary>
        /// Foreign key property for RoomType
        /// </summary>
        [Required]
        [ForeignKey("RoomType")]
        [EntityMember(IsReadOnly = false, Order = 7, Reference = "RoomType", IsQueryable = false, IsSortable = false)]
        public virtual long RoomTypeId
        {
            get { return _roomTypeId; }
            set { _roomTypeId = value; }
        }

        [EntityMember(IsReadOnly = false, Order = 8)]
        public virtual RoomType RoomType
        {
            get { return _roomType; }
            set { _roomType = value; }
        }


        #endregion


        #region Framework Properties

        /// <summary>
        /// Tenant identifier, for internal framework usage only
        /// </summary>
        [EntityMember(IsReadOnly = true, IsHidden = true, Order = 9, IsQueryable = false, IsSortable = false)]
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
        [EntityMember(IsReadOnly = true, Order = 10, IsHidden = true, IsQueryable = false, IsSortable = false)]
        public virtual byte[] RowVersion
        {
            get;
            set;
        }


        #endregion

    }

}
