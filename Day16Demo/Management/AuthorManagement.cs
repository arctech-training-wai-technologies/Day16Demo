using Day16Demo.Entitites;

namespace Day16Demo.Management
{
    internal class AuthorManagement
    {        
        private const string fileName = "Authors.csv";
        private readonly string filePath = Path.Combine(DataConstants.RootFolder, fileName);

        public void List()
        {
            var fileData = File.ReadAllLines(filePath);
            DisplayDataHeader();

            for (int i = 1; i < fileData.Length; i++)
            {
                var csvLine = fileData[i];

                var author = new Author(csvLine);
                Console.WriteLine(author.FormattedData);
            }

            DisplayDataFooter();
        }

        public void Create()
        {
            Author author = GenerateNewAuthor();

            SaveToFile(author);
        }        

        public void Update()
        {
            Console.Write("Enter Author Id to Update: ");
            string idToDeleteText = Console.ReadLine();
            int idToDelete = int.Parse(idToDeleteText);

            // did not make this toList because it is not required in Update
            string[] fileDataList = File.ReadAllLines(filePath);

            for (int i = 1; i < fileDataList.Length; i++)
            {
                var csvLine = fileDataList[i];

                var author = new Author(csvLine);

                if (author.Id == idToDelete)
                {
                    bool confirmed = GetConfirmation(author, "update");

                    if(confirmed)
                    {
                        var editedAuthor = GenerateNewAuthor(author.Id);

                        fileDataList[i] = editedAuthor.DataCsv;

                        File.WriteAllLines(filePath, fileDataList);

                        ConsoleHelper.ShowSuccessMessage("Record successfully updated!");
                    }
                    else
                        ConsoleHelper.ShowWarningMessage("Update aborted......");

                    break;
                }
            }            
        }        

        public void Delete()
        {
            Console.Write("Enter Author Id to Delete: ");
            string idToDeleteText = Console.ReadLine();
            int idToDelete = int.Parse(idToDeleteText);

            // Made this tolist because we need RemoveAt which is only available in List not in array            
            List<string> fileDataList = File.ReadAllLines(filePath).ToList();

            for (int i = 1; i < fileDataList.Count; i++)
            {
                var csvLine = fileDataList[i];

                var author = new Author(csvLine);

                if(author.Id == idToDelete)
                {
                    bool confirmed = GetConfirmation(author, "delete");

                    if (confirmed)
                    {
                        fileDataList.RemoveAt(i);
                        File.WriteAllLines(filePath, fileDataList);
                        ConsoleHelper.ShowSuccessMessage("Record successfully deleted!");
                    }
                    else
                        ConsoleHelper.ShowWarningMessage("Deleting aborted......");

                    break;
                }
            }
        }

        private static Author GenerateNewAuthor(int? authorId = null)
        {
            var author = new Author();

            if (authorId != null)
                author.Id = (int)authorId;
            else
            {
                Console.Write("Enter Author Id: ");
                string idText = Console.ReadLine();
                author.Id = int.Parse(idText);
            }

            Console.Write("Enter Author Name: ");
            author.Name = Console.ReadLine();

            Console.Write("Enter Author Notes: ");
            author.Notes = Console.ReadLine();
            return author;
        }

        private static bool GetConfirmation(Author author, string action)
        {
            Console.WriteLine("Author found");

            DisplayDataHeader();

            Console.WriteLine(author.FormattedData);

            DisplayDataFooter();

            Console.Write($"Are you sure you want to {action} [y/n]: ");
            var confirmKey = Console.ReadKey();

            Console.WriteLine();
            return confirmKey.Key == ConsoleKey.Y;
        }

        private void SaveToFile(Author author)
        {
            if (!File.Exists(filePath))
                File.WriteAllText(filePath, Author.HeadingCsv);

            File.AppendAllText(filePath, author.DataCsv);
        }

        private static void DisplayDataFooter()
        {
            Console.WriteLine("*********************************************************************************************");
        }

        private static void DisplayDataHeader()
        {
            Console.WriteLine("=============================================================================================");
            Console.WriteLine(Author.FormattedHeading);
            Console.WriteLine("=============================================================================================");
        }
    }
}
