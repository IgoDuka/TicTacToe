using System;
namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] PlayingField = new char[,] { { 'X', ' ', ' ' }, { ' ', 'X', ' ' }, { '0', ' ', '0' } };
            Console.WriteLine("Output: " + Winer(PlayingField));
            PlayingField = new char[,] { { ' ', 'X', ' ' }, { 'X', 'X', ' ' }, { '0', '0', '0' } };
            Console.WriteLine("Output: " + Winer(PlayingField));
        }
        public static char Winer(char[,] Matrix)
        {
            for (int i = 0, j = 0; i < 3; i++)
            {
                if (Matrix[i, j] == 'X' && Matrix[i, j + 1] == 'X' && Matrix[i, j + 2] == 'X')
                    return 'X';
                else if (Matrix[i, j] == '0' && Matrix[i, j + 1] == '0' && Matrix[i, j + 2] == '0')
                    return '0';

                if (Matrix[j, i] == 'X' && Matrix[j, i + 1] == 'X' && Matrix[j, i + 2] == 'X')
                    return 'X';
                else if (Matrix[j, i] == '0' && Matrix[j, i + 1] == '0' && Matrix[j, i + 2] == '0')
                    return '0';
            }

            if (Matrix[0, 0] == 'X' && Matrix[1, 1] == 'X' && Matrix[2, 2] == 'X')
                return 'X';
            else if (Matrix[0, 0] == '0' && Matrix[1, 1] == '0' && Matrix[2, 2] == '0')
                return '0';

            if (Matrix[2, 0] == 'X' && Matrix[1, 1] == 'X' && Matrix[0, 2] == 'X')
                return 'X';
            else if (Matrix[2, 0] == '0' && Matrix[1, 1] == '0' && Matrix[0, 2] == '0')
                return '0';

            return ' ';
        }
    }
}