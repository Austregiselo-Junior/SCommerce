using System.Collections.Generic;

namespace SCommerce.Main.Model.Entities
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string Image { get; set; }

        public List<string> ImagesFromProduct = new List<string>();
        public int Rating { get; set; }
        public string Description { get; set; }

        public Product(int iD, string name, float price, string image, List<string> imagesFromProducy, int rating, string description)
        {
            ID = iD;
            Name = name;
            Price = price;
            Image = image;
            ImagesFromProduct = imagesFromProducy;
            Rating = rating;
            Description = description;
        }

        public Product(int id, string name, float price, string image)
        {
            ID = id;
            Name = name;
            Price = price;
            Image = image;
        }

        public Product()
        {
        }
    }
}


