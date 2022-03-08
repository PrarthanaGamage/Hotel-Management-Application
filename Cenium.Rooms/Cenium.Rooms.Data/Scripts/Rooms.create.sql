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
 * Prarthana.G 01/26/2022    Created
 */

/* Replace with component specific create script */

create table [dbo].[Rooms_Rooms] (
    [RoomId] [bigint] not null identity,
    [RoomNo] [nvarchar](255) not null,
	[RoomStatus] [nvarchar](50) not null default('Clean'),
	[IsAvailable] [bit] not null,
	[ReservedFrom] [Date] null,
	[ReservedTill] [Date] null,
	[RoomTypeId] [bigint] not null,
	[TenantId] [uniqueidentifier] not null,
    [RowVersion] [rowversion] not null,
    primary key ([RoomId])
);

create table [dbo].[Rooms_RoomFeatures] (   --mapping table
    [RoomFeatureId] [bigint] not null identity,
    [RoomId] [bigint] not null,
    [FeatureId] [bigint] not null,
	[TenantId] [uniqueidentifier] not null,
    [RowVersion] [rowversion] not null,
    primary key ([RoomFeatureId])
);


create table [dbo].[Rooms_Features] (
    [FeatureId] [bigint] not null identity,
    [FeatureName] [nvarchar](255) not null,
    [Description] [nvarchar](255) null,
	[TenantId] [uniqueidentifier] not null,
    [RowVersion] [rowversion] not null,
    primary key ([FeatureId])
);

create table [dbo].[Rooms_RoomTypes] (
    [RoomTypeId] [bigint] not null identity,
	[RoomTypeCode] [nvarchar](255) null,
    [RoomTypeName] [nvarchar](255) null,
	[PriceId] [bigint] null,
	[PriceCode] [nvarchar](255) null,
    [TenantId] [uniqueidentifier] not null,
    [RowVersion] [rowversion] not null,
    primary key ([RoomId])
);

alter table [dbo].[Rooms_RoomFeatures] add constraint [Rooms_Rooms_Rooms_RoomFeatures] foreign key ([RoomId]) references [dbo].[Rooms_Rooms]([RoomId]) on delete cascade;
alter table [dbo].[Rooms_RoomFeatures] add constraint [Rooms_Features_Rooms_RoomFeatures] foreign key ([FeatureId]) references [dbo].[Rooms_Features]([FeatureId]) on delete cascade;
alter table [dbo].[Rooms_RoomTypes] add constraint [Rooms_Rooms_Rooms_RoomTypes] foreign key ([RoomId]) references [dbo].[Rooms_RoomTypes]([RoomId]) on delete cascade;

#SetVersion([Cenium.Rooms.Data.RoomsEntitiesDbContext], [Rooms], [0.0.0.6], [D6730250496FD32AE0DA18B2B509E96F110F83848EA3C2E468E298EFF9E9BB32])