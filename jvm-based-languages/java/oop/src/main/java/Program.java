import interfaces.examples.SomeClass;
import interfaces.examples.SomeInterface;
import interfaces.sealed.PermittedClass;
import interfaces.sealed.SealedInterface;

public class Program {
    public static void main(String[] args) {
        SomeInterface a = new SomeClass();

        System.out.println(a.getString());
        System.out.println(a.getInt());

        SealedInterface b = new PermittedClass();

        System.out.println(b.getClass().isSealed());
        System.out.println(b.getString());
    }
}