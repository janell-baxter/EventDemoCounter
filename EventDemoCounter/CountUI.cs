using System;
using static System.Console;

namespace EventDemoCounter
{
    class CountUI
    {
        Counter counter;
        public CountUI() => SetUp();

        private void SetUp()
        {
            Clear();
            Title = "Event Example (counter and threshold)";
            counter = new Counter(new Random().Next(2, 10));
            counter.ThresholdReached += c_ThresholdReached;
            ShowInstructions();
        }
        private void ShowInstructions()
        {
            WriteLine($"A random number has been chosen as a threshold ({counter.Threshold}).\nNumbers will increment automatically until this threshold has been met.");
            Run();
        }

        private void Run()
        {
            counter.Add(1);
            WriteLine(counter.Total);
            Run();
        }
     
        private void c_ThresholdReached(object sender, EventArgs e)
        {
            WriteLine($"*{counter.Total}*");
            WriteLine($"The threshold {counter.Threshold} was reached. Press any key to run this again, or x to exit.");
            if (Console.ReadKey().Key == ConsoleKey.X)
                Environment.Exit(0);
            //else
            SetUp();
        }
    }
}
