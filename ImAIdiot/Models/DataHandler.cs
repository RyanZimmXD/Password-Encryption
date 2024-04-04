using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ImAIdiot.Models
{
    public class DataHandler
    {
        private string Key;
        private string IV;

        public DataHandler()
        {
            this.Key = "0123456789ABCDEF";
            this.IV = "FEDCBA9876543210";
        }

        //public DataHandler(string Key, string IV)
        //{
        //    //turn password for app to key
        //    this.Key = Key;
        //    this.IV = IV;
        //}


        public void encryptData(PasswordInformation passwordInfo)
        {
            PasswordInformation passwordInformation = passwordInfo;
            if (!Directory.Exists("./Information"))
            {
                Directory.CreateDirectory("./Information"); //Incase direcotry doesn't exists.
            }

            string fileName = "./Information/" + Path.GetRandomFileName();
            //The reading of the second piece of info is messed up so resorting to storing each password in a seperate file.

            using (FileStream fileStream = new FileStream(fileName, FileMode.Create)) //Created in the bin/Debug Folder
            {
                using (Aes aes = Aes.Create())
                {
                    aes.Key = Encoding.UTF8.GetBytes(Key);
                    aes.IV = Encoding.UTF8.GetBytes(IV);

                    ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                    using (CryptoStream cryptoStream = new CryptoStream(
                        fileStream,
                        encryptor,
                        CryptoStreamMode.Write))
                    {
                        using (StreamWriter encryptWriter = new StreamWriter(cryptoStream))
                        {
                            try
                            {
                                encryptWriter.WriteLine(passwordInformation.ToString());
                            }
                            catch (Exception e) { Console.WriteLine(e + " Failed to Write line +"); }
                        }
                    }
                }
            }
        }


        public List<PasswordInformation> DecryptDataFromFile()
        {
            try
            {
                using (Aes aes = Aes.Create())
                {
                    aes.Key = Encoding.UTF8.GetBytes(Key);
                    aes.IV = Encoding.UTF8.GetBytes(IV);
                    //aes.Key = this.Key;
                    //aes.IV = this.iv;
                    List<PasswordInformation> result = new List<PasswordInformation>(); //What we return
                    string[] getFileNames = Directory.GetFiles("./Information");
                    foreach (string fileName in getFileNames)
                    {
                        using (FileStream fileStream = new FileStream(fileName, FileMode.OpenOrCreate))
                        {
                            using (CryptoStream cryptoStream = new CryptoStream(fileStream, aes.CreateDecryptor(aes.Key, aes.IV), CryptoStreamMode.Read))
                            {
                                using (StreamReader DecryptReader = new StreamReader(cryptoStream))
                                {
                                    string line;

                                    while ((line = DecryptReader.ReadLine()) != null)
                                    {
                                        PasswordInformation data = new PasswordInformation();
                                        string[] parts = line.Trim().Split(';');

                                        if (parts.Length >= 4)//Cant figure a way other than this?
                                        {
                                            data = new PasswordInformation();
                                            data.email = parts[0];
                                            data.password = parts[1];
                                            data.websiteName = parts[2];
                                            data.username = parts[3];

                                            result.Add(data);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    return result; //Needs to be at the end of the foreach loop in the Aes Area btw.
                }
            }catch(Exception ex) { return new List<PasswordInformation>();  }
        }

        public void EditFile(string FileName, PasswordInformation PasswordInfo)
        {
            string[] fileNames = Directory.GetFiles("./Information"); ;

            PasswordInformation passwordInformation = PasswordInfo;
            if (!Directory.Exists("./Information"))
            {
                Directory.CreateDirectory("./Information"); //Incase direcotry doesn't exists.
            }

            using (FileStream fileStream = new FileStream(FileName, FileMode.OpenOrCreate)) //Created in the bin/Debug Folder
            {
                using (Aes aes = Aes.Create())
                {
                    aes.Key = Encoding.UTF8.GetBytes(Key);
                    aes.IV = Encoding.UTF8.GetBytes(IV);

                    ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                    using (CryptoStream cryptoStream = new CryptoStream(
                        fileStream,
                        encryptor,
                        CryptoStreamMode.Write))
                    {
                        using (StreamWriter encryptWriter = new StreamWriter(cryptoStream))
                        {
                            try
                            {
                                encryptWriter.WriteLine(passwordInformation.ToString());
                            }
                            catch (Exception e) { Console.WriteLine(e + " Failed to Write line +"); }
                       }
                    }
                }
            }
        }
    }
}

