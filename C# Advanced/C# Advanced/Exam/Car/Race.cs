﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheRace
{
    public class Race
    {
        private List<Racer> data;

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count { get { return data.Count(); } }

        public Race(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            data = new List<Racer>();
        }

        public void Add(Racer racer)
        {
            if (data.Count < Capacity)
            {
                data.Add(racer);
            }
        }

        public bool Remove(string name)
        {
            if(data.Where(x => x.Name == name).Any())
            {
                data.Remove(data.Where(x => x.Name == name).FirstOrDefault());
                return true;
            }
            else
            {
                return false;
            }
        }

        public Racer GetOldestRacer()
        {
            return data.OrderByDescending(x => x.Age).FirstOrDefault();
        }

        public Racer GetRacer(string name)
        {
            return data.Where(x => x.Name == name).FirstOrDefault();
        }

        public Racer GetFastestRacer()
        {
            return data.OrderByDescending(x => x.Car.Speed).FirstOrDefault();
        }

        public string Report()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Racers participating at {Name}:");
            sb.AppendLine($"{String.Join(Environment.NewLine, data)}");

            return sb.ToString().TrimEnd();
        }
    }
}
