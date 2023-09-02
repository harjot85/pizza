namespace BestbitePizza.Models.DataModels
{
    public class ClientQuery
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Query { get; set; } = string.Empty;

    }
}
