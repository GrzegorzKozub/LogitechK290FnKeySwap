namespace GrzegorzKozub.LogitechK290FnKeySwap
{
    using System;

    internal class KeyboardNotFoundException : Exception
    {
        public KeyboardNotFoundException(string message)
            : base(message)
        {
        }
    }
}
