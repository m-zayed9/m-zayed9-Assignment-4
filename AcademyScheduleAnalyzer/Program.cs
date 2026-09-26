using System;
using System.Text;
using BenchmarkDotNet.Running;
using AcademyScheduleAnalyzer.Benchmarks;

namespace AcademyScheduleAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            // Part 1
            string[] sessionNames =
            {
                "C# Basics",
                "Arrays",
                "Functions",
                "Date and Time",
                "Exception Handling"
            };

            DateTime[] sessionDates =
            {
                new DateTime(2026, 9, 10, 18, 0, 0),
                new DateTime(2026, 9, 13, 18, 0, 0),
                new DateTime(2026, 9, 17, 18, 0, 0),
                new DateTime(2026, 9, 28, 18, 0, 0),
                new DateTime(2026, 9, 29, 18, 0, 0)
            };

            int[] sessionDurations =
            {
                180,
                240,
                180,
                240,
                180
            };

            RunMenu(sessionNames, sessionDates, sessionDurations);
        }

        // Part 31
        static void RunMenu(string[] sessionNames, DateTime[] sessionDates, int[] sessionDurations)
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine("===================================");
                Console.WriteLine("Academy Schedule Analyzer");
                Console.WriteLine("===================================");
                Console.WriteLine("1.  Display all sessions (Part 2)");
                Console.WriteLine("2.  Search for a session (Part 3)");
                Console.WriteLine("3.  Sort session names (Part 4.1)");
                Console.WriteLine("4.  Reverse session names (Part 4.2)");
                Console.WriteLine("5.  Find session index (Part 4.3)");
                Console.WriteLine("6.  Check if session exists (Part 4.4)");
                Console.WriteLine("7.  Find a session (Part 4.5)");
                Console.WriteLine("8.  Find session index using a condition (Part 4.6)");
                Console.WriteLine("9.  Copy array demo (Part 4.7)");
                Console.WriteLine("10. Duration statistics (Part 5)");
                Console.WriteLine("11. ref example (Part 7.1)");
                Console.WriteLine("12. out example (Part 7.2)");
                Console.WriteLine("13. Reference type without ref example (Part 7.3)");
                Console.WriteLine("14. params example (Part 8)");
                Console.WriteLine("15. Session date details (Part 9)");
                Console.WriteLine("16. Compare two session dates (Part 10)");
                Console.WriteLine("17. Past and upcoming sessions (Part 11)");
                Console.WriteLine("18. Find next session (Part 12)");
                Console.WriteLine("19. Date formatting examples (Part 13)");
                Console.WriteLine("20. Read and validate a custom date (Part 14)");
                Console.WriteLine("21. Select session by index (Part 16)");
                Console.WriteLine("22. Validate session duration (Part 17 & 18)");
                Console.WriteLine("23. Generate report using string (Part 19)");
                Console.WriteLine("24. Generate report using StringBuilder (Part 20)");
                Console.WriteLine("25. Run BenchmarkDotNet benchmarks (Part 21)");
                Console.WriteLine("0.  Exit");
                Console.Write("Choose an option: ");

                int option = ReadMenuOption(); // Part 15

                switch (option)
                {
                    case 1:
                        DisplaySessions(sessionNames, sessionDates, sessionDurations);
                        break;

                    case 2:
                        SearchSession(sessionNames, sessionDates, sessionDurations);
                        break;

                    case 3:
                        SortSessionNames(sessionNames);
                        break;

                    case 4:
                        ReverseSessionNames(sessionNames);
                        break;

                    case 5:
                        FindSessionIndex(sessionNames);
                        break;

                    case 6:
                        CheckSessionExists(sessionNames);
                        break;

                    case 7:
                        FindSessionByCondition(sessionNames);
                        break;

                    case 8:
                        FindSessionIndexByCondition(sessionNames);
                        break;

                    case 9:
                        CopyArrayDemo(sessionNames);
                        break;

                    case 10:
                        ShowDurationStatistics(sessionDurations);
                        break;

                    case 11:
                        ShowRefExample();
                        break;

                    case 12:
                        ShowOutExample(sessionNames, sessionDurations);
                        break;

                    case 13:
                        ShowReferenceTypeWithoutRefExample(sessionNames);
                        break;

                    case 14:
                        ShowParamsExample();
                        break;

                    case 15:
                        ShowSessionDateDetails(sessionNames, sessionDates, sessionDurations);
                        break;

                    case 16:
                        CompareSessionDates(sessionNames, sessionDates);
                        break;

                    case 17:
                        ShowPastAndUpcomingSessions(sessionNames, sessionDates);
                        break;

                    case 18:
                        FindNextSession(sessionNames, sessionDates);
                        break;

                    case 19:
                        ShowDateFormattingExamples(sessionNames, sessionDates);
                        break;

                    case 20:
                        DateTime customDate = ReadSessionDate();
                        Console.WriteLine($"Valid date entered: {customDate}");
                        break;

                    case 21:
                        SelectSessionByIndex(sessionNames, sessionDates, sessionDurations);
                        break;

                    case 22:
                        ValidateDurationInput();
                        break;

                    case 23:
                        string reportString = BuildReportUsingString(sessionNames, sessionDates, sessionDurations);
                        Console.WriteLine(reportString);
                        break;

                    case 24:
                        string reportBuilder = BuildReportUsingStringBuilder(sessionNames, sessionDates, sessionDurations);
                        Console.WriteLine(reportBuilder);
                        break;

                    case 25:
                        RunBenchmarks();
                        break;

                    case 0:
                        running = false;
                        Console.WriteLine("Goodbye!");
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please choose a valid menu number.");
                        break;
                }

                Console.WriteLine();
            }
        }

        // Part 2
        static void DisplaySessions(string[] sessionNames, DateTime[] sessionDates, int[] sessionDurations)
        {
            for (int i = 0; i < sessionNames.Length; i++)
            {
                DisplaySessionDetails(i, sessionNames, sessionDates, sessionDurations);
            }
        }

        // Part 6
        static void DisplaySessionDetails(int index, string[] sessionNames, DateTime[] sessionDates, int[] sessionDurations)
        {
            Console.WriteLine($"{index + 1}. {sessionNames[index]}");
            Console.WriteLine($"   Date: {sessionDates[index]:dd MMMM yyyy}");
            Console.WriteLine($"   Start Time: {sessionDates[index]:hh:mm tt}");
            Console.WriteLine($"   Duration: {sessionDurations[index]} minutes");
        }

        // Part 3
        static void SearchSession(string[] sessionNames, DateTime[] sessionDates, int[] sessionDurations)
        {
            Console.Write("Enter session name: ");
            string name = Console.ReadLine() ?? "";

            int index = Array.IndexOf(sessionNames, name);

            if (index == -1)
            {
                Console.WriteLine("Session not found.");
                return;
            }

            Console.WriteLine($"Name: {sessionNames[index]}");
            Console.WriteLine($"Date: {sessionDates[index]:dd MMMM yyyy}");
            Console.WriteLine($"Start Time: {sessionDates[index]:hh:mm tt}");
            Console.WriteLine($"Duration: {sessionDurations[index]} minutes");
        }

        // Part 4.1
        static void SortSessionNames(string[] sessionNames)
        {
            string[] sortedNames = new string[sessionNames.Length];
            Array.Copy(sessionNames, sortedNames, sessionNames.Length);
            Array.Sort(sortedNames);

            Console.WriteLine("Sorted Session Names:");
            foreach (string name in sortedNames)
            {
                Console.WriteLine($"- {name}");
            }
        }

        // Part 4.2
        static void ReverseSessionNames(string[] sessionNames)
        {
            string[] reversedNames = new string[sessionNames.Length];
            Array.Copy(sessionNames, reversedNames, sessionNames.Length);
            Array.Reverse(reversedNames);

            Console.WriteLine("Reversed Session Names:");
            foreach (string name in reversedNames)
            {
                Console.WriteLine($"- {name}");
            }
        }

        // Part 4.3
        static void FindSessionIndex(string[] sessionNames)
        {
            Console.Write("Enter session name: ");
            string name = Console.ReadLine() ?? "";

            int index = Array.IndexOf(sessionNames, name);

            if (index != -1)
            {
                Console.WriteLine($"Index: {index}");
            }
            else
            {
                Console.WriteLine("Session not found.");
            }
        }

        // Part 4.4
        static void CheckSessionExists(string[] sessionNames)
        {
            Console.Write("Enter session name: ");
            string name = Console.ReadLine() ?? "";

            bool exists = Array.Exists(sessionNames, n => n == name);

            Console.WriteLine(exists ? "Session exists." : "Session does not exist.");
        }

        // Part 4.5
        static void FindSessionByCondition(string[] sessionNames)
        {
            Console.Write("Enter part of the session name to search for: ");
            string keyword = Console.ReadLine() ?? "";

            string? found = Array.Find(sessionNames, n => n.Contains(keyword));

            Console.WriteLine(found != null
                ? $"Found session: {found}"
                : "No session matched that condition.");
        }

        // Part 4.6
        static void FindSessionIndexByCondition(string[] sessionNames)
        {
            Console.Write("Enter part of the session name to search for: ");
            string keyword = Console.ReadLine() ?? "";

            int index = Array.FindIndex(sessionNames, n => n.Contains(keyword));

            Console.WriteLine(index != -1
                ? $"Index: {index}"
                : "No session matched that condition.");
        }

        // Part 4.7
        static void CopyArrayDemo(string[] sessionNames)
        {
            string[] copiedNames = new string[sessionNames.Length];
            Array.Copy(sessionNames, copiedNames, sessionNames.Length);

            copiedNames[0] = "CHANGED SESSION NAME";

            Console.WriteLine("Original array:");
            foreach (string name in sessionNames)
            {
                Console.WriteLine($"- {name}");
            }

            Console.WriteLine("Copied array (after modification):");
            foreach (string name in copiedNames)
            {
                Console.WriteLine($"- {name}");
            }
        }

        // Part 5
        static int GetTotalDuration(int[] sessionDurations)
        {
            int total = 0;
            for (int i = 0; i < sessionDurations.Length; i++)
            {
                total += sessionDurations[i];
            }
            return total;
        }

        // Part 5
        static double GetAverageDuration(int[] sessionDurations)
        {
            return (double)GetTotalDuration(sessionDurations) / sessionDurations.Length;
        }

        // Part 5
        static int GetShortestDuration(int[] sessionDurations)
        {
            int shortest = sessionDurations[0];
            for (int i = 1; i < sessionDurations.Length; i++)
            {
                if (sessionDurations[i] < shortest)
                {
                    shortest = sessionDurations[i];
                }
            }
            return shortest;
        }

        // Part 5
        static int GetLongestDuration(int[] sessionDurations)
        {
            int longest = sessionDurations[0];
            for (int i = 1; i < sessionDurations.Length; i++)
            {
                if (sessionDurations[i] > longest)
                {
                    longest = sessionDurations[i];
                }
            }
            return longest;
        }

        // Part 5
        static void ShowDurationStatistics(int[] sessionDurations)
        {
            Console.WriteLine($"Total Duration: {GetTotalDuration(sessionDurations)} minutes");
            Console.WriteLine($"Average Duration: {GetAverageDuration(sessionDurations):0.##} minutes");
            Console.WriteLine($"Shortest Duration: {GetShortestDuration(sessionDurations)} minutes");
            Console.WriteLine($"Longest Duration: {GetLongestDuration(sessionDurations)} minutes");

            int[] sortedDurations = new int[sessionDurations.Length];
            Array.Copy(sessionDurations, sortedDurations, sessionDurations.Length);
            Array.Sort(sortedDurations);

            Console.WriteLine("Durations sorted (smallest to largest):");
            foreach (int duration in sortedDurations)
            {
                Console.WriteLine($"- {duration} minutes");
            }
        }

        // Part 9
        static DateTime GetSessionEndTime(DateTime sessionDate, int durationMinutes)
        {
            return sessionDate.AddMinutes(durationMinutes);
        }

        // Part 9
        static void ShowSessionDateDetails(string[] sessionNames, DateTime[] sessionDates, int[] sessionDurations)
        {
            Console.Write("Enter session name: ");
            string name = Console.ReadLine() ?? "";

            int index = Array.IndexOf(sessionNames, name);

            if (index == -1)
            {
                Console.WriteLine("Session not found.");
                return;
            }

            DateTime date = sessionDates[index];
            int duration = sessionDurations[index];
            DateTime endTime = GetSessionEndTime(date, duration);

            Console.WriteLine($"Session: {sessionNames[index]}");
            Console.WriteLine($"Date: {date:dd MMMM yyyy}");
            Console.WriteLine($"Day: {date.DayOfWeek}");
            Console.WriteLine($"Year: {date.Year}");
            Console.WriteLine($"Month: {date.Month}");
            Console.WriteLine($"Day Number: {date.Day}");
            Console.WriteLine($"Start Time: {date:hh:mm tt}");
            Console.WriteLine($"Duration: {duration} minutes");
            Console.WriteLine($"End Time: {endTime:hh:mm tt}");
        }

        // Part 11
        static void ShowPastAndUpcomingSessions(string[] sessionNames, DateTime[] sessionDates)
        {
            for (int i = 0; i < sessionNames.Length; i++)
            {
                string status = sessionDates[i] < DateTime.Now ? "Past" : "Upcoming";
                Console.WriteLine($"{sessionNames[i]} {status}");
            }
        }

        // Part 12
        static void FindNextSession(string[] sessionNames, DateTime[] sessionDates)
        {
            int nextIndex = -1;
            DateTime nearestDate = DateTime.MaxValue;

            for (int i = 0; i < sessionDates.Length; i++)
            {
                if (sessionDates[i] > DateTime.Now && sessionDates[i] < nearestDate)
                {
                    nearestDate = sessionDates[i];
                    nextIndex = i;
                }
            }

            if (nextIndex == -1)
            {
                Console.WriteLine("There are no upcoming sessions.");
                return;
            }

            TimeSpan remaining = sessionDates[nextIndex] - DateTime.Now;

            Console.WriteLine("Next Session:");
            Console.WriteLine(sessionNames[nextIndex]);
            Console.WriteLine($"{sessionDates[nextIndex]:dd MMMM yyyy}");
            Console.WriteLine($"{sessionDates[nextIndex]:hh:mm tt}");
            Console.WriteLine("Time Remaining:");
            Console.WriteLine($"{remaining.Days} days");
            Console.WriteLine($"{(int)remaining.TotalHours} hours");
        }

        // Part 10
        static void CompareSessionDates(string[] sessionNames, DateTime[] sessionDates)
        {
            Console.Write("First Session: ");
            string firstName = Console.ReadLine() ?? "";
            Console.Write("Second Session: ");
            string secondName = Console.ReadLine() ?? "";

            int firstIndex = Array.IndexOf(sessionNames, firstName);
            int secondIndex = Array.IndexOf(sessionNames, secondName);

            if (firstIndex == -1 || secondIndex == -1)
            {
                Console.WriteLine("One or both sessions were not found.");
                return;
            }

            TimeSpan difference = sessionDates[secondIndex] - sessionDates[firstIndex];

            if (difference < TimeSpan.Zero)
            {
                difference = difference.Negate();
            }

            Console.WriteLine("Difference:");
            Console.WriteLine($"{difference.Days} days");
            Console.WriteLine($"{(int)difference.TotalHours} hours");
        }

        // Part 13
        static void ShowDateFormattingExamples(string[] sessionNames, DateTime[] sessionDates)
        {
            Console.Write("Enter session name: ");
            string name = Console.ReadLine() ?? "";

            int index = Array.IndexOf(sessionNames, name);

            if (index == -1)
            {
                Console.WriteLine("Session not found.");
                return;
            }

            DateTime date = sessionDates[index];

            Console.WriteLine(date.ToString("yyyy-MM-dd"));
            Console.WriteLine(date.ToString("dd/MM/yyyy"));
            Console.WriteLine(date.ToString("dd MMMM yyyy"));
            Console.WriteLine(date.ToString("dddd, dd MMMM yyyy"));
            Console.WriteLine(date.ToString("hh:mm tt"));
        }

        // Part 14
        static DateTime ReadSessionDate()
        {
            string format = "yyyy-MM-dd HH:mm";
            DateTime result;

            while (true)
            {
                Console.Write("Enter a date (yyyy-MM-dd HH:mm): ");
                string input = Console.ReadLine() ?? "";

                bool success = DateTime.TryParseExact(
                    input,
                    format,
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None,
                    out result);

                if (success)
                {
                    return result;
                }

                Console.WriteLine("Invalid date format. Please try again.");
            }
        }

        // Part 15
        static int ReadMenuOption()
        {
            while (true)
            {
                string input = Console.ReadLine() ?? "";

                try
                {
                    int option = int.Parse(input);
                    return option;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid menu option. Enter a number.");
                    Console.Write("Choose an option: ");
                }
            }
        }

        // Part 16
        static void SelectSessionByIndex(string[] sessionNames, DateTime[] sessionDates, int[] sessionDurations)
        {
            Console.Write("Enter session index: ");
            string input = Console.ReadLine() ?? "";

            try
            {
                int index = int.Parse(input);

                string name = sessionNames[index];
                DateTime date = sessionDates[index];
                int duration = sessionDurations[index];

                Console.WriteLine($"Session: {name}");
                Console.WriteLine($"Date: {date:dd MMMM yyyy}");
                Console.WriteLine($"Duration: {duration} minutes");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("The selected session index is out of range.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter a valid whole number for the index.");
            }
        }

        // Part 17
        static void ValidateDuration(int duration)
        {
            if (duration <= 0)
            {
                throw new ArgumentException("Duration must be greater than zero.");
            }

            Console.WriteLine("Duration accepted.");
        }

        // Part 17 & Part 18
        static void ValidateDurationInput()
        {
            Console.Write("Enter duration: ");
            string input = Console.ReadLine() ?? "";

            try
            {
                int duration = int.Parse(input);
                ValidateDuration(duration);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter a valid whole number for the duration.");
            }
            finally
            {
                Console.WriteLine("Input operation finished.");
            }
        }

        // Part 19
        static string BuildReportUsingString(string[] sessionNames, DateTime[] sessionDates, int[] sessionDurations)
        {
            string result = "";

            for (int i = 0; i < sessionNames.Length; i++)
            {
                result += $"{sessionNames[i]} - {sessionDates[i]:dd/MM/yyyy hh:mm tt} - {sessionDurations[i]} minutes\n";
            }

            return result;
        }

        // Part 20
        static string BuildReportUsingStringBuilder(string[] sessionNames, DateTime[] sessionDates, int[] sessionDurations)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < sessionNames.Length; i++)
            {
                sb.Append(sessionNames[i]);
                sb.Append(" - ");
                sb.Append(sessionDates[i].ToString("dd/MM/yyyy hh:mm tt"));
                sb.Append(" - ");
                sb.Append(sessionDurations[i]);
                sb.Append(" minutes\n");
            }

            return sb.ToString();
        }

        // Part 21
        static void RunBenchmarks()
        {
            BenchmarkRunner.Run<StringBenchmark>();
        }

        // Part 7.1
        static void IncrementDuration(ref int duration)
        {
            duration += 30;
        }

        // Part 7.1
        static void ShowRefExample()
        {
            int duration = 180;
            Console.WriteLine($"Before: {duration} minutes");

            IncrementDuration(ref duration);

            Console.WriteLine($"After: {duration} minutes");
        }

        // Part 7.2
        static bool TryFindSession(string[] sessionNames, int[] sessionDurations, string name, out int index, out int duration)
        {
            index = Array.IndexOf(sessionNames, name);

            if (index == -1)
            {
                duration = 0;
                return false;
            }

            duration = sessionDurations[index];
            return true;
        }

        // Part 7.2
        static void ShowOutExample(string[] sessionNames, int[] sessionDurations)
        {
            Console.Write("Enter session: ");
            string name = Console.ReadLine() ?? "";

            bool found = TryFindSession(sessionNames, sessionDurations, name, out int index, out int duration);

            if (found)
            {
                Console.WriteLine($"Index: {index}");
                Console.WriteLine($"Duration: {duration} minutes");
            }
            else
            {
                Console.WriteLine("Session not found.");
            }
        }

        // Part 7.3
        static void RenameFirstSession(string[] names, string newName)
        {
            if (names.Length > 0)
            {
                names[0] = newName;
            }
        }

        // Part 7.3
        static void ShowReferenceTypeWithoutRefExample(string[] sessionNames)
        {
            Console.WriteLine("Before calling the function:");
            Console.WriteLine(sessionNames[0]);

            RenameFirstSession(sessionNames, "Renamed Session");

            Console.WriteLine("After calling the function:");
            Console.WriteLine(sessionNames[0]);

            RenameFirstSession(sessionNames, "C# Basics");
        }

        // Part 8
        static int CalculateTotalDuration(params int[] durations)
        {
            int total = 0;
            foreach (int d in durations)
            {
                total += d;
            }
            return total;
        }

        // Part 8
        static void ShowParamsExample()
        {
            Console.WriteLine($"Total (2 values): {CalculateTotalDuration(120, 180)} minutes");
            Console.WriteLine($"Total (3 values): {CalculateTotalDuration(120, 180, 240)} minutes");
            Console.WriteLine($"Total (5 values): {CalculateTotalDuration(60, 90, 120, 180, 240)} minutes");
        }
    }
}