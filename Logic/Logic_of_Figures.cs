namespace Logic_of_Figures;
using Logic;
using Field;

public class King : Fig
{
    public King(Colors color) : base(PieceTypes.King, color) { }

    public override bool IsValidMove(int xStart, int yStart, int xEnd, int yEnd, Chessfield field)
    {
        int[,] validMoves = { { -1, -1 }, { -1, 0 }, { -1, 1 }, { 0, -1 }, { 1, -1 }, { 1, 1 }, { 1, 0 }, { 0, 1 } };

        Fig? target = field.GetFigure(yEnd, xEnd);
        if (target != null && target.color == this.color)
            return false;

        for (int i = 0; i < validMoves.GetLength(0); i++)
        {
            int newX = xStart + validMoves[i, 0];
            int newY = yStart + validMoves[i, 1];

            // FIX: tatsächlich prüfen, ob das Ziel ein gültiger King-Zug ist
            if (newX == xEnd && newY == yEnd)
                return true;
        }
        return false;
    }
}

public class Queen : Fig
{
    public Queen(Colors color) : base(PieceTypes.Queen, color) { }

    public override bool IsValidMove(int xStart, int yStart, int xEnd, int yEnd, Chessfield field)
    {
        int[,] directions = { { -1, 0 }, { 0, -1 }, { 1, 0 }, { 0, 1 }, { -1, -1 }, { -1, 1 }, { 1, -1 }, { 1, 1 } };

        Fig? target = field.GetFigure(yEnd, xEnd);
        if (target != null && target.color == this.color)
            return false;

        for (int i = 0; i < directions.GetLength(0); i++)
        {
            for (int j = 1; j < 8; j++)
            {
                int newX = xStart + directions[i, 0] * j;
                int newY = yStart + directions[i, 1] * j;

                if (newX < 0 || newX > 7 || newY < 0 || newY > 7) break; // FIX: Grenzprüfung

                if (newX == xEnd && newY == yEnd)
                    return true;

                if (field.GetFigure(newY, newX) != null)
                    break;
            }
        }
        return false;
    }
}

public class Bishop : Fig
{
    public Bishop(Colors color) : base(PieceTypes.Bishop, color) { }

    public override bool IsValidMove(int xStart, int yStart, int xEnd, int yEnd, Chessfield field)
    {
        int[,] directions = { { -1, -1 }, { 1, 1 }, { -1, 1 }, { 1, -1 } };

        Fig? target = field.GetFigure(yEnd, xEnd);
        if (target != null && target.color == this.color)
            return false;

        for (int i = 0; i < directions.GetLength(0); i++)
        {
            for (int j = 1; j < 8; j++) // FIX: j startet bei 1, nicht 0
            {
                int newX = xStart + directions[i, 0] * j;
                int newY = yStart + directions[i, 1] * j;

                if (newX < 0 || newX > 7 || newY < 0 || newY > 7) break; // FIX: Grenzprüfung

                if (newX == xEnd && newY == yEnd)
                    return true;

                if (field.GetFigure(newY, newX) != null)
                    break; // FIX: break statt return false, damit andere Richtungen weiter geprüft werden
            }
        }
        return false;
    }
}

public class Springer : Fig
{
    public Springer(Colors color) : base(PieceTypes.Springer, color) { }

    public override bool IsValidMove(int xStart, int yStart, int xEnd, int yEnd, Chessfield field)
    {
        // FIX: letzter Eintrag war {-1, -2} (Duplikat) — korrigiert zu {1, -2}
        int[,] directions = { { -2, -1 }, { -2, 1 }, { -1, 2 }, { 1, 2 }, { 2, 1 }, { 2, -1 }, { -1, -2 }, { 1, -2 } };

        Fig? target = field.GetFigure(yEnd, xEnd);
        if (target != null && target.color == this.color)
            return false;

        for (int i = 0; i < directions.GetLength(0); i++)
        {
            int newX = xStart + directions[i, 0];
            int newY = yStart + directions[i, 1];

            // FIX: tatsächlich prüfen, ob das Ziel ein gültiger Springer-Zug ist
            if (newX == xEnd && newY == yEnd)
                return true;
        }
        return false;
    }
}

public class Rook : Fig
{
    public Rook(Colors color) : base(PieceTypes.Rook, color) { }

    public override bool IsValidMove(int xStart, int yStart, int xEnd, int yEnd, Chessfield field)
    {
        int[,] directions = { { -1, 0 }, { 0, 1 }, { 1, 0 }, { 0, -1 } };

        Fig? target = field.GetFigure(yEnd, xEnd);
        if (target != null && target.color == this.color)
            return false;

        for (int i = 0; i < directions.GetLength(0); i++)
        {
            for (int j = 1; j < 8; j++) // FIX: j startet bei 1, nicht 0
            {
                int newX = xStart + directions[i, 0] * j;
                int newY = yStart + directions[i, 1] * j;

                if (newX < 0 || newX > 7 || newY < 0 || newY > 7) break; // FIX: Grenzprüfung

                if (newX == xEnd && newY == yEnd)
                    return true;

                if (field.GetFigure(newY, newX) != null)
                    break;
            }
        }
        return false;
    }
}

public class Pawn : Fig
{
    public Pawn(Colors color) : base(PieceTypes.Pawn, color) { }

    public override bool IsValidMove(int xStart, int yStart, int xEnd, int yEnd, Chessfield field)
    {
        Fig? target = field.GetFigure(yEnd, xEnd);
        int dx = xEnd - xStart;
        int dy = yEnd - yStart;

        if (this.color == Colors.white)
        {
            // Vorwärts 1 Feld
            if (dx == -1 && dy == 0 && target == null)
                return true;

            // FIX: HasMoved-Logik war invertiert — 2 Felder nur wenn HasMoved == false
            if (dx == -2 && dy == 0 && !this.HasMoved && target == null)
            {
                // Zwischenfeld darf nicht blockiert sein
                Fig? between = field.GetFigure(yStart, xStart - 1);
                return between == null;
            }

            // Diagonal schlagen
            if (dx == -1 && (dy == -1 || dy == 1) && target != null && target.color != this.color)
                return true;
        }
        else // black
        {
            // Vorwärts 1 Feld
            if (dx == 1 && dy == 0 && target == null)
                return true;

            // FIX: HasMoved-Logik war invertiert — 2 Felder nur wenn HasMoved == false
            if (dx == 2 && dy == 0 && !this.HasMoved && target == null)
            {
                Fig? between = field.GetFigure(yStart, xStart + 1);
                return between == null;
            }

            // Diagonal schlagen
            if (dx == 1 && (dy == -1 || dy == 1) && target != null && target.color != this.color)
                return true;
        }

        return false;
    }
}