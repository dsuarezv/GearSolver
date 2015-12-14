using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycloidGenerator
{
    public interface ISolver
    {
        IList<SolverParameter> GetParams();
        void Run(IExportClient client);
    }
}
