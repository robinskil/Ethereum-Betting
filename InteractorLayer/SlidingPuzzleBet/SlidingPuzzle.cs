using InteractorLayer.RequestModels;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace InteractorLayer.SlidingPuzzleBet
{

    public class SlidingPuzzle : IDisposable
    {
        public int[,] Puzzle { get; }
        public int[,] Answer { get; }
        public SlidingPuzzleMoveModel Black { get; set; }

        private Random Random { get; }
        public bool Finished { get; private set; }
        public List<int> Numbers { get; }
        public Stopwatch Time { get; }
        public double CompletedTime { get; }
        public SlidingPuzzle()


        {
            Random = new Random();
            Puzzle = new int[4, 4];
            Black = new SlidingPuzzleMoveModel();
            Answer = new int[Puzzle.GetLength(0), Puzzle.GetLength(1)];
            Numbers = new List<int>();
            GenerateRandomPuzzle();

            Time = new Stopwatch();
            Time.Start();
        }


        public int FindDifference(int nr1, int nr2)
        {
            int a = Math.Abs(nr1 - nr2);
            return a;
        }


        public bool DoMove(SlidingPuzzleMoveModel moveModel)
        {
            if ((FindDifference(Black.X, moveModel.X) == 1) && (FindDifference(Black.Y, moveModel.Y) == 0) ||
                (FindDifference(Black.Y, moveModel.Y) == 1) && (FindDifference(Black.X, moveModel.X) == 0))
            {

                int old_black = Puzzle[Black.X, Black.Y];
                int old_moveModel = Puzzle[moveModel.X, moveModel.Y];

                Puzzle[Black.X, Black.Y] = old_moveModel;
                Puzzle[moveModel.X, moveModel.Y] = old_black;


                TryFinish();
                return true;

            }
            else
            {

                return false;
            }
            //throw new NotImplementedException();
        }

        public bool TryFinish()
        {
            var equal =
                Puzzle.Rank == Answer.Rank &&
                Enumerable.Range(0, Puzzle.Rank).All(dimension => Puzzle.GetLength(dimension) == Answer.GetLength(dimension)) &&
                Puzzle.Cast<int>().SequenceEqual(Answer.Cast<int>());

            if (equal == true)
            {
                Time.Stop();
                Finished = true;
                return true;
            }
            else
            {
                return false;
            }

            //throw new NotImplementedException();
        }

        public void Shuffle(List<int> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = this.Random.Next(n + 1);
                int value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        /// <summary>
        /// This method fills in the puzzle
        /// </summary>
        private void GenerateRandomPuzzle()
        {

            for (int a = 0; a < Puzzle.Length; a++)
            {
                Numbers.Add(a);
            }
            Shuffle(Numbers);

            int cnt = 0;
            int cnt2 = 1;

            for (int y = 0; y < Puzzle.GetLength(1); y++)
            {

                for (int x = 0; x < Puzzle.GetLength(0); x++)
                {

                    Puzzle[x, y] = Numbers[cnt];

                    if (Numbers[cnt] == 0)
                    {
                        Black.X = x;
                        Black.Y = y;
                    }
                    Answer[x, y] = cnt2;

                    cnt++;
                    cnt2++;

                }
            }
            Answer[(Puzzle.GetLength(0) - 1), (Puzzle.GetLength(1) - 1)] = 0;


            //throw new NotImplementedException();
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~SlidingPuzzle() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }

}

