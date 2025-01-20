namespace Library_management_system_API.Dto.Manager
{
    public class ManagerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public DateTime Birthday { get; set; }

        public string Username { get; set; }

        public int TotalBooks   { get; set; }

        public int TotalClients  { get; set; }
    }
}
