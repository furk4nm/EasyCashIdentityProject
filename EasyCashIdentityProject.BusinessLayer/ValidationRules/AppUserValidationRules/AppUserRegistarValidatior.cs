using EasyCashIdentityProject.DtoLayer.Dtos.AppUserDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashIdentityProject.BusinessLayer.ValidationRules.AppUserValidationRules
{
    public class AppUserRegistarValidatior:AbstractValidator<AppUserRegisterDto>
    {
        public AppUserRegistarValidatior() 
        
        {
            
            RuleFor(x=>x.Name).NotEmpty().WithMessage("Ad alanı boş geçilemez");
            RuleFor(x=>x.Surname).NotEmpty().WithMessage("Soyad alanı boş geçilemez");
            RuleFor(x=>x.Username).NotEmpty().WithMessage("Kullanıcı adı alanı boş geçilemez");
            RuleFor(x=>x.Email).NotEmpty().WithMessage("Email alanı boş geçilemez");
            RuleFor(x=>x.Password).NotEmpty().WithMessage("Şifre alanı boş geçilemez");
            RuleFor(x=>x.ConfirmPassword).NotEmpty().WithMessage("Şifre alanı boş geçilemez");
            RuleFor(x=>x.Name).MaximumLength(30).WithMessage("Lütfen 30 en fazla karekter Giriş yapınız");
            RuleFor(x=>x.Name).MinimumLength(2).WithMessage("Lütfen 2 en az karekter Giriş yapınız");
            RuleFor(x => x.ConfirmPassword).Matches(x => x.Password).WithMessage("Parola eslesmiyor!");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Lütfen geçerli bir mail adresi giriniz");


        }
    }
}
