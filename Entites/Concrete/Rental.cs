﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Entites.Concrete
{
    public class Rental
    {
        public int Id { get; set; }
        public int CarId{ get; set; }
        public int CustomerId { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}