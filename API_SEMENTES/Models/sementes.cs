namespace API_SEMENTES.Models
{
    public class sementes
    {
        public string? seedType { get; set; }
        public double seedLevel { get; set; }
        public string? seedStatus { get; set; }
        public DateTime plantingDate { get; set; }

        internal static IEnumerable<object> GroupBy(Func<object, object> p)
        {
            throw new NotImplementedException();
        }
    }
}
