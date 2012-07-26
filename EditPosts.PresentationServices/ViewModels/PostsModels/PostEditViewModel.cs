using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using EditPosts.Domain.Models;

namespace EditPosts.PresentationServices.ViewModels.PostsModels
{
    public class PostEditViewModel
    {
        public int Id { get; set; }

        public int HitCount { get; set; }

        public DateTime Date { get; set; }

        [Required]
        public string Name { get; set; }

        public string Tags { get; set; }

        public string Body { get; set; }
    }
}