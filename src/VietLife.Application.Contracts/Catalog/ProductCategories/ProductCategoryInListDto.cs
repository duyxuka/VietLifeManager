using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace VietLife.Catalog.ProductCategories
{
    public class ProductCategoryInListDto : EntityDto<Guid>
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public int SortOrder { get; set; }
        public bool IsActive { get; set; }
        public string CoverPicture { get; set; }
        public bool Visibility { get; set; }
    }
}
