namespace SergRasKoin.Features.DtoModels.Course
{
    public sealed record EditCourse
    {
        public Guid? Isnnode { get; init; }

        public double? course { get; init; }

        public DateTime? dateTime { get; init; }
    }
}
