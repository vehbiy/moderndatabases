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
using System.Reflection;

namespace CreditApplication.BL
{
    [Flags]
	public enum UsageType
	{
        [Description("Pe�in")]
        Advance = 1,
	    [Description("Kredili")]
        Credit = 2,
	    [Description("Kiral�k")]
        Rent = 4
	}

    //public static class EnumExt
    //{
    //    public static string GetDescription<T>(this T enumerationValue)
    //        where T : struct
    //    {
    //        Type type = enumerationValue.GetType();
    //        if (!type.IsEnum)
    //        {
    //            throw new ArgumentException("EnumerationValue must be of Enum type", "enumerationValue");
    //        }

    //        //Tries to find a DescriptionAttribute for a potential friendly name
    //        //for the enum
    //        MemberInfo[] memberInfo = type.GetMember(enumerationValue.ToString());
    //        if (memberInfo != null && memberInfo.Length > 0)
    //        {
    //            object[] attrs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

    //            if (attrs != null && attrs.Length > 0)
    //            {
    //                //Pull out the description value
    //                return ((DescriptionAttribute)attrs[0]).Description;
    //            }
    //        }
    //        //If we have no description attribute, just return the ToString of the enum
    //        return enumerationValue.ToString();
    //    }
    //}
}

