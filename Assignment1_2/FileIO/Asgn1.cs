using System.Collections;
using System.Diagnostics;
using System.Runtime.Serialization.Formatters.Binary;

namespace FileIO
{
    internal class Asgn1
    {
        static void Main(string[] args)
        {
            #region FileWriter

           /* string path = @"C:\Users\Pavan\OneDrive\Desktop\Test\test.txt";
             FileStream fs = null;

             if (File.Exists(path))
             {
                 fs = new FileStream(path, FileMode.Append, FileAccess.Write);
             }
             else
             {
                 fs = new FileStream(path, FileMode.Create, FileAccess.Write);

             }

             StreamWriter streamWriter = new StreamWriter(fs);
             String data = Console.ReadLine();

             streamWriter.WriteLine(data);

             streamWriter.Close();
             fs.Close();*/

             #endregion


             #region FileReader
           /*  FileStream fileStream = new FileStream(@"C:\Users\akhil\OneDrive\Desktop\Test\test.txt", FileMode.Open, FileAccess.Read);

             StreamReader streamReader = new StreamReader(fileStream);

             String allData = streamReader.ReadToEnd();

             Console.WriteLine(allData);

             streamReader.Close();
             fileStream.Close();*/
            #endregion

            #region read From File
            /*FileStream fStream = new FileStream(@"C:\Users\akhil\OneDrive\Desktop\Test\test.txt", FileMode.Open, FileAccess.Read);

            StreamReader sReader = new StreamReader(fStream);
            String line = null;
            while ((line=sReader.ReadLine())!=null)
            {

                FileStream fS = new FileStream(@"C:\Users\akhil\OneDrive\Desktop\Test\output.html", FileMode.Append, FileAccess.Write);

                StreamWriter sWriter = new StreamWriter(fS); 

                switch (line)
            {
                case "a":
                    sWriter.WriteLine("<h1>Pavan Welcomes You</h1>");
                    break;

                case "b":
                    sWriter.WriteLine("<h2>Pavan Welcomes You</h2>");
                    break;

                case "c":
                    sWriter.WriteLine("<h3>Pavan Welcomes You</h3>");
                    break;

                case "d":
                    sWriter.WriteLine("<h4>Pavan Welcomes You</h4>");
                    break;

            }
               
                sWriter.Close();
                fS.Close();
            }
            sReader.Close();
                fStream.Close();*/
            #endregion

            ArrayList objectList = new ArrayList();

            while (true)
            {
                Console.WriteLine("Enter '1' to add an Emp or '2' to add a Book (Press any other key to exit):");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    Emp emp = new Emp();

                    Console.WriteLine("Enter Emp No:");
                    emp.No = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Enter Emp Name:");
                    emp.Name = Console.ReadLine();

                    Console.WriteLine("Enter Emp Address:");
                    emp.Address = Console.ReadLine();

                    objectList.Add(emp);
                }
                else if (choice == "2")
                {
                    Book book = new Book();

                    Console.WriteLine("Enter Book ISBN:");
                    book.ISBN = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Enter Book Title:");
                    book.Title = Console.ReadLine();

                    Console.WriteLine("Enter Book Author:");
                    book.Author = Console.ReadLine();

                    Console.WriteLine("Enter Book Price:");
                    book.Price = Convert.ToInt32(Console.ReadLine());

                    objectList.Add(book);
                }
                else
                {
                    break;
                }
            }

            string path = @"C:\Users\akhil\OneDrive\Desktop\Test\objects.bin";
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(fs, objectList);
            fs.Close();

            FileStream fsRead = new FileStream(path, FileMode.Open, FileAccess.Read);
            ArrayList deserializedList = (ArrayList)binaryFormatter.Deserialize(fsRead);
            fsRead.Close();

            foreach (var obj in deserializedList)
            {
                if (obj is Emp)
                {
                    Emp deserializedEmp = (Emp)obj;
                    Console.WriteLine($"Emp: No - {deserializedEmp.No}, Name - {deserializedEmp.Name}, Address - {deserializedEmp.Address}");
                }
                else if (obj is Book)
                {
                    Book deserializedBook = (Book)obj;
                    Console.WriteLine($"Book: ISBN - {deserializedBook.ISBN}, Title - {deserializedBook.Title}, Author - {deserializedBook.Author}, Price - {deserializedBook.Price}");
                }
            }
        }
    }

    [Serializable]
    public class Emp
    {
        public int No { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }

    [Serializable]
    class Book
    {
        public int ISBN { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
    }
}