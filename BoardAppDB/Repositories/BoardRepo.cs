using BoardAppDB.Data;
using BoardAppDB.Interfaces;
using BoardAppDB.Models;
using Microsoft.EntityFrameworkCore;

namespace BoardAppDB.Repositories
{
    public class BoardRepo : IBoard
    {
        private readonly BoardContext _dbContext;
        public BoardRepo(BoardContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public Board Create(Board board)
        {
            _dbContext.Add(board);
            _dbContext.SaveChanges();
            return board;
        }

        public bool Delete(Board board)
        {
            _dbContext.Remove(board);
            _dbContext.SaveChanges();
            return IsExist(board.BoardCode);
        }

        public Board Details(string boardCode)
        {
            Board board = _dbContext.Boards.FirstOrDefault(b => b.BoardCode == boardCode)!;
            Console.WriteLine("Retrieved");
            Console.WriteLine(boardCode+"asdfghjk");
            if (board != null)
            {
            Console.WriteLine(board.BoardCode);
            Console.WriteLine(board.FlashKb);
            Console.WriteLine(board.BoardCode);
            Console.WriteLine(board.BoardCode);

            }
            return board;
        }

        public Board Edit(Board board)
        {
            _dbContext.Update(board);
            _dbContext.SaveChanges();
            return board;
        }

        public IEnumerable<Board> GetBoards()
        {
            var boards = _dbContext.Boards.ToList();
            return boards;
        }

        public bool IsExist(string boardCode)
        {
            bool isExist = false;
            Board board = Details(boardCode);
            if (board == null)
            {
                isExist = true;
            }
            return isExist;
        }
    }
}
