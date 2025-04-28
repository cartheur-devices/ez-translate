using System;
using System.Text;
using OpenNETCF.Phone.Sms;

namespace MobileTranslation
{
    /// <summary>
    /// The class that allows sending message by SMS.
    /// </summary>
    public static class SMS
    {
        public static bool SendSMS(string Text, string RecipientNumber)
        {
            bool Success = false;

            try
            { 
                Sms NewSMS = new Sms();

                NewSMS.SendMessage(new OpenNETCF.Phone.Sms.SmsAddress(RecipientNumber, OpenNETCF.Phone.AddressType.International), Text);

                Success = true;
            }
            catch(Exception ex)
            {
                string s = ex.Message;
                System.Windows.Forms.MessageBox.Show(":" + ex.Message + " RecipientNumber = " + RecipientNumber);
            }

            return Success;
        }
    }
}
