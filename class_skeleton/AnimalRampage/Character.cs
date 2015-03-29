using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimalRampage
{
    class Character: GameObject, Attackable
    {
        private BackpackAnimal primary;
        private BackpackAnimal secondary;
        private Hoodie hoodie;
        private Backpack backpack;
        private CharacterStats stats;

        public void move()
        {
            throw new NotImplementedException();
        }

        public void attack()
        {
            throw new NotImplementedException();
        }

        private void die()
        {
            throw new NotImplementedException();
        }

        void Attackable.takeDamage()
        {
            throw new NotImplementedException();
        }
    }
}
