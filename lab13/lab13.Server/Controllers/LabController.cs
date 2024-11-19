using Microsoft.AspNetCore.Mvc;
using LAB13_React.Server.Models;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;


namespace LAB13_React.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LabController : ControllerBase
    {
        private readonly IWebHostEnvironment _environment;

        public LabController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        [HttpGet("lab1")]
        public IActionResult Lab1()
        {
            var model = new LabViewModel
            {
                TaskNumber = "1",
                TaskVariant = "52",
                TaskDescription = "Іван працює на заводі, який виготовляє важку техніку. " +
                "Його робота дуже проста – він збирає коробки та пакує в них техніку для замовників. Кожна така коробка є паралелепіпедом. " +
                "Для збирання коробки Іван використовує шість прямокутних дерев'яних плиток. Кожна плита є однією зі сторін коробки. " +
                "Петро підбирає плитки для Івана. Петро недостатньо розумний і тому часто припускається помилок – він приносить Івану такі плитки, з яких неможливо зібрати коробку. " +
                "Але Іван не довіряє Петру. Тому він завжди витрачає багато часу на те, щоб пояснити Петру те, де він припустився помилки." +
                "\r\nНа щастя, Петро любить усе, що з комп'ютерами і вірить у те, що комп'ютери будь-коли помиляються. Іван вирішив, що можна використати це у їхній роботі. " +
                "Іван попросив Вас написати програму, яка за заданими розмірами шести плиток скаже: чи можливо збудувати з них коробку.\r\n",
                InputDescription = "Вхідний файл INPUT.TXT містить шість рядків, кожен з яких містить два натуральні числа w і h (1 ≤ w, h ≤ 10 000) – ширина та висота плити в міліметрах.",
                OutputDescription = "У вихідний файл OUTPUT.TXT виведіть «POSSIBLE», якщо можна зібрати коробку з цих плит, і «IMPOSSIBLE» в іншому випадку.",
                TestCases = new List<TestCase>
            {
                new TestCase { Input = "1345 2584\r\n2584 683\r\n2584 1345\r\n683 1345\r\n683 1345\r\n2584 683\r\n", Output = "POSSIBLE" },
                new TestCase { Input = "1234 4567\r\n1234 4567\r\n4567 4321\r\n4322 4567\r\n4321 1234\r\n4321 1234\r\n", Output = "IMPOSSIBLE" }
            }
            };

            return Ok(model);
        }

        [HttpGet("lab2")]
        public IActionResult Lab2()
        {
            var model = new LabViewModel
            {
                TaskNumber = "2",
                TaskVariant = "52",
                TaskDescription = "На прямій дощечці вбито гвоздики. Будь-які два гвоздики можна з'єднати ниточкою. " +
                "Потрібно з'єднати деякі пари гвоздиків ниточками так, щоб до кожного гвоздика була прив'язана хоча б одна ниточка, а сумарна довжина всіх ниток була мінімальна.",
                InputDescription = "У першому рядку вхідного файлу INPUT.TXT записано число N - кількість гвоздиків (2 ≤ N ≤ 100). " +
                "У наступному рядку записано N чисел - координати всіх гвоздиків (невід'ємні цілі числа, що не перевищують 10000).",
                OutputDescription = "У вихідний файл OUTPUT.TXT потрібно вивести однину - мінімальну сумарну довжину всіх ниток.",
                TestCases = new List<TestCase>
            {
                new TestCase { Input = "6\r\n63 4 12 6 14 13", Output = "59" }
            }
            };

            return Ok(model);
        }

        [HttpGet("lab3")]
        public IActionResult Lab3()
        {
            var model = new LabViewModel
            {
                TaskNumber = "3",
                TaskVariant = "52",
                TaskDescription = "Сема - любитель ігор на шахівниці. Найбільше він любить грати у шашки. Сема вирішив написати програму, яка гратиме у шашки. " +
                "За його задумом, вона показуватиме, які шашки можна взяти на цьому ходу. Ваше завдання – реалізувати цю функцію. " +
                "Після того, як біла шашка переміщається на порожнє поле, чорна шашка знімається з дошки та вважається взятою. " +
                "При цьому якщо після переміщення білої шашки, у неї знову з'являється можливість взяти, то вона продовжує свій хід. " +
                "Аналогічні правила для чорних шашок.\r\nЗазначимо, що у варіанті гри в шашки, що розглядається, відсутня поняття «дамка»," +
                " тобто можливості шашки по взяттю не залежать від того, доходила вона до останньої горизонталі чи ні.\r\n",
                InputDescription = "У перших восьми рядках вхідного файлу INPUT.TXT записані по вісім символів з множини {«.», «B», «W»}," +
                " які позначають порожнє поле, чорну шашку та білу шашку відповідно. У вхідному файлі не більше 12 шашок кожного кольору. Усі шашки розташовані " +
                "або на чорних або на білих полях.",
                OutputDescription = "У вихідний файл OUTPUT.TXT видайте поля, де стоять шашки, які можна взяти, якщо ходять білі чи чорні. " +
                "Використовуйте формат виводу аналогічний прикладам.",
                TestCases = new List<TestCase>
            {
                new TestCase
                {
                    Input = ".W.W.W.W\r\nW.W.W.W.\r\n.....W..\r\nW.W...W.\r\n.B.B....\r\nB...B.B.\r\n.B.B.B.B\r\nB.B...B.",
                    Output = "White: 3\r\n(5, 2)\r\n(5, 4)\r\n(7, 4)\r\nBlack: 1\r\n(4, 3)\r\n"
                }
            }
            };

            return Ok(model);
        }

        [HttpPost("processLab")]
        public async Task<IActionResult> ProcessLab([FromForm] int labNumber, IFormFile inputFile)
        {
            if (inputFile == null || inputFile.Length == 0)
                return BadRequest("Please upload a file");

            string[] lines;
            using (var reader = new StreamReader(inputFile.OpenReadStream()))
            {
                var fileContent = await reader.ReadToEndAsync();
                lines = fileContent.Split(Environment.NewLine);
            }

            string output;

            switch (labNumber)
            {
                case 1:
                    output = lab1.Program.ProcessLines(lines);
                    break;
                case 2:
                    int res = lab2.Program.CalculateMinimumSpanningTree(lines);
                    output = res.ToString().Trim();
                    break;
                case 3:
                    char[,] board = lab3.Program.LoadBoard(lines);
                    (List<(int, int)> whiteCanTake, List<(int, int)> blackCanTake) = lab3.Program.FindTakes(board);
                    string strs = lab3.Program.WriteOutput(lines, whiteCanTake, blackCanTake);
                    output = strs.ToString();
                    break;
                default:
                    return BadRequest("Invalid lab number");
            }

            var result = new { output = output };
            return Ok(new { output = output });
        }
    }
}
