
using System.Collections.Generic;

namespace Vidly.Models.ViewModels
{
    public class MovieFormViewModel
    {
        public Movie Movie { get; set; }
        public IEnumerable<GenreLkp> GenreLkps { get; set; }
    }
}