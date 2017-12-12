using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaExpertoPoligonos
{
    internal class IntFact: IFact
    {
        protected String name, question=null;
        protected int value, level;

        public String Name()
        {
            return name;
        }
        public object Value()
        {
            return value;
        }
        public int Level()
        {
            return level;
        }
        public String Question()
        {
            return question;
        }
        public void SetLevel(int l)
        {
            level = l;
        }
        public IntFact(String _name, int _value, String _question=null, int _level=0)
        {
            name = _name;
            value = _value;
            question = _question;
            level = _level;
        }
        public override string ToString()
        {
            return name + "=" + value + "(" + level + ")";
        }
    }
}
