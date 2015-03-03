using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Reflection;
using System.Text.RegularExpressions;
using Microsoft.Win32;

namespace NvnTest.Common {

    public class Common {
        public static string AppPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + Path.DirectorySeparatorChar;
        public static string LocalPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\NvnTest\\";
        public static string LocalImagesPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\NvnTest\\Images\\";
        public static string UniqueId = DateTime.Now.ToString("yyyy_MM_dd_") + Guid.NewGuid().ToString().Replace("-", "").Substring(0, 5);
        public static LogoType LogoType = LogoType.NvnTest;

        public static string GetJavaClassName(string source) {
            string className = string.Empty;
            Regex classNameRegex = new Regex(@"class[\s]+(?<name>[\w]+)", RegexOptions.Compiled);
            Match match = classNameRegex.Match(source);
            if (match.Success) {
                className = match.Groups["name"].Value;
            }

            return className;
        }
    }

    public class Waiter {
        private static Waiter instance;
        private WaitForm waitForm = new WaitForm();

        private Waiter() { }

        public static Waiter Instance {
            get {
                if (instance == null) instance = new Waiter();
                return instance;
            }
        }

        public void Start() {
            Thread waitThread = new Thread(new ThreadStart(WaitFormThread));
            waitThread.IsBackground = true;
            waitThread.Start();
        }

        public void Stop() {
            waitForm.DialogResult = DialogResult.OK;
        }

        private void WaitFormThread() {
            try {
                waitForm.ShowDialog();
            } catch {
                // TODO: not a good way to do
                waitForm.DialogResult = DialogResult.OK;
            } 
        }
    }

    #region Pre-requisite
    //java -cp "c:\Users\Naveen Hegde\Desktop" TestClass
    public class PrerequisitesAdapter {
        private static string javaPath = string.Empty;

        public static string JavaPath {
            get { return javaPath; }
        }

        public static string Analyze() {
            List<string> unavailability = new List<string>();

            bool isJavaAvailable = IsJavaAvailable();
            if (isJavaAvailable == false) {
                unavailability.Add("Unable to find Java Runtime. Please install Java Runtime if you want to answer programming questions in Java.");
            }

            return unavailability.Count > 0 ? String.Join(Environment.NewLine, unavailability.ToArray()) : string.Empty;
        }

        private static bool IsJavaAvailable() {
            // 1. Try to get path using 32 registry
            string key = @"HKEY_LOCAL_MACHINE\SOFTWARE\JavaSoft\Java Runtime Environment";
            javaPath = GetPathFromRegistry(key);
            if (String.IsNullOrEmpty(javaPath) == false) {
                return true;
            }

            // 2. Try to get path using 64 registry
            key = @"HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\JavaSoft\Java Runtime Environment";
            javaPath = GetPathFromRegistry(key);
            if (String.IsNullOrEmpty(javaPath) == false) {
                return true;
            }

            // 3. Check Program files folder
            string programFilesJavaPath = GetJrePathFromRootDir(Environment.GetEnvironmentVariable("ProgramFiles") + @"\java") + @"\bin\java.exe";
            if (File.Exists(programFilesJavaPath)) {
                javaPath = programFilesJavaPath;
                return true;
            }

            // 4. Check Program files (86) folder
            string programFiles86JavaPath = GetJrePathFromRootDir(Environment.GetEnvironmentVariable("ProgramFiles(x86)") + @"\java") + @"\bin\java.exe";
            if (File.Exists(programFiles86JavaPath)) {
                javaPath = programFiles86JavaPath;
                return true;
            }

            // 5. Use java runtime in System32 folder if any other java.exe location not found
            string systemJavaPath = Environment.GetEnvironmentVariable("systemroot") + @"\system32\java.exe";
            if (File.Exists(systemJavaPath)) {
                javaPath = systemJavaPath;
                return true;
            }

            return false;
        }

        private static string GetPathFromRegistry(string key) {
            string version = (string)Registry.GetValue(key, "CurrentVersion", null);
            if (String.IsNullOrEmpty(version) == false) {
                string runtimeKey = key + @"\" + version;
                string runtimeDir = (string)Registry.GetValue(runtimeKey, "JavaHome", null);

                string path = runtimeDir + @"\bin\java.exe";
                if (String.IsNullOrEmpty(path) == false && File.Exists(path)) {
                    return path;
                }
            }

            return string.Empty;
        }

        private static string GetJrePathFromRootDir(string rootDir) {
            if (Directory.Exists(rootDir)) {
                string[] dirs = Directory.GetDirectories(rootDir, "jre*", SearchOption.TopDirectoryOnly);
                if (dirs.Length > 0) {
                    List<string> dirList = new List<string>(dirs);
                    dirList.Sort();
                    return dirList[0];
                }
            }

            return string.Empty;
        }
    }
    #endregion

