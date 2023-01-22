/*
	This file was generated automatically by Garcia Framework. 
	Do not edit manually. 
	Add a new partial class with the same name if you want to add extra functionality.
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using Garcia;
using System.ComponentModel.DataAnnotations;

namespace CreditApplication.BL
{
    [Flags]
	public enum UserType
	{
        [Description("Bireysel")]
        Personal = 1,
	    [Description("Kurumsal")]
        Corporate = 2
	}
}

