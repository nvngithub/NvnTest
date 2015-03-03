using System;
using System.Collections.Generic;
using System.Security.Cryptography;

internal class EncryptDecrypt
{
    private const string privatekey = "<RSAKeyValue><Modulus>1Wpatab+6fUduu9c/n0qwoyIULHfeqGNmr71K5m9jQL9j+4embckuiVpgtFlpR+SuYlRSYE6P5sg4iMo/PzXRB+gSu0T7j0OiN+OyD3lPGjknRMTrCwOyB4g+FF5lp3ED/yoyn4CoTAj/o/PfmhPNTHzcYR3oDEN6u5f8MZuBX0=</Modulus><Exponent>AQAB</Exponent><P>7X+OKt4xv1208b7T7B+tH39of+uIjxBzKLfLqgCR9UZNE6uV5eo+Z5sFfqvJ/p2wZdHnxiFsz6cwg5XeyoYBtw==</P><Q>5gqDgJtlokY1Q74hIZCpOqYIhmTrsI8cDUu1Gv8iGKc4iog91QmoeUh1AsH9F1Jt0iUIGwnmUnFnL10AOVciaw==</Q><DP>npaYZkOs0G5QT0Tv2jJkti2rqA+tRmrjmwLv+nsa+7+P5FylYbuDJEe96ZHo9h5yFeuOax0Sva6UlKlU9cN6DQ==</DP><DQ>NA4A/+MqNnRIrVGi0aOYh8r2duLzanqX0HJnQvqkzotYghCeXUzYMMmyoLMhAFwIudrjYKr20YUT4mXbHR6YjQ==</DQ><InverseQ>2Z7snjSz7CNIpGFdTZddTCFBRAPB5c3XBlnDcRJC791llg4eNw/7ewUnW45fsH0SOfXkIOjR7pMR/NLlxtnZzw==</InverseQ><D>SRwVFROvUhCRbb+gOOJCKsGf1R0KNOVxMCjorlYNlGgI2yy0uO3/m/FDEviO/KEzT3IWMbsebDnFaxKmcPxg9apBFr49lDG4dcBHOPTTulgk738zxU2u0Gzb419xRccGtQIkyYAK5JJPxK10liuWvbVH5lU9x0wviKLb+3CO11U=</D></RSAKeyValue>";
    private const string publickey = "<RSAKeyValue><Modulus>1Wpatab+6fUduu9c/n0qwoyIULHfeqGNmr71K5m9jQL9j+4embckuiVpgtFlpR+SuYlRSYE6P5sg4iMo/PzXRB+gSu0T7j0OiN+OyD3lPGjknRMTrCwOyB4g+FF5lp3ED/yoyn4CoTAj/o/PfmhPNTHzcYR3oDEN6u5f8MZuBX0=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";

    public static string Encrypt(string text)
    {
        CspParameters CSPParam = new CspParameters();
        CSPParam.Flags = CspProviderFlags.UseMachineKeyStore;
        using (RSACryptoServiceProvider m_rsaProvider = new RSACryptoServiceProvider(CSPParam))
        {
            m_rsaProvider.FromXmlString(publickey);
            byte[] baPlainbytes = System.Text.Encoding.UTF8.GetBytes(text);
            byte[] baCipherbytes = m_rsaProvider.Encrypt(baPlainbytes, false);
            return Convert.ToBase64String(baCipherbytes);
        }
    }

    public static string Decrypt(string text)
    {
        CspParameters CSPParam = new CspParameters();
        CSPParam.Flags = CspProviderFlags.UseMachineKeyStore;
        using (RSACryptoServiceProvider m_rsaProvider = new RSACryptoServiceProvider(CSPParam))
        {
            byte[] baGetPassword = Convert.FromBase64String(text);
            m_rsaProvider.FromXmlString(privatekey);
            byte[] baPlain = m_rsaProvider.Decrypt(baGetPassword, false);
            return System.Text.Encoding.UTF8.GetString(baPlain);
        }
    }
}