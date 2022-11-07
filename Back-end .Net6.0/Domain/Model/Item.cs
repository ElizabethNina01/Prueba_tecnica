using System.Collections;
using System.Collections.Generic;
namespace prueba_back.Domain.Model
{
    public class Item
    {
        public int ID { get; set; }
        public string Cod { get; set; }
        public string NameArt { get; set; }
        public string DescArt { get; set; }
        public int Cant { get; set; }
    }
}