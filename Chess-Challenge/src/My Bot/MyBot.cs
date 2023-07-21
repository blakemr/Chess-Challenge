// Play the move that moves closest to the enemy king

using ChessChallenge.API;

public class MyBot : IChessBot
{
    public Move Think(Board board, Timer timer)
    {
        Move[] moves = board.GetLegalMoves();

        Move move_to_play = moves[0];

        int king_distance = SquareDistance(
            move_to_play.TargetSquare,
            board.GetKingSquare(!board.IsWhiteToMove)
        );

        foreach (Move move in moves)
        {
            int new_distance = SquareDistance(
                move.TargetSquare,
                board.GetKingSquare(!board.IsWhiteToMove)
            );

            if (new_distance < king_distance)
            {
                move_to_play = move;
            }
        }
        return move_to_play;
    }

    int SquareDistance(Square s1, Square s2)
    {
        // Math isn't allowed, so I have to do my own abs I guess...
        int f = s1.File - s2.File;
        if (f < 0) { f *= -1; }

        int r = s1.Rank - s2.Rank;
        if (r < 0) { r *= -1; }

        return f + r;
    }
}