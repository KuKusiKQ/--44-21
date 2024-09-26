namespace Ivanov_Leonid_KT_44_21.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string? Title { get; set; }
        public int GroupId { get; set; }
        public Group? Group { get; set; }
    }
}