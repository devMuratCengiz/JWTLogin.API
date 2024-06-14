using FluentValidation;
using JWTLogin.DTO.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWTLogin.Business.Validators
{
    public class UserRegisterValidator : AbstractValidator<UserRegisterDto>
    {
        public UserRegisterValidator()
        {
            RuleFor(x=>x.UserName).MaximumLength(20).WithMessage("Kullanıcı adı 20 karakterden fazla olamaz.");

            RuleFor(x => x.UserName).MinimumLength(5).WithMessage("Kullanıcı adı 5 karakterden az olamaz.");

            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı adı boş bırakılamaz.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email boş bırakılamaz.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre boş bırakılamaz.");

            RuleFor(x => x.Email).EmailAddress().WithMessage("Lütfen geçerli bir mail giriniz.");

        }
    }
}
