using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaExpertoPoligonos
{
    public class Rule
    {
        public List<IFact> Premises { get; set; }
        public IFact Conclusion { get; set; }
        public String Name { get; set; }
        public Rule (String _name, List<IFact> _premises, IFact _conclusion)
        {
            Name = _name;
            Premises = _premises;
            Conclusion = _conclusion;
        }
        public override string ToString()
        {
            return Name + ":IF(" + String.Join("AND", Premises) + ")THEN" + Conclusion.ToString();
        }
    }
}
