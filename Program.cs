using System;
using System.IO;

namespace hotdog {
    class hotdog {
        /*
        TODO: finish Main()
        TODO: make options
        */
        static int state = 0; // 0 main menu, 1 select file, 2 editor, 3 options
        public static string selectedFile = "empty";
        public static void Main(string[] args) {
            //Console.Clear();
            if (args.Length >= 1) {
                selectedFile = args[0];
            }
            Console.Title = $"<< hotdog | selected file: {selectedFile} >>";
            switch (state) {
                case 0:
                    Console.WriteLine("<< hotdog | open-source text editor >>");
                    Console.WriteLine("1. editor");
                    Console.WriteLine("2. select file");
                    Console.WriteLine("3. options");
                    Console.WriteLine("4. exit");
                    ConsoleKeyInfo input = Console.ReadKey();
                    string key = input.Key.ToString();
                    Console.WriteLine(key);
                    if (key == "D1") {
                        Editor.Edit();
                    } else if (key == "D2") {
                        Explorer.selectFile();
                    } else if (key == "D3") {
                        
                    } else if (key == "D4") {
                        
                    } else {
                        Main(new String[0]);
                    }
                    break;
                case 1:
                    break;
                case 2:
                    break;
            }
        }
    }
}