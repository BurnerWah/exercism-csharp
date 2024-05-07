using System;

public static class ErrorHandling {
    public static void HandleErrorByThrowingException() => throw new Exception();

    public static int? HandleErrorByReturningNullableType(string input) {
        try {
            return Int32.Parse(input);
        }
        catch (Exception) {
            return null;
        }
    }

    public static bool HandleErrorWithOutParam(string input, out int result) {
        try {
            result = Int32.Parse(input);
            return true;
        }
        catch (Exception) {
            result = -1;
            return false;
        }
    }

    public static void DisposableResourcesAreDisposedWhenExceptionIsThrown(IDisposable disposableObject) {
        disposableObject.Dispose();
        throw new Exception();
    }
}
