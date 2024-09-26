namespace Ivanov_Leonid_KT_44_21.Models
{
    public class Student
    {
        public int GroupId { get; set; }

        public int StudentId {get; set;}

        public string? FirstName { get; set;}

        public string? LastName { get; set;} 

        public string? MiddleName { get; set;}

        public Group? Group { get; set;}
    }
}
