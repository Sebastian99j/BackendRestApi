using OfficeOpenXml;
using BackendRestApi.Data;
using BackendRestApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace BackendRestApi.Data
{
    using OfficeOpenXml;
    using BackendRestApi.Data;
    using BackendRestApi.Models;
    using Microsoft.EntityFrameworkCore;

    public static class DbSeeder
    {
        public static async Task SeedAsync(AIContext context)
        {
            if (!await context.Users.AnyAsync())
            {
                var user = new Users
                {
                    Username = "admin",
                    AiIdentifier = "admin",
                    PasswordHash = "$2b$12$gDoxZnJYRQKsxB17nfE5k.th/m8Snl104idWwdEI.9AaYvH./io/6"
                };

                context.Users.Add(user);
                await context.SaveChangesAsync();

                var trainingType = new TrainingTypes
                {
                    Name = "Bench press"
                };

                context.TrainingTypes.Add(trainingType);
                await context.SaveChangesAsync();

                var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "SeedData", "dane_do_regresji.xlsx");
                if (!File.Exists(filePath))
                    throw new FileNotFoundException("Plik Excel nie znaleziony:", filePath);

                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using var package = new ExcelPackage(new FileInfo(filePath));
                if (package.Workbook.Worksheets.Count == 0)
                    throw new Exception("Plik Excel nie zawiera arkuszy.");

                var worksheet = package.Workbook.Worksheets[0];

                for (int row = 2; worksheet.Cells[row, 1].Value != null; row++)
                {
                    var training = new TrainingSeries
                    {
                        UserId = user.Id,
                        TrainingTypeId = trainingType.Id,
                        Weight = float.Parse(worksheet.Cells[row, 2].Text, CultureInfo.InvariantCulture),
                        Reps = int.Parse(worksheet.Cells[row, 3].Text),
                        Sets = int.Parse(worksheet.Cells[row, 4].Text),
                        RPE = int.Parse(worksheet.Cells[row, 5].Text),
                        DateTime = DateTime.Parse(worksheet.Cells[row, 6].Text),
                        BreaksInSeconds = int.Parse(worksheet.Cells[row, 7].Text),
                        Trained = false
                    };

                    context.TrainingSeries.Add(training);
                }

                await context.SaveChangesAsync();
            }
        }
    }
}
