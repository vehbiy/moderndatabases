/*
	This file was generated automatically by Garcia Framework. 
	Do not edit manually. 
	Add a new partial class with the same name if you want to add extra functionality.
*/
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Garcia;
using System.ComponentModel.DataAnnotations;

namespace CreditApplication.BL
{
	public partial class Credit
	{
		public double? CreditAmount { get; set; }
		[Required]
		public double InterestRateWithTax { get; set; }

		#region Lazy load
		#endregion

		public Credit()
		{
		}
	}
}

