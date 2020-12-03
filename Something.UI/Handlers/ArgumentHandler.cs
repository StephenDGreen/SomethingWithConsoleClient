using Something.UI.Models;
using System;

namespace Something.UI
{
    public abstract class ArgumentHandler : IHandler
    {
        private IHandler Next { get; set; }

        public virtual void Handle(string[] args, Token token)
        {
            if (Next == null)
            {
                throw new ArgumentException();
            }
            Next.Handle(args, token);
        }

        public IHandler SetNext(IHandler next)
        {
            Next = next;

            return Next;
        }
    }
}
