using System;

namespace MonoTest
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new MyGame())
                game.Run();
        }
    }
}
