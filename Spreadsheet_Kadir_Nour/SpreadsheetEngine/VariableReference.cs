using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CptS321
{
    /// <summary>
    /// Singleton class that holds the Variable Dictionary
    /// </summary>
    public sealed class VariableReference
    {
        private VariableReference() { }
        private static VariableReference instance = null;

        /// <summary>
        /// Property to make sure only one instance of this class is created
        /// </summary>
        public static VariableReference Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new VariableReference();
                }
                return instance;
            }
        }
        public Dictionary<string, double?> VariableDictionary = new Dictionary<string, double?>();

        public void ClearDictionary()
        {
            VariableDictionary.Clear();
        }
    }
}
