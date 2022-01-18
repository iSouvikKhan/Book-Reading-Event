using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Assignment.Web.Data
{
    public class Books
    {


        // These are the DataBase columns or Table columns

        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string Catagory { get; set; }

        //public string Language { get; set; }

        public int LanguageId { get; set; }

        public int TotalPages { get; set; }


        public string CoverImageUrl { get; set; }

        public string BookPdfUrl { get; set; }


        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatededOn { get; set; }


        public Language Language { get; set; }


        public ICollection<BookGallery> bookGallery { get; set; }


    }
}
