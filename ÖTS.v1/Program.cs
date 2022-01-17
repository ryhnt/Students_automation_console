using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ÖTS.v1
{
    internal class Program
    {
        private static int idx;

        static void Main(string[] args)
        {
            string vs_SystemName = "Öğrenci Yönetim Sistemi v1.0 _ © 2021 UCC Software";

            // Öncelikle sisteme giriş için yetkili olan kişiler çok basit bilgilerle (Ad Soyad UID Password)
            // bir variable değişgene (arrUsers) atanıyor. Bunun için bu yapıya uygun bir class yazıldı (Users) yazıldı ve public
            // tanımlandı ki dışarıdan bu sınıfın özelliklerine erişilebilsin.

            var arrUsers = new Users[]
            {
                new Users("Ümit","Karaçivi","umit.k","123"),
                new Users("Buse","Alkan","buse.a","123"),
                new Users("Tuğcan","Ergün","tugcan.e","123"),
                new Users("Reyhan","Taşdemir","reyhan.t","123"),
                new Users("Ece","Dinçer","ece.d","123"),
                new Users("Meryem Can","Doğan","meryemc.d","123"),
                new Users("Enes","Ünsür","enes.u","123"),
                new Users("Hümeyra Betül","Akgül","humeyrab.a","123"),
                new Users("Hayri","Öztürk","hayri.o","123"),
                new Users("Burak","İnce","burak.i","123"),
                new Users("Adem","Şimşek","adem.s","123"),
                new Users("Kerem","Bilgiç","kerem.b","123"),
                new Users("Demet","Bayrak","demet.b","123"),
                new Users("Osman","Sivrikaya","osman.s","123"),
                new Users("Mustafa","Gedik","mustafa.g","123"),
                new Users("Özgün","Erbudak","ozgun.e","123")
            };

            // Sisteme giriş başarılı mı/başarısız mı sonucunu tutan boolean değişgen tanımlandı.
            bool LoginSuccess = false;

            // Login kısmı
            Login:
            while (!LoginSuccess)
            {
                Console.Clear();
                Console.Title = vs_SystemName;

                Console.WriteLine("Kullanıcı adınız : ");
                var username = Console.ReadLine();

                Console.WriteLine("Kullanıcı şifreniz : ");
                var password = Console.ReadLine();

                int UserIndex=0;

                foreach (Users user in arrUsers)
                {


                    if (username == user.Username && password == user.Password)
                    {
                        LoginSuccess = true;
                        idx = UserIndex;
                        break;
                    }
                    else
                    {
                        LoginSuccess = false;
                    }

                    UserIndex++;
                }

                if (LoginSuccess)
                {
                    Console.WriteLine("Sisteme başarılı olarak girdiniz !!!..Menü için bir tuşa basınız...");
                    Console.ReadLine();
                    goto Start;
                }
                else
                {
                    Console.WriteLine("Bilgilerde hata var ..Kontrol ediniz !!!");
                    Console.ReadLine();
                    goto Login;
                }
            }

            // Programın menüsünün geldiği yer
        Start:
            StdClass stdClass = new StdClass(); // Öncelikle bir StdClass isminde bir sınıftan bir değişgen tanımlandı

            string vc_Choice; // Ekrandan hangi seçeneğin seçildiğini tutan değişgen

            Console.Clear();
            Console.Title = vs_SystemName + " - Kullanıcı : " + arrUsers[idx].UserFName + " " +arrUsers[idx].UserLName;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("========  MENÜ ========");
            Console.WriteLine("");
            Console.WriteLine("1 - Öğrenci Ekle");
            Console.WriteLine("");
            Console.WriteLine("2 - Öğrenci Bilgi Değişikliği");
            Console.WriteLine("");
            Console.WriteLine("3 - Bütün Öğrencileri Listele");
            Console.WriteLine("");
            Console.WriteLine("4 - Bütün Öğrencileri Cinsiyetlerine Göre Dağılımlarını Listele");
            Console.WriteLine("_________________________________________________________________");
            Console.WriteLine("");

            do // 0 tuşuna basılana kadar
            {
                Console.WriteLine("Seçiminiz..(Çıkmak için 0 seçiniz)");
                vc_Choice = Console.ReadLine();

                switch (vc_Choice)
                {
                    case "1":
                        AddStudent(stdClass);
                        break;
                    case "2":
                        // Bu bölüm sonraya bırakıldı.
                        //UpdateStudent(stdClass);
                        break;
                    case "3":
                        ListStudent(stdClass);
                        break;
                    case "4":
                        ListStudentbyGender(stdClass);
                        break;
                    case "0":
                        Environment.Exit(0); // Program çıkış
                        break;

                }

            } while (vc_Choice != "0");
        }
        

        #region Öğrenci ekleme
        // StdClass sınıfı bu kısma parametre olarak gönderiliyor ki StdClass altındaki liste üzerinde işlem yapabileyim
        private static void AddStudent(StdClass stdClass)
        {
            // Öncelikle ilerleyen satırlarda Student class içeriğini kullanacağım için o ayağa kaldırılıyorList olarak tuut
            Student student = new Student();

            Console.Write("Öğrencinin Numarası: ");
            student.StudentNo = Convert.ToInt32(Console.ReadLine());

            Console.Write("Öğrencinin Adı: ");
            student.StudentFName = Console.ReadLine();

            Console.Write("Öğrencinin Soyadı: ");
            student.StudentLName = Console.ReadLine();

            Console.Write("Öğrencinin Sınıfı (A/B/C/D): ");
            student.StudentClass = Convert.ToChar(Console.ReadLine());

            Console.Write("Öğrencinin Doğum Tarihi: ");
            student.StudentBirthDate = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Öğrencinin Cinsiyeti (E/K): ");
            student.StudentGender = Convert.ToChar(Console.ReadLine());

            // StdClass sınıfı altındaki List olarak tuttuğum Listeye öğrenci ekleniyor.
            stdClass.StudentList.Add(student);

            Console.WriteLine(student.StudentNo + " nolu öğrencinin bilgileri sisteme girilmiştir.");
        }

        #endregion

        #region Öğrenci Bilgisi Güncelleme
        private static void UpdateStudent(StdClass stdClass)
        {
            // Bu kısım daha sonraya bırakıldı.
            // Öncelikle öğrenci listesini ekrana getirme

            //ListStudent();

            //Console.WriteLine("");
            //Console.WriteLine("");
            //Console.WriteLine("Bilgisi değiştirilecek öğrencinin numarasını giriniz..");

        }

        #endregion

        #region Öğrencilerin listesini alma
        static void ListStudent(StdClass stdClass)
        {
            // Direkt olarak StdClass altındaki StudenList metodu çağrılıyor (1. yapı ...Parametresiz)
            stdClass.ListStudent();
        }

        #endregion

        #region Öğrencilerin listesini cinsiyete göre alma
        static void ListStudentbyGender(StdClass stdClass)
        {
            Console.Write("Listelemek istediğiniz cinsiyeti girin (K/E)");

            string gender = Console.ReadLine();

            // Polymorphism özelliğinden faydalanılarak aynı isimdeki metod bu sefer parametreli yapıyla çağırılıyor.
            stdClass.ListStudent(gender);

        }

        #endregion


    }
}
