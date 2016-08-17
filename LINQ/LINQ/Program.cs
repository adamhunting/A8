using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    class Program
    {
        // Create a data source by using a collection initializer.
        static List<Student> students = new List<Student>
    {
       new Student {First="Svetlana", Last="Omelchenko", ID=111, Scores= new List<int> {97, 92, 81, 60}},
       new Student {First="Claire", Last="O'Donnell", ID=112, Scores= new List<int> {75, 84, 91, 39}},
       new Student {First="Sven", Last="Mortensen", ID=113, Scores= new List<int> {88, 94, 65, 91}},
       new Student {First="Cesar", Last="Garcia", ID=114, Scores= new List<int> {97, 89, 85, 82}},
       new Student {First="Debra", Last="Garcia", ID=115, Scores= new List<int> {35, 72, 91, 70}},
       new Student {First="Fadi", Last="Fakhouri", ID=116, Scores= new List<int> {99, 86, 90, 94}},
       new Student {First="Hanying", Last="Feng", ID=117, Scores= new List<int> {93, 92, 80, 87}},
       new Student {First="Hugo", Last="Garcia", ID=118, Scores= new List<int> {92, 90, 83, 78}},
       new Student {First="Lance", Last="Tucker", ID=119, Scores= new List<int> {68, 79, 88, 92}},
       new Student {First="Terry", Last="Adams", ID=120, Scores= new List<int> {99, 82, 81, 79}},
       new Student {First="Eugene", Last="Zabokritski", ID=121, Scores= new List<int> {96, 85, 91, 60}},
       new Student {First="Michael", Last="Tucker", ID=122, Scores= new List<int> {94, 92, 91, 91} }
    };

        static void Main(string[] args)
        {
            students.ListStudents();
            LastNameIsGarica(students);
            FirstNameStartWithH(students);
            FirstNameAlphabetical(students);
            FirstNameFirstOrDefalut(students);
            GroupingByFirstName(students);
            StudentAverageTestScore(students);
            TestAverage(students);
        }


        //Q02
        public static void LastNameIsGarica(List<Student> student)
        {
            var lastNameIsGarica = student.Where(e => e.Last == "Garcia");
            Console.WriteLine();
            (lastNameIsGarica.ToList()).ListStudents();
        }

        //Q03
        public static void FirstNameStartWithH(List<Student> student)
        {
            var firstNameStartsWithH = from s in student where s.First.StartsWith("H") select s;
            Console.WriteLine();
            firstNameStartsWithH.ToList().ListStudents();
        }

        //Q04
        public static void FirstNameAlphabetical(List<Student> student)
        {
            var firstNameAlphabetical = student.OrderBy(s => s.First);
            Console.WriteLine();
            firstNameAlphabetical.ToList().ListStudents();
        }

        //Q06
        public static void FirstNameFirstOrDefalut(List<Student> student)
        {
            var firstNameAlphabetical = student.OrderBy(s => s.First);
            var firstStudentFirstName = firstNameAlphabetical.FirstOrDefault();
            Console.WriteLine();
            Console.WriteLine(firstStudentFirstName.ToString());
        }

        //Q08
        public static void GroupingByFirstName(List<Student> student)
        {
            var studentInGroupByFirstName = from s in student group s by s.First[0];
            Console.WriteLine();
        //Q10
            foreach (var studentgroups in studentInGroupByFirstName)
            {
                Console.WriteLine(studentgroups.Key);
                foreach (Student s in studentgroups)
                {
                    Console.WriteLine(" {0} {1}", s.First, s.Last);
                }
            }
        }

        //Q12
        public static void StudentAverageTestScore(List<Student> student)
        {
            Console.WriteLine();
            foreach (var s in student)
            {
                Console.WriteLine(" {0} {1} Test AVG: {2}", s.Last, s.First, s.Scores.Average());
            }
        }

        //Q13
        public static void TestAverage(List<Student> student)
        {
            var scoresCount = student.First().Scores.Count;
            Console.WriteLine();
            var avgScoreByTest = Enumerable.Range(0, scoresCount).Select(i => student.Average(s => s.Scores[i]));
            var displayValues = avgScoreByTest.Select(t => String.Format("Test Avg: {0:0.00}", t));
            var output = string.Join(Environment.NewLine, displayValues);
            Console.WriteLine(output);
        }

    }

    public class Student
    {
        public string First { get; set; }
        public string Last { get; set; }
        public int ID { get; set; }
        public List<int> Scores;


        public override string ToString()
        {
            return $"Fist: {First}, Last: {Last}, ID: {ID}";
        }
    }

    public static class Extension
    {
        //Q01
        public static void ListStudents(this List<Student> student)
        {
            foreach (var x in student)
            {
                Console.WriteLine(x.ToString());
            }
        }

    }

}
