namespace Amoeba.Models
{
    using System.Collections.Generic;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Windows.Shapes;

    internal class Amoeba : LivingCreature
    {
        private bool _hasFeed;

        public Amoeba()
        {
            Name = "Amoeba";
        }

        private Amoeba(LivingCreature a) : base(a)
        {
            Name = "Amoeba";
        }

        public override void Draw(Canvas theCanvas)
        {
            var ellipse = new Ellipse
            {
                Width = 5.0,
                Height = 5.0,
                Fill = _hasFeed ? Brushes.Blue : Brushes.Green
            };

            theCanvas.Children.Add(ellipse);
            Canvas.SetLeft(ellipse, X - 2.5);
            Canvas.SetTop(ellipse, Y - 2.5);
        }

        public override List<LivingCreature> Breed()
        {
            List<LivingCreature> daughters = new List<LivingCreature>();

            if (Random.NextDouble() < 0.01)
            {
                daughters.Add(new Amoeba(this));
            }
            return daughters;
        }

        public override List<LivingCreature> Eat(List<LivingCreature> z)
        {
            List<LivingCreature> devoured = new List<LivingCreature>();
            foreach (var item in z)
            {
                if (!(item is Bacteria))
                {
                    continue;
                }
                var dx = item.X - X;
                var dy = item.Y - Y;
                if (dx * dx + dy * dy > 2 * 2)
                {
                    continue; 
                }
                devoured.Add(item);
                _hasFeed = true;
            }

            return devoured;
        }
    }
}