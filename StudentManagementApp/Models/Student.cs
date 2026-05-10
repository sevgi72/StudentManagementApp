namespace StudentManagementApp.Models
{
    public class Student:BaseEntity
    {
        public string FullName { get; set; }
        public int  Age { get; set; }
        public string  Email { get; set; }
        public Group Group { get; set; }
        public int GroupId { get; set; }
    }
}
