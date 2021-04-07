using DevvFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevvFramework.Entities.Concrete
{
    public class Category : IEntity
    {
        public virtual int Id { get; set; }
        public virtual string CategoryName { get; set; }
    }
}
