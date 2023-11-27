
namespace Application.Common.Dto
{
    public class EmployeeDto
    {
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public required DateTime BirthDate { get; set; }
        public required int DepartmendId { get; set; }
    }
}
