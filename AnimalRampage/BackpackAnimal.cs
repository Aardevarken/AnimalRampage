using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimalRampage
{
    abstract class BackpackAnimal: BackpackObject
    {
        private BackpackAnimalStats stats;

        public void usePrimary()
        {
            throw new NotImplementedException();
        }
        
        public void useSecondary()
        {
            throw new NotImplementedException();
        }

    }
}
