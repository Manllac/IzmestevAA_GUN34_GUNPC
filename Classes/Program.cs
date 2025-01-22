using System;
using System.Collections.Generic;
using UnitWeapon;
using static Classes.Program;

namespace Classes
{
    internal static class Program
    {
        public struct Interval
        {
            private static Random random = new Random();

            public double Min { get; private set; }
            public double Max { get; private set; }

            public double Get
            {
                get
                {

                    return random.NextDouble() * (Max - Min) + Min;

                }
            }

            public Interval (int minValue, int maxValue)
            {
                if (minValue > maxValue)
                {
                    (minValue, maxValue) = (maxValue, minValue);
                    Console.WriteLine("Некорректные входные данные");
                }
                if (minValue<0)
                {
                    minValue = 0;
                    Console.WriteLine("Минимальные значение меньше 0");
                }
                
                if(maxValue<0)
                {
                    maxValue = 0;
                    Console.WriteLine("Максимальные значения иеньше 0");
                }

                if(minValue==maxValue)
                {
                    maxValue += 10;
                    Console.WriteLine("Значения min и max равны");
                }

                Min = minValue;
                Max = maxValue;
            }

            
        }

        public struct Room
        {
            public Unit Unit { get; private set; }
            public Weapon Weapon { get; private set; }

            public Room (Unit unit, Weapon weapon)
            {
                Unit = unit;
                Weapon = weapon;
            }
        }

        public class Dungeon
        {
            private Room[] _room;

            public Dungeon()
            {
                _room = new Room[]
                {
                new Room(new Unit("Воин", 10, 22), new Weapon("Меч", 15, 25)),
                new Room(new Unit("Маг", 5, 10), new Weapon("Посох", 12, 20)),
                new Room(new Unit("Монах", 8, 14), new Weapon("Перчатки", 14, 23))

                };
            }

            public void ShowRooms()
            {
                for (int i = 0; i < _room.Length; i++)
                {
                    var room = _room[i];
                    Console.WriteLine($"Комната {i + 1}:");
                    Console.WriteLine($"Юнит: {room.Unit.Name}");
                    Console.WriteLine($"Оружие: {room.Weapon.Name}");
                    Console.WriteLine("—");
                }

            }
            


        }

        static void Main()
        {
            Dungeon dungeon = new Dungeon();
            dungeon.ShowRooms();
            Console.ReadKey();
        }
    }
}
