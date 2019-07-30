using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeriesModels;




namespace SeriesManager.Data
{
    public class SeriesRepos
    {

        public static List<Series> TVSeriesList()
        {
            List<Series> SeasonList = new List<Series>();
            {

               SeasonList.Add(new Series { Id = 1, Title = "Criminal Minds", ReleaseYear = 2005, Genre = "Drama", CompletedSeries = false });
               SeasonList.Add(new Series { Id = 2, Title = "Parks and Recreation", ReleaseYear = 2009, Genre = "Comdey", CompletedSeries = true });
               SeasonList.Add(new Series { Id = 3, Title = "How I Met Your Mother", ReleaseYear = 2005, Genre = "Comedy", CompletedSeries = true });
               SeasonList.Add(new Series { Id = 4, Title = "Grey's Anatomy", ReleaseYear = 2005, Genre = "Drama", CompletedSeries = false });
               SeasonList.Add(new Series { Id = 5, Title = "Brooklyn Nine-Nine", ReleaseYear = 2013, Genre = "Comedy", CompletedSeries = false });
               SeasonList.Add(new Series { Id = 6, Title = "Scrubs", ReleaseYear = 2001, Genre = "Comedy", CompletedSeries = true });
               SeasonList.Add(new Series { Id = 7, Title = "The Office", ReleaseYear = 2005, Genre = "Comedy", CompletedSeries = true });
               SeasonList.Add(new Series { Id = 8, Title = "SuperNatural", ReleaseYear = 2005, Genre = "Drama", CompletedSeries = false }) ;
               SeasonList.Add(new Series { Id = 9, Title = "Freaks and Geeks", ReleaseYear = 1999, Genre = "Comedy", CompletedSeries = true });
               SeasonList.Add(new Series { Id = 10, Title = "Law & Order:SVU", ReleaseYear = 1999, Genre = "Drama", CompletedSeries = false });
            }


            return SeasonList;
        }



        private List<Series> SeriesList = TVSeriesList();
        

        public void Create(Series series)
        {
            int nextID = SeriesList.Count();
            nextID += 1;
            series.Id = nextID;
            SeriesList.Add(series);

        }


        public List<Series> ReadAll()
        {

           return SeriesList;
        

        }

        public string ReadById(int userEnteredId)
        {
            foreach (var x in SeriesList)
            {
                if (x.Id == userEnteredId)
                {
                    return x.Title;

                }

            }

            return null;
        }

        public void Update(int id, string DVD, int ReleaseYear, string Genre, bool CompletedSeries)
        {
          
            id--;
            SeriesList[id].Title = DVD;
            SeriesList[id].ReleaseYear = ReleaseYear;
            SeriesList[id].Genre = Genre;
            SeriesList[id].CompletedSeries = CompletedSeries;
        }

        public string Delete(int id)
        {
            

            foreach (Series x in SeriesList)
            {
                if (x.Id == id)
                {
                    string titleRemoved = x.Title;
                    SeriesList.Remove(x);
                    return titleRemoved;

                }
                
            }

            return null;
        }



    }
}



        
        
   

   

