using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program {
  public static void Main (string[] args) {

    var bot = new Bot();
    bot.RunAsync().GetAwaiter().GetResult();
  }
}