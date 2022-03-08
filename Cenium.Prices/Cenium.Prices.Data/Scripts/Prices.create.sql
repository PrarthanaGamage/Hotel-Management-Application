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


create table [dbo].[Prices_Prices] (
    [PriceId] [bigint] not null identity,
    [PriceCode] [nvarchar](255) not null,
    [Amount] [decimal] not null,
	[Description] [nvarchar](255) null,
    [TenantId] [uniqueidentifier] not null,
    [RowVersion] [rowversion] not null,
    primary key ([PriceId])
);

#SetVersion([Cenium.Prices.Data.PricesEntitiesDbContext], [Prices], [0.0.0.1], [D6730250496FD32AE0DA18B2B509E96F110F83848EA3C2E468E298EFF9E9BB32])