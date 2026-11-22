#nullable enable

using System;

namespace Lab2
{
    public interface Pet
    {
        void express();
        string getName();
        int getAge();
        int getAgeInHumanYears();
    }

    public abstract class Animal : Pet
    {
        private readonly string name;
        private int age;

        protected Animal(string name, int age)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Кличка не может быть пустой.", nameof(name));
            }

            if (age < 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(age),
                    "Возраст не может быть отрицательным.");
            }

            this.name = name;
            this.age = age;
        }

        public void happyBirthday()
        {
            age = checked(age + 1);
        }

        public string getName()
        {
            return name;
        }

        public int getAge()
        {
            return age;
        }

        public abstract void express();

        public abstract int getAgeInHumanYears();
    }

    public class Parrot : Animal
    {
        public Parrot(string name, int age) : base(name, age)
        {
        }

        public override int getAgeInHumanYears()
        {
            return checked(getAge() * 5);
        }

        public override void express()
        {
            Console.WriteLine($"{getName()}: \"Hello!\"");
            Console.WriteLine(@"   \");
            Console.WriteLine("   (o>");
            Console.WriteLine(@"\\_//)");
            Console.WriteLine(@" \_/_)");
            Console.WriteLine("  _|_");
            Console.WriteLine();
        }
    }

    public class Turtle : Animal
    {
        public Turtle(string name, int age) : base(name, age)
        {
        }

        public override int getAgeInHumanYears()
        {
            if (getAge() == 0)
            {
                return 0;
            }

            return checked(15 + (getAge() - 1) * 2);
        }

        public override void express()
        {
            Console.WriteLine("  _____     ____");
            Console.WriteLine(@" /      \  |  o |");
            Console.WriteLine(@"|        |/ ___\|");
            Console.WriteLine("|_________/");
            Console.WriteLine("|_|_| |_|_|");
            Console.WriteLine();
        }
    }

    public class Person
    {
        private readonly string name;
        private Pet? pet;

        public Person(string name) : this(name, null)
        {
        }

        public Person(string name, Pet? pet)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Имя не может быть пустым.", nameof(name));
            }

            this.name = name;
            this.pet = pet;
        }

        public void setPet(Pet? pet)
        {
            this.pet = pet;
        }

        public void getPetInfo()
        {
            Console.WriteLine("--------------------");

            if (pet is null)
            {
                Console.WriteLine($"{name} has no pet yet");
                Console.WriteLine("--------------------");
                return;
            }

            Console.WriteLine($"Pet for {name} is named {pet.getName()}");
            Console.WriteLine(
                $"Age: {pet.getAge()} year(s), about {pet.getAgeInHumanYears()} human years");
            Console.WriteLine("And it expresses itself like this:");

            pet.express();

            Console.WriteLine("--------------------");
        }
    }

    public static class Program
    {
        public static void Main()
        {
            Parrot kesha = new Parrot("Kesha", 2);
            Turtle zavala = new Turtle("Zavala", 4);

            kesha.happyBirthday();

            Person jack = new Person("Jack", kesha);
            Person john = new Person("John");

            jack.getPetInfo();
            john.getPetInfo();

            john.setPet(zavala);
            john.getPetInfo();
        }
    }
}