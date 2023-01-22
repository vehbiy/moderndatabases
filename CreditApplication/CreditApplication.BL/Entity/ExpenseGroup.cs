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
    public partial class ExpenseGroup : CustomEntity
    {
        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string Name { get; set; }
        [Required]
        public List<Expense> Expenses { get { return Get(ref _expenses); } set { Set(ref _expenses, value); } }

        [Required]
        public double Total
        {
            get { return this.Expenses.Sum(x => x.Value); }
        }

        #region Lazy load
        private List<Expense> _expenses;
        #endregion

        public ExpenseGroup()
        {
            this.Expenses = new List<Expense>();
        }

        public override string ToString()
        {
            return new GarciaStringBuilder(' ', this.Name, this.Total.ToString()).ToString();
        }
    }
}

