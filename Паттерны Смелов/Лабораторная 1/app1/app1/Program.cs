// See https://aka.ms/new-console-template for more information
C1 class_1 = new C1();
C1 class_2 = new C1(333777332, "adress_2", 123456);
C1 class_3 = new C1(class_2);
C2 forMethod = new C2(1234567, "address_3", 45637);

class_2.Information();
class_2.Perform(class_2.Info);

forMethod.PerRandom();

forMethod.Information();
forMethod.Perform(forMethod.Info);

C4 objC4 = new C4();

// Доступ к полям (свойствам) класса C4
objC4.publicFieldC4 = 10;
Console.WriteLine("C4 publicFieldC4: " + objC4.publicFieldC4);

// Доступ к наследованным полям (свойствам) класса C3
objC4.publicField = 20;
Console.WriteLine("C3 publicField (inherited): " + objC4.publicField);

// Вызов методов класса C4
objC4.PublicMethodC4();

// Вызов унаследованных методов класса C3
objC4.PublicMethod();
/*objC4.ProtectedMethod();*/

interface I1
{
    public string Place { get; set; }
    public void Information();
    //индексатор
    string this[int index] { get; set; }
    event EventHandler MyEvent;

}

class C1 : I1
{
    //константы
    private const int Id = 1;
    public const string Ip = "172.16.194.31";
    protected const string Email = "randomemail@gmail.com";
    //поля
    private int Number;
    public string Address;
    protected int Password;
    public event EventHandler MyEvent;
    private string[] data = new string[10];
    //свойства
    private int Property 
    {
        get { return Number; }
        set { Number = value; }
    }
    public string Place 
    {
        get { return Address; }
        set { Address = value; }
    }
    public int Info 
    {
        get { return Password; }
        set { Password = value; }
    }
    

    //конструкторы
    //по умолчанию
    public C1(){}
    //с параметрами
    public C1(int property, string place, int info)
    {
        Property = property;
        Place = place;
        Info = info;
    }
    //копирующий
    public C1(C1 other)
    {
        Number = other.Number;
        Address = other.Address;
        Password = other.Password;
    }
    //методы
    private bool CorrectPass(int pas)
    {
        bool res = false;
        if (pas > 10000)
        {
            Console.WriteLine("Good password;)");
            res = true;
        }
        return res;
    }
    public void Perform(int pas)
    {
        bool res = CorrectPass(pas);
    }
    public void DoSomething()
    {
        // Генерация события
        MyEvent?.Invoke(this, EventArgs.Empty);
    }
    public string this[int index]
    {
        get { return data[index]; }
        set { data[index] = value; }
    }
    public void Information()
    {
        Console.WriteLine("Id: " + Id);
        Console.WriteLine("Ip: " + Ip);
        Console.WriteLine("Email: " + Email);
        Console.WriteLine("Number: " + Number);
        Console.WriteLine("Address: " + Place);
        Console.WriteLine("Password: " + Info);
    }
    protected string Random()
    {
        string res = "Этот protected-метод вызывается из наследуемого класса, а не напрямую!!";
        Console.WriteLine(res);
        return res;
    }
}
class C2 : C1, I1
{
    private const int Id = 2;
    public const string Ip = "192.168.0.1";
    protected const string Email = "anotheremail@gmail.com";

    private int Number;
    public string Address;
    protected int Password;
    public event EventHandler MyEvent;
    private string[] data = new string[10];

    private int Property
    {
        get { return Number; }
        set { Number = value; }
    }
    public string Place
    {
        get { return Address; }
        set { Address = value; }
    }
    public int Info
    {
        get { return Password; }
        set { Password = value; }
    }

    public C2() { }

    public C2(int property, string place, int info)
    {
        Property = property;
        Place = place;
        Info = info;
    }

    public C2(C2 other)
    {
        Number = other.Number;
        Address = other.Address;
        Password = other.Password;
    }

    private bool CorrectPass(int pas)
    {
        bool res = false;
        if (pas > 10000)
        {
            Console.WriteLine("Good password;)");
            res = true;
        }
        return res;
    }

    public void Perform(int pas)
    {
        bool res = CorrectPass(pas);
    }

    public void DoSomething()
    {
        MyEvent?.Invoke(this, EventArgs.Empty);
    }

    public string this[int index]
    {
        get { return data[index]; }
        set { data[index] = value; }
    }

    public void Information()
    {
        Console.WriteLine("Id: " + Id);
        Console.WriteLine("Ip: " + Ip);
        Console.WriteLine("Email: " + Email);
        Console.WriteLine("Number: " + Number);
        Console.WriteLine("Address: " + Place);
        Console.WriteLine("Password: " + Info);
    }

    public string PerRandom()
    {
        return Random();
    }
}

class C3
{
    private int privateField;
    protected int protectedField;
    public int publicField;

    private void PrivateMethod()
    {
        Console.WriteLine("C3 private method");
    }

    protected void ProtectedMethod()
    {
        Console.WriteLine("C3 protected method");
    }

    public void PublicMethod()
    {
        Console.WriteLine("C3 public method");
    }
}

class C4 : C3
{
    private int privateFieldC4;
    public int publicFieldC4;

    private void PrivateMethodC4()
    {
        Console.WriteLine("C4 private method");
    }

    public void PublicMethodC4()
    {
        Console.WriteLine("C4 public method");
    }
}