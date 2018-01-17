using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlimeQuest
{
    public class ScreenWindows
    {
        
        /// <summary>
        /// Displays the game screen with borders
        /// </summary>
        static public void DisplayGameScreen()
        {
            //     ================TOP===========================
            Console.SetCursorPosition(34, 8);
            Console.Write("+");
            for (int i = 0; i < 30; i++)
            {
                Console.Write("=+");
            }
            //=========================LEFT============================
            int downwardPOS = 9;
            for (int i = 0; i < 19; i++)
            {
                Console.SetCursorPosition(34, downwardPOS);
                Console.WriteLine("|");
                downwardPOS++;

            }
            //=========================RIGHT============================
            downwardPOS = 9;
            for (int i = 0; i < 19; i++)
            {
                Console.SetCursorPosition(94, downwardPOS);
                Console.WriteLine("|");
                downwardPOS++;

            }
            //=========================BOTTOM============================
            Console.SetCursorPosition(34, 27);
            Console.Write("+");
            for (int i = 0; i < 30; i++)
            {
                Console.Write("=+");
            }
        }

        /// <summary>
        /// Clears gamescreen
        /// The screen that displays the slimes
        /// </summary>
        static public void ClearSlime()
        {

            Console.Write("                                                          ");
            Console.SetCursorPosition(35, 14);
            Console.Write("                                                          ");
            Console.SetCursorPosition(35, 15);
            Console.Write("                                                          ");
            Console.SetCursorPosition(35, 16);
            Console.Write("                                                          ");
            Console.SetCursorPosition(35, 17);
            Console.Write("                                                          ");
            Console.SetCursorPosition(35, 18);
            Console.Write("                                                          ");
            Console.SetCursorPosition(35, 19);
            Console.Write("                                                          ");
            Console.SetCursorPosition(35, 20);
            Console.Write("                                                          ");
            Console.SetCursorPosition(35, 21);
            Console.Write("                                                          ");
            Console.SetCursorPosition(35, 22);
            Console.Write("                                                          ");
            Console.SetCursorPosition(35, 23);
            Console.Write("                                                          ");
            Console.SetCursorPosition(35, 24);
            Console.Write("                                                          ");
            Console.SetCursorPosition(35, 25);
            Console.Write("                                                          ");

        }


        /// <summary>
        /// Displays a textbox for diolouge and player options
        /// </summary>
        static public void DisplayTextBoxPlayer()
        {
            //top ONE
            int down = 31;
            Console.SetCursorPosition(25, 30);
            Console.Write("+");
            for (int i = 0; i < 40; i++)
            {
                Console.Write("=+");
            }

            //side left
            for (int i = 0; i < 9; i++)
            {
                Console.SetCursorPosition(25, down);
                Console.Write("|");
                down++;
            }
            down = 31;
            //Across bottom
            Console.SetCursorPosition(25, 40);
            Console.Write("+");
            for (int i = 0; i < 40; i++)
            {
                Console.Write("=+");
            }

            for (int i = 0; i < 9; i++)
            {
                Console.SetCursorPosition(105, down);
                Console.Write("|");
                down++;
            }
        }

        /// <summary>
        /// clears the lower textbox called playerTextbox
        /// </summary>
        static public void ClearPlayerTextBox()
        {
            Console.SetCursorPosition(26, 31);
            Console.WriteLine("                                                                             ");
            Console.SetCursorPosition(26, 32);
            Console.WriteLine("                                                                             ");
            Console.SetCursorPosition(26, 33);
            Console.WriteLine("                                                                             ");
            Console.SetCursorPosition(26, 34);
            Console.WriteLine("                                                                             ");
            Console.SetCursorPosition(26, 35);
            Console.WriteLine("                                                                             ");
            Console.SetCursorPosition(26, 36);
            Console.WriteLine("                                                                             ");
            Console.SetCursorPosition(26, 37);
            Console.WriteLine("                                                                             ");

        }

        /// <summary>
        /// Displays the mainscreen textbox
        /// </summary>
        static public void DisplayTextboxMain()
        {
            Console.Clear();
            #region Main
            //Across Top
            Console.SetCursorPosition(34, 8);
            Console.Write("+");
            for (int i = 0; i < 30; i++)
            {
                Console.Write("=+");
            }
            //Down Left
            int downwardPOS = 9;
            for (int i = 0; i < 10; i++)
            {
                Console.SetCursorPosition(34, downwardPOS);
                Console.WriteLine("|");
                downwardPOS++;

            }
            //Down Right
            downwardPOS = 9;
            for (int i = 0; i < 10; i++)
            {
                Console.SetCursorPosition(94, downwardPOS);
                Console.WriteLine("|");
                downwardPOS++;

            }
            //Across Bottom
            Console.SetCursorPosition(34, 19); //90  // 16
            Console.Write("+");
            for (int i = 0; i < 30; i++)
            {
                Console.Write("=+");
            }
            #endregion
        }


        /// <summary>
        /// Prompts the user to continue by bliping the cursor onscreen
        /// </summary>
        /// <param name="across">X Position on the screen</param>
        /// <param name="down">Y Position on the screen</param>
        static public void DisplayContinuePrompt(int across, int down)
        {
            Console.WriteLine();
            Console.SetCursorPosition(across, down);
            Console.CursorVisible = true;
            Console.ReadKey();
            Console.CursorVisible = false;
            Console.SetCursorPosition(27, 33);
        }

        /// <summary>
        /// THis will Determine the Color of the slime that is displayed and also displays
        /// </summary>
        /// <param name="slime">The slime class to determine the color</param>
        static public void SlimeAndChatColor(Slime slime)
        {
            if (slime.Color == "green")
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else if (slime.Color == "red")
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else if (slime.Color == "blue")
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
            }
            else if (slime.Color == "pink")
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
            }
            else if (slime.Color == "purple")
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
            }
            else if (slime.Color == "pine")
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
            }
        }

        /// <summary>
        /// Displays the king slime
        /// </summary>
        static public void DisplayKingSlime()
        {

            Console.Write("                   __    _    __                          ");
            Console.SetCursorPosition(35, 14);
            Console.Write("                   |  \\_/ \\_/  |                         ");
            Console.SetCursorPosition(35, 15);
            Console.Write("                   +++++++++++++                          ");
            Console.SetCursorPosition(35, 16);
            Console.Write("                      =======                             ");
            Console.SetCursorPosition(35, 17);
            Console.Write("                  ====       ====                         ");
            Console.SetCursorPosition(35, 18);
            Console.Write("               ===              ===                       ");
            Console.SetCursorPosition(35, 19);
            Console.Write("             ==     v       v     ==                      ");
            Console.SetCursorPosition(35, 20);
            Console.Write("           ===     (6)     (9)     ===                    ");
            Console.SetCursorPosition(35, 21);
            Console.Write("          ===       ^       ^       ===                   ");
            Console.SetCursorPosition(35, 22);
            Console.Write("         ====                       ====                  ");
            Console.SetCursorPosition(35, 23);
            Console.Write("          ===                       ===                   ");
            Console.SetCursorPosition(35, 24);
            Console.Write("            ====-               -====                     ");
            Console.SetCursorPosition(35, 25);
            Console.Write("                 ==============                           ");

        }

        /// <summary>
        /// Displays a slime
        /// </summary>
        /// <param name="slime"></param>
        static public void DisplaySlime(Slime slime)
        {
            SlimeAndChatColor(slime);
            Console.SetCursorPosition(35, 16);
            Console.Write("                      =======                             ");
            Console.SetCursorPosition(35, 17);
            Console.Write("                  ====       ====                         ");
            Console.SetCursorPosition(35, 18);
            Console.Write("               ===              ===                       ");
            Console.SetCursorPosition(35, 19);
            Console.Write("             ==     v       v     ==                      ");
            Console.SetCursorPosition(35, 20);
            Console.Write("           ===     (6)     (9)     ===                    ");
            Console.SetCursorPosition(35, 21);
            Console.Write("          ===       ^       ^       ===                   ");
            Console.SetCursorPosition(35, 22);
            Console.Write("         ====                       ====                  ");
            Console.SetCursorPosition(35, 23);
            Console.Write("          ===                       ===                   ");
            Console.SetCursorPosition(35, 24);
            Console.Write("            ====-               -====                     ");
            Console.SetCursorPosition(35, 25);
            Console.Write("                 ==============                           ");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        
    }
}
