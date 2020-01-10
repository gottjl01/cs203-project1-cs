using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFW.CSIST203.Project1.Functions
{

    public class ArrayFunctions
    {

        /// <summary>
        /// The persistent file used to load and store data when the Store() and Load() methods are utilized
        /// </summary>
        /// <returns></returns>
        internal string PersistentFile { get; set; }

        public static readonly string DefaultPersistentFile = "data.txt";

        internal Random Randomizer { get; set; }

        public ArrayFunctions() : this("data.txt")
        {
        }

        public ArrayFunctions(string persistentFile) : this(persistentFile, null)
        {
        }

        public ArrayFunctions(string persistentFile, int? seed)
        {
            // TODO: Implement
        }


        public void Store(string[] data)
        {
            // TODO: Implement
            throw new NotImplementedException();
        }

        public string[] Load(int dataCount)
        {
            // TODO: Implement
            throw new NotImplementedException();
        }

        public string[] Randomize(string[] data)
        {
            // TODO: Implement
            throw new NotImplementedException();
        }

        public string[] ShiftRight(string[] data)
        {
            // TODO: Implement
            throw new NotImplementedException();
        }

        public string[] ShiftLeft(string[] data)
        {
            // TODO: Implement
            throw new NotImplementedException();
        }

        public string[] Reverse(string[] data)
        {
            // TODO: Implement
            throw new NotImplementedException();
        }
    }

}
