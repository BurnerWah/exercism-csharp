using System;

public class Orm(Database database) {
    public void Write(string data) {
        try {
            database.BeginTransaction();
            database.Write(data);
            database.EndTransaction();
        }
        catch (InvalidOperationException) {
            database.Dispose();
            throw;
        }
    }

    public bool WriteSafely(string data) {
        try {
            Write(data);
            return true;
        }
        catch (InvalidOperationException) {
            return false;
        }
    }
}
