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
        
        internal static IFact Fact(string factStr)
        {
            factStr = factStr.Trim();
            if(factStr.Contains("="))
            {
                // Existe un símbolo '=' por lo que es un IntFactor,
                // separamos el nombre del valor
                String[] nameValue=factStr.Split(new String[] { "=", "(", ")"}, StringSplitOptions.RemoveEmptyEntries);
                if(nameValue.Length>=2)
                {
                    String question = null;
                    if(nameValue.Length==3)
                    {
                        // Podemos pedir, y recuperar,
                        // la pregunta vinculada
                        question = nameValue[2].Trim();
                    }
                    return new IntFact(nameValue[0].Trim(), int.Parse(nameValue[1].Trim()), question);
                }
                else
                {
                    // Sintaxis incorrecta
                    return null;
                }
            }
            else
            {
                // No hay símbolo igual, es un hecho de la clase BoolFact
                bool value = true;
            }
        }               
    }
}
