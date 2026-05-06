using System.Numerics;

namespace ModuloExponentiation;

internal static class Program
{
    private const string Error = "Error!";
    private const string DefaultInputError = "Enter the correct value, pls";
    
    private const int SeparatorLength = 20;

    public static void Main()
    {
        var baseNumber = EnterNumber("Base");
        var expNumber = EnterNumber("Exponent", number => number >= 0, "Negative exponent is not supported");
        var modNumber = EnterNumber("Modulus", number => number > 0, "Modulus must be greater than 0");

        Console.WriteLine("\n" + new string('-', SeparatorLength) + "\n");

        Console.WriteLine($"{baseNumber}^{expNumber} % {modNumber}:");
        Console.WriteLine($"Old method: {LegacyModPow(baseNumber, expNumber, modNumber)}");
        Console.WriteLine($"Custom method: {CustomModPow(baseNumber, expNumber, modNumber)}");
        Console.WriteLine($"System method: {SystemModPow(baseNumber, expNumber, modNumber)}");
    }

    private static long EnterNumber(
        string numbStr,
        Func<long, bool>? isValid = null,
        string errorMessage = DefaultInputError)
    {
        while (true)
        {
            Console.Write($"{numbStr}: ");

            var input = Console.ReadLine();
            if (input == null)
                throw new EndOfStreamException();

            if (long.TryParse(input, out var result))
            {
                if (isValid == null || isValid(result))
                    return result;

                Console.WriteLine($"{Error} {errorMessage}");
            }
            else
                Console.WriteLine($"{Error} {DefaultInputError}");
        }
    }

    [Obsolete("Uses double-based calculation, works slow and incorrect. Use BigInteger.MathPow instead", false)]
    private static double LegacyModPow(long baseNumber, long expNumber, long modNumber) =>
        Math.Pow(baseNumber, expNumber) % modNumber;

    private static long CustomModPow(long baseNumber, long expNumber, long modNumber)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(expNumber);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(modNumber, 0);

        if (modNumber == 1)
            return 0;

        long result = 1;
        var tempBaseNumber = baseNumber % modNumber; // reduce base to prevent overflow in the operations loop
        var tempExpNumber = expNumber;
        while (tempExpNumber > 0) // fast exponential loop - O(log N)
        {
            // If exponent is odd, accumulate the current base into the result.
            // Cast to Int128 prevents overflow during intermediate multiplication.
            // C# automatically promotes numbers to Int128 for this calculation.
            if (tempExpNumber % 2 != 0)
                result = (long)((Int128)result * tempBaseNumber % modNumber);

            // Square the base to halve the required loop iterations.
            tempBaseNumber = (long)((Int128)tempBaseNumber * tempBaseNumber % modNumber);

            tempExpNumber /= 2;
        }

        return result;
    }

    private static BigInteger SystemModPow(long baseNumber, long expNumber, long modNumber) =>
        BigInteger.ModPow(baseNumber, expNumber, modNumber);
}