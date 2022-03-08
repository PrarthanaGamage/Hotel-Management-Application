﻿/*
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

using System;
using Cenium.Framework;
using Cenium.Framework.Security;

[assembly: Component("Contacts")]
[assembly: ComponentDescription("Contacts", "Provide a description of what the component does here.", "")]
[assembly: ComponentVersion("1.0.0.0", "")]

[assembly: SecureResourceType("Contacts.administration", "Administer contacts", "Administer setup data for contacts.", SecureResourceAccessType.Secure)]
