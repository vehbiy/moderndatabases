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
using System.Web.Mvc;
using CreditApplication.BL;

namespace CreditApplication.UI.Controllers
{
	public partial class VehicleOutputController : GarciaEntityMvcController<VehicleOutput>
	{
	    public override ActionResult Edit(int? id)
	    {
	        if (!id.HasValue)
	        {

	        }

	        return base.Edit(id);
	    }
	}
}

