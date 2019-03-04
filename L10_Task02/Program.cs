using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Шаблонный метод (Template Method) определяет общий алгоритм поведения подклассов,
// позволяя им переопределить отдельные шаги этого алгоритма без изменения его структуры.


// Когда использовать шаблонный метод?

// -- Когда планируется, что в будущем подклассы должны будут переопределять различные этапы алгоритма без изменения его структуры
// -- Когда в классах, реализующим схожий алгоритм, происходит дублирование кода. Вынесение общего кода в шаблонный метод уменьшит его дублирование в подклассах.

namespace L10_Task02
{
    // AbstractClass: определяет шаблонный метод TemplateMethod(), который реализует алгоритм.
    // Алгоритм может состоять из последовательности вызовов других методов, часть из которых может
    // быть абстрактными и должны быть переопределены в классах-наследниках. При этом сам метод TemplateMethod(),
    // представляющий структуру алгоритма, переопределяться не должен.
    abstract class AbstractClass
    {
        // Формальная реализация паттерна
        public void TemplateMethod()
        {
            Operation1();
            Operation2();
        }
        public abstract void Operation1();
        public abstract void Operation2();
    }

    // ConcreteClass: подкласс, который может переопределять различные методы родительского класса.
    class ConcreteClass : AbstractClass
    {
        public override void Operation1()
        {
        }

        public override void Operation2()
        {
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }


}
