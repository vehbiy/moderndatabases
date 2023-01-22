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
	public partial class PurchasePowerOutput : CustomEntity
	{
		[Required]
		public double Price { get; set; }
		[Required]
		public double AdvancePayment { get; set; }
		[Required]
		public double InstallmentAmount { get; set; }
		[Required]
		public int Months { get; set; }
		[Required]
		public double MonthlyInterestRate { get; set; }
		[Required]
		public double CreditAmount { get; set; }

		#region Lazy load
		#endregion

		public PurchasePowerOutput()
		{
		}
	}
}

