using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Program
    {
        public static Piece[,] board = new Piece[8, 8];

        static void Main(string[] args)
        {
            Pawn p1W =      new Pawn(0, 6);
            Pawn p2W =      new Pawn(1, 6);
            Pawn p3W =      new Pawn(2, 6);
            Pawn p4W =      new Pawn(3, 6);
            Pawn p5W =      new Pawn(4, 6);
            Pawn p6W =      new Pawn(5, 6);
            Pawn p7W =      new Pawn(6, 6);
            Pawn p8W =      new Pawn(7, 6);
            Rook r1W =      new Rook(0, 7);
            Knight n1W =    new Knight(1, 7);
            Bishop b1W =    new Bishop(2, 7);
            Queen q1W =     new Queen(3, 7);
            King k1W =      new King(4, 7);
            Bishop b2W =    new Bishop(5, 7);
            Knight n2W =    new Knight(6, 7);
            Rook r2W =      new Rook(7, 7);

            Pawn p1B =      new Pawn(0, 1);
            Pawn p2B =      new Pawn(1, 1);
            Pawn p3B =      new Pawn(2, 1);
            Pawn p4B =      new Pawn(3, 1);
            Pawn p5B =      new Pawn(4, 1);
            Pawn p6B =      new Pawn(5, 1);
            Pawn p7B =      new Pawn(6, 1);
            Pawn p8B =      new Pawn(7, 1);
            Rook r1B =      new Rook(0, 0);
            Knight n1B =    new Knight(1, 0);
            Bishop b1B =    new Bishop(2, 0);
            Queen q1B =     new Queen(3, 0);
            King k1B =      new King(4, 0);
            Bishop b2B =    new Bishop(5, 0);
            Knight n2B =    new Knight(6, 0);
            Rook r2B =      new Rook(7, 0);


            board[p1W.X, p1W.Y] = p1W;
            board[p2W.X, p2W.Y] = p2W;
            board[p3W.X, p3W.Y] = p3W;
            board[p4W.X, p4W.Y] = p4W;
            board[p5W.X, p5W.Y] = p5W;
            board[p6W.X, p6W.Y] = p6W;
            board[p7W.X, p7W.Y] = p7W;
            board[p8W.X, p8W.Y] = p8W;
            board[r1W.X, r1W.Y] = r1W;
            board[n1W.X, n1W.Y] = n1W;
            board[b1W.X, b1W.Y] = b1W;
            board[q1W.X, q1W.Y] = q1W;
            board[k1W.X, k1W.Y] = k1W;
            board[b2W.X, b2W.Y] = b2W;
            board[n2W.X, n2W.Y] = n2W;
            board[r2W.X, r2W.Y] = r2W;

            board[p1B.X, p1B.Y] = p1B;
            board[p2B.X, p2B.Y] = p2B;
            board[p3B.X, p3B.Y] = p3B;
            board[p4B.X, p4B.Y] = p4B;
            board[p5B.X, p5B.Y] = p5B;
            board[p6B.X, p6B.Y] = p6B;
            board[p7B.X, p7B.Y] = p7B;
            board[p8B.X, p8B.Y] = p8B;
            board[r1B.X, r1B.Y] = r1B;
            board[n1B.X, n1B.Y] = n1B;
            board[b1B.X, b1B.Y] = b1B;
            board[q1B.X, q1B.Y] = q1B;
            board[k1B.X, k1B.Y] = k1B;
            board[b2B.X, b2B.Y] = b2B;
            board[n2B.X, n2B.Y] = n2B;
            board[r2B.X, r2B.Y] = r2B;


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
                    if (board[j, i] == null)
                    {
                        Console.Write("   |");
                    }
                    else
                    {
                        Console.Write(board[j, i].Draw() + "|");
                    }
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
            Console.WriteLine("         a   b   c   d   e   f   g   h  ");
        }
    }

    class Piece
    {
        public Piece(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }
        public int X { get; set; }
        public int Y { get; set; }
        public int Color { get; set; }
        public bool HasMoved { get; set; }
        public virtual bool IsValidMove(int X, int Y, int newX, int newY)
        {
            return false;
        }
        public virtual string Draw()
        {
            return "   ";
        }
    }

    class Pawn : Piece
    {
        public Pawn(int X, int Y) : base(X, Y)
        {

        }
        public override bool IsValidMove(int X, int Y, int newX, int newY)
        {
            if (X == newX && newY < 8 && newY >= 0 && newY == (Y + 1) && Program.board[newX, newY] == null)
            {
                return true;
            }
            else if (!HasMoved && X == newX && newY == (Y + 2) && Program.board[newX, newY] == null && Program.board[newX, newY - 1] == null)
            {
                return true;
            }
            return false;
        }
        public override string Draw()
        {
            return " p ";
        }
    }

    class Rook : Piece
    {
        public Rook(int X, int Y) : base(X, Y)
        {

        }
        public override bool IsValidMove(int X, int Y, int newX, int newY)
        {
            if (X == newX)
            {
                if (newY < Y)
                {
                    for (int i = Y + 1; i <= newY; i++)
                    {
                        if (Program.board[X, i] != null)
                        {
                            return false;
                        }
                    }
                }
                if (newY > Y)
                {
                    for (int i = Y - 1; i >= newY; i--)
                    {
                        if (Program.board[X, i] != null)
                        {
                            return false;
                        }
                    }
                }
            }
            else if (Y == newY)
            {

            }
            return false;
        }
        public override string Draw()
        {
            return " r ";
        }
    }

    class Knight : Piece
    {
        public Knight(int X, int Y) : base(X, Y)
        {

        }
        public override string Draw()
        {
            return " n ";
        }
    }

    class Bishop : Piece
    {
        public Bishop(int X, int Y) : base(X, Y)
        {

        }
        public override string Draw()
        {
            return " b ";
        }
    }

    class King : Piece
    {
        public King(int X, int Y) : base(X, Y)
        {

        }
        public override string Draw()
        {
            return " k ";
        }
    }

    class Queen : Piece
    {
        public Queen(int X, int Y) : base(X, Y)
        {

        }
        public override string Draw()
        {
            return " q ";
        }
    }
}



