using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace VietLife.TuongTac.Insurer.SEOs
{
    public class SeoConfigInListDto : EntityDto<Guid>
    {
        public string PageKey { get; set; } = string.Empty;
        public string SeoTitle { get; set; } = string.Empty;
        public string? SeoDescription { get; set; }
        public string? Robots { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
