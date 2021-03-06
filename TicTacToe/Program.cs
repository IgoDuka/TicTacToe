using System;
namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] Players = new char[] { 'X', '0' };
            int numberPlayer = 1;
            PlayingField p = new PlayingField();

            while (true)
            {
                int[] XY = new int[2];
                bool success = false;
                do
                {
                    Console.WriteLine(Players[numberPlayer] + " enters coordinates  x and y");
                    for (int i = 0; i < 2; i++)
                        XY[i] = int.Parse(IsDigitsOnly(Console.ReadLine()));
                    success = p.Add(XY[1], XY[0], Players[numberPlayer]);
                }
                while (success == false);

                p.GetPlayingField();

                char status = p.Status();
                if(status != ' ')
                {
                    Console.WriteLine(Players[numberPlayer] + " won!");
                    p.Clean();
                    continue;
                }
                if (p.FieldFullness())
                {
                    Console.WriteLine("Nobody won");
                    p.Clean();
                }
                numberPlayer = (numberPlayer == 1) ? 0 : 1;
            }
        }

        static string IsDigitsOnly(string str)
        {
            foreach (var c in str)
                if (c < '0' || c > '9')
                    return "999";
            return str;
        }
    }
    public class PlayingField
    {
        private char[,] Field = new char[,] { { ' ', ' ', ' ' }, { ' ', ' ', ' ' }, { ' ', ' ', ' ' } };
        public bool Add(int X, int Y, char Player)
        {
            if (CoordinateCheck(X, Y))
            {
                Field[X, Y] = Player;
                return true;
            }
            return false;
        }
        public void GetPlayingField()
        {
            Console.WriteLine(" - - - ");
            for (int i = 0, j = 0; i < 3; i++)
                Console.WriteLine($"[{Field[i, j]}|{Field[i, j + 1]}|{Field[i, j + 2]}]");
            Console.WriteLine(" - - - ");
        }

        /// <summary>
        /// Get Status game
        /// </summary>
        /// <param name="Matrix"></param>
        /// <returns>if X - X won; if 0 - 0 won; if '' the game continues </returns>
        public char Status()
        {
            for (int i = 0, j = 0; i < 3; i++)
            {
                //horizontal check 
                if (Field[i, j] == 'X' && Field[i, j + 1] == 'X' && Field[i, j + 2] == 'X')
                    return 'X';
                else if (Field[i, j] == '0' && Field[i, j + 1] == '0' && Field[i, j + 2] == '0')
                    return '0';

                //vertical check 
                if (Field[j, i] == 'X' && Field[j + 1, i] == 'X' && Field[j + 2, i] == 'X')
                    return 'X';
                else if (Field[j, i] == '0' && Field[j + 1, i] == '0' && Field[j + 2, i] == '0')
                    return '0';
            }
            //diagonal check 
            if (Field[0, 0] == 'X' && Field[1, 1] == 'X' && Field[2, 2] == 'X')
                return 'X';
            else if (Field[0, 0] == '0' && Field[1, 1] == '0' && Field[2, 2] == '0')
                return '0';

            if (Field[2, 0] == 'X' && Field[1, 1] == 'X' && Field[0, 2] == 'X')
                return 'X';
            else if (Field[2, 0] == '0' && Field[1, 1] == '0' && Field[0, 2] == '0')
                return '0';
            return ' ';
        }
        
        public void Clean()
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    Field[i, j] = ' ';
        }
        
        public bool FieldFullness()
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (Field[i, j] == ' ')
                        return false;
            return true;
        }

        /// <summary>
        /// Check coordinate
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns>true - if success</returns>
        private bool CoordinateCheck(int X, int Y)
        {
            if (X >= 0 && X <= 2 && Y >= 0 && Y <= 2)
                if (Field[X, Y] == ' ')
                    return true;
            return false;
        }
    }
}