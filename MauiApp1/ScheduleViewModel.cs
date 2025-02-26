using System.ComponentModel;

namespace MauiApp1
{
    public class ScheduleViewModel : INotifyPropertyChanged
    {
        private string schedule;  // Promìnná pro uchování textu rozvrhu
        private System.Timers.Timer timer1;  // Èasovaè pro aktualizaci rozvrhu každou sekundu

        // Vlastnost pro propojení s UI, která zobrazuje informace o rozvrhu
        public string ScheduleText
        {
            get => schedule;
            set
            {
                schedule = value;
                OnPropertyChanged(nameof(ScheduleText));  // Oznámení UI o zmìnì vlastnosti
            }
        }

        // Konstruktor, ve kterém je spuštìn èasovaè
        public ScheduleViewModel()
        {
            StartTimer();  // Spuštìní èasovaèe pro aktualizaci rozvrhu
        }

        // Metoda pro inicializaci èasovaèe
        private void StartTimer()
        {
            timer1 = new System.Timers.Timer(1000); // Nastavení èasovaèe, který se spustí každou sekundu
            timer1.Elapsed += (sender, e) => UpdateSchedule();  // Událost pro aktualizaci rozvrhu pøi každém "tiknutí" èasovaèe
            timer1.Start();  // Spuštìní èasovaèe
            UpdateSchedule();  // Poèáteèní aktualizace rozvrhu pøi naètení stránky
        }

        // Metoda, která aktualizuje rozvrh na základì aktuálního data a èasu
        private void UpdateSchedule()
        {
            var now = DateTime.Now;  // Získání aktuálního data a èasu

            // Seznam státních svátkù
            var statniSvatky = new List<DateTime>
            {
                new DateTime(now.Year, 1, 1),   // Nový rok
                new DateTime(now.Year, 5, 1),   // Svátek práce
                new DateTime(now.Year, 5, 8),   // Den vítìzství
                new DateTime(now.Year, 7, 5),   // Cyril a Metodìj
                new DateTime(now.Year, 7, 6),   // Mistr Jan Hus
                new DateTime(now.Year, 9, 28),  // Den èeské státnosti
                new DateTime(now.Year, 10, 28), // Vznik ÈSR
                new DateTime(now.Year, 11, 17), // Den boje za svobodu
                new DateTime(now.Year, 12, 24), // Štìdrý den
                new DateTime(now.Year, 12, 25), // 1. svátek vánoèní
                new DateTime(now.Year, 12, 26)  // 2. svátek vánoèní
            };

            // Seznam školních prázdnin
            var prazdniny = new List<(DateTime start, DateTime end)>
            {
                (new DateTime(now.Year, 10, 29), new DateTime(now.Year, 10, 30)), // Podzimní prázdniny
                (new DateTime(now.Year, 12, 23), new DateTime(now.Year + 1, 1, 3)), // Vánoèní prázdniny
                (new DateTime(now.Year, 1, 31), new DateTime(now.Year, 1, 31)), // Pololetní prázdniny
                (new DateTime(now.Year, 2, 3), new DateTime(now.Year, 2, 9)), // Jarní prázdniny
                (new DateTime(now.Year, 4, 17), new DateTime(now.Year, 4, 17)), // Velikonoèní prázdniny
                (new DateTime(now.Year, 6, 28), new DateTime(now.Year, 8, 31)) // Hlavní prázdniny
            };

            // Kontrola, jestli je dnes státní svátek
            if (statniSvatky.Contains(now.Date))
            {
                ScheduleText = "Dnes je státní svátek,\n užívej volna!";  // Zobrazení zprávy pro státní svátek
                return;
            }

            // Kontrola, jestli jsou právì prázdniny
            foreach (var (start, end) in prazdniny)
            {
                if (now.Date >= start && now.Date <= end)
                {
                    ScheduleText = "Jsou prázdniny,\n užívej volna!";  // Zobrazení zprávy pro prázdniny
                    return;
                }
            }

            // Kontrola, jestli je víkend
            if (now.DayOfWeek == DayOfWeek.Saturday || now.DayOfWeek == DayOfWeek.Sunday)
            {
                ScheduleText = "Máš volno,\n užívej víkend!";  // Zobrazení zprávy pro víkend
                return;
            }

            TimeSpan nowTime = now.TimeOfDay;  // Získání aktuálního èasu dne
            TimeSpan startOfDay = new TimeSpan(7, 0, 0);  // Stanovení zaèátku pracovního dne (7:00)

            // Seznam hodin v rozvrhu (pro každý den)
            var schedule = new (TimeSpan start, TimeSpan end, string lesson)[]
            {
                (new TimeSpan(8, 0, 0), new TimeSpan(8, 45, 0), "1. hodina"),
                (new TimeSpan(8, 55, 0), new TimeSpan(9, 40, 0), "2. hodina"),
                (new TimeSpan(9, 45, 0), new TimeSpan(10, 30, 0), "3. hodina"),
                (new TimeSpan(10, 50, 0), new TimeSpan(11, 35, 0), "4. hodina"),
                (new TimeSpan(11, 40, 0), new TimeSpan(12, 25, 0), "5. hodina")
            };

            // Pøidání hodin pro dny, které nejsou pátek
            if (now.DayOfWeek != DayOfWeek.Friday)
            {
                schedule = schedule.Concat(new (TimeSpan, TimeSpan, string)[]
                {
                    (new TimeSpan(12, 30, 0), new TimeSpan(13, 15, 0), "6. hodina"),
                    (new TimeSpan(13, 15, 0), new TimeSpan(14, 10, 0), "7. hodina")
                }).ToArray();
            }
            // Pokud je pátek a èas je po 12:25, zobrazení zprávy o volnu
            else if (nowTime >= new TimeSpan(12, 25, 0))
            {
                ScheduleText = "Máš volno, užívej!";  // Zpráva pro pátek po poledni
                return;
            }

            // Pokud je èas pøed zaèátkem pracovního dne, zobrazí se zpráva o spánku
            if (nowTime < startOfDay)
            {
                ScheduleText = "Ještì mùžeš spát";  // Zpráva pro èas pøed 7:00
                return;
            }

            // Procházíme rozvrh a zjistíme, která hodina právì probíhá nebo na kterou se èeká
            foreach (var (start, end, lesson) in schedule)
            {
                if (nowTime >= start && nowTime < end)
                {
                    TimeSpan remaining = end - nowTime;  // Zbývající èas do konce hodiny
                    ScheduleText = $"{lesson} probíhá\nZbývá: {remaining.Minutes} min {remaining.Seconds} s";  // Zobrazení informací o probíhající hodinì
                    return;
                }
                else if (nowTime < start)
                {
                    TimeSpan countdown = start - nowTime;  // Èas do zaèátku následující hodiny
                    ScheduleText = $"Následuje {lesson}\nza {countdown.Minutes} min {countdown.Seconds} s";  // Zobrazení èasu do zaèátku následující hodiny
                    return;
                }
            }

            // Pokud není žádná hodina v rozvrhu, zobrazení zprávy o volnu
            ScheduleText = "Máš volno, užívej!";  // Zpráva, když není žádná hodina v rozvrhu
        }

        // Událost pro notifikaci o zmìnách vlastností
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
