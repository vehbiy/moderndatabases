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
	public partial class Expense : CustomEntity
	{
		[Required]
		[StringLength(200, MinimumLength = 0)]
		public string Name { get; set; }
		[Required]
		public double Value { get; set; }

		#region Lazy load
		#endregion

		public Expense(string name, double value)
		{
            this.Name = name;
		    this.Value = value;
		}

		public override string ToString()
		{
			return new GarciaStringBuilder(' ', this.Name, this.Value.ToString()).ToString();
		}
	}
}

