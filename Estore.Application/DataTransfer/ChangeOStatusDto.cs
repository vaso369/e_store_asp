using Estore.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Estore.Application.DataTransfer
{
    public class ChangeOStatusDto
    {
        public int OrderId { get; set; }
        public OrderStatus Status { get; set; }
    }
}
