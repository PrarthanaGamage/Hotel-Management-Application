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

  #Version([0.0.0.1])

  create table [dbo].[Rooms_Rooms] (
    [RoomId] [bigint] not null identity,
    [RoomNo] [nvarchar](255) not null,
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

alter table [dbo].[Rooms_RoomFeatures] add constraint [Rooms_Rooms_Rooms_RoomFeatures] foreign key ([RoomId]) references [dbo].[Rooms_Rooms]([RoomId]) on delete cascade;
alter table [dbo].[Rooms_RoomFeatures] add constraint [Rooms_Features_Rooms_RoomFeatures] foreign key ([FeatureId]) references [dbo].[Rooms_Features]([FeatureId]) on delete cascade;

#SetVersion([Cenium.Rooms.Data.RoomsEntitiesDbContext], [Rooms], [0.0.0.1], [D6730250496FD32AE0DA18B2B509E96F110F83848EA3C2E468E298EFF9E9BB32])


#Version([0.0.0.2])

#AddColumn([Rooms_Rooms], [RoomStatus], [nvarchar(50) not null default('Clean')])
#AddColumn([Rooms_Rooms], [IsAvailable], [bit not null default(0)])
#AddColumn([Rooms_Rooms], [ReservedFrom], [Date null])
#AddColumn([Rooms_Rooms], [ReservedTill], [Date null])

#SetVersion([Cenium.Rooms.Data.RoomsEntitiesDbContext], [Rooms], [0.0.0.2], [D6730250496FD32AE0DA18B2B509E96F110F83848EA3C2E468E298EFF9E9BB32])


#Version([0.0.0.3])

create table [dbo].[Rooms_RoomTypes] (
    [RoomTypeId] [bigint] not null identity,
    [RoomTypeCode] [nvarchar](255) null,
	[RoomTypeName] [nvarchar](255) null,
    [TenantId] [uniqueidentifier] not null,
    [RowVersion] [rowversion] not null,
    primary key ([RoomTypeId])
);

#SetVersion([Cenium.Rooms.Data.RoomsEntitiesDbContext], [Rooms], [0.0.0.3], [D6730250496FD32AE0DA18B2B509E96F110F83848EA3C2E468E298EFF9E9BB32])

#Version([0.0.0.4])

#AddColumn([Rooms_Rooms], [RoomTypeId], [bigint not null default(0)])

#SetVersion([Cenium.Rooms.Data.RoomsEntitiesDbContext], [Rooms], [0.0.0.4], [D6730250496FD32AE0DA18B2B509E96F110F83848EA3C2E468E298EFF9E9BB32])


#Version([0.0.0.5])

#AddColumn([Rooms_RoomTypes], [PriceId], [bigint null default(0)])

#SetVersion([Cenium.Rooms.Data.RoomsEntitiesDbContext], [Rooms], [0.0.0.5], [D6730250496FD32AE0DA18B2B509E96F110F83848EA3C2E468E298EFF9E9BB32])


#Version([0.0.0.6])

#AddColumn([Rooms_RoomTypes], [PriceCode], [nvarchar(50) null])

#SetVersion([Cenium.Rooms.Data.RoomsEntitiesDbContext], [Rooms], [0.0.0.6], [D6730250496FD32AE0DA18B2B509E96F110F83848EA3C2E468E298EFF9E9BB32])