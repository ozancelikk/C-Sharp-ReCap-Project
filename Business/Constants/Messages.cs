using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public class Messages
    {
        public static string CarAdded = "Araç eklendi";
        public static string CarNameInvalid = "Araç İsmi geçersiz";
        internal static string MaintenanceTime="Sistem Bakımda";
        internal static string CarsListed="Araçlar Listelendi";
        public static string UserAdded = "Kullanıcı Eklendi.";
        internal static string UserNameInvalid= "Kullanıcı Oluşturulmadı";
        internal static string InvalidRental;
        internal static string RentalAdded;
        internal static string CustomerAdded;
        internal static string BrandNameInvalid;
        internal static string BrandAdded;
        internal static string BrandDeleted;
        internal static string BrandUpdated;
        internal static string ColorAdded;
        internal static string ColorDeleted;
        internal static string ColorUpdated;

        public static string ColorNameInvalid { get; internal set; }
    }
}
