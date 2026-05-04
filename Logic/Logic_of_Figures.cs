namespace Logic_of_Figures;
using Logic;
using Field;
using System.Runtime.Serialization;

public class King : Fig
{
    public King(Colors color) : base(PieceTypes.King, color)
    {

    }
    public override bool IsValidMove(int xStart, int yStart, int xEnd, int yEnd, Chessfield field)
    {
        int[,] Valid_moves = { { -1, -1 }, { -1, 0 }, { -1, 1 }, { 0, -1 }, { 1, -1 }, { 1, 1 }, { 1, 0 }, { 0, 1 } };

        Fig? target = field.GetFigure(yEnd, xEnd);

        if (target != null && target.color == this.color)
        {
            return false;
        }

        for (int i = 0; i < Valid_moves.GetLength(0); i++)
        {
            int newX = xStart + Valid_moves[i, 0];
            int newY = yStart + Valid_moves[i, 1];

            if (newX == xEnd && newY == yStart){
                return true;
            }
        }
        return true;
    }
}
public class Queen : Fig
{
    public Queen(Colors color) : base(PieceTypes.Queen, color)
    {

    }
    public override bool IsValidMove(int xStart, int yStart, int xEnd, int yEnd, Chessfield field)
    {
        int[,] directions = { { -1, 0 }, { 0, -1 }, { 1, 0 }, { 0, 1 }, { -1, -1 }, { -1, 1 }, { 1, -1 }, { 1, 1 } };

        Fig? target = field.GetFigure(yEnd, xEnd);

        if (target != null && target.color == this.color)
        {
            return false;
        }

        for (int i = 0; i < directions.GetLength(0); i++)
        {
            for (int j = 1; j < 8; j++)
            {
                int newX = xStart + directions[i, 0] * j;
                int newY = yStart + directions[i, 1] * j;

                if (newX < 0 || newX > 7 || newY < 0 || newY > 7) break;

                if (newX == xEnd && newY == yEnd)
                {
                    return true;
                }
                if (field.GetFigure(newY, newX) != null)
                {
                    break;
                }
            }
        }
        return false;
    }
}
public class Bishop : Fig
{
    public Bishop(Colors color) : base(PieceTypes.Bishop, color)
    {

    }
    public override bool IsValidMove(int xStart, int yStart, int xEnd, int yEnd, Chessfield field)
    {
        int[,] directions = { { -1, -1 }, { 1, 1 }, { -1, 1 }, { 1, -1 } };
        Fig? target = field.GetFigure(yEnd, xEnd);

        if (target != null && target.color == this.color)
        {
            return false;
        }

        for (int i = 0; i < directions.GetLength(0); i++)
        {
            for (int j = 0; j < 8; j++)
            {
                int newX = xStart + directions[i, 0] * j;
                int newY = yStart + directions[i, 1] * j;

                if (newX < 0 || newX > 7 || newY < 0 || newY > 7) break;

                if (newX == xEnd && newY == yEnd)
                {
                    return true;
                }
                else if (field.GetFigure(newY, newX) != null)
                {
                    break;
                }
            }
        }
        return true;
    }
}
public class Springer : Fig
{
    public Springer(Colors color) : base(PieceTypes.Springer, color)
    {

    }
    public override bool IsValidMove(int xStart, int yStart, int xEnd, int yEnd, Chessfield field)
    {
        int[,] directions = { { -2, -1 }, { -2, 1 }, { -1, 2 }, { 1, 2 }, { 2, 1 }, { 2, -1 }, { -1, -2 }, {1, -2 } };

        Fig? target = field.GetFigure(yEnd, xEnd);

        if (target != null && target.color == this.color)
        {
            return false;
        }

        for (int i = 0; i < directions.GetLength(0); i++)
        {
            int newX = xStart + directions[i, 0];
            int newY = yStart + directions[i, 1];

            if (newX == xEnd && newY == yEnd){
            return true;
            }
        }
        return true;
    }
}
public class Rook : Fig
{
    public Rook(Colors color) : base(PieceTypes.Rook, color)
    {

    }
    public override bool IsValidMove(int xStart, int yStart, int xEnd, int yEnd, Chessfield field)
    {
        int[,] directions = { { -1, 0 }, { 0, 1 }, { 1, 0 }, { 0, -1 } };
        Fig? target = field.GetFigure(yEnd, xEnd);

        if (target != null && target.color == this.color)
        {
            return false;
        }

        for (int i = 0; i < directions.GetLength(0); i++)
        {
            for (int j = 0; j < 8; j++)
            {
                int newX = xStart + directions[i, 0] * j;
                int newY = yStart + directions[i, 1] * j;

                 if (newX < 0 || newX > 7 || newY < 0 || newY > 7) break;

                if (newX == xEnd && newY == yEnd)
                {
                    return true;
                }
                else if (field.GetFigure(newY, newX) != null)
                {
                    return false;
                }
            }
        }
        return true;
    }
}
public class Pawn : Fig
{
    public Pawn(Colors color) : base(PieceTypes.Pawn, color)
    {

    }
    public override bool IsValidMove(int xStart, int yStart, int xEnd, int yEnd, Chessfield field)
    {
        Fig? target = field.GetFigure(yEnd, xEnd);
        int dx = xEnd - xStart;
        int dy = yEnd - yStart;
 
        if (this.color == Colors.white)
        {
            if (dx == -1 && dy == 0 && target == null)
                return true;
 
            if (dx == -2 && dy == 0 && !this.HasMoved && target == null)
            {
                Fig? between = field.GetFigure(yStart, xStart - 1);
                return between == null;
            }
 
            if (dx == -1 && (dy == -1 || dy == 1) && target != null && target.color != this.color)
                return true;
        }
        else
        {
            if (dx == 1 && dy == 0 && target == null)
                return true;
 
            if (dx == 2 && dy == 0 && !this.HasMoved && target == null)
            {
                Fig? between = field.GetFigure(yStart, xStart + 1);
                return between == null;
            }

            if (dx == 1 && (dy == -1 || dy == 1) && target != null && target.color != this.color)
                return true;
        }
 
        return false;
    }
}