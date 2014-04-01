using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading; 
using SFML.Graphics;
using SFML.Window;

namespace SpaceBagel
{
	class MainClass
	{
		public static void Main (string[] args)
		{
            /*
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed);
                Thread.Sleep(1); 
            }
            stopwatch.Stop();
            
            */

            SFMLProgram app = new SFMLProgram();
            app.StartWindow(); 
           /*
			while(true)
			{
				//Console.WriteLine("test");
				Keyboard keyboard = new Keyboard();

				/*
                 List<Key.KeyCode> allKeysDown = new List<Key.KeyCode>();

				allKeysDown = keyboard.GetKeysDown();

				foreach (Key.KeyCode keyCode in allKeysDown)
				{
					Console.Write(keyCode.ToString() + ", ");
				}

				Console.WriteLine(keyboard.IsKeyDown(Key.KeyCode.Space));

				Console.WriteLine("end");
			}
             */
            
		}
	}

    class SFMLProgram
    {
        RenderWindow mWindow;

        CircleShape cs = new CircleShape(85.0f);
        private static CircleShape circle = new CircleShape(100.0f);
        private static Text description;
        private static Text mousePosition;
        private static Text timeDisplay; 
        private static Sprite sprite;

        static Texture texture = new Texture("Images/Hat.PNG");
        static Font font = new Font("Resources/sansation.ttf"); 
        static Vector2f spritePosition;
        //ParticleSystem particleSystem; 

        Stopwatch timer; 
        
        
        public void StartWindow()
        {
            mWindow = new RenderWindow(new VideoMode(800, 600), "Window");
            mWindow.SetVisible(true);
            //Add event functions
            mWindow.Closed += new EventHandler(OnClosed);
            mWindow.KeyPressed += new EventHandler<KeyEventArgs>(OnKeyPressed);
            mWindow.MouseButtonPressed += new EventHandler<MouseButtonEventArgs>(OnMousePressed);
            
            
            sprite = new Sprite(texture);
            
            sprite.Scale /= 4;
            
            
            cs.FillColor = Color.Black;
            cs.OutlineColor = Color.Red;
            cs.OutlineThickness = 3.0f;

            description = new Text("This is text yo", font, 20);
            description.Position = new Vector2f(10, 530);
            description.Color = new Color(80, 80, 80);
            description.Style = Text.Styles.Bold;

            mousePosition = new Text("Mouse Coords:", font, 20);
            mousePosition.Position = new Vector2f(400, 530);
            mousePosition.Color = new Color(255, 160, 0);

            //particleSystem = new ParticleSystem(1000); 

            timer = new Stopwatch();
            timeDisplay = new Text("Timer: ", font, 20);
            timeDisplay.Position = new Vector2f(500,30);
            timeDisplay.Color = Color.Red; 

            
            
            
            


            while (mWindow.IsOpen())
            {
                timer.Start(); 
                mWindow.DispatchEvents();

                float x = (float)Mouse.GetPosition(mWindow).X;
                float y = (float)Mouse.GetPosition(mWindow).Y;
                mousePosition.DisplayedString = ("Mouse coords: " +"X:"+ x.ToString()+"  Y: " + y.ToString());
                timeDisplay.DisplayedString = ("Timer: " + timer.Elapsed.ToString()); 
                sprite.Position = spritePosition;

                mWindow.Clear(Color.Transparent);
                mWindow.Draw(cs);
                mWindow.Draw(circle); 
                mWindow.Draw(sprite);
                mWindow.Draw(description);
                mWindow.Draw(mousePosition);
                mWindow.Draw(timeDisplay); 
                
                mWindow.Display();
            }
        }



        //Closing the Window
        void OnClosed(object sender, EventArgs e)
        {
            RenderWindow window = (RenderWindow)sender;
            mWindow.Close();
        }

        //Handling Mouse Events
        static void OnMousePressed(object sender, MouseButtonEventArgs e)
        {
            RenderWindow window = (RenderWindow)sender;
            if (e.Button == SFML.Window.Mouse.Button.Left)
            {
                description.DisplayedString = "Left Mouse Button Clicked"; 

            }
            if (e.Button == SFML.Window.Mouse.Button.Right)
            {
                description.DisplayedString = "Right Mouse Button Clicked"; 
            }
        }
        //Handling Keyboard Events
        static void OnKeyPressed(object sender, KeyEventArgs e)
        {

            RenderWindow window = (RenderWindow)sender;
            Keyboard keyboard = new Keyboard();
            if (e.Code == SFML.Window.Keyboard.Key.Escape)
            {

                window.Close(); 
                
            }

            switch (e.Code)
            {
                case SFML.Window.Keyboard.Key.Left:
                    description.DisplayedString = "Left Button pressed";
                    spritePosition.X -= 10;
                    break;

                case SFML.Window.Keyboard.Key.Right:
                    description.DisplayedString = "Right Button pressed";
                    spritePosition.X += 10;
                    break;

                case SFML.Window.Keyboard.Key.Down:
                    description.DisplayedString = "Down Button pressed";
                    spritePosition.Y += 10;
                    break;

                case SFML.Window.Keyboard.Key.Up:
                    description.DisplayedString = "Up Button pressed";
                    spritePosition.Y -= 10;
                    break;

                case SFML.Window.Keyboard.Key.Space:
                    Random random = new Random();

                    description.DisplayedString = "Space Button pressed";
                    circle.FillColor = new Color((byte)random.Next(0, 255), (byte)random.Next(0, 255), (byte)random.Next(0, 255));
                    circle.Position = new Vector2f(random.Next(0, 700), random.Next(0, 500));
                    break;

                default:
                    
                    break;
            }
        }
    }

    class ParticleSystem 
    {
        private struct Particle
        {
            public Vector2f velocity;
            public TimeSpan lifeSpan;
        };


        public ParticleSystem(int numParticles)
        {
            for (int i = 0; i < numParticles; i++)
            {
                Particle p = new Particle();
                mParticles.Add(p); 
            }
        }
        List<Particle> mParticles = new List<Particle>(); 
        VertexArray mVertices;
        TimeSpan mLifeTime = new TimeSpan(0,0,10,0);
        Vector2f mEmitter; 

        void SetEmitter(Vector2f position)
        {
            mEmitter = position; 
        }

        void Update(TimeSpan elapsed)
        {
            for (int i = 0; i < mParticles.Count; i++)
            {
                Particle p = mParticles[i];
                p.lifeSpan -= elapsed;

                if (p.lifeSpan < TimeSpan.Zero)
                {
                    ResetParticle(i); 
                    
                }
                
            }
        }

        void ResetParticle(int index)
        {
            Random random = new Random();
            float angle = (random.Next() % 360) * 3.14f / 180.0f;
            float speed = (random.Next() % 50) + 50.0f;
            //mParticles[index].velocity = new Vector2f(((float)Math.Cos(angle) * speed), ((float)Math.Sin(angle) * speed)); 
            
        }
        
    }
}
