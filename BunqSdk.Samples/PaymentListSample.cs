﻿using System;
using Bunq.Sdk.Context;
using Bunq.Sdk.Model.Generated;
using Bunq.Sdk.Samples.Utils;

namespace Bunq.Sdk.Samples
{
    public class PaymentListSample : ISample
    {
        private const int USER_ITEM_ID = 0; // Put your user ID here
        private const int MONETARY_ACCOUNT_ITEM_ID = 0; // Put your monetary account ID here

        public void Run()
        {
            var apiContext = ApiContext.Restore();
            var paymentList = Payment.List(apiContext, USER_ITEM_ID, MONETARY_ACCOUNT_ITEM_ID);

            foreach (var payment in paymentList)
            {
                Console.WriteLine(payment.Id);
            }
        }
    }
}
