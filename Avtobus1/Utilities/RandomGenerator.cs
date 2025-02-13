namespace Avtobus1.Utilities
{
    public class RandomGenerator
    {
        private static readonly string alphabetLower = "abcdefghijklmnopqrstuvwxyz";
        private static readonly string alphabetUpper = alphabetLower.ToUpper();
        private static readonly string numbers = "0123456789";
        private static readonly string chars = alphabetLower + alphabetUpper + numbers;

        public static string GenerateString(int length = 6)
        {
            return string.Join(
                "",
                Enumerable.Range(0, length).Select(i => chars[new Random().Next(chars.Length + i) % chars.Length])
            );
        }
    }
}
