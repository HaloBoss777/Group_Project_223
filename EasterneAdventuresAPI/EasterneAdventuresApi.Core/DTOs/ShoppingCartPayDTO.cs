using System;
using System.Collections.Generic;
using System.Text;

namespace EasterneAdventuresApi.Core.DTOs
{
	public struct ShoppingCartPayDTO
	{
		public string Amount { get; set; }
		public string TransactionId { get; set; }
		public string Hash { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Email { get; set; }
		public string ReturnUrl { get; set; }
		public string CancelUrl { get; set; }
		public string NotifyUrl { get; set; }
		public string MerchantId { get; set; }
		public string MerchantKey { get; set; }
		public string ServeURL { get; set; }
	}

}
