using System;
using System.Collections.Generic;
using System.Text;
using Epam.Training_1.Task_1;
using Epam.Training_1.Task_2;

namespace Epam.TrainingRunners
{
    public class FirstTrainingRunner : TrainingRunner
    {
        public FirstTrainingRunner(IPrinter printer) : base(printer)
        {
        }

        public override void Run()
        {
            _printer.WriteLine("\n< TRAINING 1 >\n");
            try
            {
                Task1();
                Task2();
            }
            catch(ArgumentException exc)
            {
                _printer.WriteLine("\n Error: " + exc.Message);
            }
        }

        private void Task1()
        {
            _printer.WriteLine("TASK 1\n");

            ReadPerson(out Person person);

            _printer.Write(" Age to compare: ");
            int age = int.Parse(_printer.ReadLine());

            _printer.WriteLine(" > " + person.OlderThan(age));

            ReadRectangle(out Rectangle rectangle);

            _printer.WriteLine($" > Perimeter: {rectangle.Perimeter()}");
        }

        private void Task2()
        {
            _printer.WriteLine("\nTASK 2\n");

            int n;
            _printer.Write(" Enter n: ");
            if (int.TryParse(_printer.ReadLine(), out n) && n >= 0 && n < 12)
            {
                _printer.WriteLine(" " + Enum.GetName(typeof(Months), n));
            }
            else
            {
                _printer.WriteLine(" Wrong input.");
            }

            Colors color = Colors.Black;
            _printer.WriteLine(" \nColors: " + color.Values());

            var longRangeValues = Enum.GetValues(typeof(LongRange));
            _printer.WriteLine(" \nLongRange: ");
            foreach (var a in longRangeValues)
            {
                _printer.Write($" {a} = {(long)a};");
            }
        }

        private void ReadPerson(out Person person)
        {
            string firstName, lastName;
            int age;

            _printer.Write(" Enter your first name: ");
            firstName = _printer.ReadLine();

            _printer.Write(" Enter your last name: ");
            lastName = _printer.ReadLine();

            _printer.Write(" Enter your age: ");
            if (!int.TryParse(_printer.ReadLine(), out age))
            {
                throw new ArgumentException("Age must be an integer type.");
            }

            person = new Person { FirstName = firstName, LastName = lastName, Age = age };
        }

        private void ReadRectangle(out Rectangle rectangle)
        {
            double x, y, width, height;

            _printer.Write("\n Enter X: ");
            x = Double.Parse(_printer.ReadLine());

            _printer.Write(" Enter Y: ");
            y = Double.Parse(_printer.ReadLine());

            _printer.Write(" Enter width: ");
            width = Double.Parse(_printer.ReadLine());

            _printer.Write(" Enter heigth: ");
            height = Double.Parse(_printer.ReadLine());

            rectangle = new Rectangle { X = x, Y = y, Width = width, Height = height };
        }
    }
}
