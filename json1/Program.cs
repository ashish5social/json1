using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Crm.Sdk.Messages;
using System.Net;
using System.ServiceModel.Description;

namespace json1
{
	class Program
	{
		static void Main(string[] args)
		{

			IOrganizationService organizationService = null;

			try
			{
				ClientCredentials clientCredentials = new ClientCredentials();
				clientCredentials.UserName.UserName = "admin@ashishkumarjha1.onmicrosoft.com";
				clientCredentials.UserName.Password = "Micr0s0ft";

				// For Dynamics 365 Customer Engagement V9.X, set Security Protocol as TLS12
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
				// Get the URL from CRM, Navigate to Settings -> Customizations -> Developer Resources
				// Copy and Paste Organization Service Endpoint Address URL
				organizationService = (IOrganizationService)new OrganizationServiceProxy(new Uri("https://ashishkumarjha1.api.crm8.dynamics.com/XRMServices/2011/Organization.svc"),
				 null, clientCredentials, null);

				if (organizationService != null)
				{
					Guid userid = ((WhoAmIResponse)organizationService.Execute(new WhoAmIRequest())).UserId;

					Entity account = new Entity("account");
					account["name"] = "Ashishfromjsonproject";
					Guid accountId = organizationService.Create(account); 


					if (accountId != Guid.Empty)
					{
						Console.WriteLine("Created account with GUID {0} ", accountId);
					}
				}
				else
				{
					Console.WriteLine("Failed to Established Connection!!!");
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Exception caught - " + ex.Message);
			}
			Console.ReadKey();

		}
	}
}
