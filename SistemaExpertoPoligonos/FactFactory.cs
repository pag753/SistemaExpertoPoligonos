using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaExpertoPoligonos
{
    internal static class FactFactory
    {
        internal static IFact Fact(IFact f, Motor m)
        {
            IFact newFact;
            if(f.GetType().Equals(typeof(IntFact)))
            {
                // Es un hecho de valor entero
                int value = m.AskIntValue(f.Question());
                newFact = new IntFact(f.Name(), value, null, 0);
            }
            else
            {
                // Es un hecho de valor booleano
                bool value = m.AskIntValue(f.Question());
                newFact = new IntFact(f.Name(), value, null, 0);
            }
            return newFact;
        }               
    }
}
