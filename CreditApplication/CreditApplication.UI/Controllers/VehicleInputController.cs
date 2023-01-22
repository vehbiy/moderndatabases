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
using Excel.FinancialFunctions;

namespace CreditApplication.UI.Controllers
{
    public partial class VehicleInputController : GarciaEntityMvcController<VehicleInput>
    {
        public override ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                VehicleInput item = VehicleInput.Create();
                return View(item);
            }

            return base.Edit(id);
        }

        public override ActionResult Edit(VehicleInput model)
        {
            if (ModelState.IsValid)
            {
                model.CalculationResults = model.Calculate(model);
            }

            return View(model);
        }
    }
}

