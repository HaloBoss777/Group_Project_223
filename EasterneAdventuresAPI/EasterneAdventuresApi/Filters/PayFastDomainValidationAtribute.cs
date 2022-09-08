using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace EasterneAdventuresApi.Web.Filters
{
	public class PayFastDomainValidationAtribute : ActionFilterAttribute
	{
		//MongoClient dbClient;
		public PayFastDomainValidationAtribute()
		{

		}

		List<string> payfastDomains = new List<string>
		{
			"www.payfast.co.za",
			"w1w.payfast.co.za",
			"w2w.payfast.co.za",
			"sandbox.payfast.co.za"
		};

		public override void OnActionExecuting(ActionExecutingContext context)
		{
			
		}

		private string ReadBodyAsString(HttpRequest request)
		{
			var initialBody = request.Body; // Workaround

			try
			{

				using (StreamReader reader = new StreamReader(request.Body))
				{
					string text = reader.ReadToEnd();
					return text;
				}
			}
			finally
			{
				// Workaround so MVC action will be able to read body as well
				request.Body = initialBody;
			}

			return string.Empty;
		}
		
	}
}
