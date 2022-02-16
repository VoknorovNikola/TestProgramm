bool isNum = false;
bool prost = false;
bool napravl = false;
bool setNapr = false;
bool dva = false;
int n = 0;
int m = 0;
int kol = 0;
int p = 0;
while (!setNapr)
{
    int c;
    Console.WriteLine("Выберите направление поиска, введите 0 для прямого и 1 для обратного");
    string t = Console.ReadLine();
    bool chislo = int.TryParse(t, out c);
    if ((chislo) & ((c == 0) || (c == 1)))
    {
        switch (c)
        {
            case 0:
                napravl = false;
                p = 1;
                break;
            case 1:
                napravl = true;
                p = -1;
                break;
            default: break;
        }
        setNapr = true;

    }
}
while (!isNum)
 {
    Console.WriteLine("Введите 1 или 2 числа через запятую");
    string[] vvod = Console.ReadLine().Split(',');
    if (int.TryParse(vvod[0], out n)) isNum = true;
    else continue;
    for (int i = 0; i < vvod.Length; i++)
    {
        int b = 0;
        if ( i == 2)
        {
            Console.WriteLine("Слишком много чисел через запятую");
            isNum = false;
            break;
        }
        if (int.TryParse(vvod[i], out b))
        {
            if (!napravl)
            {
                isNum = true;
                if (b < n)
                {
                  m = n;
                  n = b; 
                }
                else m = b;
                if ( i == 1 ) dva = true;
            }
            else
            {
                isNum = true;
                if (b > n)
                {
                    m = n;
                    n = b;
                }
                else m = b;
                if (i == 1) dva = true;
            }
        }  
        else isNum = false;

    }
}
if (isNum)
{
    Console.WriteLine("Найденные простые числа:");
    if (n < 0) n = 0;
    for (int i = p + n; kol < 3;)
    {
        if ((dva) & (!napravl) & (((i >= m) || (i <= n)))) break;
        if ((dva) & (napravl) & (((i <= m) || (i >= n)))) break;
        if (i <= 0) break;
        prost = true;
        for (int a = 2; a <= (int)(i / 2); a++)
        {
            if (i % a == 0)
                prost = false;
        }

        if (prost)
        {
            
            kol++;
            Console.Write(i.ToString() + " ");
        }
        if (!napravl)
            i++;
        else i--;

    }

    switch (kol)
    {
        case 0:
            Console.WriteLine();
            Console.WriteLine("По заданным параметрам нет простых чисел.");
            break;
        case 1:
            Console.WriteLine();
            Console.WriteLine("Больше нет чисел, удовлетворяющих условию");
            break ;
        case 2:
            Console.WriteLine();
            Console.WriteLine("Больше нет чисел, удовлетворяющих условию");
            break;
        default: break;
    }
    Console.ReadLine();
}



