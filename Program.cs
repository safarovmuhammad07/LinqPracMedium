


//Task1
//Сгруппировать заказы по категориям и дате, вычислить общую 
//сумму заказов для каждой группы и отсортировать результаты
//по убыванию суммы.


//
// var orders = new List<Order>
// {
//     new Order { Id = 1, CustomerName = "Иван", OrderDate = new DateTime(2024, 1, 15), Amount = 1200.50m, Category = "Электроника" },
//     new Order { Id = 2, CustomerName = "Мария", OrderDate = new DateTime(2024, 1, 15), Amount = 850.75m, Category = "Книги" },
//     new Order { Id = 3, CustomerName = "Иван", OrderDate = new DateTime(2024, 1, 16), Amount = 2100.00m, Category = "Электроника" },
//     new Order { Id = 4, CustomerName = "Анна", OrderDate = new DateTime(2024, 1, 16), Amount = 450.30m, Category = "Книги" }
// };
// var query1 = orders.GroupBy(g => new { g.Category, g.OrderDate }).Select(o => new
//     {
//         Category = o.Key.Category,
//         Date = o.Key.OrderDate,
//         TotalAmount = o.Sum(o => o.Amount)
//     }).OrderByDescending(x=> x.TotalAmount).ToList();
// public class Order
// {
//     public int Id { get; set; }
//     public string CustomerName { get; set; }
//     public DateTime OrderDate { get; set; }
//     public decimal Amount { get; set; }
//     public string Category { get; set; }
// }
//Task2
//Получить список студентов с их группами и средним баллом по
//всем предметам. Отсортировать по среднему баллу (по убыванию).
//
//
// var students = new List<Student>
// {
//     new Student { Id = 1, Name = "Иван Петров", GroupId = 1 },
//     new Student { Id = 2, Name = "Мария Иванова", GroupId = 2 },
//     new Student { Id = 3, Name = "Петр Сидоров", GroupId = 1 }
// };
// //
// var query2 = (from s in students
//     join g in groups on s.GroupId equals g.Id  join gr in grades on s.Id equals gr.StudentId
//     select new
//     {
//         StudentName = s.Name,
//         GroupName = g.Name,
//         AvgScore = grades.Where(e => e.StudentId == s.Id).Average(f => f.Score)
//     }).OrderByDescending(e => e.AvgScore);

//
//
// var result = students.Join(groups,s => s.GroupId, g=> g.Id, (student, group) => new { Student = student, GroupName = group.Name })
//     .Select(studentWithGroup => new { studentWithGroup.Student,studentWithGroup.GroupName, Grades = grades.Where(grade => grade.StudentId == studentWithGroup.Student.Id) })
//     .Select(studentWithGrades => new { StudentName = studentWithGrades.Student.Name, GroupName = studentWithGrades.GroupName, AverageScore = studentWithGrades.Grades.Any() ? studentWithGrades.Grades.Average(g => g.Score) : 0 })
//     .OrderByDescending(student => student.AverageScore);
//
//
//
//
//
//
// public class Student
// {
//     public int Id { get; set; }
//     public string Name { get; set; }
//     public int GroupId { get; set; }
// }
//
// public class Group
// {
//     public int Id { get; set; }
//     public string Name { get; set; }
// }
//
// public class Grade
// {
//     public int StudentId { get; set; }
//     public string Subject { get; set; }
//     public int Score { get; set; }
// }
//




//Task3
//Найти всех сотрудников, у которых есть навык C# с уровнем выше
//3, и сгруппировать их по отделам.
//var query3 = departments.Where(d => d.Employees.Any(x => x.Skills.Any(w => w.Name == "C#" && w.Level > 3))).GroupBy(o => o.Employees).Select(x=> new { Employee = x.Key, Skill = x.Key.Select(p=> p.Skills) }).ToList();


// var result = departments.Select(department => new { DepartmentName = department.Name, Employees = department.Employees.Where(employee => employee.Skills.Any(skill => skill.Name == "C#" && skill.Level > 3))
//         .Select(employee => employee.Name) })
//     .Where(department => department.Employees.Any());
//
//
//
// public class Department
// {
//     public string Name { get; set; }
//     public List<Employee> Employees { get; set; }
// }
//
// public class Employee
// {
//     public string Name { get; set; }
//     public List<Skill> Skills { get; set; }
// }
//
// public class Skill
// {
//     public string Name { get; set; }
//     public int Level { get; set; }
// }
//


//Task4
//Рассчитать для каждого символа: минимальную цену, максимальную цену,
//среднюю цену и процент изменения между первым и последним днем.

//
// var stockPrices = new List<StockPrice>
// {
//     new StockPrice { Date = new DateTime(2024, 1, 1), Symbol = "AAPL", Price = 150.00m },
//     new StockPrice { Date = new DateTime(2024, 1, 2), Symbol = "AAPL", Price = 155.00m },
//     new StockPrice { Date = new DateTime(2024, 1, 3), Symbol = "AAPL", Price = 153.00m },
//     new StockPrice { Date = new DateTime(2024, 1, 1), Symbol = "GOOGL", Price = 2500.00m },
//     new StockPrice { Date = new DateTime(2024, 1, 2), Symbol = "GOOGL", Price = 2550.00m },
//     new StockPrice { Date = new DateTime(2024, 1, 3), Symbol = "GOOGL", Price = 2480.00m }
// };


