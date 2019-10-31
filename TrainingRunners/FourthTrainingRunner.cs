//-----------------------------------------------------------------------
// <copyright file="FourthTrainingRunner.cs" company="Epam">
//     Copyright (c) Epam. All rights reserved.
// </copyright>
// <author>Pavlo Pustelnyk</author>
//-----------------------------------------------------------------------
namespace Epam.Trainings.TrainingRunners
{
    using System;
    using System.Collections.Generic;
    using Epam.Trainings.Logger;
    using Epam.Trainings.Readers;
    using Epam.Trainings.Training_4;
    using Epam.Trainings.Writers;

    /// <summary>
    /// Runner class for Training_4 project
    /// </summary>
    public class FourthTrainingRunner : ITrainingRunner
    {
        /// <summary>
        /// Gets or sets Writer, that implements IWriter
        /// </summary>
        public IWriter Writer { get; set; }

        /// <summary>
        /// Gets or sets Reader, that implements IReader
        /// </summary>
        public IReader Reader { get; set; }

        /// <summary>
        /// Gets or sets Logger, that implements ILogger
        /// </summary>
        public ILogger Logger { get; set; }

        /// <summary>
        /// Main method for ITrainingRunner to run all training tasks
        /// </summary>
        public void Run()
        {
            this.Writer.Clear();
            this.Writer.WriteLine("\nTraining 4: Serialization");

            this.SerializationTask();

            this.Writer.WriteLine("\nPress any key to continue...");
            this.Reader.ReadLine();
        }

        #region Tasks
        /// <summary>
        /// Method to perform all types of serialization and deserialization for training.
        /// </summary>
        private void SerializationTask()
        {
            var cars = new List<Car>()
            {
                new Car { carId = 1, price = 15000, quantity = 4, total = 60000 },
                new Car { carId = 2, price = 10000, quantity = 3, total = 30000 },
                new Car { carId = 3, price = 10000, quantity = 2, total = 20000 }
            };

            try
            {
                this.Writer.WriteLine("JsonSerialization:");
                var jsonCars = this.JsonSerialization("cars.json", cars);
                this.PrintCars(jsonCars);

                this.Writer.WriteLine("\nXmlSerialization:");
                var xmlCars = this.XmlSerialization("cars.xml", cars);
                this.PrintCars(xmlCars);

                this.Writer.WriteLine("\nBinarySerialization:");
                var binaryCars = this.BinarySerialization("cars.data", cars);
                this.PrintCars(binaryCars);
            }
            catch(ArgumentException e)
            {
                this.Writer.WriteLine(e.Message);
                this.Logger.LogMessage($"Class - FourthTrainingRunner | Method - SerializationTask | {e.Message}");
            }
        }

        /// <summary>
        /// Prints all cars in list using Writer.
        /// </summary>
        /// <param name="list">List of cars</param>
        private void PrintCars(List<Car> list)
        {
            if (list == null)
            {
                throw new ArgumentException("List cannot be null");
            }
            foreach (var car in list)
            {
                this.Writer.WriteLine($"Id: {car.carId}, Price: {car.price}, Quantity: {car.quantity}");
            }
        }

        /// <summary>
        /// Method to perform JSON serialization and deserialization.
        /// </summary>
        /// <param name="file">Name of file to serialize in</param>
        /// <param name="cars">List of cars to serialize</param>
        /// <returns>Deserialized List of cars</returns>
        private List<Car> JsonSerialization(string file, List<Car> cars)
        {
            List<Car> deserializedCars = null;

            try
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.SerializeList<Car>(cars, file);
                deserializedCars = serializer.DeserializeList<Car>(file);
            }
            catch (Exception e)
            {
                this.Writer.WriteLine(e.Message);
                this.Logger.LogMessage($"Class - FourthTrainingRunner | Method - JsonSerialization | {e.Message}");
            }

            return deserializedCars;
        }

        /// <summary>
        /// Method to perform XML serialization and deserialization.
        /// </summary>
        /// <param name="file">Name of file to serialize in</param>
        /// <param name="cars">List of cars to serialize</param>
        /// <returns>Deserialized List of cars</returns>
        private List<Car> XmlSerialization(string file, List<Car> cars)
        {
            List<Car> deserializedCars = null;

            try
            {
                XmlSerializer serializer = new XmlSerializer();
                serializer.SerializeList<Car>(cars, file);
                deserializedCars = serializer.DeserializeList<Car>(file);
            }
            catch (Exception e)
            {
                this.Writer.WriteLine(e.Message);
                this.Logger.LogMessage($"Class - FourthTrainingRunner | Method - XmlSerialization | {e.Message}");
            }

            return deserializedCars;
        }

        /// <summary>
        /// Method to perform Binary serialization and deserialization.
        /// </summary>
        /// <param name="file">Name of file to serialize in</param>
        /// <param name="cars">List of cars to serialize</param>
        /// <returns>Deserialized List of cars</returns>
        private List<Car> BinarySerialization(string file, List<Car> cars)
        {
            List<Car> deserializedCars = null;

            try
            {
                BinarySerializer serializer = new BinarySerializer();
                serializer.SerializeList<Car>(cars, file);
                deserializedCars = serializer.DeserializeList<Car>(file);
            }
            catch (Exception e)
            {
                this.Writer.WriteLine(e.Message);
                this.Logger.LogMessage($"Class - FourthTrainingRunner | Method - BinarySerialization | {e.Message}");
            }

            return deserializedCars;
        }
        #endregion
    }
}
