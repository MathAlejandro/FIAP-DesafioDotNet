namespace School.Blazor.DTO
{
    public class ClassDTO
    {
        public ClassDTO() { }

        public int Id { get; set; }
        public int CourseId { get; set; }
        public string Class { get; set; }
        public int Year { get; set; }
        public bool Active { get; set; }

    }
}
