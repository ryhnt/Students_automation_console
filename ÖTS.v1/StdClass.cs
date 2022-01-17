using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ÖTS.v1
{
    class StdClass
    {
        // Öğrenci bilgilerini tutacak olan liste
        public List<Student> StudentList = new List<Student>();

        //Üzerine parametre gönderilerek StudentList'den, gelen parametreye göre ilgili öğrenciyi getirme
        public Student GetStudent(int pStudentNo)
        {
            for (int listindex = 0; listindex < StudentList.Count; listindex++)
            {
                if (StudentList[listindex].StudentNo == pStudentNo)
                {
                    return StudentList[listindex];
                }
            }
            return null;
        }

        //Tüm öğrencileri listeleyen metot
        public void ListStudent()
        {

            Console.WriteLine("Şube   No     Adı Soyadı       	 Doğ.Tar.     Cinsiyet");
            Console.WriteLine("----  -----  ----------------  	----------    --------");

            foreach (var item in StudentList)
            {
                Console.WriteLine("{0}  {1}     {2}     {3}     {4}", 
                    item.StudentClass, 
                    item.StudentNo, 
                    (item.StudentFName + " " + item.StudentLName), 
                    item.StudentBirthDate,
                    item.StudentGender);
            }
        }

        // Üzerine gelen parametreye göre(E/K) bunları listeden seçen ve yazdıran metot
        public void ListStudent(string pGender) // Polymorphism
        {

            Console.WriteLine("Şube   No     Adı Soyadı       	 Doğ.Tar.     Cinsiyet");
            Console.WriteLine("----  -----  ----------------  	----------    --------");

            foreach (var item in StudentList)
            {

                if (Convert.ToString(item.StudentGender) == pGender)
                {
                    Console.WriteLine("{0}  {1}     {2}     {3}     {4}",
                        item.StudentClass,
                        item.StudentNo,
                        (item.StudentFName + " " + item.StudentLName),
                        item.StudentBirthDate,
                        item.StudentGender);
                }

            }
        }

    }
}
