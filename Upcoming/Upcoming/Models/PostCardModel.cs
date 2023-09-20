using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Upcoming.Models
{
    public class PostCardModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        //public string ImageURL { get; set; }
        public string SourceURL { get; set; }

        public PostCardModel(string title, string description, string sourceURL)
        {
            Title = title;
            Description = description;
            SourceURL = sourceURL;
        }
    }
}
