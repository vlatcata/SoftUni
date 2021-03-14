using System;
using System.Collections.Generic;
using System.Text;

namespace P04.Recharge
{
    public abstract class Worker : IRechargeable, ISleeper
    {
        private string id;
        private int workingHours;

        public Worker(string id)
        {
            this.id = id;
        }

        public void Work(int hours)
        {
            this.workingHours += hours;
        }
        public abstract void Recharge();

        public abstract void Sleep();

    }
}
