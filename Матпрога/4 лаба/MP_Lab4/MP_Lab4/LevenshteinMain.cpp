#include "stdafx.h"
using namespace std;
#define _rand(min, max) ( rand() % ((max) - (min) + 1) + (min) )


int main()
{
	setlocale(LC_ALL, "rus");
	srand(time(NULL));
	char abc[25]; // алфавит
	char s1[300];
	char s2[250];


	// заполняем массив
	for (int i = 97, n = 0; i <= 122; ++i, ++n)
	{
		abc[n] = (char)i;
	}
	cout << "S1 = ";
	for (int i = 0; i < 301; i++)
	{
		s1[i] = abc[_rand(0, 25)];
		if (i % 50 == 0)
			cout << "\n";
		cout << s1[i];
	}

	cout << "\nS2 =";
	for (int i = 0; i < 251; i++)
	{
		s2[i] = abc[_rand(0, 25)];
		if (i % 50 == 0)
			cout << "\n";
		cout << s2[i];
	}
	cout << "\n";

	clock_t t1 = 0, t2 = 0, t3 = 0, t4 = 0;
	int lx = sizeof(s1);
	int ly = sizeof(s2);


	int S1_size[]{ 12,15,20,30,60,150,300 };
	int S2_size[]{ 10,13,17,25,50,125,250 };


	std::cout << "\n\n-- расстояние Левенштейна -----";
	std::cout << "\n\n--длина --- рекурсия -- дин.програм. ---\n";

	for (int i = 0; i < min(lx, ly); i++)
	{
		t1 = clock();
		levenshtein_r(S1_size[i], s1, S2_size[i], s2);
		t2 = clock();

		t3 = clock();
		levenshtein(S1_size[i], s1, S2_size[i], s2);
		t4 = clock();
		cout << right << setw(2) << S1_size[i] << "/" << setw(2) << S2_size[i]
			<< "        " << left << setw(10) << (t2 - t1)
			<< "   " << setw(10) << (t4 - t3) << endl;
	}
	system("pause");
	return 0;
}





