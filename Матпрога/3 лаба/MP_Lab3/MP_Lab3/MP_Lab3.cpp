
#include "stdafx.h"
#include <iostream>
#include <iomanip> 
#include "Salesman.h"
#define N 5

using namespace std;


int main()
{
	setlocale(LC_ALL, "rus");
	//3 вариант
	int d[N][N] = { // 1    2     3     4     5        
					{ INF,  6,    24,   INF,  3 },		//  1
					{ 3,    INF,  18,   65,   81 },		//  2
					{ 5,    9,    INF,  86,   52 },		//  3 
					{ 20,   55,   12,   INF,  9 },		//  4
					{ 90,   69,   52,   16,   INF } };	//  5

	int r[N];   /// результат 
	int s = salesman(
		N,          /// [in]  кол-во городов 
		(int*)d,    /// [in]  массив [n*n] расстояний 
		r           /// [out] массив [n] маршрут 0 x x x x  

	);

	cout << "\n-- Задача коммивояжера -- ";
	cout << "\n-- количество  городов: " << N;
	cout << "\n-- матрица расстояний : ";

	for (int i = 0; i < N; i++)
	{
		cout << "\n";
		for (int j = 0; j < N; j++)

			if (d[i][j] != INF) cout << setw(3) << d[i][j] << " ";

			else cout << setw(3) << "INF" << " ";
	}

	cout << "\n-- оптимальный маршрут: ";
	for (int i = 0; i < N; i++)
		cout << r[i] + 1 << "-->";

	cout << 1;
	cout << "\n-- длина маршрута     : " << s << "\n";
	system("pause");
	return 0;

}

