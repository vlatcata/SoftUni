using System.IO;
using OnlineShop.Core;
using OnlineShop.IO;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;

namespace OnlineShop
{
    public class StartUp
    {
        static void Main()
        {
            IComponent component = new Motherboard(1, "idik", "asd", 20m, 20, 1);
            IPeripheral peripheral = new Headset(1, "idik", "asd", 20m, 20, "idk");
            IComputer computer = new DesktopComputer(2, "asd", "ddsds", 200);
            computer.AddComponent(component);
            computer.AddPeripheral(peripheral);
            computer.ToString();

            string pathFile = Path.Combine("..", "..", "..", "output.txt");
            File.Create(pathFile).Close();

            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            ICommandInterpreter commandInterpreter = new CommandInterpreter();
            IController controller = new Controller();

            IEngine engine = new Engine(reader, writer, commandInterpreter, controller);
            engine.Run();
        }
    }
}
