namespace Tests;
using Logic_of_Figures;
using Field;
using Logic;

public class KingTests
{
    [Fact]
    public void King_CanMove_OneStepUp()
    {
        Chessfield field = new Chessfield();
        King king = new King(Colors.white);
        field.playing_field[4, 4] = king;
 
        bool result = king.IsValidMove(4, 4, 3, 4, field);
 
        Assert.True(result);
    }
 
    [Fact]
    public void King_CanMove_OneStepDiagonal()
    {
        Chessfield field = new Chessfield();
        King king = new King(Colors.white);
        field.playing_field[4, 4] = king;
 
        bool result = king.IsValidMove(4, 4, 3, 3, field);
 
        Assert.True(result);
    }
 
    [Fact]
    public void King_CannotMove_TwoSteps()
    {
        Chessfield field = new Chessfield();
        King king = new King(Colors.white);
        field.playing_field[4, 4] = king;
 
        bool result = king.IsValidMove(4, 4, 4, 6, field);
 
        Assert.False(result);
    }
 
    [Fact]
    public void King_CannotCapture_OwnPiece()
    {
        Chessfield field = new Chessfield();
        King king = new King(Colors.white);
        Pawn ownPawn = new Pawn(Colors.white);
        field.playing_field[4, 4] = king;
        field.playing_field[3, 4] = ownPawn;
 
        bool result = king.IsValidMove(4, 4, 3, 4, field);
 
        Assert.False(result);
    }
 
    [Fact]
    public void King_CanCapture_EnemyPiece()
    {
        Chessfield field = new Chessfield();
        King king = new King(Colors.white);
        Pawn enemyPawn = new Pawn(Colors.black);
        field.playing_field[4, 4] = king;
        field.playing_field[3, 4] = enemyPawn;
 
        bool result = king.IsValidMove(4, 4, 3, 4, field);
 
        Assert.True(result);
    }
}
 
public class QueenTests
{
    [Fact]
    public void Queen_CanMove_Horizontally()
    {
        Chessfield field = new Chessfield();
        Queen queen = new Queen(Colors.white);
        field.playing_field[4, 4] = queen;
 
        bool result = queen.IsValidMove(4, 4, 4, 0, field);
 
        Assert.True(result);
    }
 
    [Fact]
    public void Queen_CanMove_Vertically()
    {
        Chessfield field = new Chessfield();
        Queen queen = new Queen(Colors.white);
        field.playing_field[4, 4] = queen;
 
        bool result = queen.IsValidMove(4, 4, 0, 4, field);
 
        Assert.True(result);
    }
 
    [Fact]
    public void Queen_CanMove_Diagonally()
    {
        Chessfield field = new Chessfield();
        Queen queen = new Queen(Colors.white);
        field.playing_field[4, 4] = queen;
 
        bool result = queen.IsValidMove(4, 4, 1, 1, field);
 
        Assert.True(result);
    }
 
    [Fact]
    public void Queen_CannotJumpOver_Piece()
    {
        Chessfield field = new Chessfield();
        Queen queen = new Queen(Colors.white);
        Pawn blocker = new Pawn(Colors.black);
        field.playing_field[4, 4] = queen;
        field.playing_field[4, 6] = blocker;
 
        bool result = queen.IsValidMove(4, 4, 4, 7, field);
 
        Assert.False(result);
    }
 
    [Fact]
    public void Queen_CannotCapture_OwnPiece()
    {
        Chessfield field = new Chessfield();
        Queen queen = new Queen(Colors.white);
        Pawn ownPawn = new Pawn(Colors.white);
        field.playing_field[4, 4] = queen;
        field.playing_field[4, 7] = ownPawn;
 
        bool result = queen.IsValidMove(4, 4, 4, 7, field);
 
        Assert.False(result);
    }
}
 
public class BishopTests
{
    [Fact]
    public void Bishop_CanMove_Diagonally()
    {
        Chessfield field = new Chessfield();
        Bishop bishop = new Bishop(Colors.white);
        field.playing_field[4, 4] = bishop;
 
        bool result = bishop.IsValidMove(4, 4, 1, 1, field);
 
        Assert.True(result);
    }
 
