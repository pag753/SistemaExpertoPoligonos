using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaExpertoPoligonos
{
    internal class FactBase
    {
        protected List<IFact> facts;
        public List<IFact> Facts
        {
            get
            {
                return facts;
            }
        }
        public FactBase()
        {
            facts = new List<IFact>();
        }
        public void Clear()
        {
            facts.Clear();
        }
        public void AddFact(IFact f)
        {
            facts.Add(f);
        }
        public IFact Search(String _name)
        {
            return facts.FirstOrDefault(x => x.Name().Equals(_name));
        }
        public Object Value(String _name)
        {
            IFact f = facts.FirstOrDefault(x => x.Name().Equals(_name));
            if(f!=null)
            {
                return f.Value();
            }
            else
            {
                return null;
            }
        }

    }
}
