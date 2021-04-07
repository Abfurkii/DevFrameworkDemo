using DevvFramework.Entities.Concrete;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevvFramework.DataAccess.Concrete.Nhibernate.Mappings
{
    public class CategoryMap : ClassMap<Category>
    {
        public CategoryMap()
        {
            Table("Categories");
            LazyLoad();

            Id(x => x.Id).Column("CategoryID");
            Map(x => x.CategoryName).Column("CategoryName");
        }
    }
}
