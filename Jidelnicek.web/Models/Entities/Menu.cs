namespace Jidelnicek.web.Models.Entities
{
    public class Menu

    {

        public Guid Id { get; set; }
        public string? Dish { get; set; }
        public string? Grams { get; set; }
        public string? Price { get; set; }
        public bool Subscribed { get; set; }
        public int Number {  get; set; }
    }
}
