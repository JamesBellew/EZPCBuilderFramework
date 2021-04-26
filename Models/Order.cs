using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZPCBuilder.Models
{
    public class Order
    {
        private String orderId;
        // private User user;
        private int userId;
        private String userName;
        private Address billingAddress;
        private Address shippingAddress;
        private List<PC> orderItems;
        private DateTime orderDate;
        private DateTime deliveryDate;
        private double totalCost;
        private String paymentMethod;
    }
}
