using System.ComponentModel;

namespace MauiApp1
{
    public class ScheduleViewModel : INotifyPropertyChanged
    {
        private string schedule;  // Prom�nn� pro uchov�n� textu rozvrhu
        private System.Timers.Timer timer1;  // �asova� pro aktualizaci rozvrhu ka�dou sekundu

        // Vlastnost pro propojen� s UI, kter� zobrazuje informace o rozvrhu
        public string ScheduleText
        {
            get => schedule;
            set
            {
                schedule = value;
                OnPropertyChanged(nameof(ScheduleText));  // Ozn�men� UI o zm�n� vlastnosti
            }
        }

        // Konstruktor, ve kter�m je spu�t�n �asova�
        public ScheduleViewModel()
        {
            StartTimer();  // Spu�t�n� �asova�e pro aktualizaci rozvrhu
        }

        // Metoda pro inicializaci �asova�e
        private void StartTimer()
        {
            timer1 = new System.Timers.Timer(1000); // Nastaven� �asova�e, kter� se spust� ka�dou sekundu
            timer1.Elapsed += (sender, e) => UpdateSchedule();  // Ud�lost pro aktualizaci rozvrhu p�i ka�d�m "tiknut�" �asova�e
            timer1.Start();  // Spu�t�n� �asova�e
            UpdateSchedule();  // Po��te�n� aktualizace rozvrhu p�i na�ten� str�nky
        }

