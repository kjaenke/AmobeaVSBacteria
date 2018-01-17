namespace Amoeba.Models
{
    using System.Collections.Generic;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Windows.Shapes;

    internal class Bacteria : LivingCreature
    {
        public Bacteria()
        {
            Name = "Bacteria";
        }

        private Bacteria(Bacteria b) : base(b)
        {
            Name = "Bacteria";
        }

        public override void Draw(Canvas theCanvas)
        {
            var ellipse = new Ellipse
            {
                Width = 2.0,
                Height = 2.0,
                Fill = Brushes.Red
            };

            theCanvas.Children.Add(ellipse);
            Canvas.SetLeft(ellipse, X - 1.0);
            Canvas.SetTop(ellipse, Y - 1.0);
        }

        public override List<LivingCreature> Breed()
        {
            List<LivingCreature> daughters = new List<LivingCreature>();
            if (Random.NextDouble() < 0.02)
            {
                daughters.Add(new Bacteria(this));
            }
            return daughters;
        }

        public override List<LivingCreature> Eat(List<LivingCreature> z) => new List<LivingCreature>(); // Bacteria don't eat amoebas
    }
}