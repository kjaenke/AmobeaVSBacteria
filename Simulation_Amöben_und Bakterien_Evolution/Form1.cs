
using System.Windows.Forms;

namespace Simulation_Amöben_und_Bakterien_Evolution
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Threading;
    using Models;

    public partial class Form1 : Form
    {
        List<LivingCreatures> _colony = new List<LivingCreatures>();

        DispatcherTimer _uhr = new DispatcherTimer();
        public Form1()
        {
            InitializeComponent();

            _uhr.Interval = TimeSpan.FromSeconds(0.1);
            _uhr.Tick += Animieren;
            _uhr.Start();

            for (int i = 0; i < 15; i++)
            {
                _colony.Add(new Amobea());
            }
            for (int i = 0; i < 25; i++)
            {
                _colony.Add(new Bacteria());
            }

        }

        void Animieren(object sender, EventArgs e)
        {
            pictureBox.Refresh();
            Graphics objG = pictureBox.CreateGraphics();
            List<LivingCreatures> youngColony = new List<LivingCreatures>();
            List<LivingCreatures> gorged = new List<LivingCreatures>();
            foreach (var item in _colony)
            {
                if (!gorged.Contains(item))
                {
                    item.Move();
                    youngColony.AddRange(item.Breed());
                    item.Draw(objG);
                    gorged.AddRange(item.Feed(_colony));
                }
            }
            _colony.AddRange(youngColony);
            _colony.RemoveAll(x => gorged.Contains(x));
        }
    }
}
