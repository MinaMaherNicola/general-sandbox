package interfaces.sealed;

public sealed interface SealedInterface permits PermittedClass {
    String getString();
}
