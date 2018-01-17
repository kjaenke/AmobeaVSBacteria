namespace Simulation_Amöben_und_Bakterien_Evolution.Models
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;

    abstract class LivingCreatures
    {
        protected static readonly Random Random = new Random();

        public int X { get; private set; }
        public int Y { get; private set; }

        protected LivingCreatures()
        {
            X = Random.Next(0, 600);
            Y = Random.Next(0, 400);
        }

        protected LivingCreatures(LivingCreatures liv)
        {
            X = liv.X;
            Y = liv.Y;
        }

        public void Move()
        {
            X += Random.Next(-1, 3);
            Y += Random.Next(-1, 3);
        }

        public abstract void Draw(Graphics graphics);

        //Rückgabe: Liste der Neugeborenen
        public abstract List<LivingCreatures> Breed();

        //Rückgabe: Liste der Gefressenen
        public abstract List<LivingCreatures> Feed(List<LivingCreatures> z);
    }
}
