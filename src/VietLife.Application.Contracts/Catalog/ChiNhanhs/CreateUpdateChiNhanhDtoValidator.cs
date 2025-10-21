using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VietLife.Catalog.ChiNhanhs
{
    public class CreateUpdateChiNhanhDtoValidator : AbstractValidator<CreateUpdateChiNhanhDto>
    {
        public CreateUpdateChiNhanhDtoValidator()
        {
            RuleFor(x => x.TenChiNhanh).NotEmpty().MaximumLength(100);
            RuleFor(x => x.MoTa).NotEmpty().MaximumLength(250);
        }
    }
}
