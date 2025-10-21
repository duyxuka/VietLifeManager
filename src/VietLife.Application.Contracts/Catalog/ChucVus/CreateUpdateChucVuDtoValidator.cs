using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VietLife.Catalog.ChucVus
{
    public class CreateUpdateChucVuDtoValidator : AbstractValidator<CreateUpdateChucVuDto>
    {
        public CreateUpdateChucVuDtoValidator()
        {
            RuleFor(x => x.TenChucVu).NotEmpty().MaximumLength(100);
            RuleFor(x => x.MoTa).NotEmpty().MaximumLength(250);
        }
    }
}
