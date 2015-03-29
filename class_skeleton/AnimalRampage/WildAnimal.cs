using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimalRampage
{
    abstract class WildAnimal: GameObject
    {

        private AnimalStats stats;

        public BackpackAnimal getBackpackVersion()
        {
            throw new NotImplementedException();
        }

        public void die()
        {
            throw new NotImplementedException();
        }
    }
}
