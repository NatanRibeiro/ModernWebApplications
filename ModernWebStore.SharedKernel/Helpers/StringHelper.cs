namespace ModernWebStore.SharedKernel.Helpers
{
    public class StringHelper
    {

        public static string Encrypt(string value)
        {
            if (string.IsNullOrEmpty(value))
                return "";

            value += "|54be1d80-b6d0-45c0-b8d7-13b3c798729f";
            var md5 = System.Security.Cryptography.MD5.Create();
            var data = md5.ComputeHash(System.Text.Encoding.Default.GetBytes(value));
            var sbString = new System.Text.StringBuilder();

            for (var i = 0; i < data.Length; i++)
                sbString.Append(data[i].ToString("x2"));

            return sbString.ToString();
        }
    }
}
