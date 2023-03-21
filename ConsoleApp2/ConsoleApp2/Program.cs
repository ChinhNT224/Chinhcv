using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDay { get; set; }
        public string Class { get; set; }
        public double Mark1 { get; set; }
        public double Mark2 { get; set; }
        public double Mark3 { get; set; }
        public double Mark_AVG()
        {
            return (Mark1 + Mark2 + Mark3)/3;
        }
    }
    namespace TestStudent
    {
        class TestStudent
        {
            private List<Student> ListStudent = null;

            public TestStudent()
            {
                ListStudent = new List<Student>();
            }
            private int GenerateID()
            {
                int max = 1;
                if (ListStudent != null && ListStudent.Count > 0)
                {
                    max = ListStudent[0].ID;
                    foreach (Student s in ListStudent)
                    {
                        if (max < s.ID)
                        {
                            max = s.ID;
                        }
                    }
                    max++;
                }
                return max;
            }

            public int SoLuongStudent()
            {
                int Count = 0;
                if (ListStudent != null)
                {
                    Count = ListStudent.Count;
                }
                return Count;
            }

            public void Nhap()
            {
                Student s = new Student();
                s.ID = GenerateID();
                Console.Write("Nhap ten sinh vien: ");
                s.Name = Convert.ToString(Console.ReadLine());

                Console.Write("Nhap gioi tinh sinh vien: ");
                s.Gender = Convert.ToString(Console.ReadLine());

                Console.Write("Nhap tuoi sinh vien: ");
                s.Age = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Nhap ngay sinh sinh vien: ");
                s.BirthDay = Convert.ToDateTime(Console.ReadLine());

                Console.Write("Nhap lop sinh vien: ");
                s.Class = Convert.ToString(Console.ReadLine());

                Console.Write("Nhap diem 1: ");
                s.Mark1 = Convert.ToDouble(Console.ReadLine());

                Console.Write("Nhap diem 2: ");
                s.Mark2 = Convert.ToDouble(Console.ReadLine());

                Console.Write("Nhap diem 3: ");
                s.Mark3 = Convert.ToDouble(Console.ReadLine());

                ListStudent.Add(s);
            }


            public void SortByAVG()
            {
                ListStudent.Sort(delegate (Student s1, Student s2) 
                {
                    return s1.Mark_AVG().CompareTo(s2.Mark_AVG());
                });
            }

            public void SortByID()
            {
                ListStudent.Sort(delegate (Student s1, Student s2)
                {
                    return s1.ID.CompareTo(s2.ID);
                });
            }
            public void SortByName()
            {
                ListStudent.Sort(delegate (Student s1, Student s2)
                {
                    return s1.Name.CompareTo(s2.Name);
                });
            }

            public Student FindByID(int ID)
            {
                Student searchResult = null;
                if (ListStudent != null && ListStudent.Count > 0)
                {
                    foreach (Student s in ListStudent)
                    {
                        if (s.ID == ID)
                        {
                            searchResult = s;
                        }
                    }
                }
                return searchResult;
            }

            public List<Student> FindByName(String keyword)
            {
                List<Student> searchResult = new List<Student>();
                if (ListStudent != null && ListStudent.Count > 0)
                {
                    foreach (Student s in ListStudent)
                    {
                        if (s.Name.ToUpper().Contains(keyword.ToUpper()))
                        {
                            searchResult.Add(s);
                        }
                    }
                }
                return searchResult;
            }

            public bool DeleteById(int ID)
            {
                bool IsDeleted = false;
                Student s = FindByID(ID);
                if (s != null)
                {
                    IsDeleted = ListStudent.Remove(s);
                }
                return IsDeleted;
            }


            public void ShowStudent(List<Student> listSV)
            {
                Console.WriteLine("{0, -5} {1, -20} {2, -5} {3, 5} {4, -20} {5, 5} {6, 5} {7, 5} {8, 5}",
                      "ID", "Name", "Gender", "Age", "Date of birth", "Class", "Mark1", "Mark2", "Mark3");
                if (listSV != null && listSV.Count > 0)
                {
                    foreach (Student s in listSV)
                    {
                        Console.WriteLine("{0, -5} {1, -20} {2, -5} {3, 5} {4, -20} {5, 5} {6, 5} {7, 5} {8, 5}",
                                          s.ID, s.Name, s.Gender, s.Age, s.BirthDay, s.Class, s.Mark1, s.Mark2, s.Mark3);
                    }
                }
                Console.WriteLine();
            }

            public List<Student> getListStudent()
            {
                return ListStudent;
            }
        }
    }
    namespace TestStudent
    {
        class Program
        {
            static void Main(string[] args)
            {
                TestStudent testStudent = new TestStudent();

                while (true)
                {
                    Console.WriteLine("==========================================================");
                    Console.WriteLine("**  1. Input information (input details for a student).");
                    Console.WriteLine("**  2. Sorting student asccending by average mark.");
                    Console.WriteLine("**  3. Display all the student.");
                    Console.WriteLine("**  4. Search Student by Name");
                    Console.WriteLine("**  5. Delete Student by student ID.");
                    Console.WriteLine("**  6. Exit program.");
                    Console.WriteLine("==========================================================");
                    Console.Write("Option: ");
                    int key = Convert.ToInt32(Console.ReadLine());
                    switch (key)
                    {
                        case 1:
                            Console.WriteLine("\n 1. Input information (input details for a student).");
                            testStudent.Nhap();
                            break;
                        case 2:
                            if (testStudent.SoLuongStudent() > 0)
                            {
                                Console.WriteLine("\n 2. Sorting student asccending by average mark. ");
                                testStudent.SortByAVG();
                                testStudent.ShowStudent(testStudent.getListStudent());
                            }
                            else
                            {
                                Console.WriteLine("\n NULL!");
                            }
                            break;
                        case 3:
                            if (testStudent.SoLuongStudent() > 0)
                            {
                                Console.WriteLine("\n 3. Display all the student.");
                                testStudent.ShowStudent(testStudent.getListStudent());
                            }
                            else
                            {
                                Console.WriteLine("\n NULL!");
                            }
                            break;
                        case 4:
                            if (testStudent.SoLuongStudent() > 0)
                            {
                                Console.WriteLine("\n 4. Search Student by Name");
                                Console.Write("\n Name: ");
                                string name = Convert.ToString(Console.ReadLine());
                                List<Student> searchResult = testStudent.FindByName(name);
                                testStudent.ShowStudent(searchResult);
                            }
                            else
                            {
                                Console.WriteLine("\n NULL!");
                            }
                            break;
                        case 5:
                            if (testStudent.SoLuongStudent() > 0)
                            {
                                int id;
                                Console.WriteLine("\n 5. Delete Student by student ID.");
                                Console.Write("\n ID: ");
                                id = Convert.ToInt32(Console.ReadLine());
                                if (testStudent.DeleteById(id))
                                {
                                    Console.WriteLine("\n DELETE", id);
                                }
                            }
                            else
                            {
                                Console.WriteLine("\n NULL!");
                            }
                            break;
                        case 6:
                            Console.WriteLine("\n EXIT!");
                            return;
                        default:
                            Console.WriteLine("\n NULL!");
                            Console.WriteLine("\n Option 1-6");
                            break;
                    }
                }
            }
        }
    }
}

