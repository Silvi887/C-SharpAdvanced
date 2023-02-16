using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace ShoeStore
{
    public class ShoeStore
    {
        private List<Shoe> shoes;
        public ShoeStore(string name, int storageCapacity)
        {
            this.Name = name;
            this.StorageCapacity = storageCapacity;
           shoes= new List<Shoe>();//initialize with new instance
        }

        public string Name { get; set; }
        public	int StorageCapacity { get; set; }
        public List<Shoe> Shoes{ get { return shoes; } }

        public int Count { get { return shoes.Count; } }//only get Property
    
        public string AddShoe(Shoe shoe)
        {
            if (Shoes.Count == StorageCapacity)
            {
                return "No more space in the storage room.";
            }
            else
            {
                shoes.Add(shoe);
                return $"Successfully added {shoe.Type} {shoe.Material} pair of Shoesto the store." ;
            }
        }

        public int RemoveShoes(string material)
        {
            List<Shoe> removedSgoes = new List<Shoe>();
            for (int i = 0; i < shoes.Count; i++)
            {
                if (shoes[i].Material == material)
                {
                    removedSgoes.Add(shoes[i]);
                    shoes.RemoveAt(i);
                    i--;
                }

            }

            return removedSgoes.Count;
        }

        public	List<Shoe> GetShoesByType(string type)
        {
            List<Shoe> shoeByGivenType 
            = shoes.FindAll(x => x.Type.ToLower() == type.ToLower());

            return shoeByGivenType;   
        }
        public 	Shoe GetShoeBySize(double size)
        {

            Shoe shoe3 = shoes.FirstOrDefault(s => s.Size == size);
            return shoe3;
        }

        public string StockList(double size, string type)
        {

            StringBuilder sb = new StringBuilder();
            IEnumerable<Shoe> StockL =
                shoes.Where(s => s.Size == size && s.Type == type);
            if (StockL.Count() > 0)
            {

                sb.AppendLine($"Stock list for size {size} - {type} shoes:");
                foreach (var shoes in StockL)
                {

                    sb.AppendLine($"{shoes.ToString()}");

                }
                return sb.ToString().Trim();

            }
            else
            {
               return "No matches found!";
            }

        }


       

    }
}
