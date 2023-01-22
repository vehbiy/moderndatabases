using PaymentModule;

var member = new Member("Ali", "Kara", DateTime.Today.AddYears(-30));
var result = member.Save();
member.Name = "Ali1";
result = member.Save();
member.IsMarkedForDeletion = true;
result = member.Save();

var paymentResult = PaymentManager.MakePayment("1223331245124512", "123", "0122", 100);
paymentResult = PaymentManager.MakePayment("4433444433441245", "123", "0122", 1000);