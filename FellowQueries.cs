using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsandDelegates
{
    class FellowQueries
    {
        // Step 1 - Establish the datasource,a list of Fellow objects

        public IEnumerable<Fellow> Fellows = new List<Fellow>()
        {
            new Fellow(){FirstName="Solomon", LastName= "Grounding", Track="Javascript", Gender="Male", DateOfBirth= new DateTime(1992,10,30) },
            new Fellow(){FirstName="Jake", LastName= "Hassan", Track="DevOps", Gender="Male", DateOfBirth= new DateTime(1999,10,3) },
            new Fellow(){FirstName="Denola", LastName= "Grey", Track="DevOps", Gender="Female", DateOfBirth= new DateTime(1995,5,30) },
            new Fellow(){FirstName="Cephas", LastName= "Ademosun", Track="Javascript", Gender="Female", DateOfBirth= new DateTime(2002,1,22) },
            new Fellow(){FirstName="Jane", LastName= "Okeke", Track="DotNet", Gender="Female", DateOfBirth= new DateTime(1998,7,12) },
            new Fellow(){FirstName="Leke", LastName= "Ade", Track="Dotnet", Gender="Male", DateOfBirth= new DateTime(2000,4,18) },
            new Fellow(){FirstName="Temiloluwa", LastName= "Tegbe", Track="DotNet", Gender="Male", DateOfBirth= new DateTime(2005,7,31) },
            new Fellow(){FirstName="Rabo", LastName= "Yusuf", Track="Javascript", Gender="Male", DateOfBirth= new DateTime(1992,9,10) },
            new Fellow(){FirstName="Bolaji", LastName= "Asun", Track="Javascript", Gender="Male", DateOfBirth= new DateTime(1990,6,23) },
            new Fellow(){FirstName="Hope", LastName= "Casso", Track="DotNet", Gender="Male", DateOfBirth= new DateTime(2006,2,25) }
        };


        /*
        QUERY EXPECTATIONS
        1. Fetch all fellows, sorted by lastname in ascending order
        2. Fetch all fellows born in the year 2005 and later, sorted in descending order of date of birth
        3. Fetch all fellows with undisclosed gender
        4. Fetch all fellows who were not born between 1995 and 2004, and grouped by their respective tracks
        5. Fetch all fellows grouped by track, and sorted in ascending order of first name
        */



        //Step 2 - Write a bunch of queries using expression syntax

        // Fetch all fellows, sorted by lastname in ascending order
        public void GetFellowsSortedByLastName1()
        {
            IEnumerable<Fellow> lastNameSortQuery = from fellow in Fellows
                                                    orderby fellow.LastName descending
                                                    select fellow;

            Console.WriteLine("List of Fellows, sorted by last name in descending order[Expression Syntax]");
            System.Console.WriteLine("First Name \t Last Name \t Date of Birth \t Gender \t Track");

            foreach (Fellow objFellow in lastNameSortQuery)
            {
                Console.WriteLine($"{objFellow.FirstName} \t {objFellow.LastName} \t\t {objFellow.DateOfBirth.ToShortDateString()} \t{objFellow.Gender}");
            }



        }

        //Fetch all fellows born in the year 2005 and later, sorted in descending order of date of birth

        public void GetFellowsBornfrom2005SortedDesc1()
        {
            IEnumerable<Fellow> dobFrom2005SortQuery = from Fellow in Fellows
                                                       where Fellow.DateOfBirth.Year>=2005
                                                       orderby Fellow.DateOfBirth descending
                                                       select Fellow;

            Console.WriteLine("List of Fellows, born in 2005, sorted in descending order of DOB[Expression Syntax]");
            System.Console.WriteLine("First Name \t Last Name \t Date of Birth \t Gender \t Track");

            foreach (Fellow objFellow in dobFrom2005SortQuery)
            {
                Console.WriteLine($"{objFellow.FirstName} \t {objFellow.LastName} \t\t {objFellow.DateOfBirth.ToShortDateString()} \t{objFellow.Gender}");
            }


        }

        //Fetch all fellows with undisclosed gender
        public void GetFellowsNeitherMaleNorFemale1()
        {
            IEnumerable<Fellow> neitherMaleNorFemaleQuery = from fellow in Fellows
                                                            where fellow.Gender != "Male" && fellow.Gender != "Female"
                                                            select fellow;

            Console.WriteLine("\n\n List of Fellows neither male nor female[EXPRESSION SYNTAX]");
            Console.WriteLine("\nFirstName\t\tLastName\t\t Date Of Birth\t\t Gender\t\tTrack");

            foreach (Fellow objFellow in neitherMaleNorFemaleQuery)
            {
                Console.WriteLine($"{objFellow.FirstName} \t {objFellow.LastName} \t\t {objFellow.DateOfBirth.ToShortDateString()} \t{objFellow.Gender}");

            }
        }

        // Fetch all fellows who were not born between 1995 and 2004, and grouped by their respective tracks

        public void GetFellowsGroupedByTracks()
        {
            IEnumerable<IGrouping<string,Fellow>> groupedByTrackQuery = from fellow in Fellows
                                                      where fellow.DateOfBirth.Year <= 1995 || fellow.DateOfBirth.Year >= 2004
                                                      group fellow by fellow.Track;

            Console.WriteLine("\n\n List of Fellows not born btw 1995 and 2004, grouped by tracks[EXPRESSION SYNTAX]");
            Console.WriteLine("\nFirstName\t\tLastName\t\t Date Of Birth\t\t Gender\t\tTrack");

            //Execute query to obtain the results
            foreach (var objGroup in groupedByTrackQuery)
            {
                Console.WriteLine(objGroup.Key.ToUpper());

                foreach (Fellow objFellow in objGroup)
                {
                    Console.WriteLine($"{objFellow.FirstName} \t {objFellow.LastName} \t\t {objFellow.DateOfBirth.ToShortDateString()} \t{objFellow.Gender}");

                }



            }
        }




        //Step 3 - Repeat the above queries using method syntax
        // fetch all Fellows sorted by lastname in descending order, using method syntax
        public void GetFellowsSortedByLastName2()
        {
            IEnumerable<Fellow> lastNameQuerySort = Fellows.OrderByDescending(f => f.LastName);

            Console.WriteLine("\n\n List of Fellows, sorted by lastname in descending order.......METHOD SYNTAX");
            Console.WriteLine("\nFirstName\t\tLastName\t\t Date Of Birth\t\t Gender");

            foreach (Fellow objFellow in lastNameQuerySort)
            {
                Console.WriteLine($"{objFellow.FirstName} \t {objFellow.LastName} \t\t {objFellow.DateOfBirth.ToShortDateString()} \t{objFellow.Gender}");

            }
        }

        //Fetch all fellows born in the year 2005 and later, sorted in descending order of date of birth

        public void GetFellowsBornfrom2005SortedByDesc2()
        {

            IEnumerable<Fellow> dobFrom2005SortQuery = Fellows
                                                       .Where(f => f.DateOfBirth.Year >= 2005)
                                                       .OrderByDescending(f => f.DateOfBirth);

            Console.WriteLine("List of Fellows, born in 2005, sorted in descending order of DOB[Method Syntax]");
            System.Console.WriteLine("First Name \t Last Name \t Date of Birth \t Gender \t Track");

            foreach (Fellow objFellow in dobFrom2005SortQuery)
            {
                Console.WriteLine($"{objFellow.FirstName} \t {objFellow.LastName} \t\t {objFellow.DateOfBirth.ToShortDateString()} \t{objFellow.Gender}");
            }
        }



        //Fetch all fellows with undisclosed gender
        public void GetFellowsNeitherMaleNorFemale2()
        {
            IEnumerable<Fellow> neitherMaleNorFemaleQuery = Fellows
                                                            .Where(f => f.Gender != "Male" && f.Gender != "Female");


            Console.WriteLine("\n\n List of Fellows neither male nor female[METHOD SYNTAX]");
            Console.WriteLine("\nFirstName\t\tLastName\t\t Date Of Birth\t\t Gender\t\tTrack");

            foreach (Fellow objFellow in neitherMaleNorFemaleQuery)
            {
                Console.WriteLine($"{objFellow.FirstName} \t {objFellow.LastName} \t\t {objFellow.DateOfBirth.ToShortDateString()} \t{objFellow.Gender}");

            }
        }

        // Fetch all fellows who were not born between 1995 and 2004, and grouped by their respective tracks

        public void GetFellowsGroupedByTracks2()
        {
            IEnumerable<IGrouping<string, Fellow>> groupedByTrackQuery = Fellows
                                                                         .Where(f => f.DateOfBirth.Year <= 1995 || f.DateOfBirth.Year >= 2004)
                                                                         .GroupBy(f => f.Track);

            Console.WriteLine("\n\n List of Fellows not born btw 1995 and 2004, grouped by tracks[METHOD SYNTAX]");
            Console.WriteLine("\nFirstName\t\tLastName\t\t Date Of Birth\t\t Gender\t\tTrack");

            //Execute query to obtain the results
            foreach (var objGroup in groupedByTrackQuery)
            {
                Console.WriteLine(objGroup.Key.ToUpper());

                foreach (Fellow objFellow in objGroup)
                {
                    Console.WriteLine($"{objFellow.FirstName} \t {objFellow.LastName} \t\t {objFellow.DateOfBirth.ToShortDateString()} \t{objFellow.Gender}");

                }



            }
        }


    }
}
