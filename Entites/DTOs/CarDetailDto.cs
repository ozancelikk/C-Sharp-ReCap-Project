using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entites.DTOs
{
    public class CarDetailDto:IDto

    {
        public int CarsId { get; set; }
        public string Description { get; set; }
        public string ColorName { get; set; }
        public string BrandsName { get; set; }
        public int  ModelYears { get; set; }
        public int DailyPrice { get; set; }
    }
}
