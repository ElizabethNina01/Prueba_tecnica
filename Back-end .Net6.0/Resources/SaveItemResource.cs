

using System.ComponentModel.DataAnnotations;
using prueba_back.Resources;

namespace prueba_back.Resources
{
    public class SaveItemResource 
    {
        [Required]
        public string Cod { get; set; }
        [Required]
        public string NameArt { get; set; }
        [Required]
        public string DescArt { get; set; }
        [Required]
        public int Cant { get; set; }
        
    }
}