using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sorter
{
    public class Obj // основной класс объекта, обладающий свойством colour
    {
        private string _colour;
        public string Colour
        {
            get { return _colour; }
            set { _colour = value; }
        }

    }
    public class Cl1 : Obj // класс-наследник объекта, определяющий какие по цвету объекты будут идти первыми
    {
    }
    public class Cl2 : Obj // класс-наследник объекта, определяющий какие по цвету объекты будут идти вторыми
    {
    }
    public class Cl3 : Obj // класс-наследник объекта, определяющий какие по цвету объекты будут идти третьими
    { 
    }
    public class ColourComparer : IComparer<Obj> // метод сортировки объектов по цветам
    {
        static readonly Type[] priority = { typeof(Cl1), typeof(Cl2), typeof(Cl3) }; // здесь задается последовательность цветов 
        public int Compare(Obj o1, Obj o2)
        {
            if (ReferenceEquals(o1, o2)) return 0;
            if (ReferenceEquals(o1, null)) return 1;
            if (ReferenceEquals(o2, null)) return -1;

            int xOrder = Array.IndexOf(priority, o1.GetType());
            int yOrder = Array.IndexOf(priority, o2.GetType());

            if (xOrder == yOrder) return 0;
            if (xOrder == -1) return 1;
            if (yOrder == -1) return -1;

            return xOrder.CompareTo(yOrder);
        }
    }

    public class ConsoleReader // метод для ввода данных из консоли
    {
        public virtual string GetNextStr1()
        {
            return Console.ReadLine();
        }
        public virtual string GetNextStr2()
        {
            return Console.ReadLine();
        }
    }

    

    public class Inicial // метод инициализации для выбора правила последоватльности цветов
    {
        public void Mess()
        {
            Console.WriteLine("Выберите последовательность цветов (задайте соответствующую цифру):");
            Console.WriteLine("1 : Красный - Синий - Зеленый");
            Console.WriteLine("2 : Красный - Зеленый - Синий");
            Console.WriteLine("3 : Синий - Красный - Зеленый");
            Console.WriteLine("4 : Синий - Зеленый - Красный");
            Console.WriteLine("5 : Зеленый - Синий - Красный");
            Console.WriteLine("6 : Зеленый - Красный - Синий");
        }
       


        private static string c1;
        private static string c2;
        private static string c3;
        
        private static int ux;

        public int SetVar(string u) // функция для чтения задания из консоли
        {
            
            

                if (Int32.TryParse(u, out ux)) // проверка введенных данных (должны быть int)
                {
                    ux = Convert.ToInt32(u);
                }
                else
                {
                    Console.WriteLine("Неверный ввод!");
                }
                if (ux > 0 && ux < 7) // проверка введенных данных (должны быть от 1 до 6)
                {
                   
                }
               
                else
                {
                    Console.WriteLine("Нужно ввести цифру от 1 до 6!");
                    ux = 0;
                }
            
            return ux;

        }
        public (string, string, string) SortIni(int uv) // функция для выбора соответствующего правила
        {     

                if (uv == 1) // если пользователь ввел "1" вы бирается первое правило
                {
                    c1 = "Красный";
                    c2 = "Синий";
                    c3 = "Зеленый";
                }
                else if (uv == 2) // если пользователь ввел "2" вы бирается второе правило
            {
                    c1 = "Красный";
                    c2 = "Зеленый";
                    c3 = "Синий";
                }
                else if (uv == 3) // если пользователь ввел "3" вы бирается третье правило
            {
                    c1 = "Синий";
                    c2 = "Красный";
                    c3 = "Зеленый";
                } 
                else if (uv == 4) // если пользователь ввел "4" вы бирается четвертое правило
            {
                    c1 = "Синий";
                    c2 = "Зеленый";
                    c3 = "Красный";
                }
                else if (uv == 5) // если пользователь ввел "5" вы бирается пятое правило
            {
                    c1 = "Зеленый";
                    c2 = "Синий";
                    c3 = "Красный";
                }
                else if (uv == 6) // если пользователь ввел "6" вы бирается шестое правило
            {
                    c1 = "Зеленый";
                    c2 = "Красный";
                    c3 = "Синий";
                }
                else
                {
                    Console.WriteLine("Нужно ввести цифру от 1 до 6!");
                }
            
            return (c1, c2, c3); 
        }
 
    }
    public class GenObj // метод генерации объектов на входе
    {
        private string con1;
        public string NumIn;
        public (string,List<Obj>) genobj(string co1, string co2, string co3) // функция создает лист псевдо-рандомно раскрашенных объектов
        {
            Random rand = new Random(); // псевдо-рандом
            
            ConsoleReader CReaderNum = new ConsoleReader();
            
            Console.WriteLine("Сколько объектов на входе?");
            int on1 = 0;


            uint i = 0;
            while (on1 == 0)
            {
                con1 = CReaderNum.GetNextStr2(); // пользователь задает количество объектов в листе
                if (UInt32.TryParse(con1, out i))
                {
                    i = Convert.ToUInt32(con1);
                    on1 = 1;
                }
                else
                {
                    Console.WriteLine("Неверный ввод! Количество объектов задается целым положительным числом!");
                }
            }
            List<Obj> objectoList = new List<Obj>(); // функция генерирует новый массив (лист) объектов 
            
            for (int j = 0; j < i; j++) // лист объектов заполняется заданным количеством объектов
            {

                // каждому новому объекту листа присваивается случайный цвет:

                int k = rand.Next(100);
                float p = 100 / 3;
                float p2 = p * 2;
                if (k < p)
                {
                    objectoList.Add(new Cl1 { Colour = co1 }); 
                }
                else if (k > p && k < p2)
                {
                    objectoList.Add(new Cl2 { Colour = co2 });
                }
                else if (k > p2)
                {
                    objectoList.Add(new Cl3 { Colour = co3 });
                }
            }
            Console.WriteLine("Не отсортированный список:");
            foreach (Obj currObj in objectoList)
            {
                Console.WriteLine(currObj.Colour); // выводим массив несортированных объектов
            }
            NumIn = objectoList.Count.ToString();
            return (NumIn, objectoList);
        }
        
    }

    public class SorterMain // метод сортировки объектов по выбранному правилу
    {
        public string InList(List<Obj> list) // функция получает на вход несортированных лист объектов
        {
            ColourComparer CC = new ColourComparer(); // новая функция сортировки
            list.Sort(CC); // выполняется сортировка листа по функции сортировки
            Console.WriteLine("Отсортированный список:");
            foreach (Obj currObj in list)
            {
                Console.WriteLine(currObj.Colour); // выводим отсортированный массив объектов
            }
            string NumOut = list.Count.ToString();
            return NumOut;
        }
    }
    
    
    public class SortColour  // проверка работоспособности сортировщика
    {
        public static void Main()
        {
            //Тест 1: при выборе правила вводим 0
            try
            {
                Inicial test1 = new Inicial();
                int tu1 = test1.SetVar("0");
            }
            catch
            {
                Console.WriteLine("Тест 1 - Ошибка обработки!");
            }
            finally
            {
                Console.WriteLine("Тест 1 пройден");
            }

            //Тест 2: при выборе правила вводим 7
            try
            {
                Inicial test2 = new Inicial();
                int tu2 = test2.SetVar("7");
            }
            catch
            {
                Console.WriteLine("Тест 2 - Ошибка обработки!");
            }
            finally
            {
                Console.WriteLine("Тест 2 пройден");
            }

            //Тест 3: при выборе правила вводим "test"
            try
            {
                Inicial test3 = new Inicial();
                int tu3 = test3.SetVar("test");
            }
            catch
            {
                Console.WriteLine("Тест 3 - Ошибка обработки!");
            }
            finally
            {
                Console.WriteLine("Тест 3 пройден");
            }

            //Тест 4: при выборе правила вводим "'@#$%#!@#"
            try
            {
                Inicial test4 = new Inicial();
                int tu4 = test4.SetVar("'@#$%#!@#");
            }
            catch
            {
                Console.WriteLine("Тест 4 - Ошибка обработки!");
            }
            finally
            {
                Console.WriteLine("Тест 4 пройден");
            }
           
            
            Console.WriteLine("");

            // ручная проверка: 

            Inicial init1 = new Inicial(); 
            init1.Mess();
            ConsoleReader CReaderCol = new ConsoleReader();
            int uu = 0;

            while (uu == 0)
            {
                string u = CReaderCol.GetNextStr1(); // пользователь вводит данные
                uu = init1.SetVar(u);

            }
            (string oc1, string oc2, string oc3) = init1.SortIni(uu); // выводим последовательность цветов, в зависимости от выбранного правила

            Console.WriteLine(oc1);
            Console.WriteLine(oc2);
            Console.WriteLine(oc3);

        GenObj gen1 = new GenObj(); // создаем массив несоритрованных объектов
        List<Obj> oL1 = gen1.genobj(oc1, oc2, oc3).Item2; 

        SorterMain sort1 = new SorterMain();     // сортируем массив объеков
            sort1.InList(oL1);            
        }
    }
}