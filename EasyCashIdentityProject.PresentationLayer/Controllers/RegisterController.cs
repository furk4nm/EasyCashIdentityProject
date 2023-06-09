using EasyCashIdentityProject.DtoLayer.Dtos.AppUserDtos;
using EasyCashIdentityProject.EntityLayer.Concrete;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MimeKit;

namespace EasyCashIdentityProject.PresentationLayer.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
		


		public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(AppUserRegisterDto appUserRegisterDto)
        {
           if (ModelState.IsValid)
            {
                Random random = new Random();
                 int code;
                code = random.Next(100000, 1000000);
                AppUser appUser = new AppUser()
                {
                    UserName = appUserRegisterDto.Username,
                    Name = appUserRegisterDto.Name,
                    Surname = appUserRegisterDto.Surname,
                    Email = appUserRegisterDto.Email,
                    City = "NULL",
                    District = "NULL",
                    ImageUrl = "NULL",
                    ConfirmCode = code

                };
                var result = await _userManager.CreateAsync(appUser, appUserRegisterDto.Password);
                if (result.Succeeded)
                {
                    //nesne örneği
                    MimeMessage mimeMessage = new MimeMessage();
                    //Mail kimden gidiyor ,Mail eposta adresi
                    MailboxAddress mailboxAddressFrom = new MailboxAddress("Easy Cash Admin", "furkanbankamail@gmail.com");
                    //Mail kime gidiyor,giden userın epostası
                    MailboxAddress mailboxAddresTo = new MailboxAddress("User", appUser.Email);
                    //meail kimden gidicek mailboxadresden gelen değerden gidicek
                    mimeMessage.From.Add(mailboxAddressFrom);
                    //kime gidicek mailboxtadrestodan gelen değere
                    mimeMessage.To.Add(mailboxAddresTo);

                    var bodyBuilder = new BodyBuilder();
                    // mesaj içeriği ve mesaj konusu
                    bodyBuilder.TextBody = "Kayıt işlemini gerçekleştirmek için onay kodunuz: " + code;
                    mimeMessage.Body = bodyBuilder.ToMessageBody();
                    mimeMessage.Subject = "Easy Cash Onay Kodu";

                    SmtpClient client = new SmtpClient();
                    //587 türkite portu false güvenlğiğ sağla
                    client.Connect("smtp.gmail.com", 587, false);
                    //kendi mail yollayıcı mailimizi ve mail adresinden aldığımız guidid şifresini yazıyoruz
                    client.Authenticate("furkanbankamail@gmail.com", "eqrsjqrleoootvah");
                    client.Send(mimeMessage);
                    client.Disconnect(true);



                    TempData["Mail"] = appUserRegisterDto.Email;


                    return RedirectToAction("Index", "Confirm");

                }
                else
                {
                    foreach(var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }



                
            }
            return View();


            
        }
    }
}
