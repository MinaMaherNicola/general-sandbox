package interfaces.sealed;

public non-sealed class PermittedClass implements SealedInterface {

    public String getString() {
        return "This is sealed class";
    }
}
