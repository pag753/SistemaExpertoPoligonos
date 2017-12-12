using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaExpertoPoligonos
{
    public class Motor
    {
        private FactBase fDB;
        private RulesBase rDB;
        private HumanInterface ihm;

        public Motor(HumanInterface _ihm)
        {
            ihm = _ihm;
            fDB = new FactBase();
            rDB = new RulesBase();
        }       

        internal int AskIntValue(String p)
        {
            return ihm.AskIntValue(p);
        }

        internal bool AskIntBoolValue(String p)
        {
            return ihm.AskBoolValue(p);
        }

        private int CanApply(Rule r)
        {
            int maxLevel = -1;
            // Se comprueba si se cumple cada premisa
            foreach (IFact f in r.Premises)
            {
                IFact foundFact = fDB.Search(f.Name());
                if (foundFact == null)
                {
                    // Este hecho no existe en la base actualmente
                    if (f.Question() != null)
                    {
                        // Se le consulta al usuario
                        // y se agrega a la base
                        foundFact = FactFactory.Fact(f, this);
                        fDB.AddFact(foundFact);
                        maxLevel = Math.Max(maxLevel, 0);
                    }
                    else
                    {
                        // Se sabe que la regla no se aplica
                        return -1;
                    }
                }
                // Tenemos un hecho en la base, verificamos su valor
                if (!foundFact.Value().Equals(f.Value()))
                {
                    // No se corresponde
                    return -1;
                }
                else
                {
                    // Se corresponde
                    maxLevel = Math.Max(maxLevel, foundFact.Level());
                }
            }
            return maxLevel;
        }

        private Tuple<Rule, int> FindUsableRule(RulesBase rBase)
        {
            foreach (Rule r in rBase.Rules)
            {
                int level = CanApply(r);
                if (level != -1)
                {
                    return Tuple.Create(r, level);
                }
            }
            return null;
        }

        public void Solve()
        {
            // Se realiza una copia de las reglas existentes
            // + creación de una base de hechos vacía
            bool moreRules = true;
            RulesBase usableRules = new RulesBase();
            usableRules.Rules = new List<Rule>(rDB.Rules);
            fDB.Clear();
            // Mientras existan reglas para aplicar
            while (moreRules)
            {
                //Busca una regla para aplicar
                Tuple<Rule, int> t = FindUsableRule(usableRules);

                if (t != null)
                {
                    // Aplica la regla y agrega el nuevo hecho
                    // a la base
                    IFact newFact = t.Item1.Conclusion;
                    newFact.SetLevel(t.Item2 + 1);
                    fDB.AddFact(newFact);

                    // Elimina la regla de las reglas aplicables
                    usableRules.Remove(t.Item1);
                }
                else
                {
                    // Si no hay más reglas posibles: se detiene
                    moreRules = false;
                }
            }

            // Esclibe el resultado
            ihm.PrintFacts(fDB.Facts);
        }
    }    
}
