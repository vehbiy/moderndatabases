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
using Microsoft.WindowsAzure.Storage.Table;

namespace CreditApplication.UI.Controllers
{
    public partial class PurchasePowerInputController : GarciaEntityMvcController<PurchasePowerInput>
    {
        public override ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                PurchasePowerInput item = PurchasePowerInput.Create();
                item.Price = 100000;
                item.Months = 24;
                item.InterestRate = 0.78;
                item.AdvancePayment = 35000;
                item.InstallmentAmount = 2500;
                item.CreditType = CreditType.Vehicle;
                item.UserType = UserType.Personal;
                Session["PurchasePowerInput"] = item;
                return View(item);
            }

            return base.Edit(id);
        }

        [HttpPost]
        public override ActionResult Edit(PurchasePowerInput model)
        {
            if (ModelState.IsValid)
            {
                if (model.AdvancePayment >= model.Price)
                {
                    ModelState.AddModelError("AdvancePayment", GarciaLocalizationManager.Localize("AdvancePaymentCannotBeGreaterThanPrice"));
                }
                else
                {
                    model.SelectedProduct = model.Products?.Where(x => x.Price == model.Price).FirstOrDefault();
                    model.Calculate();
                    Session["PurchasePowerInput"] = model;
                }
            }

            return View("Edit", model);
        }

        [HttpPost]
        public ActionResult UpgradeProduct()
        {
            PurchasePowerInput item = Session["PurchasePowerInput"] as PurchasePowerInput;

            if (item == null)
            {
                return Edit(id: null);
            }

            item.Upgrade();
            return Edit(item);
            //return View("Edit", item);
        }
    }

    //public class PurchasePowerInputUpgradeProductModel
    //{
    //    public double Price { get; set; }
    //}
}

