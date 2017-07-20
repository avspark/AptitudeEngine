using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AptitudeEngine.Entity
{
    class World
    {
        private List<Entity> objects = new List<Entity>();

        public void loop()
        {
            foreach (Entity entity in objects)
            {
                render();

                if (entity is Sprite)
                {
                    update();
                }

            }
        }
    }
}
