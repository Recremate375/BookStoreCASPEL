﻿namespace TestTaskCASPEL.Models
{
    public class Orders
    {
        public int ID { get; set; }
        public List<Books> Books { get; set; } = new();
    }
}
