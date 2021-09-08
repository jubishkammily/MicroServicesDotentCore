
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Orange.Services.ShoppingCartAPI.Model
{
    public class CartDetails
    {
        public int CartDetailsId { get; set; }


        // this is the syntax for adding foreign key  CartHeaderId is a foreign key to CartHeader table
        public int CartHeaderId { get; set; }
        [ForeignKey("CartHeaderId")]
        public virtual CartHeader CartHeader { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
        public int Count { get; set; }
    }
}
