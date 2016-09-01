using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace BootStrapMVCPluralSite.Services
{
  public class MockMailService : IMailService
  {
    public bool SendMail(string from, string to, string subject, string comment)
    {
      Debug.WriteLine(string.Concat("SendMail: ", subject));
      return true;
    }
  }
}