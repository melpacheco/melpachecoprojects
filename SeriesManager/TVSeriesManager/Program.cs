using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeriesManager;
using SeriesManager.Data;

using SeriesManager.View;

namespace TVSeriesManager
{
    public class Program
    {
        static void Main(string[] args)
        {
            SeriesController seriesController = new SeriesController();
            while (true)
            {
                seriesController.Run();
                Console.ReadLine();
                Console.Clear();
            }





            //This block probably needs to go in the "View" of this method rather than program? and then call the view 
            //    method as part of the workflow/program






            //AlexHelpLists alexHelpLists = new AlexHelpLists();

            //List<string> TwatWaffleLists = alexHelpLists.ListofStingsCreatedOneByOne();
            //List<HusbandsAreCool> NewListOfShit = alexHelpLists.ButAlsoWeird();

            //foreach ( var x in NewListOfShit)
            //{
            //    Console.WriteLine(x.Id);
            //    Console.WriteLine(x.Description);


            //    Console.ReadLine();

            //}

        }
    }


    //class AlexHelpLists
    //{

    //    public List<string> ListofStingsCreatedOneByOne()
    //    {
    //        List<string> FuckingListOfStrings = new List<string>();

    //        string one = "I am awesome";
    //        string two = "I am super cool";
    //        string three = "I prefer sausage to taco";

    //        FuckingListOfStrings.Add(one);
    //        FuckingListOfStrings.Add(two);
    //        FuckingListOfStrings.Add(three);

    //        return FuckingListOfStrings;


    //    }

    //    public List<HusbandsAreCool> ButAlsoWeird()
    //    {
    //        List<HusbandsAreCool> ButAlsoWeird = new List<HusbandsAreCool>();

    //        for (int i = 0; i < 15; i++)
    //        {
    //            HusbandsAreCool newhusband = new HusbandsAreCool();
    //            newhusband.Id = i;
    //            newhusband.Description = "Hot and smart";

    //            ButAlsoWeird.Add(newhusband);

    //        }

    //        return ButAlsoWeird;

    //    }


       
    //}
    //public class HusbandsAreCool
    //{
    //    public int Id { get; set; }
    //    public string Description { get; set; }
    //}
}

