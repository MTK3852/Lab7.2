using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7._2
{
    class ReaderWriter
    {


        public List<string> readDataFromFile()
        {
            List<string> lines = new List<string>();
            string line;
            StreamReader file = new StreamReader("E:text2.txt", Encoding.GetEncoding(1251));
            while ((line = file.ReadLine()) != null)
            {
                lines.Add(line);
            }

            file.Close();
            return lines;
        }

        public void saveList(ArrayList playlists)
        {
            using (StreamWriter save = new StreamWriter("E:text2.txt", false, Encoding.GetEncoding(1251)))
            {
                string str = null;

                foreach (PlayList playlist in playlists)
                {
                    str = playlist.Name + ","+playlist.Singer + ","+ playlist.Album+","+ playlist.Date.ToString("dd/MM/yyyy")+","+playlist.Duration;
                    save.WriteLine(str);
                }

            }
        }
    }
}