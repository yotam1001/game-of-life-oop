using System;
using System.Xml.Linq;


namespace GameOfLifeOOP
{

    public class GameBoard
    {
        Random rnd = new Random();
        private int CountAlive(int i, int j){
            int count = 0;
            for (int x = -1; x <= 1; x++)
            {
                for(int y = -1; y<=1; y++)
                {
                    if(IsInBounds(i-x, j-y)){
                        if(boardState[(i - x), (j - y)] == true && x != 1 && y != 1)
                        {
                            count++;
                        }//make sure that the cell dosent count itself
                    }
                }
            }
            return count;
        }

        private static bool UpdateCell(bool[,] boardState, int[,] counterBoard, int i, int j)
        {
        if (boardState[i ,j] == true){
            if(counterBoard[i, j] < 2)
            {
                return false;
            }else if(counterBoard[i, j] > 2 && counterBoard[i, j] < 4)
            {
                return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (counterBoard[i, j] == 2)
                {
                    return true;
                }else{return false;}
            }
        }
        private int boardSize;

        private bool[,] boardState;
        public GameBoard(int boardSize)
        {
            Random rnd = new Random();

            this.boardSize = (boardSize-1);

            boardState = new bool [boardSize, boardSize];

            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    boardState[i, j] = rnd.NextDouble() >= 0.5;
                }
            }

        }
        public GameBoard()
        {
            this.boardSize = 6;

            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    boardState[i, j] = rnd.NextDouble() >= 0.5;
                }
            }
        }

        private bool IsInBounds(int i, int j)
        {
            if(i <= boardState.GetLength(1) && i >= 0 || j <= boardState.GetLength(1) && j >= 0)//checks if the cell is in the array, if its out of bound 0 < x < i, 0< y < j;
            {
                return true;
            }
            return false;

        }


        public void UpdateGameState()
        {
            int [,] BoardCounter = new int [boardSize, boardSize];
            for (int i = 0; i < boardSize; i++)
            {
                for(int j = 0; j < boardSize; j++)
                {
                    BoardCounter[i,j] = CountAlive(i, j);
                }//this updates the  board counter for each alive cell, and stores it in the counter array.
            }
            for (int i = 0; i < boardSize; i++)
            {
                for(int j = 0; j < boardSize; j++)
                {
                    boardState[i,j] = UpdateCell(boardState ,BoardCounter, i, j);
                }//this updates the  board counter for each alive cell, and stores it in the counter array.
            }
        }




        // store the board, display the board and claclulate the next step.
    }
    internal class Program
    {
        static void Main(string[] args)
        {

        }
    }
}
