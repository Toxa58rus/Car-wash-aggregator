using System;
using System.Collections.Generic;
using System.Text;
using CarWashAggregator.Common.Domain.Contracts;

namespace CarWashAggregator.Common.Domain.DTO.Order.Querys.Request
{
    public class RequestOrderByReservationTime :Query
    {
        public DateTime ReservationDate { get; set; }
        public DateTime? ReservationTime { get; set; }

    }
}
