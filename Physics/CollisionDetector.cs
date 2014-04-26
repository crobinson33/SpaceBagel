using System;
using System.Collections.Generic;

namespace SpaceBagel
{
	/// <summary>
	/// Used by world to find collisions
	/// </summary>
	public class CollisionDetector
	{
        public struct CheckAllTriggers
        {
            public Collider one;
            public Collider two;
            
            public CheckAllTriggers(Collider one, Collider two)
            {
                this.one = one;
                this.two = two;
            }
        }

        List<CheckAllTriggers> allTriggers = new List<CheckAllTriggers>();

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
            //Console.WriteLine(colliderOne.position.X + ", " +colliderOne.position.Y + ": " + colliderTwo.position.X + ", " + colliderTwo.position.Y + ": " + colliderOne.size + ": " + colliderTwo.size);
			// Exit with no intersection if found separated along an axis
			if (colliderOne.position.X + colliderOne.size.X < colliderTwo.position.X || colliderOne.position.X > colliderTwo.position.X + colliderTwo.size.X)
			{
				return false;
			}
			if (colliderOne.position.Y + colliderOne.size.Y < colliderTwo.position.Y || colliderOne.position.Y > colliderTwo.position.Y + colliderTwo.size.Y)
			{
				return false;
			}

			Vector2 collisionNormal;
            
		
			// Vector from A to B
			Vector2 normal = colliderTwo.position - colliderOne.position;

			// Calculate half extents along x axis for each object
			float colliderOne_extent = ((colliderOne.position.X + colliderOne.size.X) - colliderOne.position.X) * 0.5f;
            float colliderTwo_extent = ((colliderTwo.position.X + colliderTwo.size.X) - colliderTwo.position.X) * 0.5f;


			if (colliderOne_extent > colliderTwo_extent)
			{
				colliderTwo_extent = colliderOne_extent;
			}
			
			if (colliderOne_extent < colliderTwo_extent)
			{
				colliderOne_extent = colliderTwo_extent;
			}

			float x_overlap = colliderOne_extent + colliderTwo_extent - Math.Abs(normal.X);

			// SAT test on x axis
			if(x_overlap > 0)
			{
                //Console.WriteLine("we have an overlap");
				// Calculate half extents along x axis for each object
                float colliderOne_extent2 = ((colliderOne.position.Y + colliderOne.size.Y) - colliderOne.position.Y) * 0.5f;
                float colliderTwo_extent2 = ((colliderTwo.position.Y + colliderTwo.size.Y) - colliderTwo.position.Y) * 0.5f;

				if (colliderOne_extent2 > colliderTwo_extent2)
				{
					colliderTwo_extent2 = colliderOne_extent2;
				}

				if (colliderOne_extent2 < colliderTwo_extent2)
				{
					colliderOne_extent2 = colliderTwo_extent2;
				}

				// Calculate overlap on y axis
				float y_overlap = colliderOne_extent2 + colliderTwo_extent2 - Math.Abs(normal.Y);

                if (colliderOne.tag == "one" && colliderTwo.tag == "box1")
                {
                    //Console.WriteLine("collsion! x: " + x_overlap + ", y: " + y_overlap);
                }
				//Console.WriteLine ("x: " + x_overlap + ", y: " + y_overlap);

				// SAT test on y axis
				if(y_overlap > 0) 
				{
                    //Console.WriteLine("double overlap, what does it mean");
					// Find out which axis is axis of least penetration
                    //Console.WriteLine(x_overlap + ", " + y_overlap);
 					if(x_overlap < y_overlap)
					{
                        //Console.WriteLine("FIRST");
						// Point towards B knowing that n points from A to B
						if(normal.X < 0)
						{
							collisionNormal = new Vector2(-1, 0);
                            //Console.WriteLine("left");
						}
						else
						{
                            collisionNormal = new Vector2(1, 0);
                            //Console.WriteLine("right");
						}
						
						collisionInfo.collisionNormal = collisionNormal;
						collisionInfo.penetrationAmount = x_overlap;

                        //Console.WriteLine(collisionInfo.collisionNormal + ", " + collisionInfo.penetrationAmount);
						
						return true;
					}
					else
					{
                        //Console.WriteLine("Second");
						// Point toward B knowing that n points from A to B
						if(normal.Y < 0)
						{
							collisionNormal = new Vector2(0,-1);
                            //Console.WriteLine("here3");
						}
						else
						{
							collisionNormal = new Vector2(0,1);
                            //Console.WriteLine("here4");
						}

                        

						collisionInfo.collisionNormal = collisionNormal;
						collisionInfo.penetrationAmount = y_overlap;

                        //Console.WriteLine(collisionInfo.collisionNormal + ", " + collisionInfo.penetrationAmount);

						return true;
					}
				}
				return false;
			}
			return false;
		}

