using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SergRasKoin.Features.DtoModels.Course
{
    public sealed record CourseDto
    {
        public Guid? Isnnode { get; init; }

        public uint? course { get; init; }

        public string? dateTime { get; init; }
    }
}
