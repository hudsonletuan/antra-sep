namespace _03OOP;

// Interfaces
public interface IPersonService
{
    int CalculateAge();
    decimal CalculateSalary();
}

public interface IStudentService : IPersonService
{
    void EnrollInCourse(Course course);
    double CalculateGPA();
}

public interface IInstructorService : IPersonService
{
    decimal CalculateBonusSalary();
}

public interface ICourseService
{
    void EnrollStudent(Student student);
}

// Person Class
public abstract class Person : IPersonService
{
    private string name;
    private DateTime dateOfBirth;
    private decimal salary;
    private List<string> addresses;

    public Person(string name, DateTime dateOfBirth)
    {
        this.name = name;
        this.dateOfBirth = dateOfBirth;
        this.addresses = new List<string>();
    }

    public void AddAddress(string address)
    {
        addresses.Add(address);
    }

    public List<string> GetAddresses()
    {
        return addresses;
    }

    public int CalculateAge()
    {
        return DateTime.Now.Year - dateOfBirth.Year;
    }

    public virtual decimal CalculateSalary()
    {
        return salary < 0 ? 0 : salary;
    }

    protected void SetSalary(decimal value)
    {
        if (value >= 0)
            salary = value;
        else
            throw new ArgumentException("Salary cannot be negative");
    }
}

// Instructor Class
public class Instructor : Person, IInstructorService
{
    private string department;
    private DateTime joinDate;

    public Instructor(string name, DateTime dateOfBirth, string department, DateTime joinDate) 
        : base(name, dateOfBirth)
    {
        this.department = department;
        this.joinDate = joinDate;
        SetSalary(50000);
    }

    public override decimal CalculateSalary()
    {
        return base.CalculateSalary() + CalculateBonusSalary();
    }

    public decimal CalculateBonusSalary()
    {
        int yearsOfExperience = DateTime.Now.Year - joinDate.Year;
        return yearsOfExperience * 1000;
    }
}

// Student Class
public class Student : Person, IStudentService
{
    private List<Course> courses;

    public Student(string name, DateTime dateOfBirth) 
        : base(name, dateOfBirth)
    {
        courses = new List<Course>();
        SetSalary(0);
    }

    public void EnrollInCourse(Course course)
    {
        courses.Add(course);
        course.EnrollStudent(this);
    }

    public double CalculateGPA()
    {
        double totalPoints = 0;
        int totalCourses = courses.Count;

        foreach (var course in courses)
        {
            totalPoints += course.GetGrade(this);
        }

        return totalCourses > 0 ? totalPoints / totalCourses : 0.0;
    }
}

// Course Class
public class Course : ICourseService
{
    private List<Student> enrolledStudents;
    
    public Course()
    {
        enrolledStudents = new List<Student>();
    }

    public void EnrollStudent(Student student)
    {
        enrolledStudents.Add(student);
    }

   private Dictionary<Student, char> grades = new Dictionary<Student, char>();

   public void AssignGrade(Student student, char grade)
   {
       grades[student] = grade;
   }

   public double GetGrade(Student student)
   {
       if (grades.TryGetValue(student, out char grade))
       {
           switch (grade)
           {
               case 'A': return 4.0;
               case 'B': return 3.0;
               case 'C': return 2.0;
               case 'D': return 1.0;
               case 'F': return 0.0;
               default: return 0.0;
           }
       }
       return 0.0;
   }
}

// Department Class
public class Department
{
   private string name;
   private Instructor headInstructor;
   private decimal budget;

   public Department(string name, Instructor headInstructor, decimal budget)
   {
       this.name = name;
       this.headInstructor = headInstructor;
       this.budget = budget;
   }

   public Instructor HeadInstructor => headInstructor;

   public decimal Budget => budget;
}

public class BuildingClasses
{
    public static void Build(string[] args)
    {
        Instructor instructor = new Instructor("John Doe", new DateTime(1985, 5, 15), "Computer Science", new DateTime(2015, 8, 1));
        Student student = new Student("Jane Smith", new DateTime(2002, 3, 10));

        Course course1 = new Course();
        course1.AssignGrade(student, 'A');

        student.EnrollInCourse(course1);

        Department csDepartment = new Department("Computer Science", instructor, 100000);

        Console.WriteLine($"Instructor: {instructor.CalculateAge()} years old with salary: {instructor.CalculateSalary()}");
        Console.WriteLine($"Student: {student.CalculateAge()} years old with GPA: {student.CalculateGPA()}");
    }
}