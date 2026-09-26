using BoardAppDB.Interfaces;
using BoardAppDB.Models;
using Microsoft.AspNetCore.Mvc;

namespace BoardAppDB.Controllers
{
    public class BoardController : Controller
    {
        private readonly IBoard _boardRepo;

        public BoardController(IBoard boardRepo)
        {
            _boardRepo = boardRepo;
        }

        public IActionResult Index()
        {
            return View(_boardRepo.GetBoards());
        } 

        public IActionResult Details(string boardCode)
        {
            return View(_boardRepo.Details(boardCode));
        } 

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.ShowAdd = false;
            return View();
        } 

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("BoardCode, Make, Model, FlashKb, Price")] Board board)
        {
            if (ModelState.IsValid)
            {
                ViewBag.SuccessMessage = $"Board {board.BoardCode} was added.";
                ViewBag.ShowAdd = true;
                board = _boardRepo.Create(board);
            }

            if (_boardRepo.IsExist(board.BoardCode))
            {
                return View(board);
            }

            return View();
        } 

        [HttpGet]
        public IActionResult Edit(string boardCode)
        {
            ViewBag.ShowSave = false;
            var board = _boardRepo.Details(boardCode);
            return View(board);
        } 

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string boardCode, [Bind("BoardCode, Make, Model, FlashKb, Price")] Board board)
        {
            if (ModelState.IsValid)
            {
                board = _boardRepo.Edit(board);
                ViewBag.SuccessMessage = $"Board {boardCode} was updated.";
                ViewBag.ShowSave = true;
            }

            if (_boardRepo.IsExist(board.BoardCode))
            {
                return View(board);
            }

            return View(board);
        } 

        [HttpGet]
        public IActionResult Delete(string boardCode)
        {
            var board = _boardRepo.Details(boardCode);
            ViewBag.ShowDelete = true;
            return View(board);
        } 

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(string boardCode, Board board)
        {
            bool found = _boardRepo.Delete(board);

            if (found)
            {
                ViewBag.SuccessMessage = $"Board {board.BoardCode} was deleted.";
                ViewBag.ShowDelete = false;
            }

            return View();
        } 
    } 
} 
