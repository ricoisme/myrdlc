using Microsoft.AspNetCore.Mvc;

namespace MyRDLC.Controllers
{
    public class AccountController1 : Controller
    {
        private readonly IEmailService _emailService;

        public AccountController1(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public async Task<IActionResult> Index()
        {
            var accountService = new AccountService();

            accountService.EmailService = _emailService;

            await accountService.CreateAsync("12", _emailService);
            return View();
        }
    }
}
