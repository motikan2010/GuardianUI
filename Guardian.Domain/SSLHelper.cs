﻿using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace Guardian.Domain
{
    public static class SSLHelper
    {
        private const string winCmd = "req -newkey rsa:2048 -x509 -nodes -keyout {2}\\{1}.key -new -out {2}\\{1}.crt -subj \"/CN={0}\" -reqexts SAN -extensions SAN -config \"{3}\" -sha256 -days 3650";

        public static SSL CreateSSL(string domain)
        {
            if (Infrastructure.OperatingSystem.IsWindows())
            {
                return CreateWinSSL(domain);
            }

            return null;
        }

        private static SSL CreateWinSSL(string domain)
        {
            var openSSLDir = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "openssl");

            var execPath = Path.Combine(openSSLDir, "openssl.exe");

            var baseFileName = Guid.NewGuid().ToString("N");

            //Load base config file, append needed data and save for later usage
            var configFilePath = Path.Combine(openSSLDir, $"{baseFileName}.cnf");
            var configFileContent = File.ReadAllText(Path.Combine(openSSLDir, "openssl.cnf")).Replace("{dir_placeholder}", openSSLDir + "\\ssl") +
                    $"[SAN]\nsubjectAltName=DNS:{domain},IP:192.168.1.26";

            File.WriteAllText(configFilePath, configFileContent);

            var args = string.Format(winCmd, domain, baseFileName, openSSLDir, configFilePath);

            //var batFilePath = Path.Combine(openSSLDir, $"\\{baseFileName}.bat");
            //File.WriteAllText(batFilePath, $"set OPENSSL_CONF={configFilePath}{Environment.NewLine}{execPath} {args}{Environment.NewLine}pause");

            var psi = new Process
            {
                StartInfo = new ProcessStartInfo(execPath, args)
                {
                    UseShellExecute = true,
                }
            };
            psi.Start();

            psi.WaitForExit();

            var certCrtPath = Path.Combine(openSSLDir, $"{baseFileName}.crt");
            var certKeyPath = Path.Combine(openSSLDir, $"{baseFileName}.key");

            var result = new SSL()
            {
                CertCrt = File.ReadAllText(certCrtPath),
                CertKey = File.ReadAllText(certKeyPath)
            };

            //Lets clear the path.
            ////File.Delete(batFilePath);
            //File.Delete(certCrtPath);
            //File.Delete(certKeyPath);
            //File.Delete(configFilePath);

            return result;
        }
    }
}