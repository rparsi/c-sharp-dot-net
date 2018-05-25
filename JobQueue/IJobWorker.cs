using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleApp.JobQueue
{
    public interface IJobWorker
    {
        void Run();
    }
}
