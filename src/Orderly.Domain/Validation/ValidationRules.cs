using System.Text.RegularExpressions;

namespace Orderly.Domain.Validation;

public static partial class ValidationRules
{
    public static void ValidateRequired(string? value, string fieldName, IValidator errors)
    {
        if (string.IsNullOrWhiteSpace(value))
            errors.AddValidationError($"'{fieldName}' is required.");
    }

    public static void ValidateStringLength(
        string value,
        string fieldName,
        int minLength,
        int maxLength,
        IValidator errors
    )
    {
        if (value.Length < minLength || value.Length > maxLength)
            errors.AddValidationError(
                $"'{fieldName}' should be between {minLength} and {maxLength} characters."
            );
    }

    public static void ValidateMaxStringLength(
        string value,
        string fieldName,
        int maxLength,
        IValidator errors
    )
    {
        ValidateStringLength(value, fieldName, 0, maxLength, errors);
    }

    public static void ValidatePositive(int value, string fieldName, IValidator errors)
    {
        if (int.IsNegative(value))
            errors.AddValidationError($"'{fieldName}' should be positive.");
    }

    public static void ValidatePositive(decimal value, string fieldName, IValidator errors)
    {
        if (decimal.IsNegative(value))
            errors.AddValidationError($"'{fieldName}' should be positive.");
    }

    public static void ValidateEmail(string email, string fieldName, IValidator errors)
    {
        if (!EmailRegex().IsMatch(email))
            errors.AddValidationError($"Invalid '{fieldName}' format.");
    }

    public static void ValidateCpf(string cpf, string fieldName, IValidator errors)
    {
        var cpfNumbers = DigitOnlyRegex().Replace(cpf, "");

        if (cpfNumbers.Length != 11 || IsRepeatedDigits(cpfNumbers) || !IsValidCpf(cpfNumbers))
            errors.AddValidationError($"'{fieldName}' is not valid.");

        return;

        bool IsRepeatedDigits(string input)
        {
            return input.Distinct().Count() == 1;
        }

        bool IsValidCpf(string cpfDigits)
        {
            var digits = cpfDigits.Select(c => int.Parse(c.ToString())).ToArray();

            var checksum1 = 0;
            var checksum2 = digits[9] * (11 - 9);

            for (var i = 0; i < 9; i++)
            {
                checksum1 += digits[i] * (10 - i);
                checksum2 += digits[i] * (11 - i);
            }

            var remainder1 = checksum1 % 11;
            var remainder2 = checksum2 % 11;

            var digit1 = remainder1 < 2 ? 0 : 11 - remainder1;
            var digit2 = remainder2 < 2 ? 0 : 11 - remainder2;

            return digits[9] == digit1 && digits[10] == digit2;
        }
    }

    public static void ValidateCnpj(string cnpj, string fieldName, IValidator errors)
    {
        var cnpjNumbers = DigitOnlyRegex().Replace(cnpj, "");

        if (cnpjNumbers.Length != 14 || IsRepeatedDigits(cnpjNumbers) || !IsValidCnpj(cnpjNumbers))
            errors.AddValidationError($"'{fieldName}' is not valid.");

        return;

        bool IsRepeatedDigits(string input)
        {
            return input.Distinct().Count() == 1;
        }

        bool IsValidCnpj(string cnpjDigits)
        {
            var digits = cnpjDigits.Select(c => int.Parse(c.ToString())).ToArray();

            var weights1 = new[] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            var weights2 = new[] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            var checksum1 = 0;
            var checksum2 = digits[12] * weights2[12];

            for (var i = 0; i < 12; i++)
            {
                checksum1 += digits[i] * weights1[i];
                checksum2 += digits[i] * weights2[i];
            }

            var remainder1 = 11 - checksum1 % 11;
            var remainder2 = 11 - checksum2 % 11;

            var digit1 = remainder1 >= 10 ? 0 : remainder1;
            var digit2 = remainder2 >= 10 ? 0 : remainder2;

            return digits[12] == digit1 && digits[13] == digit2;
        }
    }

    public static void ValidatePhoneNumber(string phone, string fieldName, IValidator errors)
    {
        var validatePhoneNumberRegex = new Regex(
            @"^(\+55\s?)?(\(\d{2}\)\s?)?(\d{4,5}-\d{4}|\d{11})$"
        );
        if (validatePhoneNumberRegex.IsMatch(phone) == false)
            errors.AddValidationError($"'{fieldName}' is not valid.");
    }

    [GeneratedRegex("^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$")]
    private static partial Regex EmailRegex();

    [GeneratedRegex("[^\\d]")]
    private static partial Regex DigitOnlyRegex();
}
