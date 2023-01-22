using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace PaymentModule
{
    public class Member
    {
        public Member(string name, string surname, DateTime birthDate)
        {
            Name = name;
            Surname = surname;
            BirthDate = birthDate;
        }

        public Member()
        {
        }

        public int Id { get; private set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsMarkedForDeletion { get; set; }

        public bool Save()
        {
            if (Id == 0)
            {
                return Insert();
            }
            else if (IsMarkedForDeletion)
            {
                return Delete();
            }
            else
            {
                return Update();
            }
        }

        private bool Insert()
        {
            string sql = "insert into Member (Name, Surname, BirthDate) values (@Name, @Surname, @BirthDate);select @@identity";
            var dbHelper = new DBHelper();
            var parameters = new Dictionary<string, object>();
            parameters.Add("Name", Name);
            parameters.Add("Surname", Surname);
            parameters.Add("BirthDate", BirthDate);
            object newId = dbHelper.ExecuteScalar(sql, parameters);
            Id = Convert.ToInt32(newId);
            return Id != 0;

            #region Commented
            //var connection = new SqlConnection("server=.;database=PaymentModule;integrated security=SSPI");
            //var command = new SqlCommand(sql, connection);
            //command.Parameters.AddWithValue("Name", this.Name);
            //command.Parameters.AddWithValue("Surname", this.Surname);
            //command.Parameters.AddWithValue("BirthDate", this.BirthDate);
            //connection.Open();
            //object newId = command.ExecuteScalar();
            //Id = Convert.ToInt32(newId);
            //connection.Close(); 
            #endregion
        }

        private bool Delete()
        {
            string sql = "update Member set DeletedOn=getdate() where Id=@Id";
            var parameters = new Dictionary<string, object>();
            var dbHelper = new DBHelper();
            parameters.Add("Id", Id);
            int rowCount = dbHelper.ExecuteNonQuery(sql, parameters);
            return rowCount > 0;
        }

        private bool Update()
        {
            string sql = "update Member set Name=@Name, Surname=@Surname, BirthDate=@BirthDate where Id=@Id";
            var dbHelper = new DBHelper();
            var parameters = new Dictionary<string, object>();
            parameters.Add("Id", Id);
            parameters.Add("Name", Name);
            parameters.Add("Surname", Surname);
            parameters.Add("BirthDate", BirthDate);
            int rowCount = dbHelper.ExecuteNonQuery(sql, parameters);
            return rowCount > 0;
            #region Commented
            //var connection = new SqlConnection("server=.;database=PaymentModule;integrated security=SSPI");
            //var command = new SqlCommand(sql, connection);
            //command.Parameters.AddWithValue("Id", this.Id);
            //command.Parameters.AddWithValue("Name", this.Name);
            //command.Parameters.AddWithValue("Surname", this.Surname);
            //command.Parameters.AddWithValue("BirthDate", this.BirthDate);
            //connection.Open();
            //int rowCount = command.ExecuteNonQuery();
            //connection.Close(); 
            #endregion
        }
    }
}
