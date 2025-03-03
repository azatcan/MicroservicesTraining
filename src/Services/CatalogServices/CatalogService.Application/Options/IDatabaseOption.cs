using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Application.Options
{
    public interface IDatabaseOption
    {
        public string CourseCollectionName { get; set; }
        public string CategoryCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
