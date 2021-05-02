using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EZPCBuilder.Models
{
    public class Basket
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("AspNetUsers")]
        public string UserID { get; set; }

        [ForeignKey("PC")]
        public int PCID { get; set; }

        public virtual IdentityUser User { get; set; }

        public virtual PC PC { get; set; }

        public Basket AddToBasket(IdentityUser User, int PCID)
        {
            Basket basket = null;


            return basket;
        }

        public static List<PC> GetUserBasket(string Id)
        {
            List<PC> itemsInBasket = new List<PC>();
            

            return null;
        }
    }
}
