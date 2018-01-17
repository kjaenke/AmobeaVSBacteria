namespace Amoeba.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Controls;
    using System.Windows.Threading;
    using Models;
    using Prism.Mvvm;

    internal class ShellViewModel : BindableBase
    {
        private readonly DispatcherTimer _uhr = new DispatcherTimer();

        private string _amobeaCounter;

        private string _amobeaPercentCounter;

        private string _bacteriaCounter;

        private string _bacteriaPercentCounter;

        private string _fullCounter;
        public List<LivingCreature> Zoo = new List<LivingCreature>();

        public ShellViewModel()
        {
            _uhr.Interval = TimeSpan.FromSeconds(0.1);
            _uhr.Tick += Animieren;
            _uhr.Start();

            Petrischale = new Canvas();
            for (var i = 0; i < 15; i++)
            {
                Zoo.Add(new Amoeba());
            }
            for (var i = 0; i < 25; i++)
            {
                Zoo.Add(new Bacteria());
            }
        }

        
        public Canvas Petrischale { get; set; }



        public string BacteriaCounter
        {
            get => _bacteriaCounter;
            set => SetProperty(ref _bacteriaCounter, value);
        }

        public string BacteriaPercentCounter
        {
            get => _bacteriaPercentCounter;
            set => SetProperty(ref _bacteriaPercentCounter, value);
        }

        public string AmoebaCounter
        {
            get => _amobeaCounter;
            set => SetProperty(ref _amobeaCounter, value);
        }

        public string AmoebaPercentCounter
        {
            get => _amobeaPercentCounter;
            set => SetProperty(ref _amobeaPercentCounter, value);
        }

        public string FullCounter
        {
            get => _fullCounter;
            set => SetProperty(ref _fullCounter, value);
        }

        private int _bacteriaDied = 0;

        private string _bacteriaDiedCounter;
        public string BacteriaDiedCounter { get => $"Gestorben: {_bacteriaDied}"; set => SetProperty(ref _bacteriaDiedCounter, value); }

        private int _amobeaDied = 0;

        private string _amobeaDiedCounter;
        public string AmobeaDiedCounter
        {
            get => $"Gefressen: {_amobeaDied}";
            set => SetProperty(ref _amobeaPercentCounter, value);
        }

        public void Update()
        {
            AmoebaCounter = $"Amöben: {Zoo.Count(x => x.Name == "Amoeba")}";
            BacteriaCounter = $"Bakterien: {Zoo.Count(x => x.Name == "Bacteria")}";

            FullCounter = $"Gesamt: {Zoo.Count}";
            AmoebaPercentCounter = $"Amöben in %: {(double)Zoo.Count(x => x.Name == "Amoeba") * 100 / (double)Zoo.Count}";
            BacteriaPercentCounter = $"Bakterien in %: {(double)Zoo.Count(x => x.Name == "Bacteria") * 100 / (double)Zoo.Count}";
        }

        private void Animieren(object sender, EventArgs e)
        {
            Petrischale.Children.Clear();
            List<LivingCreature> kindergarten = new List<LivingCreature>();
            List<LivingCreature> gefressen = new List<LivingCreature>();
            foreach (var item in Zoo)
            {
                if (gefressen.Contains(item))
                {
                    continue;
                }
                item.Move();
                kindergarten.AddRange(item.Breed());
                item.Draw(Petrischale);
                gefressen.AddRange(item.Eat(Zoo));
            }
            gefressen.AddRange(Gestorben(Zoo.Where(x => x.Name == "Bacteria").ToList()));
            Zoo.AddRange(kindergarten);
            Zoo.RemoveAll(x => gefressen.Contains(x));
            Update();
        }

        //Return: All creatures that have died because they have left the test area
        private IEnumerable<LivingCreature> Gestorben(List<LivingCreature> liv)
        {
            List<LivingCreature> gestorben = new List<LivingCreature>();

            foreach (var item in liv)
            {
                if (item.X > 590 || item.X < 0 || item.Y > 280 || item.Y < 0)
                {
                    if (item.Name == "Bacteria")
                    {
                        gestorben.Add(item);
                        _bacteriaDied += 1;
                    }
                    else if (item.Name == "Amobea")
                    {
                        gestorben.Add(item);
                        _amobeaDied += 1;
                    }
                }
            }
            return gestorben;
        }
    }
}