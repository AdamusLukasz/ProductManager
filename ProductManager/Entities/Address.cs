﻿namespace ProductManager.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? PostalCode { get; set; }
        public virtual Shop? Shop { get; set; }
    }
}