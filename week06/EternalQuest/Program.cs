/* 
    * Motivational Quotes
    After every Recorded Event, the program displays one of three random quotes
    to motivate the user.
    * Checklist goals award their bonus only once.
*/

using System;

namespace EternalQuest
{
    class Program
    {
        static void Main(string[] args)
        {
            GoalManager manager = new GoalManager();
            manager.Start();
        }
    }
}