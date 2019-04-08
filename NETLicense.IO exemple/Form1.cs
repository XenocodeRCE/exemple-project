using System;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace NETLicense.IO_exemple {
    public partial class Form1 : Form {

        /// <summary>
        /// The very secret key
        /// Mzrked to be a server variable
        /// </summary>
        [Obfuscation(Exclude = false, Feature = "server")]
        public string key = "ThisIsAVerySecretKey";

        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            /// We call a method marked to be a Remote method
            txt_result.Text = CryptoHelper.Encrypt(txt_cipher.Text, key);
        }

        private void button2_Click(object sender, EventArgs e) {
            /// We call a method marked to be a Remote method
            txt_decrypted.Text = CryptoHelper.Decrypt(txt_result.Text, key);
        }

        private void Form1_Load(object sender, EventArgs e) {

        }
    }

    /// <summary>
    /// A simple crypto class, contingent
    /// only for demonstration purposes
    /// </summary>
    public static class CryptoHelper {

        /// <summary>
        /// Marked to be a Remote method
        /// </summary>
        /// <param name="plainString">a string you want to encryt</param>
        /// <param name="argKey">tge very secret key</param>
        /// <returns>an encrypted string</returns>
        [Obfuscation(Exclude = false, Feature = "remote")]
        public static string Encrypt(string plainString, string argKey) {
            var data = Encoding.UTF8.GetBytes(plainString);
            var md5 = new MD5CryptoServiceProvider();
            var key = md5.ComputeHash(Encoding.UTF8.GetBytes(argKey));
            var tripleDes = new TripleDESCryptoServiceProvider() { Key = key, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 };
            var transform = tripleDes.CreateEncryptor();
            var resultsByteArray = transform.TransformFinalBlock(data, 0, data.Length);
            return Convert.ToBase64String(resultsByteArray);
        }

        /// <summary>
        /// Marked to be a Remote method
        /// </summary>
        /// <param name="encryptedString">an encrypted string you want to decrypt</param>
        /// <param name="argKey">the very secret key</param>
        /// <returns></returns>
        [Obfuscation(Exclude = false, Feature = "remote")]
        public static string Decrypt(string encryptedString, string argKey) {
            var data = Convert.FromBase64String(encryptedString);
            var md5 = new MD5CryptoServiceProvider();
            var key = md5.ComputeHash(Encoding.UTF8.GetBytes(argKey));
            var tripleDes = new TripleDESCryptoServiceProvider() { Key = key, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 };
            var transform = tripleDes.CreateDecryptor();
            var resultsByteArray = transform.TransformFinalBlock(data, 0, data.Length);
            return Encoding.UTF8.GetString(resultsByteArray);
        }
    }
}
