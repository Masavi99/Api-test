using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ApiTesting.EF.Models
{
    public class News
    {
        [Key]   
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime Date { get; set; }
        //category foreign key
        [ForeignKey("Category")]
        public int Cat_Id { get; set; }
        [JsonIgnore]
        public virtual Category Category { get; set; }
    }
}