        /// <summary>
        /// Test Circle vs circle and stick collision info into manifest. 
        /// </summary>
        /// <param name="one">Collider</param>
        /// <param name="two">Collider</param>
        /// <param name="collisionInfo">CollisionInformation</param>
        /// <returns></returns>
        public bool CircleVsCirlce(Collider one, Collider two, CollisionInformation collisionInfo)
        { 
            // Vector from A to B
            Vector2 normal = two.position - one.position;
 
            float radii = one.radius + two.radius;
            //radii *= radius;

            float length = normal.LengthSquared();
            // see if we can early out with non heavy collision detection
            if(length > radii)
            {
                return false;
            }
 
            // Circles have collided, now compute manifold
            float distance = (float) Math.Sqrt( Math.Pow((one.position.X - two.position.X), 2) + Math.Pow((one.position.Y - two.position.Y), 2) ); // perform actual sqrt
 
            // If distance between circles is not zero
            if(distance != 0)
            {
                // Distance is difference between radius and distance
                collisionInfo.penetrationAmount = radii - distance;
 
                // Utilize our d since we performed sqrt on it already
                // Points from A to B, and is a unit vector
                collisionInfo.collisionNormal = normal.Normalize(length);
                return true;
            } 
            // Circles are on same position
            else
            {
                // Choose random (but consistent) values
                collisionInfo.penetrationAmount = one.radius;
                collisionInfo.collisionNormal = new Vector2(1, 0);
                return true;
            }
        }

        /// <summary>
        /// Test a AABB vs Circle
        /// </summary>
        /// <param name="one">Box Collider</param>
        /// <param name="two">Circle Collider</param>
        /// <param name="collisionInfo">CollisionInfo</param>
        /// <returns>true if collision</returns>
        public bool AABBvsCircle(Collider one, Collider two, CollisionInformation collisionInfo)
        { 
            // Vector from A to B
            Vector2 normal = two.position - one.position;
 
            // Closest point on A to center of B
            Vector2 closest = normal;
 
            // Calculate half extents along each axis
            float x_extent = (one.bottomRight.X - one.topLeft.X) / 2;
            float y_extent = (one.bottomRight.Y - one.topLeft.Y) / 2;
 
            // Clamp point to edges of the AABB
            closest.X = Util.Clamp( closest.X, -x_extent, x_extent  );
            closest.Y = Util.Clamp( closest.Y, -y_extent, y_extent  );
 
            bool inside = false;
 
            // Circle is inside the AABB, so we need to clamp the circle's center
            // to the closest edge
            if(normal == closest)
            {
                inside = true;
 
                // Find closest axis
                if(Math.Abs( normal.X ) > Math.Abs( normal.Y ))
                {
                    // Clamp to closest extent
                    if(closest.X > 0)
                    {
                        closest.X = x_extent;
                    }
                    else
                    {
                        closest.X = -x_extent;
                    }
                }
 
                // y axis is shorter
                else
                {
                    // Clamp to closest extent
                    if(closest.Y > 0)
                    {
                        closest.Y = y_extent;
                    }
                    else
                    {
                        closest.Y = -y_extent;
                    }
                }
            }
 
            Vector2 normal2 = normal - closest;
            float direction = normal2.LengthSquared();
            float radius = two.radius;
 
            // Early out of the radius is shorter than distance to closest point and
            // Circle not inside the AABB
            if(direction > radius * radius && !inside)
            {
                return false;
            }
 
            // Avoided sqrt until we needed
            //float distance = (float) Math.Sqrt( Math.Pow((one.position.X - two.position.X), 2) + Math.Pow((one.position.Y - two.position.Y), 2) ); // perform actual sqrt
            float distance = (float) Math.Sqrt( direction );


            // Collision normal needs to be flipped to point outside if circle was
            // inside the AABB
            if(inside)
            {
                //m->normal = -n
                //m->penetration = r + d
                collisionInfo.collisionNormal = -normal;
                collisionInfo.penetrationAmount = radius + distance;
            }
            else
            {
                //m->normal = n
                //m->penetration = r + d
                collisionInfo.collisionNormal = normal;
                collisionInfo.penetrationAmount = radius + distance;
            }
 
            return true;
        }