    [Fact]
    public void Bishop_CannotMove_Horizontally()
    {
        Chessfield field = new Chessfield();
        Bishop bishop = new Bishop(Colors.white);
        field.playing_field[4, 4] = bishop;
 
        bool result = bishop.IsValidMove(4, 4, 4, 6, field);
 
        Assert.False(result);
    }
 
    [Fact]
    public void Bishop_CannotMove_ThroughPiece()
    {
        Chessfield field = new Chessfield();
        Bishop bishop = new Bishop(Colors.white);
        Pawn blocker = new Pawn(Colors.black);
        field.playing_field[4, 4] = bishop;
        field.playing_field[3, 3] = blocker;
 
        bool result = bishop.IsValidMove(4, 4, 2, 2, field);
 
        Assert.False(result);
    }
 
    [Fact]
    public void Bishop_OtherDiagonal_StillReachable_WhenOneDiagonalIsBlocked()
    {
        Chessfield field = new Chessfield();
        Bishop bishop = new Bishop(Colors.white);
        Pawn blocker = new Pawn(Colors.black);
        field.playing_field[4, 4] = bishop;
        field.playing_field[3, 3] = blocker;
 
        bool result = bishop.IsValidMove(4, 4, 3, 5, field);
 
        Assert.True(result);
    }
}
 
public class SpringerTests
{
    [Fact]
    public void Springer_CanMove_InLShape()
    {
        Chessfield field = new Chessfield();
        Springer springer = new Springer(Colors.white);
        field.playing_field[4, 4] = springer;
 
        bool result = springer.IsValidMove(4, 4, 2, 3, field);
 
        Assert.True(result);
    }
 
    [Fact]
    public void Springer_CanMove_AllEightDirections()
    {
        Chessfield field = new Chessfield();
        Springer springer = new Springer(Colors.white);
        field.playing_field[4, 4] = springer;
 
        Assert.True(springer.IsValidMove(4, 4, 2, 3, field));
        Assert.True(springer.IsValidMove(4, 4, 2, 5, field));
        Assert.True(springer.IsValidMove(4, 4, 3, 2, field));
        Assert.True(springer.IsValidMove(4, 4, 5, 2, field));
        Assert.True(springer.IsValidMove(4, 4, 6, 3, field));
        Assert.True(springer.IsValidMove(4, 4, 6, 5, field));
        Assert.True(springer.IsValidMove(4, 4, 3, 6, field));
        Assert.True(springer.IsValidMove(4, 4, 5, 6, field));
    }
 
    [Fact]
    public void Springer_CannotMove_InStraightLine()
    {
        Chessfield field = new Chessfield();
        Springer springer = new Springer(Colors.white);
        field.playing_field[4, 4] = springer;
 
        bool result = springer.IsValidMove(4, 4, 4, 6, field);
 
        Assert.False(result);
    }
 
    [Fact]
    public void Springer_CanJumpOver_OtherPieces()
    {
        Chessfield field = new Chessfield();
        Springer springer = new Springer(Colors.white);
        Pawn blocker = new Pawn(Colors.white);
        field.playing_field[4, 4] = springer;
        field.playing_field[3, 4] = blocker;
        field.playing_field[4, 5] = blocker;
 
        bool result = springer.IsValidMove(4, 4, 2, 5, field);
 
        Assert.True(result);
    }
}
 
public class RookTests
{
    [Fact]
    public void Rook_CanMove_Horizontally()
    {
        Chessfield field = new Chessfield();
        Rook rook = new Rook(Colors.white);
        field.playing_field[4, 4] = rook;
 
        bool result = rook.IsValidMove(4, 4, 4, 0, field);
 
        Assert.True(result);
    }
 
    [Fact]
    public void Rook_CanMove_Vertically()
    {
        Chessfield field = new Chessfield();
        Rook rook = new Rook(Colors.white);
        field.playing_field[4, 4] = rook;
 
        bool result = rook.IsValidMove(4, 4, 0, 4, field);
 
        Assert.True(result);
    }
 
    [Fact]
    public void Rook_CannotMove_Diagonally()
    {
        Chessfield field = new Chessfield();
        Rook rook = new Rook(Colors.white);
        field.playing_field[4, 4] = rook;
 
        bool result = rook.IsValidMove(4, 4, 6, 6, field);
 
        Assert.False(result);
    }
 
