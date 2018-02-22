using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bitboard  {
    public int counter;
    public ulong[] boards = new ulong[2];
    int[] height = { 0, 7, 14, 21, 28, 35, 42 };
    List<int> possiblemoves = new List<int>();
    public int[] moves = new int[42];

    
    bool IsWin(ulong bitboard)
    {
        Debug.Log("bitboard" + bitboard);
        if ((bitboard & (bitboard >> 6) & (bitboard >> 12) & (bitboard >> 18)) != 0) return true; // diagonal 
        if ((bitboard & (bitboard >> 8) & (bitboard >> 16) & (bitboard >> 24)) != 0) return true; // diagonal
        if ((bitboard & (bitboard >> 7) & (bitboard >> 14) & (bitboard >> 21)) != 0) return true; // horizontal
        if ((bitboard & (bitboard >> 1) & (bitboard >> 2) & (bitboard >> 3)) != 0) return true; // vertical
        return false;
    }

    public void makebitboardMove(int col)
    {

        Debug.Log("Move Was made to col: " + col);
        

        ulong move = 1UL << height[col]++; ;                                        
        boards[counter & 1] ^= move; 
        moves[counter] = col;
        if (IsWin(boards[counter & 1]))
        {
            Debug.Log("VOITTO!");
        }
        counter++;
    }
    public void undoMove()
    {
        int col = moves[--counter];    
        ulong move = 1UL << --height[col]; 
        boards[counter & 1] ^= move;  
    }
     List<int> listMoves()
    {
        ulong TOP = 0x1020408102040;
        for (int col = 0; col <= 6; col++)
        {
            if ((TOP & (1UL << height[col])) == 0) possiblemoves.Add(col);
        }
        return possiblemoves;
    }
}
