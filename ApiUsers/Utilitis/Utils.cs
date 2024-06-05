using System.Text.RegularExpressions;
using System.Text;
using System.Security.Cryptography;
using Microsoft.Extensions.Configuration;


namespace ApiUsers.Utilitis
{
    public class Utils
    {
        private static IConfiguration _configuration;
        public bool IsValidEmail(string email)
        {
            const string emailRegex = @"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$";
            return Regex.IsMatch(email, emailRegex);
        }



        public string EncryptPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var passwordBytes = Encoding.UTF8.GetBytes(password);
            var hashedPasswordBytes = sha256.ComputeHash(passwordBytes);
            return Convert.ToBase64String(hashedPasswordBytes);
        }

        public  bool IsValidPassword(string Password)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
           .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            _configuration = builder.Build();
            
            bool permitirMayusculas = _configuration.GetValue<bool>("ValidacionContraseña:PermitirMayusculas");
            bool permitirNumero = _configuration.GetValue<bool>("ValidacionContraseña:PermitirNumero");
            bool permitirCaracteresEspeciales = _configuration.GetValue<bool>("ValidacionContraseña:PermitirCaracteresEspeciales");

           
            string expresionRegular = "^";

            if (permitirMayusculas)
            {
                expresionRegular += "(?=.*[A-Z])";
            }

            if (permitirNumero)
            {
                expresionRegular += "(?=.*\\d)";
            }

            if (permitirCaracteresEspeciales)
            {
                expresionRegular += "(?=.*[@$!%*?&])";
            }

            expresionRegular += "[A-Za-z\\d@$!%*?&]{8,}$";

            // Validar la contraseña con la expresión regular
            Regex regex = new Regex(expresionRegular);
            return regex.IsMatch(Password);
        }
     
    }
}
