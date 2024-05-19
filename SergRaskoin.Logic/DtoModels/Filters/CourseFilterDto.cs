using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SergRaskoin.Logic.DtoModels.Filters
{
    public sealed record CourseFilterDto
    {
        public uint course { get; set; }

        public string dateTime { get; set; }
    }
}
