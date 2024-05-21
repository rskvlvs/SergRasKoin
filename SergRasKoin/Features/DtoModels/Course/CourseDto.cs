using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace SergRasKoin.Features.DtoModels.Course
{
    public sealed record CourseDto
    {
        public Guid? Isnnode { get; init; }

        public double? course { get; init; }

        public DateTime? dateTime { get; init; }
    }
}
