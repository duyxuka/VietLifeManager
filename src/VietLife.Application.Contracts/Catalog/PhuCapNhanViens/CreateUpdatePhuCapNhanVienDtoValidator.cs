using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VietLife.Catalog.PhuCapNhanViens
{
    public class CreateUpdatePhuCapNhanVienDtoValidator : AbstractValidator<CreateUpdatePhuCapNhanVienDto>
    {
        public CreateUpdatePhuCapNhanVienDtoValidator()
        {
            RuleFor(x => x.TenPhuCap).NotEmpty().MaximumLength(100);
        }
    }
}
