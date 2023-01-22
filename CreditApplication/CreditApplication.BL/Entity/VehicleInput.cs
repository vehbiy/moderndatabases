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
	public class ProductBase : CustomEntity
	{
		public double? Price { get; set; }
		public virtual void AfterUpgrade(Product upgrade)
		{
		}
	}
	
	public class Product : ProductBase
	{
		
	}
	
	public partial class VehicleInput : ProductBase
    {
	    [Required]
        public double? Price { get; set; }
	    [Required]
        public double? AdvancePayment { get; set; }
	    [Required]
        public double? UsageDuration { get; set; }
	    [Required]
        public double? MaximumRent { get; set; }
		[Required]
		public double InterestRate { get; set; }
		[Required]
		public UserType UserType { get; set; }
		[Required]
		public UsageType UsageType { get; set; }

	    [MvcListIgnore]
	    [Required]
	    public List<VehicleOutput> CalculationResults { get { return Get(ref _calculationResults); } set { Set(ref _calculationResults, value); } }

	    #region Lazy load
	    private List<VehicleOutput> _calculationResults;
	    #endregion

	    public VehicleInput()
	    {
	        this.CalculationResults = new List<VehicleOutput>();
	    }
    }
}

