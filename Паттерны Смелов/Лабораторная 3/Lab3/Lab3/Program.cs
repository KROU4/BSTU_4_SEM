using Lec03BLibN;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("Лабораторная работа # 3");
            IFactory l1 = Lec03BLib.getL1();                                                    // фабрика 1

            Employee employee1 = new(                                                           // 1-а
                l1.getA(25)); // стоимость 1 часа           

            Console.WriteLine(string.Format("Bonus-L1-A = {0}", employee1.calcBonus(4)));

            Employee employee2 = new(                                                           // 1-b
                l1.getB(25, // стоимость 1 часа
                1.1f)); // повышающий/понижающий коэффициент                         

            Console.WriteLine(string.Format("Bonus-L1-B = {0}", employee2.calcBonus(4)));

            Employee employee3 = new(                                                           // 1-c
                l1.getC(25,  // стоимость 1 часа
                1.1f,  // повышающий/понижающий коэффициент         
                5.0f)); // величина снижения/повышения           

            Console.WriteLine(string.Format("Bonus-L1-C = {0}", employee3.calcBonus(4)));

            IFactory l2 = Lec03BLib.getL2(                                                      // фабрика 2
                1);  // величина снижения/повышения отработанных часов

            Employee employee4 = new(                                                           // 2-a
                l2.getA(25));  // стоимость 1 часа             

            Console.WriteLine(string.Format("Bonus-L2-A = {0}", employee4.calcBonus(4)));

            Employee employee5 = new(                                                           // 2-b
                l2.getB(25, // стоимость 1 часа       
                1.1f));   // повышающий/понижающий коэффициент                              

            Console.WriteLine(string.Format("Bonus-L2-B = {0}", employee5.calcBonus(4)));

            Employee employee6 = new(                                                           // 2-c
                l2.getC(25, // стоимость 1 часа    
                1.1f, // повышающий/понижающий коэффициент   
                5.0f));  // величина снижения/повышения                 

            Console.WriteLine(string.Format("Bonus-L2-C = {0}", employee6.calcBonus(4)));

            Employee employee62 = new(                                                           // 2-d
                    l2.getD(25, // стоимость 1 часа    
                    1.1f, // повышающий/понижающий коэффициент   
                    5.0f, // величина снижения/повышения   
                    2.4f));

            Console.WriteLine(string.Format("Bonus-L2-D = {0}", employee62.calcBonus(4)));


            IFactory l3 = Lec03BLib.getL3(                                                      // фабрика 3
                1, // величина снижения/повышения отработанных часов
                0.5f); // величина снижения/повышения стоимости 1 часа                                             

            Employee employee7 = new(                                                           // 3-a
                l3.getA(25)); // стоимость 1 часа         

            Console.WriteLine(string.Format("Bonus-L3-A = {0}", employee7.calcBonus(4)));

            Employee employee8 = new(                                                           // 3-b
                l3.getB(25, // стоимость 1 часа
                1.1f)); // повышающий/понижающий коэффициент                                      

            Console.WriteLine(string.Format("Bonus-L3-B = {0}", employee8.calcBonus(4)));

            Employee employee9 = new(                                                           // 3-c
                l3.getC(25, // стоимость 1 часа
                1.1f, // повышающий/понижающий коэффициент
                0.5f));   // величина снижения/повышения           

            Console.WriteLine(string.Format("Bonus-L3-C = {0}", employee9.calcBonus(4)));

            IFactory l4 = Lec03BLib.getL4(                                                      // фабрика 4
                1, // величина снижения/повышения отработанных часов
                0.5f, // величина снижения/повышения стоимости 1 часа
                2f);

            Employee employee10 = new(                                                           // 4-a
                l4.getA(25)); // стоимость 1 часа         

            Console.WriteLine(string.Format("Bonus-L4-A = {0}", employee10.calcBonus(4)));

            Employee employee11 = new(                                                           // 4-b
                l4.getB(25, // стоимость 1 часа
                1.1f)); // повышающий/понижающий коэффициент                                      

            Console.WriteLine(string.Format("Bonus-L4-B = {0}", employee11.calcBonus(4)));

            Employee employee12 = new(                                                           // 4-c
                l4.getC(25, // стоимость 1 часа
                1.1f, // повышающий/понижающий коэффициент
                0.5f));   // величина снижения/повышения           

            Console.WriteLine(string.Format("Bonus-L4-C = {0}", employee12.calcBonus(4)));
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}