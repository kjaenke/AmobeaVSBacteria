namespace Simulation_Amöben_und_Bakterien_Evolution.Models
{
    using System.Collections.Generic;
    using System.Drawing;

    class Bacteria : LivingCreatures
    {
        public Bacteria()
        {
            
        }

        private Bacteria(Bacteria b) : base(b)
        {
        }
        private Pen _objPen;

        public override void Draw(Graphics graphics)
        {
            _objPen =  new Pen(Color.Red);
            _objPen.Width = 1;

            graphics.DrawEllipse(_objPen, 2, 2, 2, 2);
        }

        public override List<LivingCreatures> Breed()
        {
            List<LivingCreatures> daughters = new List<LivingCreatures>();
            if (Random.NextDouble() < 0.02)
            {
                daughters.Add(new Bacteria(this));
            }
            return daughters;
        }

        public override List<LivingCreatures> Feed(List<LivingCreatures> z) => new List<LivingCreatures>();
    }
}