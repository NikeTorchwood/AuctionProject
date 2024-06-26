namespace Domain.Entities
{
    public class User: IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
    }
}
