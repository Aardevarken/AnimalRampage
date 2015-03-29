using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimalRampage
{
    abstract class BackpackObject: Drawable
    {

        private int size;

        void Drawable.draw()
        {
            throw new NotImplementedException();
        }

    }
}