var query4 = from stockPrice in stockPrices
    group stockPrice by stockPrice.Symbol
    into g
    select new
    {
        Name = g.Key,
        Min = g.Min(x=>x.Price),
        Max = g.Max(x=>x.Price),
        Avg = g.Average(x=>x.Price),
        First = g.First(x=>x.Date==g.Min(e=>e.Date)).Price,
        End = g.First(x=>x.Date==g.Max(e=>e.Date)).Price
    };


//
// public class StockPrice
// {
//     public DateTime Date { get; set; }
//     public string Symbol { get; set; }
//     public decimal Price { get; set; }
// }



//
// //Task5
// //Найти все документы, которые содержат определенное слово в
// //контенте или тегах, ивернуть список с заголовками и совпадающими тегами.
//
//
// // Пример данных:
// var transactions = new List<Transaction>
// {
//     new Transaction { Id = 1, AccountId = "ACC1", Amount = 100.00m, Date = new DateTime(2024, 1, 1), Category = "Продукты" },
//     new Transaction { Id = 2, AccountId = "ACC1", Amount = -50.00m, Date = new DateTime(2024, 1, 2), Category = "Транспорт" },
//     new Transaction { Id = 3, AccountId = "ACC2", Amount = 200.00m, Date = new DateTime(2024, 1, 1), Category = "Зарплата" },
//     new Transaction { Id = 4, AccountId = "ACC2", Amount = -75.00m, Date = new DateTime(2024, 1, 2), Category = "Продукты" }
// };
//


//string responce = Console.ReadLine();

//var query5 = documents.Where(x => x.Content.ToUpper().Contains(responce.ToUpper()) || x.Tags.Any(e=>e.ToUpper().Contains(responce.ToUpper())));


//
//
// public class Transaction
// {
//     public int Id { get; set; }
//     public string AccountId { get; set; }
//     public decimal Amount { get; set; }
//     public DateTime Date { get; set; }
//     public string Category { get; set; }
// }

//Task6
//Рассчитать баланс для каждого аккаунта, сгруппировать транзакции по
//категориям и вычислить процентное соотношение расходов по категориям.
// var transactions = new List<Transaction>
// {
//     new Transaction { Id = 1, AccountId = "ACC1", Amount = 100.00m, Date = new DateTime(2024, 1, 1), Category = "Продукты" },
//     new Transaction { Id = 2, AccountId = "ACC1", Amount = -50.00m, Date = new DateTime(2024, 1, 2), Category = "Транспорт" },
//     new Transaction { Id = 3, AccountId = "ACC2", Amount = 200.00m, Date = new DateTime(2024, 1, 1), Category = "Зарплата" },
//     new Transaction { Id = 4, AccountId = "ACC2", Amount = -75.00m, Date = new DateTime(2024, 1, 2), Category = "Продукты" }
// };


//
//
// public class Transaction
// {
//     public int Id { get; set; }
//     public string AccountId { get; set; }
//     public decimal Amount { get; set; }
//     public DateTime Date { get; set; }
//     public string Category { get; set; }
// }



    //Task7
    //Проанализировать логи: найти сервисы с наибольшим количеством ошибок, сгруппировать ошибки по
    //временны минтервалам (по минутам) и вычислить частоту различных типов ошибок.
    // Пример данных:
    // var logs = new List<LogEntry>
    // {
    //     new LogEntry { Timestamp = new DateTime(2024, 1, 1, 10, 0, 0), Level = "ERROR", Service = "API", Message = "Connection failed" },
    //     new LogEntry { Timestamp = new DateTime(2024, 1, 1, 10, 0, 5), Level = "WARNING", Service = "DB", Message = "Slow query detected" },
    //     new LogEntry { Timestamp = new DateTime(2024, 1, 1, 10, 1, 0), Level = "ERROR", Service = "API", Message = "Timeout" },
    //     new LogEntry { Timestamp = new DateTime(2024, 1, 1, 10, 2, 0), Level = "INFO", Service = "Cache", Message = "Cache cleared" }
    // };
    //
    // var result = logs.Where(l => l.Level == "ERROR").GroupBy(l => l.Service).Select(sg => new
    //     {
    //         Service = sg.Key,
    //         ErrorCount = sg.Count(),
    //         ErrorsByMinute = sg.GroupBy(l => new DateTime(l.Timestamp.Year, l.Timestamp.Month, l.Timestamp.Day, l.Timestamp.Hour, l.Timestamp.Minute, 0)).Select
    //         ( mg => new
    //             {
    //                 Minute = mg.Key,
    //                 ErrorFrequency = mg.Count(),
    //                 ErrorTypes = mg.GroupBy(l => l.Message).Select(eg => new { ErrorMessage = eg.Key, Frequency = eg.Count() })
    //             }
    //         )
    //     }).OrderByDescending(s => s.ErrorCount);
    //
    //
    // public class LogEntry
    // {
    //     public DateTime Timestamp { get; set; }
    //     public string Level { get; set; }  // "ERROR", "WARNING", "INFO"
    //     public string Service { get; set; }
    //     public string Message { get; set; }
    // }
