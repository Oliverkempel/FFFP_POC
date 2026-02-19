namespace FFFP_POC_Core
{
    public class Product
    {
        public Product(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return $"{Name} {Description}";
        }
    }
}
