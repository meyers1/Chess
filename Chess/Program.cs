using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Program
    {
        public static string[,] board = new string[8, 8];

        static void Main(string[] args)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    board[i, j] = "   ";
                }
            }
            DrawBoard();
        }

        public static void DrawBoard()
        {
            Console.Write("       ---------------------------------");
            for (int i = 0; i < 8; i++)
            {
                Console.Write("\n    " + (8 - i) + "  |");
                for (int j = 0; j < 8; j++)
                {
                    Console.Write(board[i, j] + "|");
                }
                if (i == 7)
                {
                    Console.WriteLine("\n       ---------------------------------");
                }
                else
                {
                    Console.Write("\n       |---+---+---+---+---+---+---+---|");
                }
            }
            Console.Write("         a   b   c   d   e   f   g   h  ");
        }
    }

    class Piece
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int color { get; set; }
        public bool hasMoved { get; set; }
        public virtual bool IsValidMove(int X, int Y, int newX, int newY)
        {
            return false;
        }
    }

    class Pawn : Piece
    {
        public override bool IsValidMove(int X, int Y, int newX, int newY)
        {
            if (X == newX && newY < 8 && newY == (Y + 1) && Program.board[newX, newY] == "   ")
            {
                return true;
            }
            else if (!hasMoved && X == newX && newY == (Y + 2) && Program.board[newX, newY] == "   " && Program.board[newX, newY-1] == "   ")
            {
                return true;
            }
            return false;
        }
    }

    class Rook : Piece
    {
        public override bool IsValidMove(int X, int Y, int newX, int newY)
        {
            if (X == newX)
            {
                if (Y > newY)
                {
                    for (int i = Y + 1; i <= newY; i++)
                    {
                        if ()
                    }
                }
            }
        }
    }

    class Knight : Piece
    {

    }

    class Bishop : Piece
    {

    }

    class King : Piece
    {

    }

    class Queen : Piece
    {

    }
}
