namespace Day16Demo.Entitites;

/// <summary>
/// This is a test class to revise
/// properties in C#
/// </summary>
public class Employee
{
    //public int salary;

    //private string _name;
    //public string Name
    //{
    //    get { return _name; }
    //    set { _name = value; }
    //}
    public string Name { get; set; }


    //private string _designation;
    //public string Designation
    //{
    //    get { return _designation; }
    //    set { _designation = value; }
    //}

    public string Designation { get; set; }
    public string AppraisalComments { get; private set; }

    //private string _appraisalComments;
    //public string AppraisalComments
    //{
    //    get { return _appraisalComments; }
    //    private set { _appraisalComments = value; }
    //}


    //public int GetSalary()
    //{
    //    return salary;
    //}

    //public void SetSalary(int newSalary)
    //{
    //    if (newSalary < 0)
    //        throw new ArgumentException();

    //    salary = newSalary;
    //}

    // syntactic sugar
    private int _salary;
    public int Salary
    {
        //get { return _salary; }
        get => _salary;
        set
        {
            if (value < 0)
                throw new ArgumentException();

            _salary = value;
        }
    }
}
