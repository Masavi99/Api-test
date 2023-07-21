using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ApiTesting.EF.Models
{
    public class Category
    {
       
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public Category()
        {
            Newslist = new List<News>();
        }
   
        public virtual List<News>Newslist { get; set; }
    }
}