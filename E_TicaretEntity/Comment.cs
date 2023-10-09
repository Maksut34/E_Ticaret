using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_TicaretEntity
{
    public class Comment
    {
        [Key]
        public int CommentID { get; set; }
        public DateTime datetime { get; set; }
        public string comment { get; set; }
        public string Customerusername { get; set; }
        public string Customeremail { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