        // Metoda, kter� aktualizuje rozvrh na z�klad� aktu�ln�ho data a �asu
        private void UpdateSchedule()
        {
            var now = DateTime.Now;  // Z�sk�n� aktu�ln�ho data a �asu

            // Seznam st�tn�ch sv�tk�
            var statniSvatky = new List<DateTime>
            {
                new DateTime(now.Year, 1, 1),   // Nov� rok
                new DateTime(now.Year, 5, 1),   // Sv�tek pr�ce
                new DateTime(now.Year, 5, 8),   // Den v�t�zstv�
                new DateTime(now.Year, 7, 5),   // Cyril a Metod�j
                new DateTime(now.Year, 7, 6),   // Mistr Jan Hus
                new DateTime(now.Year, 9, 28),  // Den �esk� st�tnosti
                new DateTime(now.Year, 10, 28), // Vznik �SR
                new DateTime(now.Year, 11, 17), // Den boje za svobodu
                new DateTime(now.Year, 12, 24), // �t�dr� den
                new DateTime(now.Year, 12, 25), // 1. sv�tek v�no�n�
                new DateTime(now.Year, 12, 26)  // 2. sv�tek v�no�n�
            };

            // Seznam �koln�ch pr�zdnin
            var prazdniny = new List<(DateTime start, DateTime end)>
            {
                (new DateTime(now.Year, 10, 29), new DateTime(now.Year, 10, 30)), // Podzimn� pr�zdniny
                (new DateTime(now.Year, 12, 23), new DateTime(now.Year + 1, 1, 3)), // V�no�n� pr�zdniny
                (new DateTime(now.Year, 1, 31), new DateTime(now.Year, 1, 31)), // Pololetn� pr�zdniny
                (new DateTime(now.Year, 2, 3), new DateTime(now.Year, 2, 9)), // Jarn� pr�zdniny
                (new DateTime(now.Year, 4, 17), new DateTime(now.Year, 4, 17)), // Velikono�n� pr�zdniny
                (new DateTime(now.Year, 6, 28), new DateTime(now.Year, 8, 31)) // Hlavn� pr�zdniny
            };

            // Kontrola, jestli je dnes st�tn� sv�tek
            if (statniSvatky.Contains(now.Date))
            {
                ScheduleText = "Dnes je st�tn� sv�tek,\n u��vej volna!";  // Zobrazen� zpr�vy pro st�tn� sv�tek
                return;
            }

            // Kontrola, jestli jsou pr�v� pr�zdniny
            foreach (var (start, end) in prazdniny)
            {
                if (now.Date >= start && now.Date <= end)
                {
                    ScheduleText = "Jsou pr�zdniny,\n u��vej volna!";  // Zobrazen� zpr�vy pro pr�zdniny
                    return;
                }
            }

            // Kontrola, jestli je v�kend
            if (now.DayOfWeek == DayOfWeek.Saturday || now.DayOfWeek == DayOfWeek.Sunday)
            {
                ScheduleText = "M� volno,\n u��vej v�kend!";  // Zobrazen� zpr�vy pro v�kend
                return;
            }

            TimeSpan nowTime = now.TimeOfDay;  // Z�sk�n� aktu�ln�ho �asu dne
            TimeSpan startOfDay = new TimeSpan(7, 0, 0);  // Stanoven� za��tku pracovn�ho dne (7:00)

            // Seznam hodin v rozvrhu (pro ka�d� den)
            var schedule = new (TimeSpan start, TimeSpan end, string lesson)[]
            {
                (new TimeSpan(8, 0, 0), new TimeSpan(8, 45, 0), "1. hodina"),
                (new TimeSpan(8, 55, 0), new TimeSpan(9, 40, 0), "2. hodina"),
                (new TimeSpan(9, 45, 0), new TimeSpan(10, 30, 0), "3. hodina"),
                (new TimeSpan(10, 50, 0), new TimeSpan(11, 35, 0), "4. hodina"),
                (new TimeSpan(11, 40, 0), new TimeSpan(12, 25, 0), "5. hodina")
            };

            // P�id�n� hodin pro dny, kter� nejsou p�tek
            if (now.DayOfWeek != DayOfWeek.Friday)
            {
                schedule = schedule.Concat(new (TimeSpan, TimeSpan, string)[]
                {
                    (new TimeSpan(12, 30, 0), new TimeSpan(13, 15, 0), "6. hodina"),
                    (new TimeSpan(13, 15, 0), new TimeSpan(14, 10, 0), "7. hodina")
                }).ToArray();
            }
            // Pokud je p�tek a �as je po 12:25, zobrazen� zpr�vy o volnu
            else if (nowTime >= new TimeSpan(12, 25, 0))
            {
                ScheduleText = "M� volno, u��vej!";  // Zpr�va pro p�tek po poledni
                return;
            }

            // Pokud je �as p�ed za��tkem pracovn�ho dne, zobraz� se zpr�va o sp�nku
            if (nowTime < startOfDay)
            {
                ScheduleText = "Je�t� m��e� sp�t";  // Zpr�va pro �as p�ed 7:00
                return;
            }

            // Proch�z�me rozvrh a zjist�me, kter� hodina pr�v� prob�h� nebo na kterou se �ek�
            foreach (var (start, end, lesson) in schedule)
            {
                if (nowTime >= start && nowTime < end)
                {
                    TimeSpan remaining = end - nowTime;  // Zb�vaj�c� �as do konce hodiny
                    ScheduleText = $"{lesson} prob�h�\nZb�v�: {remaining.Minutes} min {remaining.Seconds} s";  // Zobrazen� informac� o prob�haj�c� hodin�
                    return;
                }
                else if (nowTime < start)
                {
                    TimeSpan countdown = start - nowTime;  // �as do za��tku n�sleduj�c� hodiny
                    ScheduleText = $"N�sleduje {lesson}\nza {countdown.Minutes} min {countdown.Seconds} s";  // Zobrazen� �asu do za��tku n�sleduj�c� hodiny
                    return;
                }
            }

            // Pokud nen� ��dn� hodina v rozvrhu, zobrazen� zpr�vy o volnu
            ScheduleText = "M� volno, u��vej!";  // Zpr�va, kdy� nen� ��dn� hodina v rozvrhu
        }

        // Ud�lost pro notifikaci o zm�n�ch vlastnost�
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
