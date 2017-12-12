using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaExpertoPoligonos
{
    public interface IFact
    {
        String Name();
        Object Value();
        int Level();
        String Question();

        void SetLevel(int p);
    }
}
