using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Lab7._2
{
   public class PlayList
    {
        private string name;
        private string singer;
        private string album;
        private DateTime date;
        private int duration;

        public PlayList(string name, string singer, string album, DateTime date, int duration)
        {
            this.name = name;
            this.singer = singer;
            this.album = album;
            this.date = date;
            this.duration = duration;
        }
        public string Name
       {
            get { return name; }
            set { name = value; }

        }
        public string Singer
        {
            get { return singer; }
            set { singer = value; }

        }
        public string Album
        {
            get { return album; }
            set { album = value; }

        }
        public DateTime Date
        {
            get { return date; }
            set { date = value; }

        }
        public int Duration
        {
            get { return duration; }
            set { duration = value; }

        }
        virtual public void showInfo()
        {
            Console.WriteLine("Назва пісні: " + name);
            Console.WriteLine("Виконавець: " + singer);
            Console.WriteLine("Альбом: " + album);
            Console.WriteLine("Рік випуску: " + date.Date.ToString("dd/MM/yyyy"));
            Console.WriteLine("Тривалість пісні: " + duration);
        }
        
    }
    public class SortByYear : IComparer
    {
        public int Compare(object d1,object d2)
        {
            PlayList play1 = (PlayList)d1;
            PlayList play2 = (PlayList)d2;
            if (play1.Date > play2.Date) return 1;
            if (play1.Date < play2.Date) return -1;
            
            
            return 0;

        }

    }
    public class SortByDuration : IComparer
    { 
       public int Compare(object d1,object d2)
        {
            PlayList play1 = (PlayList)d1;
            PlayList play2 = (PlayList)d2;
            if (play1.Duration > play2.Duration) return 1;
            if (play1.Duration < play2.Duration) return -1;

            return 0;
        }
     
    
    }


}
