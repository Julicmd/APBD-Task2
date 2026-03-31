using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APBD_TASK2.Models.Equipment;
using APBD_TASK2.Rentals;
using APBD_TASK2.Users;

namespace APBD_TASK2.Database
{
    public class Singleton
    {
        private static Singleton? _instance;
        public static Singleton Instance
        {
            get
            {
                _instance ??= new Singleton();
                return _instance;
            }
        }

        private Singleton() { }

        public static List<User> Users { get; } = new();
        public static List<Equipment> Equipments { get; } = new();
        public static List<Rental> Rentals { get; } = new();
    }
}
