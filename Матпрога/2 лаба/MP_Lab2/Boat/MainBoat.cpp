#include <iostream>
#include <iomanip>
#include "Boat.h"
#include "Auxil.h"
#include <ctime>
#include <locale>
#define MM 5
#define NN 25

int wmain()
{
    setlocale(LC_ALL, "rus");
    int V = 1500,
        c[NN] = { 110, 15, 20, 125, 30,  25, 120, 144, 120, 25, 100,  25, 60, 55, 90, 125, 30, 35, 80, 47, 70, 45, 50, 95, 60};
    short  r[MM];
    int v[NN];
    auxil::start();     // старт генерации     
    for (int i = 0; i < NN; i++)
    {
        v[i]= auxil::iget(100, 900);
    }
    int cc = boat(
        V,   // [in]  максимальный вес груза
        MM,  // [in]  количество мест для контейнеров     
        NN,  // [in]  всего контейнеров  
        v,   // [in]  вес каждого контейнера  
        c,   // [in]  доход от перевозки каждого контейнера     
        r    // [out] результат: индексы выбранных контейнеров  
    );
    std::cout << std::endl << "- Задача о размещении контейнеров на судне";
    std::cout << std::endl << "- общее количество контейнеров    : " << NN;
    std::cout << std::endl << "- количество мест для контейнеров : " << MM;
    std::cout << std::endl << "- ограничение по суммарному весу  : " << V;
    std::cout << std::endl << "- вес контейнеров                 : ";
    for (int i = 0; i < NN; i++) std::cout << std::setw(3) << v[i] << " ";
    std::cout << std::endl << "- доход от перевозки              : ";
    for (int i = 0; i < NN; i++) std::cout << std::setw(3) << c[i] << " ";
    std::cout << std::endl << "- выбраны контейнеры (0,1,...,m-1): ";
    for (int i = 0; i < MM; i++) std::cout << r[i] << " ";
    std::cout << std::endl << "- доход от перевозки              : " << cc;
    std::cout << std::endl << "- общий вес выбранных контейнеров : ";
    int s = 0; for (int i = 0; i < MM; i++) s += v[r[i]]; std::cout << s;
    std::cout << std::endl << std::endl;
    system("pause");
    return 0;
}




//
//// ============================  ЗАВИСИМОСТЬ ВРЕМЕНИ ВЫЧИСЛЕНИЯ  ============================
//

//#include <iostream>
//#include <iomanip>
//#include "Boat.h"
//#include <time.h>
//#include "Auxil.h"
//#define NN 35
//#define MM 6
//#define SPACE(n) std::setw(n)<<" "
//int wmain()
//{
//    setlocale(LC_ALL, "rus");
//    int V = 1500;
//    int v[NN];
//    int c[NN];
//    short r[MM];
//
//    auxil::start();
//    for (int i = 0; i < NN; i++)
//    {
//        v[i]= auxil::iget(100, 900);
//    }
//
//    for (int i = 0; i < NN; i++)
//    {
//        c[i] = auxil::iget(10, 150);
//    }
//
//    int maxcc = 0;
//    clock_t t1, t2;
//    std::cout << std::endl << "-- Задача об оптимальной загрузке судна -- ";
//    std::cout << std::endl << "-  ограничение по весу    : " << V;
//    std::cout << std::endl << "-  количество мест        : " << MM;
//    std::cout << std::endl << "-- количество ------ продолжительность -- ";
//    std::cout << std::endl << "   контейнеров        вычисления  ";
//    for (int i = 25; i <= NN; i++)
//    {
//        t1 = clock();
//        int maxcc = boat(V, MM, i, v, c, r);
//        t2 = clock();
//        std::cout << std::endl << SPACE(7) << std::setw(2) << i
//            << SPACE(15) << std::setw(5) << (t2 - t1);
//    }
//    std::cout << std::endl << std::endl;
//    system("pause");
//    return 0;
//}