using Logic;
using System.Text;
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
        /*playing_field[6, 0] = pawn_white1;
        playing_field[6, 1] = pawn_white2;
        playing_field[6, 2] = pawn_white3;
        playing_field[6, 3] = pawn_white4;
        playing_field[6, 4] = pawn_white5;
        playing_field[6, 5] = pawn_white6;
        playing_field[6, 6] = pawn_white7;*/
        playing_field[6, 7] = pawn_white8;/*

        playing_field[7, 0] = rook_white1;*/
        playing_field[7, 1] = springer_white1;/*
        playing_field[7, 2] = bishop_white1; 
        playing_field[7, 3] = queen_white;*/
        playing_field[7, 4] = king_white;
        /*playing_field[7, 5] = bishop_white2;
        playing_field[7, 6] = springer_white2;
        playing_field[7, 7] = rook_white2;

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
        playing_field[0, 7] = rook_black2;*/
    }

    public void Move(string startPos, string endPos)
    {
        int xStartPos = char.ToLower(startPos[0]) - 'a';
        int yStartPos = 0;
 
        int xEndPos = char.ToLower(endPos[0]) - 'a';
        int yEndPos = 0;
 
        if (int.TryParse(startPos.Substring(1), out int numberStart))
        {
            if (numberStart <= 8 && numberStart >= 1)
            {
                yStartPos = numberStart - 1;
            }
            else
            {
                throw new ArgumentException("number start postition isn't a valid input");
            }
        }
        else
        {
            throw new ArgumentException("number start postition isn't a number");
        }
 
        if (int.TryParse(endPos.Substring(1), out int numberEnd))
        {
            if (numberEnd <= 8 && numberEnd >= 1)
            {
                yEndPos = numberEnd - 1;
            }
            else
            {
                throw new ArgumentException("number end postition isn't a valid input");
            }
        }
        else
        {
            throw new ArgumentException("number end postition isn't a number");
        }
 
        if (xStartPos < 0 || xStartPos > 7)
            throw new ArgumentException("letter start postition isn't a valid input");
 
        if (xEndPos < 0 || xEndPos > 7)
            throw new ArgumentException("letter end postition isn't a valid input");
 
        Fig? moveFigure = playing_field[yStartPos, xStartPos];
 
        if (moveFigure == null)
            throw new ArgumentException("The field is null");
 
        if (moveFigure.IsValidMove(xStartPos, yStartPos, xEndPos, yEndPos, this))
        {
            playing_field[yStartPos, xStartPos] = null;
            playing_field[yEndPos, xEndPos] = moveFigure;
        }
        else
        {
            throw new ArgumentException("Invalid move");
        }
    }
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine("  a b c d e f g h");

        for (int row = 0; row < 8; row++)
        {
            sb.Append(row + 1);
            sb.Append("|");

            for (int col = 0; col < 8; col++)
            {
                string symbol;

                if (playing_field[row, col] != null)
                {
                    symbol = playing_field[row, col].ToString();
                }
                else
                {
                    symbol = ((row + col) % 2 == 1) ? "#" : " ";
                }

                sb.Append(symbol);
                sb.Append("|");
            }

            sb.AppendLine();

            if (row < 7)
            {
                sb.AppendLine(" +-+-+-+-+-+-+-+-+");
            }
        }

        return sb.ToString();
    }
    public Fig GetFigure(int x_pos, int y_pos){
        return playing_field[x_pos, y_pos];
    }
}