    [Fact]
    public void Rook_CannotMove_ThroughPiece()
    {
        Chessfield field = new Chessfield();
        Rook rook = new Rook(Colors.white);
        Pawn blocker = new Pawn(Colors.white);
        field.playing_field[4, 4] = rook;
        field.playing_field[4, 6] = blocker;
 
        bool result = rook.IsValidMove(4, 4, 4, 7, field);
 
        Assert.False(result);
    }
}
 
public class PawnTests
{
    [Fact]
    public void WhitePawn_CanMove_OneStepForward()
    {
        Chessfield field = new Chessfield();
        Pawn pawn = new Pawn(Colors.white);
        field.playing_field[4, 4] = pawn;
 
        bool result = pawn.IsValidMove(4, 4, 3, 4, field);
 
        Assert.True(result);
    }
 
    [Fact]
    public void WhitePawn_CanMove_TwoSteps_OnFirstMove()
    {
        Chessfield field = new Chessfield();
        Pawn pawn = new Pawn(Colors.white); // HasMoved ist standardmäßig false
        field.playing_field[6, 4] = pawn;
 
        bool result = pawn.IsValidMove(6, 4, 4, 4, field);
 
        Assert.True(result);
    }
 
    [Fact]
    public void WhitePawn_CannotMove_TwoSteps_AfterFirstMove()
    {
        Chessfield field = new Chessfield();
        Pawn pawn = new Pawn(Colors.white);
        pawn.HasMoved = true;
        field.playing_field[4, 4] = pawn;
 
        bool result = pawn.IsValidMove(4, 4, 2, 4, field);
 
        Assert.False(result);
    }
 
    [Fact]
    public void WhitePawn_CannotMove_IfBlocked()
    {
        Chessfield field = new Chessfield();
        Pawn pawn = new Pawn(Colors.white);
        Pawn blocker = new Pawn(Colors.black);
        field.playing_field[4, 4] = pawn;
        field.playing_field[3, 4] = blocker;
 
        bool result = pawn.IsValidMove(4, 4, 3, 4, field);
 
        Assert.False(result);
    }
 
    [Fact]
    public void WhitePawn_CanCapture_Diagonally()
    {
        Chessfield field = new Chessfield();
        Pawn pawn = new Pawn(Colors.white);
        Pawn enemy = new Pawn(Colors.black);
        field.playing_field[4, 4] = pawn;
        field.playing_field[3, 5] = enemy;
 
        bool result = pawn.IsValidMove(4, 4, 3, 5, field);
 
        Assert.True(result);
    }
 
    [Fact]
    public void WhitePawn_CannotCapture_EmptyDiagonalField()
    {
        Chessfield field = new Chessfield();
        Pawn pawn = new Pawn(Colors.white);
        field.playing_field[4, 4] = pawn;
 
        bool result = pawn.IsValidMove(4, 4, 3, 5, field);
 
        Assert.False(result);
    }
 
    [Fact]
    public void BlackPawn_CanMove_OneStepForward()
    {
        Chessfield field = new Chessfield();
        Pawn pawn = new Pawn(Colors.black);
        field.playing_field[1, 4] = pawn;
 
        bool result = pawn.IsValidMove(1, 4, 2, 4, field);
 
        Assert.True(result);
    }
 
    [Fact]
    public void BlackPawn_CanMove_TwoSteps_OnFirstMove()
    {
        Chessfield field = new Chessfield();
        Pawn pawn = new Pawn(Colors.black);
        field.playing_field[1, 4] = pawn;
 
        bool result = pawn.IsValidMove(1, 4, 3, 4, field);
 
        Assert.True(result);
    }
 
    [Fact]
    public void BlackPawn_CanCapture_Diagonally()
    {
        Chessfield field = new Chessfield();
        Pawn pawn = new Pawn(Colors.black);
        Pawn enemy = new Pawn(Colors.white);
        field.playing_field[4, 4] = pawn;
        field.playing_field[5, 5] = enemy;
 
        bool result = pawn.IsValidMove(4, 4, 5, 5, field);
 
        Assert.True(result);
    }
}