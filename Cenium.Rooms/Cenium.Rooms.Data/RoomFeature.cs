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
    [Table("Rooms_RoomFeatures")]
    public partial class RoomFeature
    {


        #region Variables

        private long _roomFeatureId;
        private long _roomId;
        private Room _room;
        private long _featureId;
        private Feature _feature;
        private Guid _tenantId = Guid.Empty;

        #endregion


        #region Primitive Properties

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [EntityMember(IsReadOnly = true, Order = 0, IsPrivate = false, IsQueryable = true, IsSortable = true)]
        public virtual long RoomFeatureId
        {
            get { return _roomFeatureId; }
            set { _roomFeatureId = value; }
        }


        #endregion


        #region Navigation Properties

        /// <summary>
        /// Foreign key property for Room
        /// </summary>
        [Required]
        [ForeignKey("Room")]
        [EntityMember(IsReadOnly = false, Order = 1, Reference = "Room", IsQueryable = false, IsSortable = false)]
        public virtual long RoomId
        {
            get { return _roomId; }
            set { _roomId = value; }
        }

        [EntityMember(IsReadOnly = false, Order = 2)]
        public virtual Room Room
        {
            get { return _room; }
            set { _room = value; }
        }

        /// <summary>
        /// Foreign key property for Feature
        /// </summary>
        [Required]
        [ForeignKey("Feature")]
        [EntityMember(IsReadOnly = false, Order = 3, Reference = "Feature", IsQueryable = false, IsSortable = false)]
        public virtual long FeatureId
        {
            get { return _featureId; }
            set { _featureId = value; }
        }

        [EntityMember(IsReadOnly = false, Order = 4)]
        public virtual Feature Feature
        {
            get { return _feature; }
            set { _feature = value; }
        }


        #endregion


        #region Framework Properties

        /// <summary>
        /// Tenant identifier, for internal framework usage only
        /// </summary>
        [EntityMember(IsReadOnly = true, IsHidden = true, Order = 5, IsQueryable = false, IsSortable = false)]
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
        [EntityMember(IsReadOnly = true, Order = 6, IsHidden = true, IsQueryable = false, IsSortable = false)]
        public virtual byte[] RowVersion
        {
            get;
            set;
        }


        #endregion

    }

}
