using System;
using System.Collections.Generic;
using System.Text;
using CarWashAggregator.Common.Domain.Contracts;

namespace CarWashAggregator.Common.Domain.DTO.Order.Querys.Request
{
    public class RequestOrderByReservationTme :Query
    {
        public DateTime ReservationDate { get; set; }
        public int? ReservationTime { get; set; }

    }
}
