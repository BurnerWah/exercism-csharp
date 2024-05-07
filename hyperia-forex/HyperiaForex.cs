using System;

public struct CurrencyAmount(decimal amount, string currency) {
    private readonly decimal amount = amount;
    private readonly string currency = currency;

    public static bool operator ==(CurrencyAmount lhs, CurrencyAmount rhs) => lhs.currency == rhs.currency ? lhs.amount == rhs.amount : throw new ArgumentException();
    public static bool operator !=(CurrencyAmount lhs, CurrencyAmount rhs) => !(lhs == rhs);

    public static bool operator >(CurrencyAmount lhs, CurrencyAmount rhs) => lhs.currency == rhs.currency ? lhs.amount > rhs.amount : throw new ArgumentException();
    public static bool operator <(CurrencyAmount lhs, CurrencyAmount rhs) => lhs.currency == rhs.currency ? lhs.amount < rhs.amount : throw new ArgumentException();

    public static CurrencyAmount operator +(CurrencyAmount lhs, CurrencyAmount rhs) => lhs.currency == rhs.currency ? new CurrencyAmount(lhs.amount + rhs.amount, lhs.currency) : throw new ArgumentException();
    public static CurrencyAmount operator -(CurrencyAmount lhs, CurrencyAmount rhs) => lhs.currency == rhs.currency ? new CurrencyAmount(lhs.amount - rhs.amount, lhs.currency) : throw new ArgumentException();
    public static CurrencyAmount operator *(CurrencyAmount lhs, CurrencyAmount rhs) => lhs.currency == rhs.currency ? new CurrencyAmount(lhs.amount * rhs.amount, lhs.currency) : throw new ArgumentException();
    public static CurrencyAmount operator /(CurrencyAmount lhs, CurrencyAmount rhs) => lhs.currency == rhs.currency ? new CurrencyAmount(lhs.amount / rhs.amount, lhs.currency) : throw new ArgumentException();

    public static explicit operator double(CurrencyAmount c) => (double)c.amount;
    public static implicit operator decimal(CurrencyAmount c) => c.amount;
}
