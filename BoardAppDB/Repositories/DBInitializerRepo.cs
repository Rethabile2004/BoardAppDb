using BoardAppDB.Data;
using BoardAppDB.Interfaces;
using BoardAppDB.Models;

namespace BoardAppDB.Repositories
{
    public class DBInitializerRepo:IDBInitializer
    {
        private readonly BoardContext _context;
        public DBInitializerRepo(BoardContext context)
        {
            _context = context;
        }
        public void Initialize()
        {
            //
            // Name             : void Initialize(CalculatorContext context)
            // Purpose          : Ensure database creation and seed default calculator data if empty
            // Re-use           : None
            // Input Parameters : CalculatorContext context
            //                    - database context used to manage calculator records
            // Output Type      : None
            //
            _context.Database.EnsureCreated();

            if (_context.Boards.Any())
            {
                return; // DB has been seeded
            } // end if

            var boards = new List<Board>()
            {
                new Board("1001", "Espressif", "ESP32-WROOM-32", 4096, 129.00m),
                new Board("1002", "Espressif", "ESP32-C3-MINI-1", 4096, 99.00m),
                new Board("1003", "STMicroelectronics", "STM32F103C8T6", 64, 75.00m),
                new Board("1004", "STMicroelectronics", "STM32F411CEU6", 512, 145.00m),
                new Board("1005", "Microchip", "ATmega328P", 32, 89.00m),
                new Board("1006", "Microchip", "ATmega2560", 256, 199.00m),
                new Board("1007", "WCH", "CH32V003F4P6", 16, 29.00m),
                new Board("1008", "Raspberry Pi", "Pico", 2048, 89.00m),
                new Board("1009", "Espressif", "ESP-01S", 1024, 65.00m),
                new Board("1010", "CUTfree", "CV32-BFN-01", 128, 49.00m)
            };

            foreach (Board b in boards)
            {
                _context.Boards.Add(b);
            } // end foreach

            _context.SaveChanges();
        }
    }
}
