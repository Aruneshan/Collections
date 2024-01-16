using System;

namespace Concepts
{
    public abstract class MobilePhone
    {
        public string Brand { get; set; }
        public string Model { get; set; }

        public abstract void Call(int phoneNumber);
        public abstract void Sms(int phoneNumber, string subject);

        public virtual void Display()
        {
            Console.WriteLine($"I have Brought {Brand} {Model} mobile phone");
        }
    }

    public class SmartPhone : MobilePhone
    {
        public override void Call(int phoneNumber)
        {
            Console.WriteLine($"{phoneNumber} - This is my phone");
        }

        public override void Sms(int phoneNumber, string subject)
        {
            Console.WriteLine($"{phoneNumber} - This is my phone {Brand} {Model}");
        }

        public override void Display()
        {
            base.Display();
            Console.WriteLine($"This is a Smart Phone");
        }
    }

    public class BasicPhone : MobilePhone
    {
        public override void Call(int phoneNumber)
        {
            Console.WriteLine($"{phoneNumber} - This is my basic phone");
        }

        public override void Sms(int phoneNumber, string subject)
        {
            Console.WriteLine($"{phoneNumber} - This is my basic phone {Brand} {Model}");
        }
    }

    public class HelloWorld
    {
        public static void Main(string[] args)
        {
            MobilePhone smartPhone = new SmartPhone { Brand = "Redmi", Model = "Note 5" };
            MobilePhone basicPhone = new BasicPhone { Brand = "Nokia", Model = "119" };
            DisplayPhoneInfo(smartPhone);
            DisplayPhoneInfo(basicPhone);
            smartPhone.Call(798786996);
            basicPhone.Sms(97979789, "This is a message to basic Phone");
        }

        static void DisplayPhoneInfo(MobilePhone phone)
        {
            phone.Display();
            Console.WriteLine();
        }
    }
}