        public bool BoxVsBox(Collider colliderOne, Collider colliderTwo, CollisionInformation collisionInfo)
        {
            if (colliderOne.position.X + colliderOne.size.X < colliderTwo.position.X || colliderOne.position.X > colliderTwo.position.X + colliderTwo.size.X)
            {
                return false;
            }
            if (colliderOne.position.Y + colliderOne.size.Y < colliderTwo.position.Y || colliderOne.position.Y > colliderTwo.position.Y + colliderTwo.size.Y)
            {
                return false;
            }

            Vector2 normal = new Vector2();

            // we now know we have a collision. 
            // have to get collision normal now and penetration amount.
            // woot.

            // find biggest overlap?
            float xLeft_overlap = Math.Abs((colliderOne.position.X + colliderOne.size.X) - colliderTwo.position.X);
            float xRight_overlap = Math.Abs(colliderOne.position.X - (colliderTwo.position.X + colliderTwo.size.X));

            float yTop_overlap = Math.Abs((colliderOne.position.Y + colliderOne.size.Y) - colliderTwo.position.Y);
            float yBottom_overlap = Math.Abs(colliderOne.position.Y - (colliderTwo.position.Y + colliderTwo.size.Y));

            float xBiggest = Math.Max(xLeft_overlap, xRight_overlap);
            float yBiggest = Math.Max(yTop_overlap, yBottom_overlap);
            //Console.WriteLine("x: " + xLeft_overlap + ", y: " + xRight_overlap);


            if (xBiggest > yBiggest)
            {
                // one points towards two.
                if (xLeft_overlap > xRight_overlap)
                {
                    //Console.WriteLine("left");
                    normal = new Vector2(-1, 0);
                }
                else
                {
                    //Console.WriteLine("right");
                    normal = new Vector2(1, 0);
                }
            }
            else
            {


                if (yTop_overlap > yBottom_overlap)
                {
                    //Console.WriteLine("top");
                    normal = new Vector2(0, -1);
                }
                else
                {
                    //Console.WriteLine("bottom");
                    normal = new Vector2(0, 1);
                }
            }



            collisionInfo.collisionNormal = normal;
            collisionInfo.penetrationAmount = Math.Min(Math.Min(xLeft_overlap, xRight_overlap), Math.Min(yTop_overlap, yBottom_overlap));

            //Console.WriteLine("nom: " + collisionInfo.collisionNormal + ", pen: " + xLeft_overlap + ", " + xRight_overlap + ", " + yTop_overlap + ", " + yBottom_overlap);

            return true;
        }

