namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Calculator();
        }

       public static double Add (double x, double y) => x + y;

        public static double Divide(double x, double y) => y != 0 ? x / y : throw new DivideByZeroException();

        public static double Multiply(double x, double y) => x * y;

        public static double Subtract(double x, double y) => x - y;

        public delegate double Operation(double x, double y);  
        
        public static  double Calculate(double x, double y, Operation operation)
        {
            return operation(x, y);
        }

        public static void Calculator()
        {
            while (true)
            {
                Console.Clear();
                double x, y;

                Console.Write("Введите первое число: ");
                while (!double.TryParse(Console.ReadLine(), out x))
                {
                    Console.Write("Ошибка! Введите корректное число: ");
                }
                string choice;
                Operation operation = null;

                do
                {
                    Console.WriteLine("Выберите операцию:");
                    Console.WriteLine("1 - Сложение (+)");
                    Console.WriteLine("2 - Вычитание (-)");
                    Console.WriteLine("3 - Умножение (*)");
                    Console.WriteLine("4 - Деление (/)");
                    Console.Write("Ваш выбор: ");
                    choice = Console.ReadLine();

                    operation = choice switch
                    {
                        "1" => Add,
                        "2" => Subtract,
                        "3" => Multiply,
                        "4" => Divide,
                        _ => null
                    };

                    if (operation == null)
                    {
                        Console.WriteLine("Неверный выбор. Попробуйте снова.\n");
                    }

                } while (operation == null);


                Console.Write("Введите второе число: ");
                while (!double.TryParse(Console.ReadLine(), out y))
                {
                    Console.Write("Ошибка! Введите корректное число: ");
                }

                try
                {
                    double result = Calculate(x, y, operation);
                    Console.WriteLine($"Результат: {result}");
                }
                catch (DivideByZeroException)
                {
                    Console.WriteLine("Ошибка: деление на ноль невозможно.");
                }

                Console.WriteLine("Хотите выполнить ещё одну операцию? (да/нет): ");
                string answer = Console.ReadLine()?.Trim().ToLower();

                if (answer != "да" && answer != "y" && answer != "yes")
                {
                    Console.WriteLine("Выход из программы...");
                    break;
                }
            }
        }

    }
}
