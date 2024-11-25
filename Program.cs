
namespace c_sharp_reflection;

class Program
{
    static void Main(string[] args)
    {
        var type = typeof(FourOperation);
        //FourOperation operation = (FourOperation)Activator.CreateInstance(type, 6, 7);
        //Console.WriteLine(operation.Add2());

        var instance = Activator.CreateInstance(type, 6, 7);
        Console.WriteLine(instance.GetType().GetMethod("Add2").Invoke(instance, null));

        var methods = type.GetMethods();
        foreach(var info in methods) {
            Console.WriteLine("Name : {0}", info.Name);

            foreach(var parameter in info.GetParameters()) {
                 Console.WriteLine("Param : {0}", parameter.Name);
            }

            foreach(var attr in info.GetCustomAttributes(false)) {
                 Console.WriteLine("Attr : {0}", attr.GetType().Name);
            }
        }
    }
}

public class FourOperation {
    private int _num1;
    private int _num2;
    public FourOperation(int num1, int num2)
    {
        _num1 = num1;
        _num2 = num2;
    }
    public int Add(int num1, int num2) {
        return num1 + num2;
    }

    public int Multiply(int num1, int num2) {
        return num1 * num2;
    }

    public int Add2() {
        return _num1 + _num2;
    }

    [MyCustom("Multiply")]
    public int Multiply2() {
        return _num1 * _num2;
    }
}


public class MyCustomAttribute: Attribute {

    public MyCustomAttribute(string name)
    {
        
    }
}