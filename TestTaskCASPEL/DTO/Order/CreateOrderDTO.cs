﻿using TestTaskCASPEL.Models;

namespace TestTaskCASPEL.DTO.Order
{
    public class CreateOrderDTO
    {
        public List<Books>? Books { get; set; }
        public DateTime? OrderDate { get; set; }
    }
}
