namespace P07_Distance_in_Labyrinth
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public class Cell
        {
            public int Value { get; private set; }
            public int Row { get; private set; }
            public int Col { get; private set; }

            public Cell(int row, int col, int value)
            {
                this.Row = row;
                this.Col = col;
                this.Value = value;
            }
        }

        private static readonly Queue<Cell> VisitedCells = new Queue<Cell>();

        public static void Main()
        {
            int dimentions = int.Parse(Console.ReadLine());

            // Fill matrix
            string[,] matrix = new string[dimentions, dimentions];

            for (int row = 0; row < dimentions; row++)
            {
                string input = Console.ReadLine();

                for (int col = 0; col < input.Length; col++)
                {
                    matrix[row, col] = input[col].ToString();
                }
            }

            // Find starting position
            int starRow = 0;
            int starCol = 0;

            for (int row = 0; row < dimentions; row++)
            {
                for (int col = 0; col < dimentions; col++)
                {
                    if (matrix[row, col] == "*")
                    {
                        starRow = row;
                        starCol = col;
                        break;
                    }
                }
            }

            // Find shortest path
            Cell startingCell = new Cell(starRow, starCol, 0);
            VisitedCells.Enqueue(startingCell);

            while (VisitedCells.Count > 0)
            {
                Cell currentCell = VisitedCells.Dequeue();
                int row = currentCell.Row;
                int col = currentCell.Col;
                int value = currentCell.Value + 1;

                VisitCell(new Cell(row, col + 1, value), matrix, dimentions);
                VisitCell(new Cell(row, col - 1, value), matrix, dimentions);
                VisitCell(new Cell(row + 1, col, value), matrix, dimentions);
                VisitCell(new Cell(row - 1, col, value), matrix, dimentions);
            }

            // Print result
            for (int row = 0; row < dimentions; row++)
            {
                for (int col = 0; col < dimentions; col++)
                {
                    Console.Write(matrix[row, col] == "0" ? "u" : $"{matrix[row, col]}");
                }

                Console.WriteLine();
            }
        }

        public static void VisitCell(Cell cell, string[,] matrix, int dimentions)
        {
            if (IsCellFree(cell, matrix, dimentions))
            {
                VisitedCells.Enqueue(cell);
                matrix[cell.Row, cell.Col] = cell.Value.ToString();
            }
        }

        public static bool IsCellFree(Cell cell, string[,] matrix, int dimentions)
        {
            int row = cell.Row;
            int col = cell.Col;

            bool isFree = row >= 0 && row < dimentions &&
                col >= 0 && col < dimentions
                && matrix[row, col] == "0";

            return isFree;
        }
    }
}
