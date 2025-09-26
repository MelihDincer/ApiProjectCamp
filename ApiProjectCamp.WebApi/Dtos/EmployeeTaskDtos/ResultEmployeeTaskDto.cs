namespace ApiProjectCamp.WebApi.Dtos.EmployeeTaskDtos
{
    public class ResultEmployeeTaskDto
    {
        public int EmployeeTaskId { get; set; }
        public int EmployeeTaskName { get; set; }
        public byte StatusValue { get; set; }
        public DateTime AssignDate { get; set; }
        public DateTime DueDate { get; set; }
        public string Priority { get; set; }
        public string TaskStatus { get; set; }
        public int ChefId { get; set; }
        public string ChefName { get; set; }
    }
}
