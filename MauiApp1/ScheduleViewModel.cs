using System.ComponentModel;

namespace MauiApp1
{
    public class ScheduleViewModel : INotifyPropertyChanged
    {
        private string schedule;
        private System.Timers.Timer timer1;

        public string ScheduleText
        {
            get => schedule;
            set
            {
                schedule = value;
                OnPropertyChanged(nameof(ScheduleText));
            }
        }

        public ScheduleViewModel()
        {
            StartTimer();
        }

        private void StartTimer()
        {
            timer1 = new System.Timers.Timer(1000); // Aktualizace každou sekundu
            timer1.Elapsed += (sender, e) => UpdateSchedule();
            timer1.Start();
            UpdateSchedule();
        }

        private void UpdateSchedule()
        {
            var now = DateTime.Now;

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


            // Kontrola státních svátkù
            if (statniSvatky.Contains(now.Date))
            {
                ScheduleText = "Dnes je státní svátek,\n užívej volna!";
                return;
            }

            // Kontrola prázdnin
            foreach (var (start, end) in prazdniny)
            {
                if (now.Date >= start && now.Date <= end)
                {
                    ScheduleText = "Jsou prázdniny,\n užívej volna!";
                    return;
                }
            }

            // Kontrola víkendu
            if (now.DayOfWeek == DayOfWeek.Saturday || now.DayOfWeek == DayOfWeek.Sunday)
            {
                ScheduleText = "Máš volno,\n užívej víkend!";
                return;
            }

            TimeSpan nowTime = now.TimeOfDay;
            TimeSpan startOfDay = new TimeSpan(7, 0, 0);

            var schedule = new (TimeSpan start, TimeSpan end, string lesson)[]
            {
                (new TimeSpan(8, 0, 0), new TimeSpan(8, 45, 0), "1. hodina"),
                (new TimeSpan(8, 55, 0), new TimeSpan(9, 40, 0), "2. hodina"),
                (new TimeSpan(9, 45, 0), new TimeSpan(10, 30, 0), "3. hodina"),
                (new TimeSpan(10, 50, 0), new TimeSpan(11, 35, 0), "4. hodina"),
                (new TimeSpan(11, 40, 0), new TimeSpan(12, 25, 0), "5. hodina")
            };

            if (now.DayOfWeek != DayOfWeek.Friday)
            {
                schedule = schedule.Concat(new (TimeSpan, TimeSpan, string)[]
                {
                    (new TimeSpan(12, 30, 0), new TimeSpan(13, 15, 0), "6. hodina"),
                    (new TimeSpan(13, 15, 0), new TimeSpan(14, 10, 0), "7. hodina")
                }).ToArray();
            }
            else if (nowTime >= new TimeSpan(12, 25, 0))
            {
                ScheduleText = "Máš volno, užívej!";
                return;
            }

            if (nowTime < startOfDay)
            {
                ScheduleText = "Ještì mùžeš spát";
                return;
            }

            foreach (var (start, end, lesson) in schedule)
            {
                if (nowTime >= start && nowTime < end)
                {
                    TimeSpan remaining = end - nowTime;
                    ScheduleText = $"{lesson} probíhá\nZbývá: {remaining.Minutes} min {remaining.Seconds} s";
                    return;
                }
                else if (nowTime < start)
                {
                    TimeSpan countdown = start - nowTime;
                    ScheduleText = $"Následuje {lesson}\nza {countdown.Minutes} min {countdown.Seconds} s";
                    return;
                }
            }

            ScheduleText = "Máš volno, užívej!";
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
