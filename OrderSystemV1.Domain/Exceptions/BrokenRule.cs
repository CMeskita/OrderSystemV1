namespace OrderSystemV1.Domain.Exceptions
{
    public class BrokenRule
    {

        public BrokenRule(string field, string description)
        {
            Field = field;
            Description = description;
        }

        public string Field { get; set; }

        public string Description { get; set; }
    }
}
