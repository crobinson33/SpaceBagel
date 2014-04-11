using System;
using System.Collections.Generic;

namespace SpaceBagel
{
	public class Level
	{
        public List<BaseObject> objects;
        public Surface surface;

        public World world;

		public Level (Surface surface)
		{
            objects = new List<BaseObject>();
            this.surface = surface;
            Console.WriteLine("surface created");
            world = new World();
		}

        public void AddObject(BaseObject newObject)
        {
            objects.Add(newObject);
        }

        public void RemoveObject(BaseObject oldObject)
        {
            objects.Remove(oldObject);
        }

        public void Update(float deltaTime)
        {
            foreach(BaseObject obj in objects)
            {
                obj.Update(deltaTime);
            }

            world.Update(deltaTime);
        }

        public void Draw()
        {
            foreach(BaseObject obj in objects)
            {
                obj.Draw(surface);
            }
        }
	}
}

