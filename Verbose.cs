using System;

namespace Lux
{
    class Verbose
    {
        public bool active = false;

        public Verbose(bool verbose)
        {
            this.active = verbose;
        }

        public void WriteLine(string s)
        {
            if (active)
            {
                Console.WriteLine(s);
            }
        }
    }
}
