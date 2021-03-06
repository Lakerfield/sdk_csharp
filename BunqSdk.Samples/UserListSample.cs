﻿using System;
using Bunq.Sdk.Context;
using Bunq.Sdk.Model.Generated;
using Bunq.Sdk.Samples.Utils;

namespace Bunq.Sdk.Samples
{
    public class UserListSample : ISample
    {
        public void Run()
        {
            var apiContext = ApiContext.Restore();
            var users = User.List(apiContext);

            apiContext.Save();

            foreach (var oneUser in users)
            {
                Console.WriteLine(oneUser.UserCompany);
            }
        }
    }
}
