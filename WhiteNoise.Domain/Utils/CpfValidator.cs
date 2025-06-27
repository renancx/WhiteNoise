using System.Text.RegularExpressions;

namespace WhiteNoise.Domain.Utils
{
    public static class CpfValidator
    {
        public static bool IsValid(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf)) return false;
            var digits = Regex.Replace(cpf, @"\D", "");
            if (digits.Length != 11) return false;
            if (new string(digits[0], 11) == digits) return false;

            int[] m1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 }, m2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string temp = digits.Substring(0, 9);
            int sum = 0;
            for (int i = 0; i < 9; i++) sum += (temp[i] - '0') * m1[i];
            int r = sum % 11; r = r < 2 ? 0 : 11 - r;
            temp += r;
            sum = 0;
            for (int i = 0; i < 10; i++) sum += (temp[i] - '0') * m2[i];
            r = sum % 11; r = r < 2 ? 0 : 11 - r;
            return digits.EndsWith(r.ToString());
        }
    }
}
