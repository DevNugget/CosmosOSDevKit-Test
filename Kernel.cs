using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Sys = Cosmos.System;
using POSCALINOPERATINGSYSTEM.Programs;
using Cosmos.System.Graphics;
using System.Drawing;

namespace POSCALINOPERATINGSYSTEM
{
    public class Kernel : Sys.Kernel
    {
        List<int> stack = new List<int>();
        List<string> st1 = new List<string>();

        bool editMode = false;
        string curRes = "0";

        string current_directory = "0:\\";
        string previous_directory = "";
        Sys.FileSystem.CosmosVFS fs;
        protected override void BeforeRun()
        {
            curRes = "2";
            Console.SetWindowSize(90, 60);
            //Console.SetWindowSize(80, 43);
            //Console.SetWindowSize(80, 25);
            fs = new Sys.FileSystem.CosmosVFS();
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(fs);

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            DrawBar();
            printInfo();

        E:
            string password = "user*";
            Console.WriteLine("");
            Console.WriteLine("-PASSWORD");
            Console.Write("--> ");
            string input = Console.ReadLine();
            if (input == password)
            {
                Console.Clear();
                printInfo();
                Run();
            }
            else
            {
                Console.WriteLine("INCORRECT: Try again");
                goto E;
            }
        }

        protected override void Run()
        {
                DrawBar();

                string[] dirs = GetDirFadr(current_directory);

                // Displaying Prompt According To Modeing
                if (editMode == false)
                {
                    Console.Write("-[");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write(current_directory);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write("]\n");
                    Console.Write("--> ");
                }
                else
                {
                    Console.Write("~ ");
                }
                DrawBar();
                var input = Console.ReadLine();
                
                if (input == "RES")
            {
                Console.WriteLine("");
                Console.WriteLine("CURRENT: " + Console.WindowWidth.ToString() + "x" + Console.WindowHeight.ToString());
                Console.WriteLine("");
                Console.WriteLine("1: 80x25");
                Console.WriteLine("2: 90x60");
                Console.WriteLine("");
                Console.WriteLine("-RESOLUTION");
                Console.Write("--> ");
                var resMode = Console.ReadLine();
                if (resMode == "2")
                {
                    curRes = "2";
                    Console.SetWindowSize(90, 60);
                } else
                {
                    curRes = "1";
                    Console.SetWindowSize(80, 25);
                }
            }

                if (input == "INFO")
                {
                    printInfo();
                }

                if (input.StartsWith("PUSH"))
                {
                    var splitVal = input.Split(" ");
                    stack.Add(int.Parse(splitVal[1]));
                    //Console.WriteLine(splitVal[1]);
                    DrawBar();
                }

                if (input == "ADD")
                {
                    if (stack.Count >= 2)
                    {
                        var valueResult = stack[^1] + stack[^2];
                        stack.RemoveAt(stack.Count - 1);
                        stack.RemoveAt(stack.Count - 1);
                        stack.Add(valueResult);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("ERROR");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(": Insufficient entries in stack to perform operation.");
                    }
                    DrawBar();
                }

                if (input == "SUB")
                {
                    if (stack.Count >= 2)
                    {
                        var valueResult = stack[^1] - stack[^2];
                        stack.RemoveAt(stack.Count - 1);
                        stack.RemoveAt(stack.Count - 1);
                        stack.Add(valueResult);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("ERROR");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(": Insufficient entries in stack to perform operation.");
                    }
                    DrawBar();
                }

                if (input == "MUL")
                {
                    if (stack.Count >= 2)
                    {
                        var valueResult = stack[^1] * stack[^2];
                        stack.RemoveAt(stack.Count - 1);
                        stack.RemoveAt(stack.Count - 1);
                        stack.Add(valueResult);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("ERROR");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(": Insufficient entries in stack to perform operation.");
                    }
                    DrawBar();
                }

                if (input == "DIV")
                {
                    if (stack.Count >= 2)
                    {
                        var valueResult = stack[^1] / stack[^2];
                        stack.RemoveAt(stack.Count - 1);
                        stack.RemoveAt(stack.Count - 1);
                        stack.Add(valueResult);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("ERROR");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(": Insufficient entries in stack to perform operation.");
                    }
                    DrawBar();
                }

                if (input == "PRT")
                {
                    if (stack.Count >= 1)
                    {
                        Console.WriteLine(stack[^1]);
                        stack.RemoveAt(stack.Count - 1);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("ERROR");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(": Insufficient entries in stack to perform operation.");
                    }
                    DrawBar();
                }

                if (input == "WRITE")
                {
                    foreach (string i in st1)
                    {
                        Console.Write(i);
                    }

                    st1.Clear();
                    DrawBar();
                }

                if (input == "HTA")
                {
                    DrawBar();
                    if (stack[^1] == 65)
                    {
                        st1.Add("A");
                    }

                    if (stack[^1] == 97)
                    {
                        st1.Add("a");
                    }

                    if (stack[^1] == 66)
                    {
                        st1.Add("B");
                    }

                    if (stack[^1] == 98)
                    {
                        st1.Add("b");
                    }

                    if (stack[^1] == 67)
                    {
                        st1.Add("C");
                    }

                    if (stack[^1] == 99)
                    {
                        st1.Add("c");
                    }

                    if (stack[^1] == 68)
                    {
                        st1.Add("D");
                    }

                    if (stack[^1] == 100)
                    {
                        st1.Add("d");
                    }

                    if (stack[^1] == 69)
                    {
                        st1.Add("E");
                    }

                    if (stack[^1] == 101)
                    {
                        st1.Add("e");
                    }

                    if (stack[^1] == 70)
                    {
                        st1.Add("F");
                    }

                    if (stack[^1] == 102)
                    {
                        st1.Add("f");
                    }

                    if (stack[^1] == 71)
                    {
                        st1.Add("G");
                    }

                    if (stack[^1] == 103)
                    {
                        st1.Add("g");
                    }

                    if (stack[^1] == 72)
                    {
                        st1.Add("H");
                    }

                    if (stack[^1] == 104)
                    {
                        st1.Add("h");
                    }

                    if (stack[^1] == 73)
                    {
                        st1.Add("I");
                    }

                    if (stack[^1] == 105)
                    {
                        st1.Add("i");
                    }

                    stack.RemoveAt(stack.Count - 1);
                }

            if (input == "POSCAFETCH++")
            {
                var totalRam = Cosmos.Core.CPU.GetAmountOfRAM();

                var usedRam = Cosmos.Core.CPU.GetEndOfKernel() + 1024 / 1048576;

                var usedRamMB = usedRam / 1024 / 1024;

                Console.ForegroundColor = ConsoleColor.Magenta;

                Console.WriteLine(@"
              _____          
             /\    \
            /::\    \
           /::::\    \
          /::::::\    \
         /:::/\:::\    \
        /:::/__\:::\    \
       /::::\   \:::\    \
      /::::::\   \:::\    \
     /:::/\:::\   \:::\____\
    /:::/  \:::\   \:::|    |
    \::/    \:::\  /:::|____|
     \/_____/\:::\/:::/    /
              \::::::/    /
               \::::/    /
                \::/____/    
                 ~~          ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("OS:");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(" POSCALIN\n");

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("VERSION:");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(" 30\n");

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("MEMORY: ");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(usedRamMB.ToString() + "/");
                Console.Write(totalRam.ToString() + "MB");
                var availableRam = totalRam - usedRam / 1024 / 1024;
                Console.Write(" AVAILABLE: " + availableRam.ToString() + "\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("CPU: ");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(Cosmos.Core.CPU.GetCPUBrandString());
                Console.Write("\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("UPTIME: ");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(Cosmos.Core.CPU.GetCPUUptime() / 1000);
                Console.Write("\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("RESOLUTION: ");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(Console.WindowWidth.ToString() + "x" + Console.WindowHeight.ToString());
                Console.Write("\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("");
            }

            if (input == "POSCAFETCH")
                {
                    var totalRam = Cosmos.Core.CPU.GetAmountOfRAM();

                    var usedRam = Cosmos.Core.CPU.GetEndOfKernel() + 1024 / 1048576;

                    var usedRamMB = usedRam / 1024 / 1024;

                    Console.ForegroundColor = ConsoleColor.Magenta;

                    Console.WriteLine(@"
              _____          
             /\    \
            /::\    \
           /::::\    \
          /::::::\    \
         /:::/\:::\    \
        /:::/__\:::\    \
       /::::\   \:::\    \
      /::::::\   \:::\    \
     /:::/\:::\   \:::\____\
    /:::/  \:::\   \:::|    |
    \::/    \:::\  /:::|____|
     \/_____/\:::\/:::/    /
              \::::::/    /
               \::::/    /
                \::/____/    
                 ~~          ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("OS:");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(" POSCALIN\n");

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("VERSION:");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(" 30\n");

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("MEMORY: ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(usedRamMB.ToString() + "/");
                    Console.Write(totalRam.ToString() + "MB");
                    var availableRam = totalRam - usedRam / 1024 / 1024;
                    Console.Write(" AVAILABLE: " + availableRam.ToString() + "\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("CPU: ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(Cosmos.Core.CPU.GetCPUBrandString());
                    Console.Write("\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("");
                }

                if (input == "HELP")
                {
                    Console.WriteLine("");
                    Console.Write("EDIT");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(" - Minimizes prompt to suit stack editing. ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("100");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("PWR");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(" - Opens power command menu. ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("100");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("CLS");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(" - Clears screen.");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("100");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("INFO");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(" - Displays OS information. ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("100");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("PUSH");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(" - Pushes following item to the stack.");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("100");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("ADD");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(" - Adds first 2 values in stack and returns it.");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("100");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("SUB");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(" - Subtracts first 2 values in stack and returns it.");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("100");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("MUL");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(" - Multiplies first 2 values in stack and returns it.");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("100");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("DIV");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(" - Divides first 2 values in stack and returns it.");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("100");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("PRT");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(" - Prints and pops first value of stack.");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("100");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("WRITE");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(" - Prints first value in string stack and pops it.");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("100");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("HTA");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(" - Converts first stack value from decimal to ascii.");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("45");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("LS");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(" - Lists all directories and files in the current directory.");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("100");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("CD");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(" - Changes current directory to the dir specified after.");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("100");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("CDR");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(" - Current directory is set to root directory.");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("100");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("MKDIR");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(" - Creates a new directory.");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("100");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("TOUCH");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(" - Creates a new file.");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("100");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("POSCAFETCH");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(" - Default system fetch tool.");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("100");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("RES");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(" - Allows user to change screen resolution.");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("100\n");
                    Console.ForegroundColor = ConsoleColor.White;
            }

                if (input == "EDIT")
                {
                    if (editMode == false)
                    {
                        editMode = true;
                    }
                    else
                    {
                        editMode = false;
                    }
                    DrawBar();
                }

                if (input == "PWR")
                {
                    Console.WriteLine("");
                    Console.WriteLine("POWER COMMANDS");
                    Console.WriteLine("SHUTDOWN - Shuts down computer");
                    Console.WriteLine("REBOOT   - Restarts computer");
                    Console.WriteLine("");
                    Console.WriteLine("-ACTION");
                    Console.Write("--> ");
                    string powerCmd = Console.ReadLine();

                    if (powerCmd == "SHUTDOWN")
                    {
                        Cosmos.System.Power.Shutdown();
                    }

                    if (powerCmd == "REBOOT")
                    {
                        Cosmos.System.Power.Reboot();
                    }
                    DrawBar();
                }

                if (input == "CLS")
                {
                    Console.Clear();
                    Console.WriteLine("");
                    DrawBar();
                }

                if (input == "LS")
                {
                    var files = Directory.GetFiles(current_directory);
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("DIRECTORIES");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    foreach (var item in dirs) { Console.WriteLine(item); }
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("FILES");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    foreach (var item in files) { Console.WriteLine(item); }
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine("");
                    DrawBar();
                }

                if (input.StartsWith("ECHO "))
                {
                    Console.WriteLine("");
                    Console.WriteLine(input.Remove(0, 5));
                    Console.WriteLine("");
                    DrawBar();
                }

                if (input == "CLRS")
                {
                    Console.WriteLine("");
                    Console.WriteLine("-SELECTION");
                    Console.Write("--> ");
                    string colorinput = Console.ReadLine();

                    if (colorinput == "DARK")
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    if (colorinput == "LIGHT")
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }

                    if (colorinput == "BLUE")
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    if (colorinput == "MATRIX")
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Green;
                    }

                    if (colorinput == "KIRBY")
                    {
                        Console.BackgroundColor = ConsoleColor.Magenta;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }

                    if (colorinput == "RED")
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                }

                if (input.StartsWith("CD "))
                {
                    string nextdir = input.Remove(0, 3);
                    previous_directory = current_directory;
                    current_directory = "0:\\" + nextdir;
                    Directory.SetCurrentDirectory(current_directory + nextdir);
                    DrawBar();
                }

                if (input.StartsWith("CDR"))
                {
                    current_directory = "0:\\";
                    previous_directory = current_directory;
                    Directory.SetCurrentDirectory("0:\\");
                    DrawBar();
                }

                if (input.StartsWith("CDB"))
                {
                    if (previous_directory != "0:\\")
                    {
                        if (previous_directory != "")
                        {
                            current_directory = previous_directory;
                            Directory.SetCurrentDirectory(previous_directory);
                        }
                    }
                    DrawBar();
                }

                if (input.StartsWith("MKDIR "))
                {
                    string nextdir = input.Remove(0, 6);
                    Directory.CreateDirectory(current_directory + nextdir);
                    DrawBar();
                }
                DrawBar();

                if (input.StartsWith("TOUCH"))
                {
                    string[] epic = input.Split(" ");
                    File.CreateText(current_directory + epic[1]);
                }
            
        }
        private string[] GetDirFadr(string adr) // Get Directories From Address
        {
            var dirs = Directory.GetDirectories(adr);
            return dirs;
        }

        public void printInfo()
        {
            Console.WriteLine("");
            Console.WriteLine("POSCALIN OS");
            Console.Write("VERSION  ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("30\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Developed by DevNugget");
            Console.WriteLine("");
        }
        private void DrawBar()
        {
            // TITLE BAR
            // Storing Original Cursor Position
            int origX = Console.CursorLeft;
            int origY = Console.CursorTop;

            // Setting Cursor Position Top Right Of Screen
            Console.SetCursorPosition(0, 0);

            // DRAWING THE TITLE BAR
            // Coloring
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Blue;

            // Time
            var hour = Cosmos.HAL.RTC.Hour;
            var minute = Cosmos.HAL.RTC.Minute;
            var strhour = hour.ToString();
            var strmin = minute.ToString();

            // Initial Bar
            if (curRes == "0" || curRes == "1")
            {
                Console.WriteLine("POSCALIN OS    KERNEL 30    INTERPRETER 02                                 " + strhour + ":" + strmin);
            } else
            {
                Console.WriteLine("POSCALIN OS    KERNEL 30    INTERPRETER 02                                           " + strhour + ":" + strmin);
            }

            // Resetting Colorst 
            Console.BackgroundColor = ConsoleColor.Black;

            // Resetting Cursor Position
            Console.SetCursorPosition(origX, origY);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
