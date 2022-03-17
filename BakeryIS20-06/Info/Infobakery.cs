using System;
namespace BakeryIS.Info
{
    [Serializable]
    internal class Infobakery
    {
        public override string ToString()
        {
            return $"\tНазвание выпечки: {Name}\n\tСостав выпечки: {Structure}\n\tКалорийность: {Calories}\n\tСтоимость: {Price}\n\tВремя готовки: {Time}";
        }

        public string Name { get; set; }
        public string Structure { get; set; }
        public string Calories { get; set; }
        public string Price { get; set; }
        public string Time { get; set; }

        public Infobakery(string name, string structure, string calories, string price, string time)
        {
            Name = name;
            Structure = structure;
            Calories = calories;
            Price = price;
            Time = time;
        }
    }
}