using System;

public static class ErrorHandling {
    public static void HandleErrorByThrowingException() => throw new Exception();

    public static int? HandleErrorByReturningNullableType(string input) => Int32.TryParse(input, out var result) ? result : null;

    public static bool HandleErrorWithOutParam(string input, out int result) => Int32.TryParse(input, out result);

    public static void DisposableResourcesAreDisposedWhenExceptionIsThrown(IDisposable disposableObject) {
        disposableObject.Dispose();
        throw new Exception();
    }
}
