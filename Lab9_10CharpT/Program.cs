using System;

// Task1
class InvalidTriangleException : Exception
{
    public InvalidTriangleException(string message) : base(message)
    {
    }
}

class Triangle
{
    private int[] sides = new int[3];
    private string color;

    public Triangle(int f, int s, int t)
    {
        if (!IsValidTriangle(f, s, t))
        {
            throw new InvalidTriangleException("Invalid triangle sides");
        }

        sides[0] = f;
        sides[1] = s;
        sides[2] = t;
    }

    public Triangle(int f, int s, int t, string col) : this(f, s, t)
    {
        color = col;
    }

    public void Print()
    {
        Console.WriteLine($"Triangle lines: a = {sides[0]}, b = {sides[1]}, c = {sides[2]}");
    }

    public int Perimeter()
    {
        return sides[0] + sides[1] + sides[2];
    }

    public double Area()
    {
        double halfPerimeter = Perimeter() / 2.0;
        return Math.Sqrt(halfPerimeter * (halfPerimeter - sides[0]) * (halfPerimeter - sides[1]) * (halfPerimeter - sides[2]));
    }

    public int GetSide(int index)
    {
        if (index < 0 || index >= sides.Length)
        {
            throw new IndexOutOfRangeException("Index is out of range for triangle sides array");
        }

        return sides[index];
    }

    public void SetSide(int index, int newValue)
    {
        ValidateSide(newValue);
        sides[index] = newValue;
    }

    public string GetColor()
    {
        return color;
    }

    private bool IsValidTriangle(int side1, int side2, int side3)
    {
        return side1 > 0 && side2 > 0 && side3 > 0 &&
               side1 + side2 > side3 &&
               side1 + side3 > side2 &&
               side2 + side3 > side1;
    }

    private void ValidateSide(int side)
    {
        if (side <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(side), "Triangle side length must be positive");
        }
    }
}

// Task1
// Task2

class FacultyDayEventArgs : EventArgs
{
    public string EventName { get; set; }

    public FacultyDayEventArgs(string eventName)
    {
        EventName = eventName;
    }
}

class Faculty
{
    public event EventHandler<FacultyDayEventArgs> FacultyDay;
    public event EventHandler<FacultyDayEventArgs> StudentDay;
    public event EventHandler<FacultyDayEventArgs> TeacherDay; // Нова подія для "Дня викладача"
    public event EventHandler<FacultyDayEventArgs> SportsDay; // Нова подія для "Дня спорту"

    public void CelebrateFacultyDay()
    {
        Console.WriteLine("Faculty Day is being celebrated!");
        OnFacultyDay(new FacultyDayEventArgs("Faculty Day"));
    }

    public void CelebrateStudentDay()
    {
        Console.WriteLine("Student Day is being celebrated!");
        OnStudentDay(new FacultyDayEventArgs("Student Day"));
    }

    public void CelebrateTeacherDay()
    {
        Console.WriteLine("Teacher Day is being celebrated!");
        OnTeacherDay(new FacultyDayEventArgs("Teacher Day"));
    }

    public void CelebrateSportsDay()
    {
        Console.WriteLine("Sports Day is being celebrated!");
        OnSportsDay(new FacultyDayEventArgs("Sports Day"));
    }

    protected virtual void OnFacultyDay(FacultyDayEventArgs e)
    {
        FacultyDay?.Invoke(this, e);
    }

    protected virtual void OnStudentDay(FacultyDayEventArgs e)
    {
        StudentDay?.Invoke(this, e);
    }

    protected virtual void OnTeacherDay(FacultyDayEventArgs e)
    {
        TeacherDay?.Invoke(this, e);
    }

    protected virtual void OnSportsDay(FacultyDayEventArgs e)
    {
        SportsDay?.Invoke(this, e);
    }
}

class Student
{
    public Student(Faculty faculty) // Підписка на кожну подію
    {
        faculty.FacultyDay += Faculty_FacultyDay;
        faculty.StudentDay += Faculty_StudentDay;
        faculty.TeacherDay += Faculty_TeacherDay;
        faculty.SportsDay += Faculty_SportsDay;
    }

    private void Faculty_FacultyDay(object sender, FacultyDayEventArgs e)
    {
        Console.WriteLine($"Student is celebrating {e.EventName}!");
    }

    private void Faculty_StudentDay(object sender, FacultyDayEventArgs e)
    {
        Console.WriteLine($"Student is celebrating {e.EventName}!");
    }

    private void Faculty_TeacherDay(object sender, FacultyDayEventArgs e)
    {
        Console.WriteLine($"Student is celebrating {e.EventName}!");
    }

    private void Faculty_SportsDay(object sender, FacultyDayEventArgs e)
    {
        Console.WriteLine($"Student is celebrating {e.EventName}!");
    }
}

// Task2

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter task: ");
        string? str = Console.ReadLine();
        int n = 0;
        if (str != null) n = int.Parse(str);
        // Task1
        if (n == 1)
        {
            try
            {
                Triangle invalidTriangle = new Triangle(3, 4, 8);
            }
            catch (InvalidTriangleException ex)
            {
                Console.WriteLine($"InvalidTriangleException caught: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        // Task1
        // Task2
        else if (n == 2)
        {
            Faculty faculty = new Faculty();

            Student student = new Student(faculty);
            Student student2 = new Student(faculty);
            Student student3 = new Student(faculty);
            Student student4 = new Student(faculty);
            Student student5 = new Student(faculty);

            faculty.CelebrateFacultyDay();
            faculty.CelebrateStudentDay();
            faculty.CelebrateTeacherDay();
            faculty.CelebrateSportsDay();
        }
        // Task2
    }
}