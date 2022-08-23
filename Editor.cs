using System;
using System.IO;
using System.Text;

namespace hotdog {
    class Editor {
        /*
        TODO: editing files
        TODO: hotkeys / shortcuts
        TODO: implement explorer functions (save/create files etc)
        */
        static bool isEditing = true;
        static bool shouldRefresh = true;
        static bool shiftMode = false;
        static String[] fileContent = File.ReadAllLines(hotdog.selectedFile);
        static String[] hotkeyList = {"LeftArrow", "UpArrow","RightArrow","DownArrow","Shift"};
        static int selectedLn = 0;
        static int selectedCol = 0;
        static int fileLines = 0;
        public static void Edit() {
            Console.Clear();
            //if (!isEditing)
            //    hotdog.Main(new String[0]);

            // set fileLines
            fileLines = fileContent.Length;

            // editor
            refresh();
            while (isEditing) {
                // readkey
                ConsoleKeyInfo input = Console.ReadKey();
                string key = input.Key.ToString();
                shouldRefresh = true;
                
                runKey(key);

                refresh();
            }
        }

        public static void refresh() {
            int countLn = 0;
            int countCol = 0;
            // refresh
            if (shouldRefresh == true) {
                Console.Clear();
                if (shiftMode) {
                    Console.WriteLine("!! TAB MODE ON !!");
                }
                foreach (String s in fileContent) {
                    if (countLn == selectedLn) {
                        foreach (var sd in s)
                        {
                            if (countCol == selectedCol) {
                                Console.Write(">");
                            }
                            Console.Write(sd);
                            countCol++;
                        }
                        Console.Write("\n");
                    } else {
                        Console.WriteLine(s);
                    }
                    countLn++;
                }
                shouldRefresh = false;
            }
            countLn = 0;
            countCol = 0;
        }

        public static void runKey(string key) {
            switch (key)
            {
                case "LeftArrow":
                    if (selectedCol >= 0) {
                        selectedCol--;
                    }
                    break;

                case "UpArrow":
                    if (selectedLn > 0) {
                        selectedLn--;
                    }
                    break;

                case "RightArrow":
                    if (selectedCol < fileContent[selectedLn].Length - 1) {
                        selectedCol++;
                    }
                    break;

                case "DownArrow":
                    if (selectedLn != fileLines) {
                        selectedLn++;
                    }
                    break;

                case "Tab":
                    shiftMode = !shiftMode;
                    break;

                default:
                    fileContent[selectedLn].Insert(3, "h");
                    //Console.Title = fileContent[selectedLn];
                    break;
            }
        }
    }
}