using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimalRampage
{
    abstract class GameObject: Drawable
    {
        private float x_pos;
        private float y_pos;

        void Drawable.draw()
        {
            throw new NotImplementedException();
        }

    }
}
