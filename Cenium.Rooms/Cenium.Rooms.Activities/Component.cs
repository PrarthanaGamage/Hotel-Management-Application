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

using System;
using Cenium.Framework;
using Cenium.Framework.Security;

[assembly: Component("Rooms")]
[assembly: ComponentDescription("Rooms", "Provide a description of what the component does here.", "")]
[assembly: ComponentVersion("1.0.0.0", "")]

[assembly: SecureResourceType("Rooms.administration", "Administer rooms", "Administer setup data for rooms.", SecureResourceAccessType.Secure)]

