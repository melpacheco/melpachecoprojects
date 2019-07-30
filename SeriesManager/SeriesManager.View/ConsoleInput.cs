using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeriesModels;







namespace SeriesManager.View
{
    public class ConsoleInput
    {
        public int GetMenuCoice()
        {

            Console.WriteLine("Choose from the following options:" + Environment.NewLine +
                "1.Create" + Environment.NewLine + "2.List All" + Environment.NewLine + "3.Find by Id" +
                Environment.NewLine + "4.Edit" + Environment.NewLine + "5.Remove");
            string input = Console.ReadLine();
            int.TryParse(input, out int choice);
            return choice;
        }

        public string GetNewSeriesTitle()
        {

            Console.Write("Enter the title of the series here: ");
            string titleInput = Console.ReadLine();
            while (!IsValidStringInput(titleInput))
            {
                Console.WriteLine("Title is a required entry. Try again: ");
                titleInput = Console.ReadLine();
            }
            return titleInput;
        }

        public int GetNewSeriesReleaseYear()
        {
            Console.Write("Enter the year the series was released here: ");
            string yearInput = Console.ReadLine();
            int releaseYear;
            while (!int.TryParse(yearInput, out releaseYear))
            {
                Console.WriteLine("Please enter a numerical value:");
                yearInput = Console.ReadLine();
            }
            return releaseYear;
        }

        public string GetNewSeriesGenre()
        {
            Console.Write("Enter the genre of the series here: ");
            string genreInput = Console.ReadLine();
            while (!IsValidStringInput(genreInput))
            {
                Console.Write("Genre is a required entry. Try again:");
                genreInput = Console.ReadLine();
            }
            return genreInput;
        }

        public bool GetNewSeriesCompleted()
        {
            Console.Write("Has the series been completed? Enter Y or N: ");
            string completeInput = Console.ReadLine();

            while (!IsValidStringInput(completeInput))
            {
                Console.Write("This is a required field. Please enter Y or N: ");
                completeInput = Console.ReadLine();

            }
            while (completeInput.ToUpper() != "Y" && completeInput.ToUpper() != "N")
            {
                Console.Write("Please enter only Y or N: ");
                completeInput = Console.ReadLine();
            }
            if (completeInput == "Y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void DisplaySeriesCreated(string seriesTitle)
        {
            Console.WriteLine($"{seriesTitle} has been created!");
        }




        public void DisplaySeriesInfo()
        {
            Console.WriteLine("Press any key to get a list of all series listed.");
            Console.ReadKey();
         
        }

        public void ListSeries(List<Series> ListAll)
        {
            foreach (var x in ListAll)
            {
                Console.WriteLine($"{ x.Id}, {x.Title}, {x.ReleaseYear}, {x.Genre}, {x.CompletedSeries}");
            }

        }

        public int EditSeriesId()
        {

            Console.Write("Enter the ID of the series to be updated: ");
            string input = Console.ReadLine();
            int id;
            while (!int.TryParse(input, out id))
            {
                Console.Write("Please enter a numerical value: ");
                input = Console.ReadLine();
            }
            return id;
        }

        public string EditSeriesTitle()
        {
            Console.Write("Enter the new title of the Series:");
            string inputTitle = Console.ReadLine();
            while (!IsValidStringInput(inputTitle))
            {
                Console.Write("This is a required field. Please enter title of the series: ");
                inputTitle = Console.ReadLine();
            }
            return inputTitle;
        }

        public int EditReleaseYear()
        {

            Console.Write("Enter the year the series was released here: ");
            string yearInput = Console.ReadLine();
            int releaseYear;
            while (!int.TryParse(yearInput, out releaseYear))
            {
                Console.WriteLine("Please enter a numerical value:");
                yearInput = Console.ReadLine();
            }
            return releaseYear;
        }

        public string EditSeriesGenre()
        {
            Console.Write("Enter the genre of the series here: ");
            string genreInput = Console.ReadLine();
            while (!IsValidStringInput(genreInput))
            {
                Console.Write("Genre is a required entry. Try again:");
                genreInput = Console.ReadLine();
            }
            return genreInput;
        }

        public bool EditCompletedSeries()
        {
            Console.Write("Has the series been completed? Enter Y or N: ");
            string completeInput = Console.ReadLine();

            while (!IsValidStringInput(completeInput))
            {
                Console.Write("This is a required field. Please enter Y or N: ");
                completeInput = Console.ReadLine();

            }
            while (completeInput.ToUpper() != "Y" && completeInput.ToUpper() != "N")
            {
                Console.Write("Please enter only Y or N: ");
                completeInput = Console.ReadLine();

            }

            if (completeInput == "Y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AreYouSureEdit(int id, string series, string genre, int releaseYear, bool completedSeries)
        {
            Console.WriteLine($"Does this look right? {id} {series} {genre} {releaseYear} {completedSeries} Enter Y or N: ");
            string input = Console.ReadLine();
            while (!IsValidStringInput(input))
            {
                Console.Write("This is a required field. Please enter Y or N: ");
                input = Console.ReadLine();

            }
            while (input.ToUpper() != "Y" && input.ToUpper() != "N")
            {
                Console.Write("Please enter only Y or N: ");
                input = Console.ReadLine();

            }
            if (input.ToUpper() == "Y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ConfirmEditedSeries(string seriesTitle)
        {
            Console.WriteLine($"{seriesTitle} has been created!");
        }


        public int SearchSeries()
        {

            Console.Write("Enter the ID of the series to be viewed: ");
            string input = Console.ReadLine();
            int.TryParse(input, out int searchID);
            return searchID;

        }

        public void DisplaySearchedSeries(string series)
        {
            Console.WriteLine($"{series}");
        }

        public int ConfirmRemove()
        {

            Console.Write("Enter the Id of the series to be removed: ");
            string input = Console.ReadLine();
            int.TryParse(input, out int removedSeries);
            return removedSeries;
        }

        public bool AreYouSureRemove(string title, int id)
        {
            Console.WriteLine($"You'd like to remove {id}: {title}. Enter Y or N:");
            string input = Console.ReadLine();
            while (!IsValidStringInput(input))
            {
                Console.Write("This is a required field. Please enter Y or N: ");
                input = Console.ReadLine();

            }
            while (input.ToUpper() != "Y" && input.ToUpper() != "N")
            {
                Console.Write("Please enter only Y or N: ");
                input = Console.ReadLine();

            }
            if (input.ToUpper() == "Y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void DisplayRemovedTitle(string title)
        {
            Console.WriteLine($"{title} has been removed!");
        }

        public static bool IsValidStringInput(string input)
        {
            if (String.IsNullOrEmpty(input))
            {
                return false;
            }
            else
            {
                return true;
            }

        }



    }
}
