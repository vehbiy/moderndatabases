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
    public partial class CreditController : GarciaEntityMvcController<Credit>
    {
        public override ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                Dictionary<string, object> qs = Request.QueryString.ToDictionary();
                CreditType type = CreditType.Personal;

                if (qs.ContainsKey("CreditType"))
                {
                    type = Helpers.GetValueFromObject<CreditType>(qs["CreditType"]);
                }

                Credit item = Credit.Create(type);
                return View(item);
            }

            return base.Edit(id);
        }

        public override ActionResult Edit(Credit model)
        {
            if (ModelState.IsValid)
            {
                model.Calculate();
            }

            return View(model);
        }

        //public override ActionResult Edit(int? id)
        //{
        //    string str = "";
        //    Credit item = new Credit()
        //    {
        //           UserType = UserType.Personal,
        //           CreditType = CreditType.Personal,
        //           CreditAmount = 100000,
        //           Months = 48,
        //           InterestRate = 1.04
        //    };

        //    item.Calculate();
        //    str += item.UserType.ToString() + " " + item.CreditType.ToString() + " " + item.InstallmentAmount.Value.ToString() + "\n";
        //    item.UserType = UserType.Personal;
        //    item.CreditType = CreditType.Vehicle;
        //    item.Calculate();
        //    str += item.UserType.ToString() + " " + item.CreditType.ToString() + " " + item.InstallmentAmount.Value.ToString() + "\n";

        //    item.UserType = UserType.Corporate;
        //    item.CreditType = CreditType.Vehicle;
        //    item.Calculate();
        //    str += item.UserType.ToString() + " " + item.CreditType.ToString() + " " + item.InstallmentAmount.Value.ToString() + "\n";

        //    item.UserType = UserType.Personal;
        //    item.CreditType = CreditType.House;
        //    item.Calculate();
        //    str += item.UserType.ToString() + " " + item.CreditType.ToString() + " " + item.InstallmentAmount.Value.ToString() + "\n";

        //       throw new Exception(str);
        //    return base.Edit(id);
        //}
    }
}

