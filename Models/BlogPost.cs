using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DailyBlogger.Models
{
    public class BlogPost
    {
        [Key]
        public int blog_id { get; set; }
        public string blog_title { get; set; }
        public string content { get; set; }
        public DateTime blog_date { get; set; }
    }
}
