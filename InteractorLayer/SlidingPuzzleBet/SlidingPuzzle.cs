using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace InteractorLayer.SlidingPuzzleBet
{
    public class SlidingPuzzle : IDisposable
    {
        public int[,] Puzzle { get; }
        public Stopwatch Time { get; }
        public double CompletedTime { get; }
        public SlidingPuzzle()
        {
            Puzzle = new int[4,4];
            GenerateRandomPuzzle();
            Time = new Stopwatch();
            Time.Start();
        }

        public bool TryFinish()
        {
            Time.Stop();
            throw new NotImplementedException();
        }

        /// <summary>
        /// This method fills in the puzzle
        /// </summary>
        private void GenerateRandomPuzzle()
        {
            for (int i = 0; i < Puzzle.GetLength(0); i++)
            {
                for (int j = 0; j < Puzzle.GetLength(1); j++)
                {

                }
            }
            throw new NotImplementedException();
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
