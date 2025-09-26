namespace ApiProjectCamp.WebApi.Entities
{
    public class Chef
    {
        public int ChefId { get; set; }
        public string ChefNameSurname { get; set; }
        public string ChefTitle { get; set; }
        public string ChefDescription { get; set; }
        public string ChefImageUrl { get; set; }
        public List<EmployeeTask> EmployeeTasks { get; set; }
    }
}
