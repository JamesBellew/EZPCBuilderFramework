using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EZPCBuilder.Models
{
    public class Order
    {
        [BsonId]
        public ObjectId ID { get; set; }

        [BsonElement("user")]
        public string UserID { get; set; }

        [BsonElement("pcs")]
        public List<PC> ItemsOrdered { get; set; }

        [BsonElement("order_date")]
        public DateTime OrderDate { get; set; }

        [BsonElement("delivery_address")]
        public Address DeliveryAddress { get; set; }

        [BsonElement("total_cost")]
        public double TotalCost { get; set; }

    }
}
