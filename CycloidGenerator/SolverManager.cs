using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CycloidGenerator
{
    public class SolverManager
    {
        private static List<ISolver> mSolvers;


        public static IList<ISolver> GetSolvers()
        {
            if (mSolvers == null) RegisterSolversInAssembly(Assembly.GetExecutingAssembly());

            return mSolvers;
        }

        public static void RegisterSolversInAssembly(Assembly a)
        {
            if (mSolvers == null) mSolvers = new List<ISolver>();

            foreach (var t in a.GetTypes())
            {
                if (t.GetTypeInfo().GetInterface("ISolver") != null)
                {
                    CreateSolverInstance(t);
                }
            }
        }

        private static void CreateSolverInstance(Type t)
        {
            var constructor = t.GetConstructor(new Type[] { });
            if (constructor == null) return;    // No parameterless constructor, automatic creation not possible.

            var newSolver = (ISolver)constructor.Invoke(new object[] { });
            mSolvers.Add(newSolver);
        }
    }
}
