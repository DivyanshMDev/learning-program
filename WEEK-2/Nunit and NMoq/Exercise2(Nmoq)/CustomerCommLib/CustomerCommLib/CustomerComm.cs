namespace CustomerCommLib
{
    public class CustomerComm
    {
        private IMailSender _mailSender;

        // Constructor Injection - we inject the dependency here
        public CustomerComm(IMailSender mailSender)
        {
            _mailSender = mailSender;
        }

        public bool SendMailToCustomer()
        {
            // Actual logic goes here
            // Define message and mail address
            bool result = _mailSender.SendMail("cust123@abc.com", "Some Message");

            return result;
        }
    }
}
