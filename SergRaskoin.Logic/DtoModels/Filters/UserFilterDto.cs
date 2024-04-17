using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SergRaskoin.Logic.DtoModels.Filters
{
	public class UserFilterDto
	{
		public string Name { get; init; }

		public string Surname { get; init; }

		public string Email { get; init; }
	}
}
