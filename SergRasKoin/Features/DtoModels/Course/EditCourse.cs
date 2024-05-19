namespace SergRasKoin.Features.DtoModels.Course
{
    public sealed record EditCourse
    {
        public Guid? Isnnode { get; init; }

        public uint? course { get; init; }

        public string? dateTime { get; init; }
    }
}
