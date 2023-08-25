namespace MyRDLC
{
    public class AccountService
    {
        private IEmailService _emailService;

        public IEmailService EmailService
        {
            get
            {
                if (_emailService is null)
                {
                    _emailService = new EmailService();
                }
                return _emailService;
            }
            set
            {
                _emailService = value;
            }
        }

        public AccountService(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public AccountService() { }

        public async Task<bool> CreateAsync(string ID, IEmailService emailService)
        {
            Console.WriteLine("ok");
            await emailService.SendAsync("test", "di", "rico@aa");
            return true;
        }
    }
}
