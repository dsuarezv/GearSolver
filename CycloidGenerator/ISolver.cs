using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycloidGenerator
{
    public interface ISolver
    {
        string Name { get; }
        string Description { get; }
        IList<SolverParameter> GetParams();
        void Run(IExportClient client);
        
    }
}
