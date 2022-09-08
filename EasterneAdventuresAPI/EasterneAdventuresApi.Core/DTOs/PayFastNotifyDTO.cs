using System;
using System.Collections.Generic;
using System.Text;

namespace EasterneAdventuresApi.Core.DTOs
{
	public class PayFastNotifyDTO
	{
		public string m_payment_id { get; set; }
		public string pf_payment_id { get; set; }
		public string payment_status { get; set; }
		public string item_name { get; set; }
		public string item_description { get; set; }
		public string amount_gross { get; set; }
		public string amount_fee { get; set; }
		public string amount_net { get; set; }
		public string name_first { get; set; }
		public string name_last { get; set; }
		public string email_address { get; set; }
		public string merchant_id { get; set; }
		public string signature { get; set; }

	}
}
