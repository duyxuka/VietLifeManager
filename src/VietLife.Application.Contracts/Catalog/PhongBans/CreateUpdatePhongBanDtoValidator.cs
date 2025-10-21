using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VietLife.Catalog.PhongBans
{
    public class CreateUpdatePhongBanDtoValidator : AbstractValidator<CreateUpdatePhongBanDto>
    {
        public CreateUpdatePhongBanDtoValidator()
        {
            RuleFor(x => x.TenPhongBan).NotEmpty().MaximumLength(100);
            RuleFor(x => x.MoTa).NotEmpty().MaximumLength(250);
        }
    }
}
