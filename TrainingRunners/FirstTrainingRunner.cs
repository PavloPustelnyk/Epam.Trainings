using System;
using System.Collections.Generic;
using System.Text;
using Epam.Training_1.Task_1;
using Epam.Training_1.Task_2;
using Epam.Readers;
using Epam.Writers;
using Epam.Logger;

namespace Epam.TrainingRunners
{
    public class FirstTrainingRunner : ITrainingRunner
    {
        public IWriter Writer { get; set; }
        public IReader Reader { get; set; }
        public ILogger Logger { get; set; }

        public void Run()
        {
            Writer.Clear();
            Writer.WriteLine("\nTRAINING 1: Structs and Enums\n");

            try
            {
                StructsTask();
                EnumsTask();
            }
            catch(ArgumentException exc)
            {
                Writer.WriteLine("\n Error: " + exc.Message);
            }
            catch(FormatException exc)
            {
                Writer.WriteLine("\n Input error: " + exc.Message);
            }

            Writer.WriteLine("\nPress any key to continue...");
            Reader.ReadLine();
        }

        private void StructsTask()
        {
            Writer.WriteLine("Task 1: Person and Rectangle Structs\n");
            PersonTask();
            RectangleTask();
        }

        private void EnumsTask()
        {
            Writer.WriteLine("\nTask 2: Enums");
            MonthsTask();
            ColorsTask();
            LongRangeValuesTask();
        }

        #region StructTasks

        private void RectangleTask()
        {
            Writer.WriteLine("\n Rectangle Struct:");
            ReadRectangle(out Rectangle rectangle);

            Writer.WriteLine($" Result: Perimeter = {rectangle.Perimeter()}");
        }

        private void PersonTask()
        {
            Writer.WriteLine(" Person Struct:\n");
            ReadPerson(out Person person);

            Writer.Write(" Age to compare: ");
            int age = int.Parse(Reader.ReadLine());

            Writer.WriteLine(" Result: " + person.OlderThan(age));
        }

        private void ReadPerson(out Person person)
        {
            string firstName, lastName;

            Writer.Write(" Enter your first name: ");
            firstName = Reader.ReadLine();

            Writer.Write(" Enter your last name: ");
            lastName = Reader.ReadLine();

            Writer.Write(" Enter your age: ");
            if (!int.TryParse(Reader.ReadLine(), out int age))
            {
                throw new ArgumentException("Age must be an integer type.");
            }

            person = new Person { FirstName = firstName, LastName = lastName, Age = age };
        }

        private void ReadRectangle(out Rectangle rectangle)
        {
            double x, y, width, height;

            Writer.Write("\n Enter X: ");
            x = Double.Parse(Reader.ReadLine());

            Writer.Write(" Enter Y: ");
            y = Double.Parse(Reader.ReadLine());

            Writer.Write(" Enter width: ");
            width = Double.Parse(Reader.ReadLine());

            Writer.Write(" Enter heigth: ");
            height = Double.Parse(Reader.ReadLine());

            rectangle = new Rectangle { X = x, Y = y, Width = width, Height = height };
        }

        #endregion

        #region EnumTasks

        private void LongRangeValuesTask()
        {
            Writer.WriteLine("\n LongRangeValues Enum:");
            Writer.WriteLine(" \n LongRange: ");
            var longRangeValues = Enum.GetValues(typeof(LongRange));
            foreach (var a in longRangeValues)
            {
                Writer.Write($" {a} = {(long)a};");
            }
            Writer.WriteLine();
        }

        private void ColorsTask()
        {
            Colors color = Colors.Black;
            Writer.WriteLine("\n Colors Enum: ");
            Writer.WriteLine(" \n Colors: " + color.Values());
        }

        private void MonthsTask()
        {
            Writer.WriteLine("\n Months Enum:\n");
            Writer.Write(" Enter n: ");
            if (int.TryParse(Reader.ReadLine(), out int n) && n >= 0 && n < 12)
            {
                Writer.WriteLine(" Month: " + Enum.GetName(typeof(Months), n));
            }
            else
            {
                Writer.WriteLine(" Wrong input.");
            }
        }

        #endregion

    }
}
