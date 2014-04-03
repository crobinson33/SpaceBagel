using System;
using System.Collections.Generic;

namespace SpaceBagel
{
	/// <summary>
	/// Used by world to find collisions
	/// </summary>
	public class CollisionDetector
	{
		public CollisionDetector ()
		{
		}

		/// <summary>
		/// Test axis aligned box vs axis aligned box.
		/// </summary>
		/// <returns><c>true</c>, if collision, <c>false</c> otherwise.</returns>
		/// <param name="colliderOne">Collider one.</param>
		/// <param name="colliderTwo">Collider two.</param>
		public bool AABBvsAABB(Collider colliderOne, Collider colliderTwo)
		{
			// Exit with no intersection if found separated along an axis
			if (colliderOne.bottomRight.X < colliderTwo.topLeft.X || colliderOne.topLeft.X > colliderTwo.bottomRight.X)
			{
				return false;
			}
			if(colliderOne.bottomRight.Y < colliderTwo.topLeft.Y || colliderOne.topLeft.Y > colliderTwo.bottomRight.Y)
			{
				return false;
			}
				
			// No separating axis found, therefor there is at least one overlapping axis
			return true;
		}

		/// <summary>
		/// This aabbvsaabb also fills out collisioninfo.
		/// </summary>
		/// <returns><c>true</c>, if collision, <c>false</c> otherwise.</returns>
		/// <param name="colliderOne">Collider one.</param>
		/// <param name="colliderTwo">Collider two.</param>
		/// <param name="collisionInfo">Collision info.</param>
		public bool AABBvsAABB(Collider colliderOne, Collider colliderTwo, CollisionInformation collisionInfo)
		{
            //Console.WriteLine("checking collision");
			Vector2 collisionNormal;
		
			// Vector from A to B
			Vector2 normal = colliderTwo.position - colliderOne.position;

			// Calculate half extents along x axis for each object
			float colliderOne_extent = (colliderOne.bottomRight.X - colliderOne.topLeft.X) / 2;
			float colliderTwo_extent = (colliderTwo.bottomRight.X - colliderTwo.topLeft.X) / 2;

			// Calculate overlap on x axis
			float x_overlap = colliderOne_extent + colliderTwo_extent - Math.Abs(normal.X);

			// SAT test on x axis
			if(x_overlap > 0)
			{
                //Console.WriteLine("we have an overlap");
				// Calculate half extents along x axis for each object
				colliderOne_extent = (colliderOne.bottomRight.Y - colliderOne.topLeft.Y) / 2;
				colliderTwo_extent = (colliderTwo.bottomRight.Y - colliderTwo.topLeft.Y) / 2;

				// Calculate overlap on y axis
				float y_overlap = colliderOne_extent + colliderTwo_extent - Math.Abs(normal.Y);

				// SAT test on y axis
				if(y_overlap > 0)
				{
                    //Console.WriteLine("double overlap, what does it mean");
					// Find out which axis is axis of least penetration
					if(x_overlap > y_overlap)
					{
                        //Console.WriteLine("FIRST");
						// Point towards B knowing that n points from A to B
						if(normal.X < 0)
						{
							collisionNormal = new Vector2(-1, 0);
						}
						else
						{
							collisionNormal = new Vector2(0,0);
						}
						
						collisionInfo.collisionNormal = collisionNormal;
						collisionInfo.penetrationAmount = x_overlap;
						
						return true;
					}
					else
					{
                        //Console.WriteLine("Second");
						// Point toward B knowing that n points from A to B
						if(normal.Y < 0)
						{
							collisionNormal = new Vector2(0,-1);
						}
						else
						{
							collisionNormal = new Vector2(0,1);
						}

						collisionInfo.collisionNormal = collisionNormal;
						collisionInfo.penetrationAmount =y_overlap;

						return true;
					}
				}
				return false;
			}
			return false;
		}

		/// <summary>
		/// Takes a list of all colliders added to the world and finds all collisions and returns a list of collisioninformation.
		/// </summary>
		/// <returns>The all collisions.</returns>
		/// <param name="objects">Objects.</param>
		public List<CollisionInformation> GetAllCollisions(List<Collider> objects)
		{
			// to be returned - Need to set clean so we don't have left overs from last time.
			List<CollisionInformation> collisions = new List<CollisionInformation>();

			// Need to loop through all objects and test all objects against all objects. 
			// 	- Might need to implement a structure here later for preformace.
			foreach (Collider colliderOne in objects)
			{
				foreach (Collider colliderTwo in objects)
				{
					// don't want to check against ourselves.
					if (colliderOne != colliderTwo)
					{
                        // check to see if we need to ignore it. (check objects one's ignores vs object two tag.
                        if (CheckForTag(colliderTwo, colliderOne.layersToIgnore) != true)
                        {
                            // i think we need this otherwise the objects just stay inside eachother for ever?
                            // we also do this before detection to try and increase preformance. 
                            if (CheckIfAlreadyInCollisionInfo(colliderOne, colliderTwo, collisions) != true)
                            {
						        // check the collisions
						        CollisionInformation collisionInfo = new CollisionInformation();
						        if (AABBvsAABB(colliderOne, colliderTwo, collisionInfo))
						        {
                            
                                    collisionInfo.objectOne = colliderOne;
                                    collisionInfo.objectTwo = colliderTwo;

                                    //Console.WriteLine("object1: " + colliderOne.velocity + ", object2: " + colliderTwo.velocity);

                                    collisions.Add(collisionInfo);

                                    // we now need to check our triggers.
                                    CheckCustomTriggers(colliderOne, colliderTwo);
                                }
						    }
                        }
					}
				}
			}

            //Console.WriteLine(collisions.Count);
			return collisions;
		}

        public bool CheckForTag(Collider collider, List<string> tags)
        {
            foreach (string tag in tags)
            {
                if (collider.tag == tag)
                {
                    return true;
                }
            }
            return false;

        }

        public bool CheckIfAlreadyInCollisionInfo(Collider one, Collider two, List<CollisionInformation> collisions)
        {
            foreach (CollisionInformation info in collisions)
            {
                if (info.objectOne == one || info.objectTwo == one)
                {
                    if (info.objectOne == two || info.objectTwo == two)
                    {
                        Console.WriteLine("already in: (" + one.tag + ", " + two.tag + "), (" + info.objectOne.tag + ", " + info.objectTwo.tag + ")");
                        return true;
                    }
                }
            }
            return false;
        }

        public void CheckCustomTriggers(Collider colliderOne, Collider colliderTwo)
        {
            //Console.WriteLine("checking triggers");
            foreach (CollisionTrigger colliderToCheck in colliderOne.triggers)
            {
                //Console.WriteLine(colliderTwo + ", " + colliderToCheck.collider);
                //check to see if the colliders match.
                if (colliderTwo == colliderToCheck.collider)
                {
                    //Console.WriteLine("calling method");
                    colliderToCheck.method();
                }
            }
        }
	}
}

