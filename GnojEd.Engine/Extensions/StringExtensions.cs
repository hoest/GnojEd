namespace GnojEd.Engine.Extensions {
  using System;
  using System.Security.Cryptography;
  using System.Text;

  /// <summary>
  /// StringExtensions class
  /// </summary>
  public static class StringExtensions {
    /// <summary>
    /// Change string to SHA512-string
    /// </summary>
    /// <param name="value">Original String value</param>
    /// <returns>SHA512 string object</returns>
    public static string ToSHA512(this string value) {
      UnicodeEncoding uniEnc = new UnicodeEncoding();
      byte[] inputBytes = uniEnc.GetBytes(value);
      SHA512Managed shaHash = new SHA512Managed();
      string strHex = String.Empty;
      byte[] hashValue = shaHash.ComputeHash(inputBytes);
      foreach (byte b in hashValue) {
        strHex += String.Format("{0:x2}", b);
      }

      return strHex;
    }
  }
}
