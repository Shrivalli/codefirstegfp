using EfcoreEg.Models;

namespace EfcoreEg
{
    class Program
    {
        private static FisbankDbContext db=new FisbankDbContext();
        public static void Main()
        {
            //AddStudent();
            // DeleteData();
            // SelectData();
            System.Console.WriteLine("Enter the Department Id");
            int did=Convert.ToInt32(Console.ReadLine());
            ListOfEmployeesbasedonDepartment(did);
        }

        public static void ListOfEmployeesbasedonDepartment(int did)
        {
            var result=(from i in db.Employees
                        where i.Deptid==did
                        select i).ToList();
            string dname=(from i in db.Departments
                        where i.Did==did
                        select i.Dname).SingleOrDefault();
        System.Console.WriteLine("List of Employees working in "+dname);
            foreach(var item in result)
            {
                System.Console.WriteLine(item.Ename);
            }
        }

        public static void AddStudent()
        {
            Student s=new Student();
            System.Console.WriteLine("Enter Sname,Marks, Doj, Email and Subject");
            //s.Sid=Convert.ToInt32(Console.ReadLine());
            s.Sname=Console.ReadLine();
            s.Marks=Convert.ToInt32(Console.ReadLine());
            s.Doj=Convert.ToDateTime(Console.ReadLine());
            s.Email=Console.ReadLine();
            s.Subject=Console.ReadLine();
            db.Students.Add(s); //add the record to the context - frontend db
            db.SaveChanges(); //permenantly add the record to the db
            System.Console.WriteLine("Record Addded");
        }

        public static void DeleteData()
        {
            Student s=new Student();
            System.Console.WriteLine("Enter Sid");
            int Studentid=Convert.ToInt32(Console.ReadLine());
            s=db.Students.Where(x=>x.Sid==Studentid).SingleOrDefault();
            db.Students.Remove(s);
            db.SaveChanges();
            System.Console.WriteLine("Record Removed");

        }

        public static void SelectData()
        {
            foreach(var item in db.Students)
            {
                System.Console.WriteLine(item.Sid+" "+item.Sname+" "+item.Email);
            }
        }
    }
}