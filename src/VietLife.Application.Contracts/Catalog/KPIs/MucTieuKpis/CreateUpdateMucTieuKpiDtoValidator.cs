using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VietLife.Catalog.KPIs.MucTieuKpis
{
    public class CreateUpdateMucTieuKpiDtoValidator : AbstractValidator<CreateUpdateMucTieuKpiDto>
    {
        public CreateUpdateMucTieuKpiDtoValidator()
        {
            RuleFor(x => x.TenMucTieu).NotEmpty().MaximumLength(100);
        }
    }
}
