package interfaces.examples;

public interface SomeInterface {
    String getString();

    default int getInt() {
        return 10;
    }
}
