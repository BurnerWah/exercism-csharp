using System;

public class Orm(Database database) : IDisposable {
    public void Begin() => database.BeginTransaction();

    public void Write(string data) {
        try {
            database.Write(data);
        }
        catch (InvalidOperationException) {
            database.Dispose();
        }
    }

    public void Commit() {
        try {
            database.EndTransaction();
        }
        catch (InvalidOperationException) {
            database.Dispose();
        }
    }

    public void Dispose() => database.Dispose();
}
