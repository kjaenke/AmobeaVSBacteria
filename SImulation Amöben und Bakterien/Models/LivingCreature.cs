namespace Amoeba.Models
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Controls;

    public abstract class LivingCreature
    {
        protected static readonly Random Random = new Random();

        protected LivingCreature()
        {
            X = Random.Next(0, 600);
            Y = Random.Next(0, 400);
        }

        protected LivingCreature(LivingCreature liv)
        {
            X = liv.X;
            Y = liv.Y;
        }

        public int X { get; private set; }

        public int Y { get; private set; }

        public void Move()
        {
            X += Random.Next(-1, 2);
            Y += Random.Next(-1, 2);
        }

        public abstract void Draw(Canvas theCanvas);
        public abstract List<LivingCreature> Breed();

        public string Name { get; set; }
        // Rückgabe: Liste der Gefressenen
        public abstract List<LivingCreature> Eat(List<LivingCreature> z);
    }
}