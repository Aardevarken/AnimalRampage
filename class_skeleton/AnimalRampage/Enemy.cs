using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimalRampage
{
    class Enemy : GameObject, Attackable
    {
        private EnemyStats stats;

        public void move()
        {
            throw new NotImplementedException();
        }

        private void attack()
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
