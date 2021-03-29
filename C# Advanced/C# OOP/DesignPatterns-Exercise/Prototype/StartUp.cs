using System;

namespace Prototype
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SandwitchMenu sandwitchMenu = new SandwitchMenu();

            sandwitchMenu["BLT"] = new Sandwitch("Wheat", "Bacon", "", "Lettuce, Tomato");
            sandwitchMenu["PB&J"] = new Sandwitch("White", "", "", "Peanut Butter, Jelly");
            sandwitchMenu["Turkey"] = new Sandwitch("Rye", "Tyrkey", "Swiss", "Lettuce, Onion, Tomato");

            sandwitchMenu["LoadedBLT"] = new Sandwitch("Wheat", "Tyrkey, Bacon", "American", "Lettuce, Tomato, Onion, Olives");
            sandwitchMenu["ThreeMeatCombo"] = new Sandwitch("Rye", "Tyrkey, Ham, Salami", "Provolone", "Lettuce, Onion");
            sandwitchMenu["Vegeterian"] = new Sandwitch("Wheat", "", "", "Lettuce, Onion, Tomato, Olives, Spinach");

            Sandwitch s1 = sandwitchMenu["BLT"].Clone() as Sandwitch;
            Sandwitch s2 = sandwitchMenu["ThreeMeatCombo"].Clone() as Sandwitch;
            Sandwitch s3 = sandwitchMenu["Vegeterian"].Clone() as Sandwitch;

        }
    }
}
