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
            _printer.Clear();
            _printer.WriteLine("\nTRAINING 1: Structs and Enums\n");
            try
            {
                StructsTask();
                EnumsTask();
            }
            catch(ArgumentException exc)
            {
                _printer.WriteLine("\n Error: " + exc.Message);
            }
            catch(FormatException exc)
            {
                _printer.WriteLine("\n Input error: " + exc.Message);
            }

            _printer.WriteLine("\nPress any key to continue...");
            _printer.ReadLine();
        }

        private void StructsTask()
        {
            _printer.WriteLine("Task 1: Person and Rectangle Structs\n");
            PersonTask();
            RectangleTask();
        }

        private void EnumsTask()
        {
            _printer.WriteLine("\nTask 2: Enums");
            MonthsTask();
            ColorsTask();
            LongRangeValuesTask();
        }

        #region StructTasks

        private void RectangleTask()
        {
            _printer.WriteLine("\n Rectangle Struct:");
            ReadRectangle(out Rectangle rectangle);

            _printer.WriteLine($" Result: Perimeter = {rectangle.Perimeter()}");
        }

        private void PersonTask()
        {
            _printer.WriteLine(" Person Struct:\n");
            ReadPerson(out Person person);

            _printer.Write(" Age to compare: ");
            int age = int.Parse(_printer.ReadLine());

            _printer.WriteLine(" Result: " + person.OlderThan(age));
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

        #endregion

        #region EnumTasks

        private void LongRangeValuesTask()
        {
            _printer.WriteLine("\n LongRangeValues Enum:");
            var longRangeValues = Enum.GetValues(typeof(LongRange));
            _printer.WriteLine(" \n LongRange: ");
            foreach (var a in longRangeValues)
            {
                _printer.Write($" {a} = {(long)a};");
            }
            _printer.WriteLine();
        }

        private void ColorsTask()
        {
            _printer.WriteLine("\n Colors Enum: ");
            Colors color = Colors.Black;
            _printer.WriteLine(" \n Colors: " + color.Values());
        }

        private void MonthsTask()
        {
            _printer.WriteLine("\n Months Enum:\n");
            int n;
            _printer.Write(" Enter n: ");
            if (int.TryParse(_printer.ReadLine(), out n) && n >= 0 && n < 12)
            {
                _printer.WriteLine(" Month: " + Enum.GetName(typeof(Months), n));
            }
            else
            {
                _printer.WriteLine(" Wrong input.");
            }
        }

        #endregion

    }
}
