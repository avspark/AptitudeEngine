using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AptitudeEngine.Entity
{
    abstract class Entity
    {
        public float posX = 0;
        private float posY = 0;

        public Entity(float posX, float posY)
        {
            this.posX = posX;
            this.posY = posY;
        }

        /**
         * called every frame
         **/
        public abstract void render();

        /**
         * called when a status update is requested 
         **/
        public abstract void update();

    }
}
