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
        public static string turn = "WHITE";
        public static List<Piece> takenWhite = new List<Piece>(), takenBlack = new List<Piece>();

        static void Main(string[] args)
        {
            SetupBoard();

            //example input: "B2F6
            string input = "";
            bool gameOver = false;
            bool valid = false;
            while(!gameOver)
            {
                valid = false;
                DrawBoard();
                do
                {
                    Console.Write(turn + "'s turn: ");
                    input = Console.ReadLine();
                    if (IsValidInput(input))
                    {
                        valid = true;
                        Move(input);
                    }
                    else
                    {
                        Console.WriteLine("INVALID INPUT");
                    }
                } while (!valid);
                EndTurn();
                //Console.WriteLine(IsValidInput(input));
            }
        }

        public static void DrawBoard()
        {
            Console.Clear();
            Console.Write("       ---------------------------------");
            for (int i = 0; i < 8; i++)
            {
                Console.Write("\n    " + (8 - i) + "  |");
                for (int j = 0; j < 8; j++)
                {
                    if (board[i, j] == null)
                    {
                        Console.Write("   |");
                    }
                    else
                    {
                        Console.Write(board[i, j].Draw() + "|");
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

            DrawTaken(43, 0);
            Console.SetCursorPosition(0, 20);
        }

        protected static void WriteAt(string s, int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(s);
        }

        public static void DrawTaken(int posX, int posY)
        {
            WriteAt("Taken Pieces: ", posX, posY);
            WriteAt("(B)    (W)", posX, posY + 1);
            for (int i = 0; i < takenBlack.Count; i++)
            {
                WriteAt(takenBlack[i].Draw(), posX, (posY + i + 2));
            }
            for (int i = 0; i < takenWhite.Count; i++)
            {
                WriteAt(takenWhite[i].Draw(), (posX + 7), (posY + i + 2));
            }
        }

        //switches the color at the end of every turn
        public static void EndTurn()
        {
            if (turn == "WHITE") turn = "BLACK";
            else turn = "WHITE";
        }

        public static bool IsValidInput(string input)
        {
            if (input.Length != 4) return false;

            //converts input into X and Y indices
            int Y1 = 7 - (char.ToUpper(input[1]) - '1'); //starting row (Y)
            int X1 = char.ToUpper(input[0]) - 'A';       //starting col (X)
            int Y2 = 7 - (char.ToUpper(input[3]) - '1'); //ending row   (Y)
            int X2 = char.ToUpper(input[2]) - 'A';       //ending col   (X)

            //checks if input is on the board and starting and ending positions are not the same
            if ((Y1 == Y2 && X1 == X2) ||
                 Y1 < 0 || Y1 > 7 ||
                 Y2 < 0 || Y2 > 7 ||
                 X1 < 0 || X1 > 7 ||
                 X2 < 0 || X2 > 7) return false;

            //checks if the piece the player is trying to capture is their own 
            if (board[Y2, X2] != null && board[Y2, X2].Color == turn) return false;

            //checks if the piece the player is moving exists and is the correct color
            if (board[Y1, X1] == null || board[Y1, X1].Color != turn) return false;

            //checks if the piece being moved is allowed to be moved in that way
            if (!(board[Y1, X1].IsValidMove(X1, Y1, X2, Y2, turn))) return false;

            return true;
        }

        public static void Move(string input)
        {
            int Y1 = 7 - (char.ToUpper(input[1]) - '1'); //starting row (Y)
            int X1 = char.ToUpper(input[0]) - 'A';       //starting col (X)
            int Y2 = 7 - (char.ToUpper(input[3]) - '1'); //ending row   (Y)
            int X2 = char.ToUpper(input[2]) - 'A';       //ending col   (X)

            //add taken pieces to a list
            if (board[Y2, X2] != null && board[Y2, X2].Color != turn)
            {
                if (board[Y2, X2].Color == "WHITE")
                {
                    takenWhite.Add(board[Y2, X2]);
                }
                else
                {
                    takenBlack.Add(board[Y2, X2]);
                }
            }
            board[Y1, X1].HasMoved = true;
            board[Y2, X2] = board[Y1, X1];
            board[Y1, X1] = null;
        }

        public static void SetupBoard()
        {
            Pawn p1W = new Pawn(0, 6, "WHITE");
            Pawn p2W = new Pawn(1, 6, "WHITE");
            Pawn p3W = new Pawn(2, 6, "WHITE");
            Pawn p4W = new Pawn(3, 6, "WHITE");
            Pawn p5W = new Pawn(4, 6, "WHITE");
            Pawn p6W = new Pawn(5, 6, "WHITE");
            Pawn p7W = new Pawn(6, 6, "WHITE");
            Pawn p8W = new Pawn(7, 6, "WHITE");
            Rook r1W = new Rook(0, 7, "WHITE");
            Knight n1W = new Knight(1, 7, "WHITE");
            Bishop b1W = new Bishop(2, 7, "WHITE");
            Queen q1W = new Queen(3, 7, "WHITE");
            King k1W = new King(4, 7, "WHITE");
            Bishop b2W = new Bishop(5, 7, "WHITE");
            Knight n2W = new Knight(6, 7, "WHITE");
            Rook r2W = new Rook(7, 7, "WHITE");

            Pawn p1B = new Pawn(0, 1, "BLACK");
            Pawn p2B = new Pawn(1, 1, "BLACK");
            Pawn p3B = new Pawn(2, 1, "BLACK");
            Pawn p4B = new Pawn(3, 1, "BLACK");
            Pawn p5B = new Pawn(4, 1, "BLACK");
            Pawn p6B = new Pawn(5, 1, "BLACK");
            Pawn p7B = new Pawn(6, 1, "BLACK");
            Pawn p8B = new Pawn(7, 1, "BLACK");
            Rook r1B = new Rook(0, 0, "BLACK");
            Knight n1B = new Knight(1, 0, "BLACK");
            Bishop b1B = new Bishop(2, 0, "BLACK");
            Queen q1B = new Queen(3, 0, "BLACK");
            King k1B = new King(4, 0, "BLACK");
            Bishop b2B = new Bishop(5, 0, "BLACK");
            Knight n2B = new Knight(6, 0, "BLACK");
            Rook r2B = new Rook(7, 0, "BLACK");


            board[p1W.Y, p1W.X] = p1W;
            board[p2W.Y, p2W.X] = p2W;
            board[p3W.Y, p3W.X] = p3W;
            board[p4W.Y, p4W.X] = p4W;
            board[p5W.Y, p5W.X] = p5W;
            board[p6W.Y, p6W.X] = p6W;
            board[p7W.Y, p7W.X] = p7W;
            board[p8W.Y, p8W.X] = p8W;
            board[r1W.Y, r1W.X] = r1W;
            board[n1W.Y, n1W.X] = n1W;
            board[b1W.Y, b1W.X] = b1W;
            board[q1W.Y, q1W.X] = q1W;
            board[k1W.Y, k1W.X] = k1W;
            board[b2W.Y, b2W.X] = b2W;
            board[n2W.Y, n2W.X] = n2W;
            board[r2W.Y, r2W.X] = r2W;

            board[p1B.Y, p1B.X] = p1B;
            board[p2B.Y, p2B.X] = p2B;
            board[p3B.Y, p3B.X] = p3B;
            board[p4B.Y, p4B.X] = p4B;
            board[p5B.Y, p5B.X] = p5B;
            board[p6B.Y, p6B.X] = p6B;
            board[p7B.Y, p7B.X] = p7B;
            board[p8B.Y, p8B.X] = p8B;
            board[r1B.Y, r1B.X] = r1B;
            board[n1B.Y, n1B.X] = n1B;
            board[b1B.Y, b1B.X] = b1B;
            board[q1B.Y, q1B.X] = q1B;
            board[k1B.Y, k1B.X] = k1B;
            board[b2B.Y, b2B.X] = b2B;
            board[n2B.Y, n2B.X] = n2B;
            board[r2B.Y, r2B.X] = r2B;
        }

    }

    class Piece
    {
        public Piece(int X, int Y, string Color)
        {
            this.X = X;
            this.Y = Y;
            this.Color = Color;
            HasMoved = false;
        }
        public int X { get; set; }
        public int Y { get; set; }
        public string Color { get; set; }
        public bool HasMoved { get; set; }
        public virtual bool IsValidMove(int X, int Y, int newX, int newY, string Color)
        {
            return true;
        }
        public virtual string Draw()
        {
            return "   ";
        }
    }

    class Pawn : Piece
    {
        public Pawn(int X, int Y, string Color) : base(X, Y, Color)
        {

        }
        public override bool IsValidMove(int X, int Y, int newX, int newY, string Color)
        {
            if (Color == "BLACK")
            {
                if (Program.board[newY, newX] == null)
                {
                    if (newX == X && newY == (Y + 1)) return true;
                    if (!HasMoved && X == newX && newY == (Y + 2) && Program.board[newY - 1, newX] == null) return true;
                    return false;
                }
                else if (Program.board[newY, newX].Color != Program.turn)
                {
                    if (Math.Abs(X - newX) == 1 && newY == (Y + 1)) return true;
                    return false;
                }
                return false;
            }
            if (Color == "WHITE")
            {
                if (Program.board[newY, newX] == null)
                {
                    if (X == newX && newY == (Y - 1)) return true;
                    if (!HasMoved && newX == X && newY == (Y - 2) && Program.board[newY + 1, newX] == null) return true;
                    return false;
                }
                if (Program.board[newY, newX].Color != Program.turn)
                {
                    if (Math.Abs(X - newX) == 1 && newY == (Y - 1)) return true;
                    return false;
                }
                return false;
            }
            return false;
        }
        public override string Draw()
        {
            if (Color == "WHITE") return "*P ";
            else if (Color == "BLACK") return " P ";
            else return "";
        }
    }

    class Rook : Piece
    {
        public Rook(int X, int Y, string Color) : base(X, Y, Color)
        {

        }
        public override bool IsValidMove(int X, int Y, int newX, int newY, string Color)
        {
            if (X == newX)
            {
                if (newY < Y)
                {
                    for (int i = Y - 1; i > newY; i--)
                    {
                        if (Program.board[i, X] != null) return false;
                    }
                    return true;
                }
                if (newY > Y)
                {
                    for (int i = Y + 1; i < newY; i++)
                    {
                        if (Program.board[i, X] != null) return false;
                    }
                    return true;
                }
                return false;
            }
            else if (Y == newY)
            {
                if (newX < X)
                {
                    for (int i = Y - 1; i > newY; i--)
                    {
                        if (Program.board[Y, i] != null) return false;
                    }
                    return true;
                }
                if (newX > X)
                {
                    for (int i = X + 1; i < newX; i++)
                    {
                        if (Program.board[Y, i] != null) return false;
                    }
                    return true;
                }
                return false;
            }
            return false;
        }
        public override string Draw()
        {
            if (Color == "WHITE")      return "*R ";
            else if (Color == "BLACK") return " R ";
            else return "";
        }
    }

    class Knight : Piece
    {
        public Knight(int X, int Y, string Color) : base(X, Y, Color)
        {

        }
        public override bool IsValidMove(int X, int Y, int newX, int newY, string Color)
        {
            if (newX == X + 1 && newY == Y + 2 ||
                newX == X + 1 && newY == Y - 2 ||
                newX == X + 2 && newY == Y + 1 ||
                newX == X + 2 && newY == Y - 1 ||
                newX == X - 1 && newY == Y + 2 ||
                newX == X - 1 && newY == Y - 2 ||
                newX == X - 2 && newY == Y + 1 ||
                newX == X - 2 && newY == Y - 1) return true;
            return false;
        }
        public override string Draw()
        {
            if (Color == "WHITE")      return "*N ";
            else if (Color == "BLACK") return " N ";
            else return "";
        }
    }

    class Bishop : Piece
    {
        public Bishop(int X, int Y, string Color) : base(X, Y, Color)
        {

        }
        public override bool IsValidMove(int X, int Y, int newX, int newY, string Color)
        {
            int disX = (newX - X), disY = (newY - Y);
            if (Math.Abs(disX) != Math.Abs(disY)) return false;
            if (disX > 0)
            {
                if (disY > 0)
                {
                    for (int i = 0; i < disX; i++)
                    {
                        if (Program.board[X + i, Y + i] != null) return false;
                    }
                    return true;
                }
                if (disY < 0)
                {
                    for (int i = 0; i < disX; i++)
                    {
                        if (Program.board[X + i, Y - i] != null) return false;
                    }
                    return true;
                }
            }
            if (disX < 0)
            {
                if (disY > 0)
                {
                    for (int i = 0; i < disX; i++)
                    {
                        if (Program.board[X - i, Y + i] != null) return false;
                    }
                    return true;
                }
                if (disY < 0)
                {
                    for (int i = 0; i < disX; i++)
                    {
                        if (Program.board[X - i, Y - i] != null) return false;
                    }
                    return true;
                }
            }
            return false;
        }
        public override string Draw()
        {
            if (Color == "WHITE")      return "*B ";
            else if (Color == "BLACK") return " B ";
            else return "";
        }
    }

    class King : Piece
    {
        public King(int X, int Y, string Color) : base(X, Y, Color)
        {

        }
        public override string Draw()
        {
            if (Color == "WHITE")      return "*K ";
            else if (Color == "BLACK") return " K ";
            else return "";
        }
    }

    class Queen : Piece
    {
        public Queen(int X, int Y, string Color) : base(X, Y, Color)
        {

        }
        public override string Draw()
        {
            if (Color == "WHITE")      return "*Q ";
            else if (Color == "BLACK") return " Q ";
            else return "";
        }
    }
}