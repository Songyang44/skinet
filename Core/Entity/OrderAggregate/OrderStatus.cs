using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Core.Entity.OrderAggregate
{
    public enum OrderStatus
    {
        [EnumMember(Value ="Pending")]
        Pending,
        [EnumMember(Value ="Payment Recevied")]
        PaymentRecevied,
        [EnumMember(Value ="Payment Failed")]
        PaymentFailed
    }
}