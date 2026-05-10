namespace StudentManagementApp.Models
{
    public class Group:BaseEntity
    {
        public string Name { get; set; }
        public List<Student> Students { get; set; }
    }
}
