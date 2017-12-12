using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaExpertoPoligonos
{
    class BoolFact : IFact
    {
        protected String name;
        public String Name()
        {
            return name;
        }

        protected bool value;
        public object Value()
        {
            return value;
        }

        protected int level;
        public int Level()
        {
            return level;
        }

        public void SetLevel(int l)
        {
            level = l;
        }

        protected String question = null;
        public String Question()
        {
            return question;
        }

        public BoolFact(String _name,bool _value, String _question=null,int _level=0)
        {
            name = _name;
            value = _value;
            question = _question;
            level = _level;
        }

        public override string ToString()
        {
            String res = "";
            if(!value)
            {
                res += "!";
            }
            res += name + "=" + value + "(" + level + ")";
            return res;
        }
    }
}