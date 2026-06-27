using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKKDotNetCore.ConsoleApp.Models
{
    internal class BlogDapperDataModel
    {
        public int BlogId { get; set;}
        public string BlogTitle { get; set; }
        public string BlogAuthor { get; set; }
        public string BlogContent { get; set; }

    }

    [Table(name: "Tbl_Blog")]
    internal class BlogDataModel
    {
        [Key]
        [Column(name: "BlogId")]
        public int BlogId { get; set; }


        [Column(name: "BlogTitle")]
        public string BlogTitle { get; set; }


        [Column(name: "BlogAuthor")]
        public string BlogAuthor { get; set; }


        [Column(name: "BlogContent")]
        public string BlogContent { get; set; }


        [Column(name: "DeleteFlag")]
        public bool DeleteFlag { get; set; }

    }
}
