namespace LoxotroniAPI.DTO
{
    public partial class UserDTO
    {
        public int Id { get; set; }

        public string Login { get; set; } = null!;

        public string Password { get; set; } = null!;

        public decimal Balance { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public bool Win { get; set; }
    }
    }
