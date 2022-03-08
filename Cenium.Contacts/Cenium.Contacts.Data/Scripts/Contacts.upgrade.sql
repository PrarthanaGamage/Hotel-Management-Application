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
 * Prarthana.G 01/25/2022    Created
 */

 #Version([0.0.0.1])

 create table [dbo].[Contacts_Contacts] (
    [ContactId] [bigint] not null identity,
    [Name] [nvarchar](255) not null,
    [DoB] [date] null,
    [TenantId] [uniqueidentifier] not null,
    [RowVersion] [rowversion] not null,
    primary key ([ContactId])
);

#SetVersion([Cenium.Contacts.Data.ContactsEntitiesDbContext], [Contacts], [0.0.0.1], [D6730250496FD32AE0DA18B2B509E96F110F83848EA3C2E468E298EFF9E9BB32])


#Version([0.0.0.2])

create table [dbo].[Contacts_Emails] (
    [EmailId] [bigint] not null identity,
    [EmailAddress] [nvarchar](255) not null,
    [TenantId] [uniqueidentifier] not null,
    [RowVersion] [rowversion] not null,
    primary key ([EmailId])
);

#SetVersion([Cenium.Contacts.Data.ContactsEntitiesDbContext], [Contacts], [0.0.0.2], [D6730250496FD32AE0DA18B2B509E96F110F83848EA3C2E468E298EFF9E9BB32])

#Version([0.0.0.3])

#AddColumn([Contacts_Emails], [ContactId], [bigint not null])
alter table [dbo].[Contacts_Emails] add constraint [Contacts_Contacts_Contacts_Emails] foreign key ([ContactId]) references [dbo].[Contacts_Contacts]([ContactId]) on delete cascade;
#SetVersion([Cenium.Contacts.Data.ContactsEntitiesDbContext], [Contacts], [0.0.0.3], [D6730250496FD32AE0DA18B2B509E96F110F83848EA3C2E468E298EFF9E9BB32])


#Version([0.0.0.4])

 create table [dbo].[Contacts_ReservationContacts] (
    [ReservationContactId] [bigint] not null identity,
	[ReservationId] [bigint] not null,
    [NickName] [nvarchar](255) not null,
    [TenantId] [uniqueidentifier] not null,
    [RowVersion] [rowversion] not null,
    primary key ([ReservationContactId])
);

#SetVersion([Cenium.Contacts.Data.ContactsEntitiesDbContext], [Contacts], [0.0.0.4], [D6730250496FD32AE0DA18B2B509E96F110F83848EA3C2E468E298EFF9E9BB32])