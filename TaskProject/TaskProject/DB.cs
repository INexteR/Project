
namespace TaskProject
{
    public class DB
    {
        public const string CONNECTION = "server=localhost;database=travelagency;password=1RU78505$;user=root";
        public static ServerVersion Version { get; }

        static DB()
        {
            Version = ServerVersion.Parse("8.0.30-mysql");
        }

        private static Context GetContext()
        {
            var options = new DbContextOptionsBuilder<Context>().UseMySql(CONNECTION, Version).Options;
            return new(options);
        }

        public static IEnumerable<Employee> GetEmployees()
        {
            using var context = GetContext();
            foreach (var employee in context.Employees)
            {
                yield return employee;
            }
        }

        public static void AddEmployee(Employee employee)
        {
            employee.Status = "Работает";
            using var context = GetContext();
            context.Employees.Add(employee);
            context.SaveChanges();
        }

        public static void RemoveEmployee(Employee employee)
        {
            using var context = GetContext();
            context.Employees.Remove(employee);
            var log = new Log
            {               
                 EmployeeFullName = employee.FullName,
                 DateTime = DateTime.Now
            };
            context.Logs.Add(log);
            context.SaveChanges();
        }

        public static void PrintDismissed()
        {
            using var context = GetContext();
            var app = new Wd.Application();
            var doc = app.Documents.Add();
            var title = doc.Paragraphs.Last;
            title.Range.Text = "Список уволенных сотрудников";
            title.Range.Bold = 1;
            title.Range.Font.Name = "Times New Roman";
            title.Range.Font.Size = 14;
            title.LineSpacingRule = Wd.WdLineSpacing.wdLineSpaceDouble;
            title.Alignment = Wd.WdParagraphAlignment.wdAlignParagraphCenter;
            title.SpaceAfter = 0;
            var next = doc.Paragraphs.Add().Next();
            next.Range.Bold = 0;
            next.Alignment = Wd.WdParagraphAlignment.wdAlignParagraphLeft;
            next.LineSpacingRule = Wd.WdLineSpacing.wdLineSpace1pt5;
            next.FirstLineIndent = app.CentimetersToPoints(1);
            foreach (var record in context.Logs)
            {
                string text = $"Сотрудник {record.EmployeeFullName} уволен {record.DateTime:f}.";
                var par = doc.Paragraphs.Last;
                par.Range.Text = text; 
                doc.Paragraphs.Add();
            }
            app.Visible = true;
        }
        public static void PrintJournal()
        {
            using var context = GetContext();
            var app = new Wd.Application();
            var doc = app.Documents.Add();
            var title = doc.Paragraphs.Last;
            title.Range.Text = "Журнал продаж туров";
            title.Range.Bold = 1;
            title.Range.Font.Name = "Times New Roman";
            title.Range.Font.Size = 14;
            title.LineSpacingRule = Wd.WdLineSpacing.wdLineSpaceDouble;
            title.Alignment = Wd.WdParagraphAlignment.wdAlignParagraphCenter;
            title.SpaceAfter = 0;
            var next = doc.Paragraphs.Add().Next();
            next.Range.Bold = 0;
            next.Alignment = Wd.WdParagraphAlignment.wdAlignParagraphLeft;
            next.LineSpacingRule = Wd.WdLineSpacing.wdLineSpace1pt5;
            next.FirstLineIndent = app.CentimetersToPoints(1);
            foreach (var record in context.Journals.Include(r => r.Tour)
                .Include(r => r.Client))
            {
                var par = doc.Paragraphs.Last;
                par.Range.Text = $"Клиент: {record.Client.FullName}";
                par = doc.Paragraphs.Add().Next();
                par.Range.Text = $"Тур: \"{record.Tour.Name}\"";
                par = doc.Paragraphs.Add().Next();
                par.Range.Text = $"Количество туров: {record.TourCount}";
                par = doc.Paragraphs.Add().Next();
                par.Range.Text = $"Сумма: {record.Tour.Cost * record.TourCount} руб.";
                par = doc.Paragraphs.Add().Next();
                par.Range.Text = $"Дата: {record.StartDate.ToLongDateString()}";
                doc.Paragraphs.Add();
                doc.Paragraphs.Add();
            }
            app.Visible = true;
        }
    }
}
