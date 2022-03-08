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

  #Version([0.0.0.1])

 create table [dbo].[Reservations_Reservations] (
    [ReservationId] [bigint] not null identity,
    [CheckInDate] [Date] not null,
    [CheckOutDate] [Date] not null,
    [ReservationStatus] [nvarchar](255) null,
	[Note] [nvarchar](255) null,
    [TenantId] [uniqueidentifier] not null,
    [RowVersion] [rowversion] not null,
    primary key ([ReservationId])
);

#SetVersion([Cenium.Reservations.Data.ReservationsEntitiesDbContext], [Reservation], [0.0.0.1], [D6730250496FD32AE0DA18B2B509E96F110F83848EA3C2E468E298EFF9E9BB32])



#Version([0.0.0.2])

#AddColumn([Reservations_Reservations], [RoomId], [bigint null])

#SetVersion([Cenium.Reservations.Data.ReservationsEntitiesDbContext], [Reservation], [0.0.0.2], [D6730250496FD32AE0DA18B2B509E96F110F83848EA3C2E468E298EFF9E9BB32])


#Version([0.0.0.3])

#AddColumn([Reservations_Reservations], [ContactId], [bigint not null])
#AddColumn([Reservations_Reservations], [PriceId], [decimal(28, 5) null])

#SetVersion([Cenium.Reservations.Data.ReservationsEntitiesDbContext], [Reservation], [0.0.0.3], [D6730250496FD32AE0DA18B2B509E96F110F83848EA3C2E468E298EFF9E9BB32])


#Version([0.0.0.4])

#AddColumn([Reservations_Reservations], [PropertyContextId], [bigint null])

#SetVersion([Cenium.Reservations.Data.ReservationsEntitiesDbContext], [Reservation], [0.0.0.4], [D6730250496FD32AE0DA18B2B509E96F110F83848EA3C2E468E298EFF9E9BB32])


#Version([0.0.0.5])

#AddColumn([Reservations_Reservations], [RoomName], [nvarchar(255) null])

#SetVersion([Cenium.Reservations.Data.ReservationsEntitiesDbContext], [Reservation], [0.0.0.5], [D6730250496FD32AE0DA18B2B509E96F110F83848EA3C2E468E298EFF9E9BB32])


#Version([0.0.0.6])

#AddColumn([Reservations_Reservations], [Price], [decimal(28, 5) not null default(0)])

#SetVersion([Cenium.Reservations.Data.ReservationsEntitiesDbContext], [Reservation], [0.0.0.6], [D6730250496FD32AE0DA18B2B509E96F110F83848EA3C2E468E298EFF9E9BB32])


#Version([0.0.0.7])

#AddColumn([Reservations_Reservations], [CustomerName], [nvarchar(255) null])

#SetVersion([Cenium.Reservations.Data.ReservationsEntitiesDbContext], [Reservation], [0.0.0.7], [D6730250496FD32AE0DA18B2B509E96F110F83848EA3C2E468E298EFF9E9BB32])


#Version([0.0.0.8])

#AddColumn([Reservations_Reservations], [RoomType], [nvarchar(255) null])

#SetVersion([Cenium.Reservations.Data.ReservationsEntitiesDbContext], [Reservation], [0.0.0.8], [D6730250496FD32AE0DA18B2B509E96F110F83848EA3C2E468E298EFF9E9BB32])