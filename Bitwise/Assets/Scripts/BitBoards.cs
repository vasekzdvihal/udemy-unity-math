namespace DefaultNamespace
{
    public class BitBoards
    {
        long SetCellState(long bitboard, int row, int col)
        {
            long newBit = 1L << (row * 8 + col);
            return (bitboard |= newBit);
        }

        bool GetCellState(long bitboard, int row, int col)
        {
            long mask = 1L << (row * 8 + col);
            return ((bitboard & mask) != 0);
        }

        int CellCount(long bitboard)
        {
            int count = 0;
            long bb = bitboard;

            while (bb != 0)
            {
                bb &= bb - 1;
                count++;
            }

            return count;
        }
    }
}