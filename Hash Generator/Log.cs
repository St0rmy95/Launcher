using System;

namespace Hash_Generator
{
    enum Loglevel
    {
        Normal,
        Warning,
        Error
    }

    class Log
    {
        public static void Write(string Text, Loglevel lvl = Loglevel.Normal)
        {
            switch (lvl)
            {
                case Loglevel.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case Loglevel.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case Loglevel.Normal:
                default:
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
            }

            Console.WriteLine(Text);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public static void Error(string Text)
        {
            Write(Text, Loglevel.Error);
        }


        public static void Warning(string Text)
        {
            Write(Text, Loglevel.Warning);
        }
    }
}
