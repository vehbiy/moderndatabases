using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Garcia;
using System.ComponentModel.DataAnnotations;

namespace CreditApplication.BL
{
    public partial class PurchasePowerOutput
    {
        public CreditType CreditType { get; set; }

        public string Description
        {
            get; set;
        }
    }
}

