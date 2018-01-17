namespace Simulation_Amöben_und_Bakterien_Evolution.Models
{
    using System.Collections.Generic;
    using System.Drawing;

    class Amobea : LivingCreatures
    {
        private Pen _objPen;
        private bool _hasFeed;

        public Amobea()
        {
        }

        private Amobea(LivingCreatures a) : base(a)
        {
        }

        public override void Draw(Graphics graphics)
        {
            _objPen = _hasFeed ? new Pen(Color.Blue) : new Pen(Color.Green);
            _objPen.Width = 1;

            graphics.DrawEllipse(_objPen,5,5,5,5);
        }

        public override List<LivingCreatures> Breed()
        {
           List<LivingCreatures> daughters = new List<LivingCreatures>();

            if (Random.NextDouble() < 0.01)
            {
                daughters.Add(new Amobea(this));
            }
            return daughters;
        }

        public override List<LivingCreatures> Feed(List<LivingCreatures> z)
        {
            List<LivingCreatures> devoured = new List<LivingCreatures>();
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