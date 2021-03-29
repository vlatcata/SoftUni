using System;
using System.Collections.Generic;
using System.Text;

namespace Prototype
{
    class SandwitchMenu
    {
        private Dictionary<string, SandwitchPrototype> sandwitches = new Dictionary<string, SandwitchPrototype>();

        public SandwitchPrototype this[string name]
        {
            get { return sandwitches[name]; }
            set { sandwitches.Add(name, value); }
        }
    }
}
