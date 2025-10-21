using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VietLife.Catalog.CheDos.LoaiCheDos
{
    public class CreateUpdateLoaiCheDoDtoValidator : AbstractValidator<CreateUpdateLoaiCheDoDto>
    {
        public CreateUpdateLoaiCheDoDtoValidator()
        {
            RuleFor(x => x.TenLoaiCheDo).NotEmpty().MaximumLength(100);
            RuleFor(x => x.MoTa).NotEmpty().MaximumLength(250);
        }
    }
}
