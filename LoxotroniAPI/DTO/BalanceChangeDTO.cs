namespace LoxotroniAPI.DTO
{
    public partial class BalanceChangeDTO
    {
        public int Id { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public int UserId { get; set; }

        public decimal Value { get; set; }
    }
}
