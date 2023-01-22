using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentModule
{
    public class Bank
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BinNumbers { get; set; }

        public static Bank GetBank(string cardNumber)
        {
            // 4255 1245 2212 4454
            var binNumber = cardNumber.Substring(0, 6);
            var dbHelper = new DBHelper();
            var dataTable = dbHelper.ExecuteDataTable($"select * from Bank where BinNumbers like '%{binNumber}%'", null);
            Bank bank = null;

            if (dataTable.Rows.Count != 0)
            {
                var row = dataTable.Rows[0];
                bank = new Bank()
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Name = row["Name"].ToString(),
                    BinNumbers = row["BinNumbers"].ToString(),
                };
            }

            return bank;
        }
    }
}
