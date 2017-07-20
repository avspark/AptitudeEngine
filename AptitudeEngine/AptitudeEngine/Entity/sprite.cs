using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AptitudeEngine.Entity
{
    class Sprite : Entity
    {
        //if this as a parent to a class the update method will be called every frame

        private String name = "Sprite";

        public Sprite(String name)
        {
            this.name = name;
        }


    }
}
