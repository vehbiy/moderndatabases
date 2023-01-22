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
    public partial class PurchasePowerInput : CreditBase
    {
        public double? Price { get; set; }
        public double? AdvancePayment { get; set; }
        [MvcIgnore]
        [Required]
        public List<PurchasePowerOutput> CalculationResults { get { return Get(ref _calculationResults); } set { Set(ref _calculationResults, value); } }

        public Product SelectedProduct { get; set; }
        public List<Product> Products { get; set; }

        #region Lazy load
        private List<PurchasePowerOutput> _calculationResults;
        #endregion

        public PurchasePowerInput()
        {
            this.CalculationResults = new List<PurchasePowerOutput>();
        }

        public override void AfterUpgrade(Product upgrade)
        {
            if (upgrade != null)
            {
                this.Price = upgrade.Price;
            }
        }

        public void Upgrade()
        {
        }
    }
}

