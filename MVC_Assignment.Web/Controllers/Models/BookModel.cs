using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using MVC_Assignment_1.Helpers;
using Microsoft.AspNetCore.Http;

namespace MVC_Assignment_1.Models
{
    public class BookModel
    {
        public int Id { get; set; }




        //[DataType(DataType.DateTime)] // DataTime.Date, DataType.Password, DataType.EmailAddress
        //[Display(Name ="Choose date and time")]
        //[MyCustomValidation(ErrorMessage ="This is custom error message")]
        [MyCustomValidation("abc")]
        public string MyField { get; set; }


        [StringLength(100, MinimumLength = 5)]
        [Required(ErrorMessage ="Pleaseenter the title of your book")]
        public string Title { get; set; }

        [Required(ErrorMessage ="Please enter the author name")]
        public string Author { get; set; }

        [StringLength(500, MinimumLength = 30)]
        public string Description { get; set; }


        public string Catagory { get; set; }

        //[Required(ErrorMessage ="Please select the language of your book")]
        //public string Language { get; set; }

        //public int Language { get; set; }

        public int LanguageId { get; set; }


        public string Language { get; set; }


        [Display(Name ="Total pages of book")]
        [Required(ErrorMessage ="Please enter total number of pages")]
        public int? TotalPages { get; set; }


        [Display(Name = "Choose the cover photo of your book")]
        [Required]
        public IFormFile CoverPhoto { get; set; }


        public string CoverImageUrl { get; set; }


        [Display(Name = "Choose the cover photo of your book")]
        [Required]
        public IFormFileCollection GalleryFiles { get; set; }


        public List<GalleryModel> Gallery { get; set; }




        [Display(Name = "Upload Your Book in Pdf format")]
        [Required]
        public IFormFile BookPdf { get; set; }
        public string BookPdfUrl { get; set; }


    }
}
