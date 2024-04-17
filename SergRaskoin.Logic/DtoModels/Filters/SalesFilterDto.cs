using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SergRaskoin.Logic.DtoModels.Filters
{
    public sealed record SalesFilterDto
    {
        //Разобраться с тем, для чего  у него описано поле код и могу ли я описать это так!!!
        public long Count_Of_Coins { get; init; }
    }
}
