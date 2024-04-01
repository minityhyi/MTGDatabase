using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace magicDatabase.Commands
{
    public interface ICommand
    {
    }

    public interface ISyncCommand : ICommand
    {
        int Execute(string[] args);
    }
}
