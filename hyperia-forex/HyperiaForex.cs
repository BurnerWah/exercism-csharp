using System;

public struct CurrencyAmount {
    private decimal amount;
    private string currency;

    public CurrencyAmount(decimal amount, string currency) {
        this.amount = amount;
        this.currency = currency;
    }

    public static bool operator ==(CurrencyAmount lhs, CurrencyAmount rhs) {
        if (lhs.currency == rhs.currency) {
            return lhs.amount == rhs.amount;
        } else {
            throw new ArgumentException();
        }
    }
    public static bool operator !=(CurrencyAmount lhs, CurrencyAmount rhs) => !(lhs == rhs);

    public static bool operator >(CurrencyAmount lhs, CurrencyAmount rhs) {
        if (lhs.currency == rhs.currency) {
            return lhs.amount > rhs.amount;
        } else {
            throw new ArgumentException();
        }
    }
    public static bool operator <(CurrencyAmount lhs, CurrencyAmount rhs) {
        if (lhs.currency == rhs.currency) {
            return lhs.amount < rhs.amount;
        } else {
            throw new ArgumentException();
        }
    }

    public static CurrencyAmount operator +(CurrencyAmount lhs, CurrencyAmount rhs) {
        if (lhs.currency == rhs.currency) {
            return new CurrencyAmount(lhs.amount + rhs.amount, lhs.currency);
        } else {
            throw new ArgumentException();
        }
    }
    public static CurrencyAmount operator -(CurrencyAmount lhs, CurrencyAmount rhs) {
        if (lhs.currency == rhs.currency) {
            return new CurrencyAmount(lhs.amount - rhs.amount, lhs.currency);
        } else {
            throw new ArgumentException();
        }
    }
    public static CurrencyAmount operator *(CurrencyAmount lhs, CurrencyAmount rhs) {
        if (lhs.currency == rhs.currency) {
            return new CurrencyAmount(lhs.amount * rhs.amount, lhs.currency);
        } else {
            throw new ArgumentException();
        }
    }
    public static CurrencyAmount operator /(CurrencyAmount lhs, CurrencyAmount rhs) {
        if (lhs.currency == rhs.currency) {
            return new CurrencyAmount(lhs.amount / rhs.amount, lhs.currency);
        } else {
            throw new ArgumentException();
        }
    }

    public static explicit operator double(CurrencyAmount c) => (double)c.amount;
    public static implicit operator decimal(CurrencyAmount c) => c.amount;
}
