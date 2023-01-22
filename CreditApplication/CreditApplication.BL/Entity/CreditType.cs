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
using System.ComponentModel;

namespace CreditApplication.BL
{
	public enum CreditType
	{
        [Description("Ýhtiyaç Kredisi")]
        Personal = 0,
	    [Description("Araç Kredisi")]
        Vehicle = 1,
	    [Description("Konut Kredisi")]
        House = 2
	}
}

