using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab7._2
{
    class Playlists
    {
        ArrayList playlist;
        public ReaderWriter readerWriter;
        
        public Playlists()
        {
            readerWriter = new ReaderWriter();
            playlist = createList();
        }
        public void setCommands()
        {
            Console.WriteLine("Додавання записiв: +");
            Console.WriteLine("Редагування записiв: E");
            Console.WriteLine("Знищення записiв: -");
            Console.WriteLine("Виведення записiв: Enter");
            Console.WriteLine("Сортування за тривалістю пісні: N");
            Console.WriteLine("Сортування за датою запису: D");
            Console.WriteLine("Вихiд: Esc");

            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.OemPlus:
                    Console.WriteLine();
                    addNew();
                    setCommands();
                    break;

                case ConsoleKey.E:
                    Console.WriteLine();
                    edit();
                    setCommands();
                    break;

                case ConsoleKey.OemMinus:
                    Console.WriteLine();
                    delete();
                    setCommands();
                    break;

                case ConsoleKey.Enter:
                    Console.WriteLine();
                    showList();
                    setCommands();
                    break;

                case ConsoleKey.N:
                    Console.WriteLine();
                    showSortByDuration();
                    setCommands();
                    break;

                case ConsoleKey.D:
                    Console.WriteLine();
                    showSortByYear();
                    setCommands();
                    break;

                case ConsoleKey.Escape:
                    return;
            }

        }
        public PlayList parseInfo(string strInfo)
        {
            string[] words = new string[6];
            words = strInfo.Split(',');
            PlayList play = new PlayList(words[0], words[1], words[2], DateTime.Parse(words[3]), int.Parse(words[4]));
            return play;
        }
        public ArrayList createList()
        {
            ArrayList arrayList = new ArrayList();
            List<string> strs = readerWriter.readDataFromFile();
            int strCount = 0;
            foreach(string s in strs)
            {
                arrayList.Add(parseInfo(s));
                strCount++;
            }
            return arrayList;
        }
        public void showList()
        {
            Console.WriteLine("{0, -15} {1, -17} {2, -12} {3, -5} {4}","Назва Пісні:","Виконавець:","Альбом:","Дата Випуску","Тривалість Пісні:");
            foreach(PlayList p in playlist )
                {
                Console.WriteLine("{0, -15} {1, -17} {2, -12} {3, -5} {4}", p.Name, p.Singer, p.Album, p.Date.Date.ToString("dd/MM/yyyy"),p.Duration);
            }
        }
        public void addNew()
        {
            Console.WriteLine("Введіть дані через кому");
            try
            {
                string strInfo = Console.ReadLine();
                PlayList play = parseInfo(strInfo);
                playlist.Add(play);
                readerWriter.saveList(playlist);
            }
            catch(FormatException exp)
            {
                Console.WriteLine(exp.Message);
            }
        }
        public void delete()
        {
            Console.WriteLine("Введіть назву пісні:");
            try
            {
                int count = 0;
                string str = Console.ReadLine();
                foreach(PlayList p in playlist)
                {

                    if (p.Name == str)
                    {
                        p.showInfo();
                        Console.WriteLine("Видалити?(Y/N)");
                        var key = Console.ReadKey().Key;
                        if (key == ConsoleKey.Y)
                        {
                            playlist.Remove(p);
                            Console.WriteLine("Видалено Успішно");
                            break;
                        }

                    }
                    else
                        count++;
                }
                if (count == playlist.Count)
                {
                    Console.WriteLine("Такої пісні немає серед альбомів");
                }
                else
                    readerWriter.saveList(playlist);
            }
            catch(FormatException exp)
            {
                Console.WriteLine(exp.Message);
            }
        }
        public void edit()
        {
            Console.WriteLine("Введіть назву пісні:");
            try
            {
                int count = 0;
                string str = Console.ReadLine();
                foreach(PlayList p in playlist)
                {
                    if(p.Name == str)
                    {
                        p.showInfo();
                        Console.WriteLine("Введіть інформацію через кому");
                        string strInfo = Console.ReadLine();
                        PlayList editedSong = parseInfo(strInfo);
                        editedSong.showInfo();
                        Console.WriteLine("Зберегти зміни?(Y/N)");
                        var key = Console.ReadKey().Key;
                        if (key == ConsoleKey.Y)
                        {
                            playlist.Remove(p);
                            playlist.Add(editedSong);
                            break;
                        }
                     
                    }
                    else
                        count++;
                }
                if (count == playlist.Count)
                    Console.WriteLine("Такої пісні немає серед альбомів");
                else
                    readerWriter.saveList(playlist);
            }
            catch(FormatException exp)
            {
                Console.WriteLine(exp.Message);
            }
        }
        public void showSortByYear()
        {
             playlist.Sort(new PlayList.SortByYear());
            showList();
            
        }
        public void showSortByDuration()
        {
            playlist.Sort(new PlayList.SortByDuration());
            showList();
        }
    }
}
