﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    interface INotifier
    {
        void NotifyUsersOfNewUser(Client user);
    }
}
