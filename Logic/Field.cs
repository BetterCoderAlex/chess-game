using Logic;
using Logic_of_Figures;
namespace Field;

public class Chessfield
{
    private int int_number_start;
    private int int_number_dest;
    Pawn pawn_white1 = new Pawn(Colors.white);
    Pawn pawn_white2 = new Pawn(Colors.white);
    Pawn pawn_white3 = new Pawn(Colors.white);
    Pawn pawn_white4 = new Pawn(Colors.white);
    Pawn pawn_white5 = new Pawn(Colors.white);
    Pawn pawn_white6 = new Pawn(Colors.white);
    Pawn pawn_white7 = new Pawn(Colors.white);
    Pawn pawn_white8 = new Pawn(Colors.white);

    Rook rook_white1 = new Rook(Colors.white);
    Rook rook_white2 = new Rook(Colors.white);

    Springer springer_white1 = new Springer(Colors.white);
    Springer springer_white2 = new Springer(Colors.white);

    Bishop bishop_white1 = new Bishop(Colors.white);
    Bishop bishop_white2 = new Bishop(Colors.white);

    Queen queen_white = new Queen(Colors.white);
    King king_white = new King(Colors.white);
    Pawn pawn_black1 = new Pawn(Colors.black);
    Pawn pawn_black2 = new Pawn(Colors.black);
    Pawn pawn_black3 = new Pawn(Colors.black);
    Pawn pawn_black4 = new Pawn(Colors.black);
    Pawn pawn_black5 = new Pawn(Colors.black);
    Pawn pawn_black6 = new Pawn(Colors.black);
    Pawn pawn_black7 = new Pawn(Colors.black);
    Pawn pawn_black8 = new Pawn(Colors.black);

    Rook rook_black1 = new Rook(Colors.black);
    Rook rook_black2 = new Rook(Colors.black);

    Springer springer_black1 = new Springer(Colors.black);
    Springer springer_black2 = new Springer(Colors.black);

    Bishop bishop_black1 = new Bishop(Colors.black);
    Bishop bishop_black2 = new Bishop(Colors.black);

    Queen queen_black = new Queen(Colors.black);
    King king_black = new King(Colors.black);
    private string text = "";
    public Fig?[,] playing_field = new Fig[8, 8];
    public Chessfield()
    {
        // WHITE (unten)
        playing_field[6, 0] = pawn_white1;
        playing_field[6, 1] = pawn_white2;
        playing_field[6, 2] = pawn_white3;
        playing_field[6, 3] = pawn_white4;
        playing_field[6, 4] = pawn_white5;
        playing_field[6, 5] = pawn_white6;
        playing_field[6, 6] = pawn_white7;
        playing_field[6, 7] = pawn_white8;

        playing_field[7, 0] = rook_white1;
        playing_field[7, 1] = springer_white1;
        playing_field[7, 2] = bishop_white1;
        playing_field[7, 3] = queen_white;
        playing_field[7, 4] = king_white;
        playing_field[7, 5] = bishop_white2;
        playing_field[7, 6] = springer_white2;
        playing_field[7, 7] = rook_white2;


        // BLACK (oben)
        playing_field[1, 0] = pawn_black1;
        playing_field[1, 1] = pawn_black2;
        playing_field[1, 2] = pawn_black3;
        playing_field[1, 3] = pawn_black4;
        playing_field[1, 4] = pawn_black5;
        playing_field[1, 5] = pawn_black6;
        playing_field[1, 6] = pawn_black7;
        playing_field[1, 7] = pawn_black8;

        playing_field[0, 0] = rook_black1;
        playing_field[0, 1] = springer_black1;
        playing_field[0, 2] = bishop_black1;
        playing_field[0, 3] = queen_black;
        playing_field[0, 4] = king_black;
        playing_field[0, 5] = bishop_black2;
        playing_field[0, 6] = springer_black2;
        playing_field[0, 7] = rook_black2;
    }

    public void Move(string starter_pos, string destination_pos)
    {
        // Umwandlung direkt ohne Substring
        int col_start = starter_pos[0] - 'a';
        int row_start = 7 - (starter_pos[1] - '1');

        int col_dest = destination_pos[0] - 'a';
        int row_dest = 7 - (destination_pos[1] - '1');

        // Bounds check (0–7)
        if (col_start < 0 || col_start >= 8 ||
            col_dest < 0 || col_dest >= 8 ||
            row_start < 0 || row_start >= 8 ||
            row_dest < 0 || row_dest >= 8)
        {
            throw new ArgumentException("Invalid position!");
        }

        Fig? move_fig = playing_field[row_start, col_start];

        if (move_fig == null)
            throw new ArgumentException("There is nothing that can be moved!");

        playing_field[row_dest, col_dest] = move_fig;
        playing_field[row_start, col_start] = null;
    }
    public override string ToString()
    {
        text += "  a b c d e f g h \n";
        string symbol;
        for (int rows = 0; rows < 8; rows++)
        {
            for (int colums = 0; colums < 8; colums++)
            {

                if ((rows + colums) % 2 == 1)
                {
                    symbol = "#";
                }
                else
                {
                    symbol = " ";
                }
                if (playing_field[rows, colums] == null && colums == 0)
                {
                    text += $"{rows + 1}|{symbol}|";
                }
                else if (playing_field[rows, colums] == null && rows > 1 && rows < 6)
                {
                    text += $"{symbol}|";
                }
                else
                {
                    if (colums == 0)
                    {
                        text += $"{rows + 1}|{playing_field[rows, colums]}|";
                    }
                    else
                    {
                        text += $"{playing_field[rows, colums]}|";
                    }
                }
                if (colums == 7)
                {
                    text += $"{Environment.NewLine}";
                    if (rows < 7)
                    {
                        text += " +-+-+-+-+-+-+-+-+";
                        text += $"{Environment.NewLine}";
                    }
                }
            }
        }
        return text;
    }
}
