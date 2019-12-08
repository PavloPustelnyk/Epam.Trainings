/*
	Copyright (c) 2019 Microsoft Corporation. All rights reserved. Licensed under the MIT license.
	See LICENSE in the project root for license information.
*/

using Microsoft.Graph;
using Microsoft.Identity.Client;
using System.Linq;
using System.Collections.Generic;

namespace Epam.Trainings.OneDrive.GraphClientFactory
{
	/// <summary>
	/// This static class returns a fully constructed 
	/// instance of the GraphServiceClient with the client 
	/// data to be used when authenticating requests to the Graph API
	/// </summary> 
	public static class GraphClientFactory
	{		
		public static GraphServiceClient GetGraphServiceClient(string clientId, string authority, string redirectUri, IEnumerable<string> scopes)
		{		
			var authenticationProvider = CreateAuthorizationProvider(clientId, authority, redirectUri, scopes);
			return new GraphServiceClient(authenticationProvider);
		}
		
		private static IAuthenticationProvider CreateAuthorizationProvider(string clientId, string authority, string redirectUri, IEnumerable<string> scopes)
		{
            var clientApplication = new PublicClientApplication(clientId, authority)
            {
                RedirectUri = redirectUri
            };
            return new MsalAuthenticationProvider(clientApplication, scopes.ToArray());		
		}
	}
}
