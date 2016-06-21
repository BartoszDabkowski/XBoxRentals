namespace XBoxRentals.Dtos
{
    public class FileDto
    {
        public int Id { get; set; }
        public string ContentType { get; set; }
        public byte[] Bytes { get; set; }
    }
}