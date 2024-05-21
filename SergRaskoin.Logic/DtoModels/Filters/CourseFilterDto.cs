using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SergRaskoin.Logic.DtoModels.Filters
{
    public sealed record CourseFilterDto
    {
        public double course { get; set; }

        public DateTime dateTime { get; set; }
    }
}
