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
 * Prarthana.G 01/27/2022    Created
 */

/* Replace with component specific create script */

create table [dbo].[Reservations_Reservations] (
    [ReservationId] [bigint] not null identity,
    [CheckInDate] [Date] not null,
    [CheckOutDate] [Date] not null,
    [ReservationStatus] [nvarchar](255) null default('Created'), 
	[Note] [nvarchar](255) null,
	[RoomId] [bigint] null,
	[RoomName] [nvarchar](255) null,
	[CustomerName] [nvarchar](255) null,
	[Price] [decimal](28, 5) null,
	[ContactId] [bigint] not null,
	[PriceId] [decimal](28, 5) null,
	[PropertyContextId] [bigint] null,
	[RoomType] [nvarchar](255) null,
    [TenantId] [uniqueidentifier] not null,
    [RowVersion] [rowversion] not null,
    primary key ([ReservationId])
);

#SetVersion([Cenium.Reservations.Data.ReservationsEntitiesDbContext], [Reservation], [0.0.0.8], [D6730250496FD32AE0DA18B2B509E96F110F83848EA3C2E468E298EFF9E9BB32])