		/// <summary>
		/// Takes a list of all colliders added to the world and finds all collisions and returns a list of collisioninformation.
		/// </summary>
		/// <returns>The all collisions.</returns>
		/// <param name="objects">Objects.</param>
		public List<CollisionInformation> GetAllCollisions(List<Collider> objects)
		{
			//Console.WriteLine (" hello");
			// to be returned - Need to set clean so we don't have left overs from last time.
			List<CollisionInformation> collisions = new List<CollisionInformation>();
            allTriggers = new List<CheckAllTriggers>();

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

								//Console.WriteLine (" hello");
                                //we need to determine the type of collision
                                
                                //test/
                                //BoxVsBox(colliderOne, colliderTwo, collisionInfo);

                                if (DoCollisionCheck(colliderOne, colliderTwo, collisionInfo))
                                {
									// we now need to check our triggers.
									//CheckCustomTriggers(colliderOne, colliderTwo);
									CheckAllTriggers newTrigger = new CheckAllTriggers(colliderOne, colliderTwo);
									allTriggers.Add(newTrigger);

									// we do triggers first so we can call when objects want to interact but not be
									// resolved. #winning.
									if (CheckTagTwoWays(colliderOne, colliderTwo) != true)
									{
										//Console.WriteLine ("adding resolution: " + colliderOne.tag + ", " + colliderTwo.tag);
	                                    collisionInfo.objectOne = colliderOne;
	                                    collisionInfo.objectTwo = colliderTwo;

	                                    //Console.WriteLine("object1: " + colliderOne.velocity + ", object2: " + colliderTwo.velocity);

	                                    collisions.Add(collisionInfo);

	                                    
									}
                                }
						        
						    }
                        }
					}
				}
			}

            //Console.WriteLine(collisions.Count);

            //check all the triggers
            CheckCustomTriggers();

			return collisions;
		}

        public bool DoCollisionCheck(Collider one, Collider two, CollisionInformation info)
        {
            //Console.WriteLine((typeof(CharacterCollider) == one.GetType()));

            // do box v box if both objects are not a circle
            if (one.GetType() != typeof(CircleCollider) && two.GetType() != typeof(CircleCollider))
            {
                //box v box
                if (BoxVsBox(one, two, info))
                {
                    //Console.WriteLine("COLLISION!");
                    info.collisionType = "AABBvsAABB";
                    return true;
                }
                //Console.WriteLine("---");
            }
            // make sure both objects are not boxes
            else if (one.GetType() != typeof(BoxCollider) && one.GetType() != typeof(CharacterCollider) &&
                two.GetType() != typeof(BoxCollider) && two.GetType() != typeof(CharacterCollider))
            {
                //circle v circle
                if (CircleVsCirlce(one, two, info))
                {
                    info.collisionType = "CircleVsCircle";
                    return true;
                }
            }
            else
            {
                // we need the box to be in position one. 
                // If the first object isn't the box we will get it later when the objects are reversed.
                if (one.GetType() == typeof(BoxCollider) || one.GetType() == typeof(CharacterCollider))
                {
                    //double check for safety. Object two needs to be a circle
                    if (two.GetType() == typeof(CircleCollider))
                    {
                        //box v circle
                        if (AABBvsCircle(one, two, info))
                        {
                            info.collisionType = "AABBvsCircle";
                            return true;
                        }
                    }
                }
            }

            return false;
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

		public bool CheckTagTwoWays(Collider one, Collider two)
		{
			foreach (string tag in one.layersToIgnore)
			{
				//Console.WriteLine ("one: " + one.tag + ", " + tag);
				if (tag == two.tag)
				{
					return true;
				}
			}
			foreach (string tag in two.layersToIgnore)
			{
				//Console.WriteLine ("two: " + two.tag + ", " + tag;
				if (tag == one.tag)
				{
					return true;
				}
			}

			return false;
		}

        public bool CheckIfAlreadyInCollisionInfo(Collider one, Collider two, List<CollisionInformation> collisions)
        {
            //Console.WriteLine(collisions.Count);
            foreach (CollisionInformation info in collisions)
            {
                if (info.objectOne.tag == one.tag || info.objectTwo.tag == one.tag)
                {
                    if (info.objectOne.tag == two.tag || info.objectTwo.tag == two.tag)
                    {
                        //Console.WriteLine("already in: (" + one.tag + ", " + two.tag + "), (" + info.objectOne.tag + ", " + info.objectTwo.tag + ")");
                        return true;
                    }
                }
            }
            return false;
        }

        public void CheckCustomTriggers()
        {
            foreach (CheckAllTriggers trigger in allTriggers)
            {
                //Console.WriteLine("checking triggers " + trigger.one.tag + ", " + trigger.two.tag);
                // check first objects triggers.
                foreach (CollisionTrigger colliderToCheck in trigger.one.triggers)
                {
                    //Console.WriteLine("tag: " + colliderToCheck.tag);
                    if (colliderToCheck.tag.Length > 0)
                    {
                        //Console.WriteLine("tagged: " + trigger.two.tag + ", " + colliderToCheck.tag);
                        if (trigger.two.tag == colliderToCheck.tag)
                        {
                            colliderToCheck.method();
                            //return;
                        }
                    }
                    //Console.WriteLine(colliderTwo + ", " + colliderToCheck.collider);
                    //check to see if the colliders match.
                    if (trigger.two == colliderToCheck.collider)
                    {
                        //Console.WriteLine("calling method");
                        colliderToCheck.method();
                        //return;
                    }
                }
                //check second objects triggers
                //Console.WriteLine(trigger.two.triggers.Count);
                foreach (CollisionTrigger colliderToCheck in trigger.two.triggers)
                {
                    //Console.WriteLine("tag: " + colliderToCheck.tag);
                    if (colliderToCheck.tag.Length > 0)
                    {
						//Console.WriteLine("tagged: " + trigger.two.tag + ", " + colliderToCheck.tag);
                        if (trigger.one.tag == colliderToCheck.tag)
                        {
                            colliderToCheck.method();
                            //return;
                        }
                    }
                    //Console.WriteLine(colliderTwo + ", " + colliderToCheck.collider);
                    //check to see if the colliders match.
                    if (trigger.one == colliderToCheck.collider)
                    {
                        //Console.WriteLine("calling method");
                        colliderToCheck.method();
                        //return;
                    }
                }
            }
        }
	}
}