    public class StringBinaryConverter {
        public static string BinaryToString(string filename) {
            string exeStream = string.Empty;
            using (FileStream fs = new FileStream(filename, FileMode.Open)) {
                using (BinaryReader br = new BinaryReader(fs)) {
                    byte[] bin = br.ReadBytes(Convert.ToInt32(fs.Length));
                    exeStream = Convert.ToBase64String(bin);
                }
            }

            return exeStream;
        }

        public static void StringToBinary(string filename, string exeStream) {
            string dirPath = Path.GetDirectoryName(filename);
            if (Directory.Exists(dirPath) == false) Directory.CreateDirectory(dirPath);

            byte[] binary = Convert.FromBase64String(exeStream);
            using (FileStream stream = new FileStream(filename, FileMode.OpenOrCreate)) {
                using (BinaryWriter writer = new BinaryWriter(stream)) {
                    writer.Write(binary);
                }
            }
        }
    }

    public class StringImageConverter {
        public static string ImageToString(Image image, ImageFormat format) {
            string imageStream = string.Empty;
            using (MemoryStream ms = new MemoryStream()) {
                image.Save(ms, format);
                byte[] imageBytes = ms.ToArray();

                imageStream = Convert.ToBase64String(imageBytes);
            }

            return imageStream;
        }

        public static Image StringToImage(string imageStream) {
            Image img = null;
            if (String.IsNullOrEmpty(imageStream) == false) {
                byte[] imageBytes = Convert.FromBase64String(imageStream);
                MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);

                ms.Write(imageBytes, 0, imageBytes.Length);
                img = Image.FromStream(ms, true);
            }

            return img;
        }
    }

    public class LoadSave {
        public static void Save(object o, Type type, string filename) {
            if (Directory.Exists(Path.GetDirectoryName(filename)) == false) Directory.CreateDirectory(Path.GetDirectoryName(filename));

            string xml = string.Empty;
            XmlSerializer ser = new XmlSerializer(type);
            using (XmlTextWriter xmlWriter = new XmlTextWriter(filename, Encoding.UTF8)) {
                ser.Serialize(xmlWriter, o);
            }

            Encrypter.EncryptFile(filename);
        }

        public static object Load(Type type, string filename) {
            object o = null;
            if (File.Exists(filename)) {
                XmlSerializer ser = new XmlSerializer(type);
                using (TextReader reader = new StreamReader(filename)) {
                    string content = Encrypter.DecryptFile(filename);
                    o = ser.Deserialize(new StringReader(content));
                }
            }
            return o;
        }
    }

    public class Encrypter {
        private const string publickey = "<RSAKeyValue><Modulus>1Wpatab+6fUduu9c/n0qwoyIULHfeqGNmr71K5m9jQL9j+4embckuiVpgtFlpR+SuYlRSYE6P5sg4iMo/PzXRB+gSu0T7j0OiN+OyD3lPGjknRMTrCwOyB4g+FF5lp3ED/yoyn4CoTAj/o/PfmhPNTHzcYR3oDEN6u5f8MZuBX0=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
        private const string desKey = "mwsdjfrk" ;

        public static string Encrypt(string text) {
            RSACryptoServiceProvider m_rsaProvider = new RSACryptoServiceProvider();
            m_rsaProvider.FromXmlString(publickey);
            byte[] baPlainbytes = System.Text.Encoding.UTF8.GetBytes(text);
            byte[] baCipherbytes = m_rsaProvider.Encrypt(baPlainbytes, false);
            return Convert.ToBase64String(baCipherbytes);
        }

        public static void EncryptFile(string filename) {
            using (FileStream stream = new FileStream(filename, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite)) {
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                des.Key = ASCIIEncoding.ASCII.GetBytes(desKey);
                des.IV = ASCIIEncoding.ASCII.GetBytes(desKey);

                ICryptoTransform desEncrypt = des.CreateEncryptor();
                using (CryptoStream cryptostream = new CryptoStream(stream, desEncrypt, CryptoStreamMode.Write)) {
                    byte[] bytearrayinput = new byte[stream.Length];
                    stream.Read(bytearrayinput, 0, bytearrayinput.Length);
                    // Clear content
                    stream.SetLength(0);
                    // Write encrypted content
                    cryptostream.Write(bytearrayinput, 0, bytearrayinput.Length);
                }
            }
        }

        public static string DecryptFile(string filename) {
            string content = string.Empty;

            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            des.Key = ASCIIEncoding.ASCII.GetBytes(desKey);
            des.IV = ASCIIEncoding.ASCII.GetBytes(desKey);

            using (FileStream stream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)) {
                ICryptoTransform desdecrypt = des.CreateDecryptor();
                CryptoStream cryptostreamDecr = new CryptoStream(stream, desdecrypt, CryptoStreamMode.Read);
                content = new StreamReader(cryptostreamDecr).ReadToEnd();
            }

            return content;
        }
    }

    public enum LogoType {
        NvnTest,
        Eduji,
        PurpleFrame
    }
}
