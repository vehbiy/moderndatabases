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
    public partial class VehicleOutput : CustomEntity
    {
        [Required]
        public UserType UserType { get; set; }
        [Required]
        public UsageType UsageType { get; set; }
        public ExpenseGroup FinancialExpenses { get { return Get(_financialExpensesId, ref _financialExpenses); } set { Set(ref _financialExpenses, ref _financialExpensesId, value); } }
        [NotSelected]
        [NotSaved]
        public int? FinancialExpensesId { get { return _financialExpensesId; } set { _financialExpensesId = value; } }
        public ExpenseGroup OperationalExpenses { get { return Get(_operationalExpensesId, ref _operationalExpenses); } set { Set(ref _operationalExpenses, ref _operationalExpensesId, value); } }
        [NotSelected]
        [NotSaved]
        public int? OperationalExpensesId { get { return _operationalExpensesId; } set { _operationalExpensesId = value; } }
        [MvcListIgnore]
        [Required]
        public double EstimatedSalePrice { get; set; }
        [MvcListIgnore]
        [Required]
        public double Tax { get; set; }
        [MvcListIgnore]
        [Required]
        public double CorporateTax { get; set; }

        [MvcListIgnore]
        [Required]
        public double TotalCost
        {
            //get { return this.FinancialExpenses.Total + this.OperationalExpenses.Total - this.EstimatedSalePrice; }
            get { return this.FinancialExpenses.Total + this.OperationalExpenses.Total - this.EstimatedSalePrice - this.Tax - this.CorporateTax; }
        }

        #region Lazy load
        private ExpenseGroup _financialExpenses;
        private int? _financialExpensesId;
        private ExpenseGroup _operationalExpenses;
        private int? _operationalExpensesId;
        #endregion

        public VehicleOutput()
        {
        }
    }
}

