namespace SberBanOnline.Dtos.GG
{
    public class CreateCardRequestDto
    {
        public string Number { get; set; } = null!;

        public DateOnly DateStart { get; set; }

        public DateOnly DateEnd { get; set; }

        public int Cvv { get; set; }

        public long Balance { get; set; }

        public int CardTypeId { get; set; }

        public int UserId { get; set; }
    }
}
