using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaExpertoPoligonos
{
    public interface HumanInterface
    {
        int AskIntValue(String question);
        bool AskBoolValue(String question);
        void PrintFacts(List<IFact> facts);
        void PrintValues(List<Rule> rules);
    }
}
