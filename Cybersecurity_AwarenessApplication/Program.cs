using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Cybersecurity_AwarenessApplication
{
    class Program
    {
        static void Main(string[] args)
        {

           

            //Call voice greeting classs
            new voice_greeeting() { };

             Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("█████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████\r\n█▌╦ ╦╔═╗╦  ╔═╗╔═╗╔╦╗╔═╗  ╔╦╗╔═╗  ╔╦╗╦ ╦╔═╗  ╔═╗╦ ╦╔╗ ╔═╗╦═╗  ╔═╗╔═╗╔═╗╦ ╦╦═╗╦╔╦╗╦ ╦  ╔═╗╦ ╦╔═╗╦═╗╔═╗╔╗╔╔═╗╔═╗╔═╗  ╔╗ ╔═╗╔╦╗▐█\r\n█▌║║║║╣ ║  ║  ║ ║║║║║╣    ║ ║ ║   ║ ╠═╣║╣   ║  ╚╦╝╠╩╗║╣ ╠╦╝  ╚═╗║╣ ║  ║ ║╠╦╝║ ║ ╚╦╝  ╠═╣║║║╠═╣╠╦╝║╣ ║║║║╣ ╚═╗╚═╗  ╠╩╗║ ║ ║ ▐█\r\n█▌╚╩╝╚═╝╩═╝╚═╝╚═╝╩ ╩╚═╝   ╩ ╚═╝   ╩ ╩ ╩╚═╝  ╚═╝ ╩ ╚═╝╚═╝╩╚═  ╚═╝╚═╝╚═╝╚═╝╩╚═╩ ╩  ╩   ╩ ╩╚╩╝╩ ╩╩╚═╚═╝╝╚╝╚═╝╚═╝╚═╝  ╚═╝╚═╝ ╩ ▐█\r\n█████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████");
            Console.ResetColor();

            //call image display class
           // new image_display() { };

            //call response system class
            new response_system() { };


        }
    }
}
