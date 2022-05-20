// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WorkFromHomeCalc_Harrison

{
    class Program
    {
        static string fileName = "Hoursbeenworked.txt"; //global var
        static void Main(string[] args)
        {
            /* giving a choice 
            for the user */

            int ch;
            //displaying a menu until a choice is made
            do
            {
                Console.WriteLine("\n1. Enter Daily hours worked\n2. Produce hours worked report\n3. Exit");
                Console.Write("Enter your choice >>> ");
                ch = int.Parse(Console.ReadLine());

                //choice 1
                if(ch==1)
                {
                    EnterDailyHours();
                }
                //choice 2
                if(ch==2)
                {
                    HoursWorkedReport();
                }
                //choice 3
                if(ch==3)
                {
                    Console.WriteLine("GoodBye!");
                }
                //if user puts in wrong number
                if(ch!=1 || ch!=2 || ch!=3)
                {
                    Console.WriteLine("Wrong Choice Choose again Fool!: ");
                    ch=int.Parse(Console.ReadLine());
                }
            } while (ch != 3);
        }
        //Read from a file
        private static void HoursWorkedReport()
        {
            //making a list to store
            List<string> lines = new List<string>(File.ReadAllLines(fileName));
            lines.Reverse();
            //ask if how many records it wants to see
            Console.WriteLine("How many records do you want to display >>> ");
            int records = int.Parse(Console.ReadLine());
                foreach(string line in lines.Take(records))
                {
                    Console.WriteLine(line);

                }
        }
        private static void EnterDailyHours()
        {
            //throw new Notimplementedexception();
            //Making week var
            int cWeek;
            Console.Write("Enter Current week number >>> ");
            cWeek=int.Parse(Console.ReadLine());
            //employee id
            int[] employeeID = new int[7];
            string[] employeename = new string [7];
            //making the arrays
            string[] days = {"Monday", "Tuesday", "Wednesday", "Thursday", "Friday"};
            int lessThirty =  0, moreForty = 0, sufficientThirties = 0;
            //loop id
            for(int i=0;i<2;i++) //the loop
            {
                Console.Write("\nEnter employee id >>> ");
                employeeID[i] = int.Parse(Console.ReadLine());
                Console.Write("\nEnter employee name >>> ");
                employeename[i] = Console.ReadLine();

                int hours = 0, totalhours = 0;
                string hoursWorked = " ";
                List<string> LessHoursDays = new List<string>();
                List<string> MoreHoursDays = new List<string>();
                foreach(string day in days) //looop through days
                {
                    Console.Write($"\nEnter Hours worked on {day} >>> ");
                    hours = int.Parse(Console.ReadLine());
                    hoursWorked = hoursWorked + hours + " ";
                    totalhours = totalhours + hours;
                    //check if hours are less than 4 or more than 10
                    if (hours<4)
                    {
                        LessHoursDays.Add(day);
                    }
                    if(hours>10)
                    {
                        MoreHoursDays.Add(day);
                    }
                } //end loop
                //display a summary
                Console.WriteLine("***************************");
                Console.WriteLine($"Summary For employee ID : {employeeID[i]} ");
                Console.WriteLine($"Emlpoyee Name : {employeename[i].ToUpper()}");
                /* CHeck if the less hours days list
                and more hours days lists are >0*/
                if(LessHoursDays.Count>0)
                {
                    Console.Write(" *** You didnt work enough on : ");
                    foreach (string day in LessHoursDays)
                    {
                        Console.Write($"{day} ");
                    }
                }
                if(MoreHoursDays.Count>0)
                {
                    Console.Write("\nYou work too much on");
                    foreach(string day in MoreHoursDays) //display all days from more hours days list
                    {
                        Console.Write($"{day} ");
                    }
                }
                //display total and check ints
                Console.Write($"\nTotal Hours Worked For the Week {cWeek} : {totalhours} Hours");
                if(totalhours<30)
                {
                    Console.Write("\n*** You Didnt Work Enough ***");
                    lessThirty++;
                }
                else if(totalhours>40)
                {
                    Console.Write("\n Take a break your working alot");
                    moreForty++;
                }
                else
                {
                    Console.Write("\n You did a nice amount of work for the week Gj");
                    sufficientThirties++;
                }
                //write to file
                string line = $"Week {cWeek}, {employeeID[i]}, {employeename[i]}, {hoursWorked}\n";
                File.AppendAllText(fileName, line);
            }//end loop
            //displaying the repor
            Console.WriteLine("\n*************************************************************************");
            Console.WriteLine("                             Weekly Employee Report                        ");
            Console.WriteLine($"Total Employees worked less than 30 hours : {lessThirty}");
            Console.WriteLine($"Total Employees worked more than 40 hours : {moreForty}");
            Console.WriteLine($"Total Employees worked between than 30-40 hours : {sufficientThirties}");
        }
    }
}