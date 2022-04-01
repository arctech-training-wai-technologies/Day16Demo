namespace Day16Demo.Entitites;

public class Author
{
    private const string dataHeader = "Id,Name,Notes";

    public int Id { get; set; }

    private string _name;
    public string Name
    {
        get => _name;
        set
        {
            if (value.Length > 250)
                throw new ArgumentException();

            _name = value;
        }
    }

    private string _notes;

    public string Notes
    {
        get => _notes;
        set
        {
            if (value != null && value.Length > 2050)
                throw new ArgumentException();

            _notes = value;
        }
    }

    public static string FormattedHeading
    {
        get
        {
            var headerArray = dataHeader.Split(',');
            return $"{headerArray[0],-10}{headerArray[1],-50}{headerArray[2]}";
        }
    }

    public string FormattedData => $"{Id,-10}{Name,-50}{Notes}";

    public string DataCsv => $"{Id},{Name},{Notes}\n";
    
    public static string HeadingCsv => $"{dataHeader}\n";

    public Author()
    {}

    public Author(int id, string name, string notes = null)
    {
        Id = id;
        Name = name;
        Notes = notes;
    }

    public Author(string csvLine)
    {
        var dataArray = csvLine.Split(',');

        Id = int.Parse(dataArray[0]);
        Name = dataArray[1];
        Notes = dataArray[2];
    }
}
