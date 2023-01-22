using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Text;

namespace PaymentModule
{
    public abstract class VPos
    {
        public string Url { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        protected abstract string CreateRequest(string cardNumber, string securityNumber, string expiryDate, int amount);
        protected abstract bool CreateResponse(string responseData);

        public bool ProcessPayment(string cardNumber, string securityNumber, string expiryDate, int amount)
        {
            string requestData = CreateRequest(cardNumber, securityNumber, expiryDate, amount);
            string responseData = SendHttpRequest(requestData);
            var paymentResult = CreateResponse(responseData);
            Console.WriteLine($"VPOS: {this.GetType().Name} Data: {requestData} Url: {Url}");
            return paymentResult;
        }

        protected virtual string SendHttpRequest(string requestString)
        {
            //var request = (HttpWebRequest)WebRequest.Create(this.Url);
            //var data = Encoding.ASCII.GetBytes(requestString);
            //request.Method = "POST";
            //request.ContentType = "application/www-form-encoded";
            //request.ContentLength = data.Length;
            //using (var stream = request.GetRequestStream())
            //{
            //    stream.Write(data, 0, data.Length);
            //}
            //var response = (HttpWebResponse)request.GetResponse();
            //var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            //return responseString;
            return requestString;
        }

        public void Initialize(DataRow row)
        {
            Url = row["Url"].ToString();
            UserName = row["UserName"].ToString();
            Password = row["Password"].ToString();
        }
    }
}
