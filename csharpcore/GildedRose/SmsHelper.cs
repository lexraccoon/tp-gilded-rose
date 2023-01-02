using Twilio;
using System;
using Twilio.Rest.Api.V2010.Account;

namespace GildedRose
{
    public class SmsHelper{
        private const string ACCOUNT_SID = "AC838aace962838f806fb40f4476d01463";
        private const string AUTH_TOKEN = "54650dbb0d7f60c42cb0708a027fb335";
        private const string FROM_PHONE_NUMBER = "+13868543131";

        public void SendSms(string phoneNumber, string message)
        {
            TwilioClient.Init(ACCOUNT_SID, AUTH_TOKEN);
            var messageResult = MessageResource.Create(
                body: message,
                from: new Twilio.Types.PhoneNumber(FROM_PHONE_NUMBER),
                to: new Twilio.Types.PhoneNumber(phoneNumber)
            );
        }
    }
}