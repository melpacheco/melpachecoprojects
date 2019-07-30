
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeriesManager.Data;
using SeriesManager.View;
using SeriesModels;


namespace SeriesManager
{
   public class SeriesController
    {
        //public SeriesController()
        //{
        SeriesRepos seriesRepository = new SeriesRepos();
        ConsoleInput consoleInput = new ConsoleInput();
         
        //}







        private void CreateSeries(string userTitle, int ruserYear, string userGenre, bool userComplete)
        {

            Series newSeries = new Series();
            newSeries.Title = userTitle;
            newSeries.ReleaseYear = ruserYear;
            newSeries.Genre = userGenre;
            newSeries.CompletedSeries = userComplete;
          



            seriesRepository.Create(newSeries);
        


        }

        private void AddSeriesWorkFlow()
        {


            Series newSeries = new Series();
            newSeries.Title = consoleInput.GetNewSeriesTitle();
            newSeries.Genre = consoleInput.GetNewSeriesGenre();
            newSeries.ReleaseYear = consoleInput.GetNewSeriesReleaseYear();
            newSeries.CompletedSeries = consoleInput.GetNewSeriesCompleted();
            CreateSeries(newSeries.Title, newSeries.ReleaseYear, newSeries.Genre, newSeries.CompletedSeries);
            consoleInput.DisplaySeriesCreated(newSeries.Title);
        }

        private List<Series> DisplaySeries()
        {
            return seriesRepository.ReadAll();
        }

        private void DisplaySeriesWorkFlow()
        {
            consoleInput.DisplaySeriesInfo();
   
            consoleInput.ListSeries(seriesRepository.ReadAll());
        }

        private string SearchSeries(int seriesID)
        {
      
          return  seriesRepository.ReadById(seriesID);
          

        }

        private void SearchSeriesWorkFlow()
        {
            int seriesID = consoleInput.SearchSeries();
            string series = SearchSeries(seriesID);
            consoleInput.DisplaySearchedSeries(series);
        }

        private void EditSeries(int id, string DVD, int releaseYear, string Genre, bool completedSeries)
        {
           
            seriesRepository.Update(id, DVD, releaseYear, Genre, completedSeries);
           


        }


        private void EditSeriesWorkFlow()
        {
            int id;
            string DVD;
            string Genre;
            bool completedSeries;
            int releaseYear;
            do
            {
                id = consoleInput.EditSeriesId();
                DVD = consoleInput.EditSeriesTitle();
                Genre = consoleInput.EditSeriesGenre();
                completedSeries = consoleInput.EditCompletedSeries();
                releaseYear = consoleInput.EditReleaseYear();

            }
            while (!consoleInput.AreYouSureEdit(id, DVD, Genre, releaseYear, completedSeries));
            EditSeries(id, DVD, releaseYear, Genre, completedSeries);
            consoleInput.ConfirmEditedSeries(DVD);
        }

        private void RemoveSeries(int removeId)
        {
           
             seriesRepository.Delete(removeId);
           
        }

   

        private void RemoveSeriesWorkFlow()
        {
            int possibleRemoveId;
            string Title;
                do
                {
                    possibleRemoveId = consoleInput.ConfirmRemove();
                    Title = seriesRepository.ReadById(possibleRemoveId);
                }
                while (!consoleInput.AreYouSureRemove(Title, possibleRemoveId));
            RemoveSeries(possibleRemoveId);
            consoleInput.DisplayRemovedTitle(Title);
            }    
        

        public void Run()
        {
            

            int choice = consoleInput.GetMenuCoice();
            switch (choice)
            {
                case 1:
                    AddSeriesWorkFlow();
                    break;

                case 2:

                    DisplaySeriesWorkFlow();
                    break;


                case 3:
                    SearchSeriesWorkFlow();
                    break;


                case 4:
                    EditSeriesWorkFlow();
                    break;
                case 5:

                    RemoveSeriesWorkFlow();
                    break;

            }



        }
    }
}
