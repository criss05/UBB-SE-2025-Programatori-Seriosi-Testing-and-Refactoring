using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team3.Entities
{
    public class Notification
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public DateTime DeliveryDateTime { get; set; }
        public string Message { get; set; }

        public Notification(int id, int userId, DateTime deliveryDateTime, string message)
        {
            Id = id;
            UserId = userId;
            DeliveryDateTime = deliveryDateTime;
            Message = message;
        }

        public Notification(int userId, DateTime deliveryDateTime, string message)
        {
            UserId = userId;
            DeliveryDateTime = deliveryDateTime;
            Message = message;
        }

        public override string ToString()
        {
            return $"[Notification] ID: {Id}, Delivery: {DeliveryDateTime}, Message: {Message}";
        }
    }
}

