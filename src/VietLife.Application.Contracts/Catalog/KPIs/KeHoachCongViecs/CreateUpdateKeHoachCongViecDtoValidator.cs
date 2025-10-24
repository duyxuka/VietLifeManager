using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VietLife.Catalog.KPIs.KeHoachCongViecs
{
    public class CreateUpdateKeHoachCongViecDtoValidator : AbstractValidator<CreateUpdateKeHoachCongViecDto>
    {
        public CreateUpdateKeHoachCongViecDtoValidator()
        {
            RuleFor(x => x.TenKeHoach).NotEmpty().MaximumLength(100);
            RuleFor(x => x.MoTa).NotEmpty().MaximumLength(250);
        }
    }
}
